package galeriotomasyonu;

import java.sql.*;
import java.util.ArrayList;

public class MuzayedeDAO {

    // Tüm müzayedeleri getirir (admin/galeri görünümü)
    public static ArrayList<Muzayede> getMuzayedeler() {
        ArrayList<Muzayede> liste = new ArrayList<>();
        String query = "SELECT m.MuzayedeID, m.EserID, e.Ad AS EserAdi, m.BaslangicTarihi, m.BitisTarihi, m.MinimumTeklif " +
                       "FROM Muzayede m JOIN Eser e ON m.EserID = e.EserID";
        try (Connection conn = DBConnection.getConnection();
             Statement stmt = conn.createStatement();
             ResultSet rs = stmt.executeQuery(query)) {

            while (rs.next()) {
                liste.add(new Muzayede(
                        rs.getInt("MuzayedeID"),
                        rs.getInt("EserID"),
                        rs.getString("EserAdi"),
                        rs.getString("BaslangicTarihi"),
                        rs.getString("BitisTarihi"),
                        rs.getDouble("MinimumTeklif")
                ));
            }

        } catch (SQLException e) {
            e.printStackTrace();
        }

        return liste;
    }

    // 💥 Müşteri bazlı: Onaylanan teklifleri hariç tutar, sadece teklif verilebilecek müzayedeleri getirir
    public static ArrayList<Muzayede> getTeklifVerilebilirler(int musteriID) {
        ArrayList<Muzayede> liste = new ArrayList<>();
        String sql = """
            SELECT m.*
            FROM Muzayede m
            WHERE NOT EXISTS (
                SELECT 1 FROM Teklifler t
                WHERE t.MuzayedeID = m.MuzayedeID
                  AND t.MusteriID = ?
                  AND t.Durum = 'Onaylandı'
            )
        """;

        try (Connection conn = DBConnection.getConnection();
             PreparedStatement stmt = conn.prepareStatement(sql)) {

            stmt.setInt(1, musteriID);
            ResultSet rs = stmt.executeQuery();

            while (rs.next()) {
                Muzayede m = new Muzayede();
                m.setMuzayedeID(rs.getInt("MuzayedeID"));
                m.setEserID(rs.getInt("EserID"));
                m.setBaslangicTarihi(rs.getTimestamp("BaslangicTarihi").toString());
                m.setBitisTarihi(rs.getTimestamp("BitisTarihi").toString());
                m.setMinimumTeklif(rs.getDouble("MinimumTeklif"));
                liste.add(m);
            }

        } catch (Exception e) {
            e.printStackTrace();
        }

        return liste;
    }
}
