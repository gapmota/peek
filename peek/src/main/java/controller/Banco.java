package controller;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class Banco {

    private static String PATH_SQL = "";

    public Connection getInstance() {
        try {
            Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");
            try {
                return DriverManager.getConnection(PATH_SQL);
            } // Handle any errors that may have occurred.
            catch (SQLException e) {
                System.out.print("ERRO SQL0001: ");
                return null;
            }
        } catch (ClassNotFoundException e1) {
            // TODO Auto-generated catch block
            System.out.print("ERRO SQL0002: ");
            return null;
        }
    }
}
