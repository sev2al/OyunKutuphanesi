/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package galeriotomasyonu;

import java.sql.Connection;
import java.sql.Statement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import galeriotomasyonu.DBConnection;

/**
 *
 * @author Lenovo
 */
public class SanatciDAO {
    public static ArrayList<Sanatci> getSanatcilar() {
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
        } catch (SQLException ex) {
            ex.printStackTrace();
        }
        return sanatcilar;
    }
}
