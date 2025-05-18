package galeriotomasyonu;

import java.sql.*;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import galeriotomasyonu.DBConnection;
import javax.swing.JOptionPane;

public class TeklifDAO {

    public static boolean teklifKaydet(int musteriID, int muzayedeID, double tutar) {
        String sql = "INSERT INTO Teklifler (MusteriID, MuzayedeID, TeklifTutari, TeklifTarihi, Durum) VALUES (?, ?, ?, ?, ?)";

        try (Connection conn = DBConnection.getConnection();
             PreparedStatement stmt = conn.prepareStatement(sql)) {

            stmt.setInt(1, musteriID);
            stmt.setInt(2, muzayedeID);
            stmt.setDouble(3, tutar);
            String tarih = LocalDateTime.now().format(DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss"));
            stmt.setString(4, tarih);
            stmt.setString(5, "Beklemede");

            stmt.executeUpdate();
            return true;
        } catch (Exception ex) {
            ex.printStackTrace();
            JOptionPane.showMessageDialog(null, "Teklif kaydedilemedi: " + ex.getMessage());
            return false;
        }
    }
    
    public static boolean dahaOnceReddedildiMi(int musteriID, int muzayedeID) {
    String sql = "SELECT COUNT(*) FROM Teklifler WHERE MusteriID = ? AND MuzayedeID = ? AND Durum = 'Reddedildi'";

    try (Connection conn = new DBConnection().getConnection();
         PreparedStatement stmt = conn.prepareStatement(sql)) {
        
        stmt.setInt(1, musteriID);
        stmt.setInt(2, muzayedeID);

        ResultSet rs = stmt.executeQuery();
        if (rs.next()) {
            return rs.getInt(1) > 0;
        }

    } catch (Exception e) {
        e.printStackTrace();
    }

    return false;
}

    public static ArrayList<Teklif> getTumTeklifler() {
        ArrayList<Teklif> teklifler = new ArrayList<>();
        String sql = "SELECT t.TeklifID, k.Ad + ' ' + k.Soyad AS Musteri, e.Ad AS EserAdi, t.TeklifTutari, t.TeklifTarihi, t.Durum " +
                     "FROM Teklifler t " +
                     "JOIN Kullanici k ON t.MusteriID = k.KullaniciID " +
                     "JOIN Muzayede m ON t.MuzayedeID = m.MuzayedeID " +
                     "JOIN Eser e ON m.EserID = e.EserID";

        try (Connection conn = DBConnection.getConnection();
             PreparedStatement stmt = conn.prepareStatement(sql);
             ResultSet rs = stmt.executeQuery()) {

            while (rs.next()) {
                teklifler.add(new Teklif(
                        rs.getInt("TeklifID"),
                        rs.getString("Musteri"),
                        rs.getString("EserAdi"),
                        rs.getDouble("TeklifTutari"),
                        rs.getString("TeklifTarihi"),
                        rs.getString("Durum")
                ));
            }
        } catch (Exception ex) {
            ex.printStackTrace();
            JOptionPane.showMessageDialog(null, "Teklifler alınamadı: " + ex.getMessage());
        }

        return teklifler;
    }

    
public static boolean teklifDurumGuncelle(int teklifID, String yeniDurum) {
    String sql = "UPDATE Teklifler SET Durum = ? WHERE TeklifID = ?";

    try (Connection conn = DBConnection.getConnection()) {
        conn.setAutoCommit(false); // 👈 işlemleri toplu yapacağız

        // Teklifi güncelle
        PreparedStatement stmt = conn.prepareStatement(sql);
        stmt.setString(1, yeniDurum);
        stmt.setInt(2, teklifID);
        stmt.executeUpdate();

        // 💥 Eğer teklif onaylandıysa satışa da kaydet
        if (yeniDurum.equalsIgnoreCase("Onaylandı")) {
            String insertSatis = """
                INSERT INTO Satislar (MusteriID, EserID, SatisTarihi, Fiyat)
                SELECT t.MusteriID, m.EserID, GETDATE(), t.TeklifTutari
                FROM Teklifler t
                JOIN Muzayede m ON t.MuzayedeID = m.MuzayedeID
                WHERE t.TeklifID = ?
            """;

            PreparedStatement satisStmt = conn.prepareStatement(insertSatis);
            satisStmt.setInt(1, teklifID);
            satisStmt.executeUpdate();
        }

        conn.commit(); // ✅ her şeyi onayla
        return true;

    } catch (Exception ex) {
        ex.printStackTrace();
        JOptionPane.showMessageDialog(null, "HATA: " + ex.getMessage());
        return false;
    }}}

