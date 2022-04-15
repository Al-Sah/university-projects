package com.alsah.dao.impl;

import com.alsah.dao.Dao;
import com.alsah.dao.Utils;
import com.alsah.models.Branch;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.Optional;

public class BranchDao implements Dao<Branch> {

    private final Connection connection;

    public BranchDao(Connection connection) {
        this.connection = connection;
    }

    @Override
    public Optional<Branch> get(long id) {
        try (PreparedStatement statement = connection.prepareStatement(sql.GET_ONE.QUERY)) {
            statement.setLong(1, id);
            var resultSet = statement.executeQuery();
            resultSet.next();
            return Optional.of(ResultSetToBranch(resultSet));
        } catch (SQLException e) {
            return Optional.empty();
        }
    }

    @Override
    public List<Branch> getAll() {
        try (Statement statement = connection.createStatement()) {
            var rs = statement.executeQuery(sql.GET_ALL.QUERY);
            var resultList =  new ArrayList<Branch>();

            while(rs.next()) {
                resultList.add(ResultSetToBranch(rs));
            }
            return resultList;

        } catch (SQLException e) {
            return new ArrayList<>();
        }
    }

    @Override
    public List<Branch> getAll(Map<String, Object> filter) {
        try (Statement statement = connection.createStatement()) {
            var rs = statement.executeQuery(sql.GET_ALL.QUERY + Utils.generateSql(filter));
            var resultList =  new ArrayList<Branch>();
            while(rs.next()) {
                resultList.add(ResultSetToBranch(rs));
            }
            return resultList;
        } catch (SQLException e) {
            return new ArrayList<>();
        }
    }

    @Override
    public boolean save(Branch branch) {

        try (PreparedStatement statement = connection.prepareStatement(sql.INSERT.QUERY)) {
            FillPreparedStatement(branch, statement);
            return statement.executeUpdate() > 0;
        } catch (SQLException e) {
            return false;
        }
    }

    @Override
    public boolean update(Branch branch) {
        try (PreparedStatement statement = connection.prepareStatement(sql.UPDATE.QUERY)) {
            FillPreparedStatement(branch, statement);
            statement.setInt(7, branch.getId());
            return statement.executeUpdate() > 0;
        } catch (SQLException e) {
            return false;
        }
    }


    @Override
    public boolean delete(Branch branch) {
        try (PreparedStatement statement = connection.prepareStatement(sql.DELETE.QUERY)) {
            statement.setInt(1, branch.getId());
            return statement.executeUpdate() > 0;
        } catch (SQLException e) {
            return false;
        }
    }




    private static void FillPreparedStatement(Branch branch, PreparedStatement statement) throws SQLException {
        statement.setString(1, branch.getName());
        statement.setString(2, branch.getLocation());
        statement.setString(3, branch.getHead());
        statement.setInt(4, branch.getManagers());
        statement.setInt(5, branch.getShares());
        statement.setInt(6, branch.getSharePrice());
    }

    private static Branch ResultSetToBranch(ResultSet rs) throws SQLException {
        return new Branch(
                rs.getInt("id"),
                rs.getString("name"),
                rs.getString("location"),
                rs.getString("head"),
                rs.getInt("managers"),
                rs.getInt("shares_count"),
                rs.getInt("share_price"));
    }

    private enum sql {
        GET_ALL("SELECT * FROM branch"),
        GET_ONE("SELECT * FROM branch WHERE id = ?"),
        INSERT("INSERT INTO branch (name, location, head, managers, shares_count, share_price) VALUES (?, ?, ?, ?, ?, ?)"),
        UPDATE("UPDATE branch SET name = ?, location = ?, head = ?, managers = ?, shares_count = ?, share_price = ? WHERE id = ?"),
        DELETE("DELETE FROM branch WHERE id = ?");

        final String QUERY;
        sql(String QUERY) {
            this.QUERY = QUERY;
        }
    }
}
