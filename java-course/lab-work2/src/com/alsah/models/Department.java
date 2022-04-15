package com.alsah.models;

import java.util.Date;

public class Department {

    private int id;
    private String address;
    private Date creation;
    private int employees;
    private boolean active;
    private int avgIncome;
    private int branchId;

    public Department(int id, String address, Date creation, int employees, boolean active, int avgIncome, int branchId) {
        this.id = id;
        this.address = address;
        this.creation = creation;
        this.employees = employees;
        this.active = active;
        this.avgIncome = avgIncome;
        this.branchId = branchId;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public Date getCreation() {
        return creation;
    }

    public void setCreation(Date creation) {
        this.creation = creation;
    }

    public int getEmployees() {
        return employees;
    }

    public void setEmployees(int employees) {
        this.employees = employees;
    }

    public boolean isActive() {
        return active;
    }

    public void setActive(boolean active) {
        this.active = active;
    }

    public int getAvgIncome() {
        return avgIncome;
    }

    public void setAvgIncome(int avgIncome) {
        this.avgIncome = avgIncome;
    }

    public int getBranchId() {
        return branchId;
    }

    public void setBranchId(int branchId) {
        this.branchId = branchId;
    }
}
