package galeriotomasyonu;

import java.sql.*;
import java.util.ArrayList;

public class EserManager implements EserIslemleri {

    @Override
    public void ekle(Eser e) {
        String sql = "INSERT INTO Eser (SanatciID, Ad, Tur, Yil, Fiyat, ResimYolu) VALUES (?, ?, ?, ?, ?, ?)";
        try (Connection conn = DBConnection.getConnection();
             PreparedStatement stmt = conn.prepareStatement(sql)) {

            stmt.setInt(1, e.getSanatciID());
            stmt.setString(2, e.getAd());
            stmt.setString(3, e.getTur());
            stmt.setInt(4, e.getYil());
            stmt.setDouble(5, e.getFiyat());
            stmt.setString(6, e.getResimYolu()); // ✔ Resim yolu da eklendi

            stmt.executeUpdate();

        } catch (SQLException ex) {
            ex.printStackTrace();
        }
    }

    @Override
    public ArrayList<Eser> listele() {
        ArrayList<Eser> eserler = new ArrayList<>();
        String sql = "SELECT * FROM Eser";

        try (Connection conn = DBConnection.getConnection();
             Statement stmt = conn.createStatement();
             ResultSet rs = stmt.executeQuery(sql)) {

            while (rs.next()) {
                Eser e = new Eser(
                        rs.getInt("EserID"),
                        rs.getString("Ad"),
                        rs.getString("Tur"),
                        rs.getInt("SanatciID"),
                        rs.getDouble("Fiyat"),
                        rs.getString("ResimYolu"),
                        rs.getInt("Yil")
                );
                eserler.add(e);
            }

        } catch (SQLException ex) {
            ex.printStackTrace();
        }

        return eserler;
    }

    @Override
    public Eser ara(int id) {
        String sql = "SELECT * FROM Eser WHERE EserID = ?";

        try (Connection conn = DBConnection.getConnection();
             PreparedStatement stmt = conn.prepareStatement(sql)) {

            stmt.setInt(1, id);
            ResultSet rs = stmt.executeQuery();

            if (rs.next()) {
                return new Eser(
                        rs.getInt("EserID"),
                        rs.getString("Ad"),
                        rs.getString("Tur"),
                        rs.getInt("SanatciID"),
                        rs.getDouble("Fiyat"),
                        rs.getString("ResimYolu"),
                        rs.getInt("Yil")
                );
            }

        } catch (SQLException ex) {
            ex.printStackTrace();
        }

        return null;
    }

    @Override
    public void guncelle(Eser eser) {
        String sql = "UPDATE Eser SET SanatciID=?, Ad=?, Tur=?, Yil=?, Fiyat=?, ResimYolu=? WHERE EserID=?";

        try (Connection conn = DBConnection.getConnection();
             PreparedStatement stmt = conn.prepareStatement(sql)) {

            stmt.setInt(1, eser.getSanatciID());
            stmt.setString(2, eser.getAd());
            stmt.setString(3, eser.getTur());
            stmt.setInt(4, eser.getYil());
            stmt.setDouble(5, eser.getFiyat());
            stmt.setString(6, eser.getResimYolu());
            stmt.setInt(7, eser.getEserID());

            stmt.executeUpdate();

        } catch (SQLException ex) {
            ex.printStackTrace();
        }
    }

    @Override
    public void sil(int id) {
        String sql = "DELETE FROM Eser WHERE EserID = ?";

        try (Connection conn = DBConnection.getConnection();
             PreparedStatement stmt = conn.prepareStatement(sql)) {

            stmt.setInt(1, id);
            stmt.executeUpdate();

        } catch (SQLException ex) {
            ex.printStackTrace();
        }
    }
}
