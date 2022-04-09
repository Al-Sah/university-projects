package com.alsah.models;

import java.util.Date;

public class Department {

    private int id;
    private String address;
    private Date creation;
    private int employees;
    private boolean active;
    private int avg_income;
    private int branch_id;

    public Department(int id, String address, Date creation, int employees, boolean active, int avg_income, int branch_id) {
        this.id = id;
        this.address = address;
        this.creation = creation;
        this.employees = employees;
        this.active = active;
        this.avg_income = avg_income;
        this.branch_id = branch_id;
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

    public int getAvg_income() {
        return avg_income;
    }

    public void setAvg_income(int avg_income) {
        this.avg_income = avg_income;
    }

    public int getBranch_id() {
        return branch_id;
    }

    public void setBranch_id(int branch_id) {
        this.branch_id = branch_id;
    }
}
