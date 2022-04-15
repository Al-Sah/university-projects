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
        connection.setAutoCommit(true);
        validate(connection);
        return connection;
    }

    private static void validate(Connection connection) throws SQLException {
        DatabaseMetaData meta = connection.getMetaData();

        if(!meta.getTables(null, null, "branch", new String[] {"TABLE"}).next()){
            throw new SQLException("Table branch not found");
        }
        if(!meta.getTables(null, null, "departments", new String[] {"TABLE"}).next()){
            throw new SQLException("Table departments not found");
        }
    }
}
