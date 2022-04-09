package com.alsah;

import java.sql.*;

public class ConnectionFactory {

    // extra parameters: ?serverTimezone=___&useSSL=false
    private static final String url = "jdbc:mysql://localhost:3306/jdbc-lab";

    private static final String user = "";
    private static final String password = "";

    public static Connection getConnection() throws SQLException {
        //Class.forName("com.mysql.cj.jdbc.Driver"); use lab-work2.iml instead
        Connection connection = DriverManager.getConnection(url, user, password);
        connection.setAutoCommit(false);
        return connection;
    }
}
