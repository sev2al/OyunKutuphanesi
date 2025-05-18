package main.java.com.sergiotomasyonu.dao;

import main.java.com.sergiotomasyonu.model.Kullanici;
import com.sergiotomasyonu.util.DatabaseConnection;
import java.sql.*;
import java.util.ArrayList;
import java.util.List;

public class KullaniciDAO {
    
    public Kullanici findByUsername(String username) {
        String sql = "SELECT * FROM Kullanicilar WHERE kullanici_adi = ?";
        try (Connection conn = DatabaseConnection.getConnection();
             PreparedStatement stmt = conn.prepareStatement(sql)) {
            
            stmt.setString(1, username);
            ResultSet rs = stmt.executeQuery();
            
            if (rs.next()) {
                Kullanici kullanici = new Kullanici();
                kullanici.setKullaniciId(rs.getInt("kullanici_id"));
                kullanici.setKullaniciAdi(rs.getString("kullanici_adi"));
                kullanici.setEposta(rs.getString("eposta"));
                kullanici.setParolaHash(rs.getString("parola_hash"));
                kullanici.setKayitTarihi(rs.getTimestamp("kayit_tarihi"));
                return kullanici;
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }
    
    public boolean save(Kullanici kullanici) {
        String sql = "INSERT INTO Kullanicilar (kullanici_adi, eposta, parola_hash, kayit_tarihi) VALUES (?, ?, ?, ?)";
        try (Connection conn = DatabaseConnection.getConnection();
             PreparedStatement stmt = conn.prepareStatement(sql)) {
            
            stmt.setString(1, kullanici.getKullaniciAdi());
            stmt.setString(2, kullanici.getEposta());
            stmt.setString(3, kullanici.getParolaHash());
            stmt.setTimestamp(4, new Timestamp(kullanici.getKayitTarihi().getTime()));
            
            return stmt.executeUpdate() > 0;
        } catch (SQLException e) {
            e.printStackTrace();
            return false;
        }
    }
    
    public boolean isUsernameExists(String username) {
        String sql = "SELECT COUNT(*) FROM Kullanicilar WHERE kullanici_adi = ?";
        try (Connection conn = DatabaseConnection.getConnection();
             PreparedStatement stmt = conn.prepareStatement(sql)) {
            
            stmt.setString(1, username);
            ResultSet rs = stmt.executeQuery();
            
            if (rs.next()) {
                return rs.getInt(1) > 0;
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return false;
    }
    
    public boolean isEmailExists(String email) {
        String sql = "SELECT COUNT(*) FROM Kullanicilar WHERE eposta = ?";
        try (Connection conn = DatabaseConnection.getConnection();
             PreparedStatement stmt = conn.prepareStatement(sql)) {
            
            stmt.setString(1, email);
            ResultSet rs = stmt.executeQuery();
            
            if (rs.next()) {
                return rs.getInt(1) > 0;
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return false;
    }
} 