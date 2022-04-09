package com.alsah;

import com.alsah.dao.impl.BranchDao;
import com.alsah.dao.impl.DepartmentDao;

import java.sql.SQLException;

public class Main {

    public static BranchDao branchDao;
    public static DepartmentDao departmentDao;

    public static void main(String[] args) {

        try {
            var connection = ConnectionFactory.getConnection();
            branchDao = new BranchDao(connection);
            departmentDao = new DepartmentDao(connection);
        } catch (SQLException e) {
            e.printStackTrace();
            return;
        }

        branchDao.getAll();
        departmentDao.getAll();

    }
}
