package controller;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.sql.Statement;

public class Banco {

	private static String PATH_SQL = "jdbc:sqlserver://mateuzserver.database.windows.net:1433;database=MEU;user=mateuz@mateuzserver;password=Banco2k18;encrypt=true;trustServerCertificate=false;hostNameInCertificate=*.database.windows.net;loginTimeout=30;";

	public Connection getInstance() {
		try {
			Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");
			try {
				return DriverManager.getConnection(PATH_SQL); 
			}
			// Handle any errors that may have occurred.
			catch (SQLException e) {
				System.out.print("ERRO SQL0001: ");
				e.printStackTrace();
				return null;
			}
		} catch (ClassNotFoundException e1) {
			// TODO Auto-generated catch block
			System.out.print("ERRO SQL0002: ");
			e1.printStackTrace();
			return null;
		}
	}

}
