package com.alsah.dao.impl;

import com.alsah.dao.Dao;
import com.alsah.dao.Utils;
import com.alsah.models.Department;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.Optional;

public class DepartmentDao implements Dao<Department> {

    private final Connection connection;

    public DepartmentDao(Connection connection) {
        this.connection = connection;
    }


    @Override
    public Optional<Department> get(long id) {
        try (PreparedStatement statement = connection.prepareStatement(sql.GET_ONE.QUERY)) {
            statement.setLong(1, id);
            var resultSet = statement.executeQuery();
            resultSet.next();
            return Optional.of(ResultSetToDepartment(resultSet));
        } catch (SQLException e) {
            return Optional.empty();
        }
    }

    @Override
    public List<Department> getAll() {
        try (Statement statement = connection.createStatement()) {
            var rs = statement.executeQuery(sql.GET_ALL.QUERY);
            var resultList =  new ArrayList<Department>();
            while(rs.next()) {
                resultList.add(ResultSetToDepartment(rs));
            }
            return resultList;
        } catch (SQLException e) {
            return new ArrayList<>();
        }
    }

    @Override
    public List<Department> getAll(Map<String, Object> filter) {
        try (Statement statement = connection.createStatement()) {
            var rs = statement.executeQuery(sql.GET_ALL.QUERY + Utils.generateSql(filter));
            var resultList =  new ArrayList<Department>();
            while(rs.next()) {
                resultList.add(ResultSetToDepartment(rs));
            }
            return resultList;
        } catch (SQLException e) {
            return new ArrayList<>();
        }
    }

    @Override
    public boolean save(Department department) {
        try (PreparedStatement statement = connection.prepareStatement(sql.INSERT.QUERY)) {
            FillPreparedStatement(department, statement);
            statement.setInt(6, department.getBranchId());
            return statement.executeUpdate() > 0;
        } catch (SQLException e) {
            return false;
        }
    }

    @Override
    public boolean update(Department department) {
        try (PreparedStatement statement = connection.prepareStatement(sql.UPDATE.QUERY)) {
            FillPreparedStatement(department, statement);
            statement.setInt(6, department.getId());
            return statement.executeUpdate() > 0;
        } catch (SQLException e) {
            return false;
        }
    }

    @Override
    public boolean delete(Department department) {
        try (PreparedStatement statement = connection.prepareStatement(sql.DELETE.QUERY)) {
            statement.setInt(1, department.getId());
            return statement.executeUpdate() > 0;
        } catch (SQLException e) {
            return false;
        }
    }


    private static void FillPreparedStatement(Department department, PreparedStatement statement) throws SQLException {
        statement.setString(1, department.getAddress());
        statement.setDate(2, new Date(department.getCreation().getTime()));
        statement.setInt(3, department.getEmployees());
        statement.setBoolean(4, department.isActive());
        statement.setInt(5, department.getAvgIncome());
    }

    private static Department ResultSetToDepartment(ResultSet rs) throws SQLException {
        return new Department(
                rs.getInt("id"),
                rs.getString("address"),
                rs.getDate("creation"),
                rs.getInt("employees"),
                rs.getBoolean("is_active"),
                rs.getInt("average_income"),
                rs.getInt("branch_id"));
    }

    private enum sql {
        GET_ALL("SELECT * FROM departments"),
        GET_ONE("SELECT * FROM departments WHERE id = ?"),
        INSERT("INSERT INTO departments (address, creation, employees, is_active, average_income, branch_id) VALUES (?, ?, ?, ?, ?, ?)"),
        UPDATE("UPDATE departments SET address = ?, creation = ?, employees = ?, is_active = ?, average_income = ? WHERE id = ?"),
        DELETE("DELETE FROM departments WHERE id = ?");

        final String QUERY;
        sql(String QUERY) {
            this.QUERY = QUERY;
        }
    }

}
