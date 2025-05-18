package galeriotomasyonu;

import java.sql.*;
import java.util.ArrayList;

public class SatisDAO {
        

public static ArrayList<SatinAlma> getSatinAlinanlar(int musteriID) {
    ArrayList<SatinAlma> liste = new ArrayList<>();
    String query = """
        SELECT e.Ad AS EserAdi, s.SatisTarihi, s.Fiyat
        FROM Satislar s
        JOIN Eser e ON s.EserID = e.EserID
        WHERE s.MusteriID = ?
    """;

    try (Connection conn = DBConnection.getConnection();
         PreparedStatement stmt = conn.prepareStatement(query)) {
        stmt.setInt(1, musteriID);
        ResultSet rs = stmt.executeQuery();

        while (rs.next()) {
            liste.add(new SatinAlma(
                    rs.getString("EserAdi"),
                    rs.getString("SatisTarihi"),
                    rs.getDouble("Fiyat")
            ));
        }

    } catch (SQLException e) {
        e.printStackTrace();
    }

    return liste;
}}