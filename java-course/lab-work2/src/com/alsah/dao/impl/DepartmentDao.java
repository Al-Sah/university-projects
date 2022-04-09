package com.alsah.dao.impl;

import com.alsah.dao.Dao;
import com.alsah.models.Department;

import java.sql.Connection;
import java.util.List;
import java.util.Optional;

public class DepartmentDao implements Dao<Department> {

    private final Connection connection;

    public DepartmentDao(Connection connection) {
        this.connection = connection;
    }


    @Override
    public Optional<Department> get(long id) {
        return Optional.empty();
    }

    @Override
    public List<Department> getAll() {
        return null;
    }

    @Override
    public boolean save(Department department) {
        return false;
    }

    @Override
    public boolean update(Department department, String[] params) {
        return false;
    }

    @Override
    public boolean delete(Department department) {
        return false;
    }

}
