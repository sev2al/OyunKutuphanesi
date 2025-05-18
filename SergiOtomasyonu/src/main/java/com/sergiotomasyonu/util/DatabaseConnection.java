package com.sergiotomasyonu.util;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class DatabaseConnection {
    // Windows Authentication için bağlantı bilgileri
    private static final String URL = "jdbc:sqlserver://localhost:1433;databaseName=SergiOtomasyonu;integratedSecurity=true;encrypt=true;trustServerCertificate=true";
    
    static {
        try {
            // JDBC sürücüsünü yükle
            Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");
            System.out.println("JDBC Driver başarıyla yüklendi.");
        } catch (ClassNotFoundException e) {
            System.err.println("JDBC Driver yüklenemedi: " + e.getMessage());
            e.printStackTrace();
        }
    }
    
    public static Connection getConnection() throws SQLException {
        try {
            Connection conn = DriverManager.getConnection(URL);
            System.out.println("Veritabanı bağlantısı başarılı.");
            return conn;
        } catch (SQLException e) {
            System.err.println("Veritabanı bağlantı hatası: " + e.getMessage());
            throw e;
        }
    }
} 