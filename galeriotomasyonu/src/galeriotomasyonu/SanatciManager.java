/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package galeriotomasyonu;

import galeriotomasyonu.DBConnection;
import java.sql.*;
import java.util.ArrayList;

public class SanatciManager implements SanatciIslemleri {

    @Override
    public void ekle(Sanatci s) {
        String sql = "INSERT INTO Sanatci (Ad, Soyad, Ulke, DogumTarihi, Biyografi) VALUES (?, ?, ?, ?, ?)";
        try (Connection conn = DBConnection.getConnection();
             PreparedStatement stmt = conn.prepareStatement(sql)) {
            stmt.setString(1, s.getAd());
            stmt.setString(2, s.getSoyad());
            stmt.setString(3, s.getUlke());
            stmt.setString(4, s.getDogumTarihi());
            stmt.setString(5, s.getBiyografi());
            stmt.executeUpdate();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    @Override
    public ArrayList<Sanatci> listele() {
        ArrayList<Sanatci> sanatcilar = new ArrayList<>();
        try (Connection conn = DBConnection.getConnection();
             Statement stmt = conn.createStatement();
             ResultSet rs = stmt.executeQuery("SELECT * FROM Sanatci")) {
            while (rs.next()) {
                sanatcilar.add(new Sanatci(
                        rs.getInt("SanatciID"),
                        rs.getString("Ad"),
                        rs.getString("Soyad"),
                        rs.getString("Ulke"),
                        rs.getString("DogumTarihi"),
                        rs.getString("Biyografi")
                ));
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return sanatcilar;
    }

    @Override
    public Sanatci ara(int id) {
        String sql = "SELECT * FROM Sanatci WHERE SanatciID = ?";
        try (Connection conn = DBConnection.getConnection();
             PreparedStatement stmt = conn.prepareStatement(sql)) {
            stmt.setInt(1, id);
            ResultSet rs = stmt.executeQuery();
            if (rs.next()) {
                return new Sanatci(
                        rs.getInt("SanatciID"),
                        rs.getString("Ad"),
                        rs.getString("Soyad"),
                        rs.getString("Ulke"),
                        rs.getString("DogumTarihi"),
                        rs.getString("Biyografi")
                );
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    @Override
    public void guncelle(Sanatci s) {
        String sql = "UPDATE Sanatci SET Ad=?, Soyad=?, Ulke=?, DogumTarihi=?, Biyografi=? WHERE SanatciID=?";
        try (Connection conn = DBConnection.getConnection();
             PreparedStatement stmt = conn.prepareStatement(sql)) {
            stmt.setString(1, s.getAd());
            stmt.setString(2, s.getSoyad());
            stmt.setString(3, s.getUlke());
            stmt.setString(4, s.getDogumTarihi());
            stmt.setString(5, s.getBiyografi());
            stmt.setInt(6, s.getSanatciID());
            stmt.executeUpdate();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    @Override
    public void sil(int id) {
        String sql = "DELETE FROM Sanatci WHERE SanatciID = ?";
        try (Connection conn = DBConnection.getConnection();
             PreparedStatement stmt = conn.prepareStatement(sql)) {
            stmt.setInt(1, id);
            stmt.executeUpdate();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
}
