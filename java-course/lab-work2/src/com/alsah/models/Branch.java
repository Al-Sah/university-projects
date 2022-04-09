package com.alsah.models;

public class Branch {

    private int id;
    private String name;
    private String location;
    private String head;
    private int managers;
    private int sharePrice;
    private int shares;

    public Branch(int id, String name, String location, String head, int managers, int sharePrice, int shares) {
        this.id = id;
        this.name = name;
        this.location = location;
        this.head = head;
        this.managers = managers;
        this.sharePrice = sharePrice;
        this.shares = shares;
    }


    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getLocation() {
        return location;
    }

    public void setLocation(String location) {
        this.location = location;
    }

    public String getHead() {
        return head;
    }

    public void setHead(String head) {
        this.head = head;
    }

    public int getManagers() {
        return managers;
    }

    public void setManagers(int managers) {
        this.managers = managers;
    }

    public int getSharePrice() {
        return sharePrice;
    }

    public void setSharePrice(int sharePrice) {
        this.sharePrice = sharePrice;
    }

    public int getShares() {
        return shares;
    }

    public void setShares(int shares) {
        this.shares = shares;
    }
}
