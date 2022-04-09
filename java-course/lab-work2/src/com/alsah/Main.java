package com.alsah;

import java.sql.SQLException;

public class Main {

    public static void main(String[] args) {

        try {
            var connection = ConnectionFactory.getConnection();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
}
