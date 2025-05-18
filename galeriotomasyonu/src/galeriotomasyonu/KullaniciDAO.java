
package galeriotomasyonu;

import galeriotomasyonu.DBConnection;
import galeriotomasyonu.Kullanici;

import java.sql.Connection;
import java.sql.PreparedStatement;

public class KullaniciDAO {

    public static boolean kullaniciEkle(Kullanici k) {
        String sql = "INSERT INTO Kullanici (Ad, Soyad, Email, Sifre, Rol) VALUES (?, ?, ?, ?, ?)";

        try (Connection conn = DBConnection.getConnection();
             PreparedStatement stmt = conn.prepareStatement(sql)) {

            stmt.setString(1, k.getAd());
            stmt.setString(2, k.getSoyad());
            stmt.setString(3, k.getEmail());
            stmt.setString(4, k.getSifre());
            stmt.setString(5, k.getRol());

            int rows = stmt.executeUpdate();
            return rows > 0;

        } catch (Exception e) {
            e.printStackTrace();
            return false;
        }
    }
    public static boolean guncelle(Kullanici k) {
    String sql = "UPDATE Kullanici SET Ad=?, Soyad=?, Sifre=? WHERE KullaniciID=?";
    try (Connection conn = DBConnection.getConnection();
         PreparedStatement stmt = conn.prepareStatement(sql)) {
        stmt.setString(1, k.getAd());
        stmt.setString(2, k.getSoyad());
        stmt.setString(3, k.getSifre());
        stmt.setInt(4, k.getId());
        int rows = stmt.executeUpdate();
        return rows > 0;
    } catch (Exception e) {
        e.printStackTrace();
        return false;
    }
}

    
    public static Kullanici girisYap(String email, String sifre) {
        String sql = "SELECT * FROM Kullanici WHERE Email = ? AND Sifre = ?";

        try (Connection conn = DBConnection.getConnection();
             PreparedStatement stmt = conn.prepareStatement(sql)) {

            stmt.setString(1, email);
            stmt.setString(2, sifre);

            var rs = stmt.executeQuery();
            if (rs.next()) {
    Kullanici k = new Kullanici(
        rs.getInt("KullaniciID"),
        rs.getString("Ad"),
        rs.getString("Soyad"),
        rs.getString("Email"),
        rs.getString("Sifre"),
        rs.getString("Rol")
    );
    return k;
}


        } catch (Exception e) {
            e.printStackTrace();
        }
        return null;
    }

}
