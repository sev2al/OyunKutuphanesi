package galeriotomasyonu;

import java.sql.*;
import java.util.ArrayList;

public class EserDAO {

    // Tüm eserleri döner
    public static ArrayList<Eser> getTumEserler() {
        ArrayList<Eser> liste = new ArrayList<>();
        String sql = "SELECT * FROM Eser";

        try (Connection conn = DBConnection.getConnection();
             PreparedStatement stmt = conn.prepareStatement(sql);
             ResultSet rs = stmt.executeQuery()) {

            while (rs.next()) {
                Eser e = new Eser();
                e.setEserID(rs.getInt("EserID"));
                e.setAd(rs.getString("Ad"));
                e.setTur(rs.getString("Tur"));
                e.setSanatciID(rs.getInt("SanatciID"));
                e.setFiyat(rs.getDouble("Fiyat"));
                e.setResimYolu(rs.getString("ResimYolu"));
                e.setYil(rs.getInt("Yil")); 
                liste.add(e);
            }

        } catch (Exception e) {
            e.printStackTrace();
        }

        return liste;
    }

    // Belirli bir ID'ye sahip eseri döner
    public static Eser getEserByID(int id) {
        Eser eser = null;
        String sql = "SELECT * FROM Eser WHERE EserID = ?";

        try (Connection conn = DBConnection.getConnection();
             PreparedStatement stmt = conn.prepareStatement(sql)) {

            stmt.setInt(1, id);
            ResultSet rs = stmt.executeQuery();

            if (rs.next()) {
                eser = new Eser();
                eser.setEserID(rs.getInt("EserID"));
                eser.setAd(rs.getString("Ad"));
                eser.setTur(rs.getString("Tur"));
                eser.setSanatciID(rs.getInt("SanatciID"));
                eser.setFiyat(rs.getDouble("Fiyat"));
                eser.setResimYolu(rs.getString("ResimYolu"));
                eser.setYil(rs.getInt("Yil"));
            }

        } catch (Exception e) {
            e.printStackTrace();
        }

        return eser;
    }
}
