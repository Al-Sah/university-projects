package com.alsah.dao.impl;

import com.alsah.dao.Dao;
import com.alsah.models.Branch;

import java.sql.Connection;
import java.util.List;
import java.util.Optional;

public class BranchDao implements Dao<Branch> {

    private final Connection connection;

    public BranchDao(Connection connection) {
        this.connection = connection;
    }

    @Override
    public Optional<Branch> get(long id) {
        return Optional.empty();
    }

    @Override
    public List<Branch> getAll() {
        return null;
    }

    @Override
    public boolean save(Branch branch) {
        return false;
    }

    @Override
    public boolean update(Branch branch, String[] params) {
        return false;
    }

    @Override
    public boolean delete(Branch branch) {
        return false;
    }

}
