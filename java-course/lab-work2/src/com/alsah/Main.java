package com.alsah;

import com.alsah.dao.impl.BranchDao;
import com.alsah.dao.impl.DepartmentDao;
import com.alsah.models.Branch;
import com.alsah.models.Department;

import java.util.Date;
import java.sql.SQLException;
import java.util.HashMap;
import java.util.Random;
import java.util.UUID;

public class Main {

    public static BranchDao branchDao;
    public static DepartmentDao departmentDao;

    public static final String baseName = "SUPER-DEVS-";
    public static final String[] locations = new String[]{"ITA","USA","UKR","DEU"};

    public static void main(String[] args) {

        try {
            var connection = ConnectionFactory.getConnection();
            branchDao = new BranchDao(connection);
            departmentDao = new DepartmentDao(connection);
        } catch (SQLException e) {
            e.printStackTrace();
            return;
        }

        for (int i = 0; i < 5; i++) {
            insertBranch();
        }
        for (Branch branch : branchDao.getAll()) {
            for (int i = 0; i < 3; i++) {
                insertDepartment(branch.getId());
            }
        }

        System.out.printf("Branches count: %d%n", branchDao.getAll().size());
        System.out.printf("Departments count: %d%n", departmentDao.getAll().size());

        branchDao.get(1).ifPresentOrElse(branch -> {
            var filter = new HashMap<String, Object>();
            filter.put("branch_id", branch.getId());
            for (Department department : departmentDao.getAll(filter)) {
                System.out.printf(" * Department: %d, branchId: %d%n", department.getId(), branch.getId());
            }
        }, () -> System.out.println("ERROR: Branch not found"));

        branchDao.get(1).ifPresentOrElse(Main::updateBranch, () -> System.out.println("ERROR: Branch not found"));
        departmentDao.get(1).ifPresentOrElse(Main::updateDepartment, () -> System.out.println("ERROR: Department not found"));

        for (var brunch: branchDao.getAll()) {
            if(branchDao.delete(brunch)){
                System.out.printf("Branch with id %d deleted%n", brunch.getId());
            } else {
                System.out.printf("Failed to delete branch %d%n", brunch.getId());
            }
        }
    }


    private static void insertBranch(){
        var random = new Random();
        var insertBranch = new Branch(0, // ID is not used here
                baseName + UUID.randomUUID().toString().substring(0,6),
                locations[random.nextInt(locations.length)],
                "undefined creature",
                random.nextInt(100),
                random.nextInt(20),
                random.nextInt(2000)
        );

        if(branchDao.save(insertBranch)){
            System.out.printf("Created new branch: %s%n", insertBranch.getName());
        } else {
            System.out.printf("Failed to create new branch: %s%n", insertBranch.getName());
        }
    }


    private static void updateBranch(Branch branch){
        var random = new Random();

        branch.setManagers(branch.getManagers() + 1);
        branch.setName(branch.getName() + "-UP");
        branch.setSharePrice(branch.getSharePrice() + random.nextInt(500));
        branch.setShares(branch.getShares() + random.nextInt(50));

        if(branchDao.update(branch)){
            System.out.printf("Updated branch: %d%n", branch.getId());
        } else {
            System.out.printf("Failed to update branch: %d%n", branch.getId());
        }
    }

    private static void updateDepartment(Department department){
        var random = new Random();

        department.setAddress(department.getAddress() + "-UP");
        department.setCreation(new Date(new Date().getTime()-200000));
        department.setEmployees(department.getEmployees() + random.nextInt(50));
        department.setAvgIncome(department.getAvgIncome() + random.nextInt(10000));

        if(departmentDao.update(department)){
            System.out.printf("Updated department: %d%n", department.getId());
        } else {
            System.out.printf("Failed to update department: %d%n", department.getId());
        }
    }

    private static void insertDepartment(int branchId){
        var random = new Random();
        var insertBranch = new Department(0, // ID is not used here
                "address-" + UUID.randomUUID().toString().substring(0,6),
                new Date(new Date().getTime()-200000),
                random.nextInt(100),
                true,
                random.nextInt(99000) + 1000,
                branchId
        );

        if(departmentDao.save(insertBranch)){
            System.out.printf("Created new department: branch - %d |%s%n", branchId, insertBranch.getAddress());
        } else {
            System.out.printf("Failed to create new department: branch - %d |%s%n", branchId, insertBranch.getAddress());
        }
    }

}
