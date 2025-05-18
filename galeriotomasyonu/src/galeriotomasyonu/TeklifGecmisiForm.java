package galeriotomasyonu;

import java.sql.PreparedStatement;
import java.sql.Connection;
import galeriotomasyonu.DBConnection;
import javax.swing.*;
import javax.swing.table.DefaultTableModel;
import java.awt.*;
import java.util.ArrayList;

public class TeklifGecmisiForm extends JFrame {

    private JTable table;
    private DefaultTableModel model;
    private JButton btnOnayla, btnReddet;

    public TeklifGecmisiForm() {
        setTitle("Teklif Geçmişi");
        setSize(800, 400);
        setLocationRelativeTo(null);
        setDefaultCloseOperation(DISPOSE_ON_CLOSE);
        setLayout(new BorderLayout());

        // Tablo başlıkları
        String[] kolonlar = {"TeklifID", "Müşteri", "Eser", "Tutar", "Tarih", "Durum"};
        model = new DefaultTableModel(kolonlar, 0);
        table = new JTable(model);
        JScrollPane scrollPane = new JScrollPane(table);
        add(scrollPane, BorderLayout.CENTER);

        // Butonlar paneli
        JPanel butonPanel = new JPanel();
        btnOnayla = new JButton("Onayla");
        btnReddet = new JButton("Reddet");

        butonPanel.add(btnOnayla);
        butonPanel.add(btnReddet);
        add(butonPanel, BorderLayout.SOUTH);

        btnOnayla.addActionListener(e -> {
    int secili = table.getSelectedRow();
    if (secili >= 0) {
        int teklifID = (int) model.getValueAt(secili, 0);
        if (teklifDurumGuncelle(teklifID, "Onaylandı")) {
            tekliflerYukle(); // tabloyu güncelle
        }
    } else {
        JOptionPane.showMessageDialog(this, "Lütfen bir teklif seçin!");
    }
});

btnReddet.addActionListener(e -> {
    int secili = table.getSelectedRow();
    if (secili >= 0) {
        int teklifID = (int) model.getValueAt(secili, 0);
        if (teklifDurumGuncelle(teklifID, "Reddedildi")) {
            tekliflerYukle(); // tabloyu güncelle
        }
    } else {
        JOptionPane.showMessageDialog(this, "Lütfen bir teklif seçin!");
    }
});

        tekliflerYukle();
    }

    private void tekliflerYukle() {
        model.setRowCount(0);
        ArrayList<Teklif> teklifler = TeklifDAO.getTumTeklifler();
        for (Teklif t : teklifler) {
            model.addRow(new Object[]{
                t.getTeklifID(),
                t.getMusteriAdSoyad(),
                t.getEserAdi(),
                t.getTeklifTutari(),
                t.getTeklifTarihi(),
                t.getDurum()
            });
        }
    }

    public static boolean teklifDurumGuncelle(int teklifID, String yeniDurum) {
        String sql = "UPDATE Teklifler SET Durum = ? WHERE TeklifID = ?";

        try {
            var conn = new DBConnection().getConnection();

            conn.setAutoCommit(false); // hem güncelle hem satış işlemini aynı anda yapalım

            PreparedStatement stmt1 = conn.prepareStatement(sql);
            stmt1.setString(1, yeniDurum);
            stmt1.setInt(2, teklifID);
            stmt1.executeUpdate();

            // Eğer onaylandıysa Satislar tablosuna ekle
            if (yeniDurum.equalsIgnoreCase("Onaylandı")) {
                String satisSql = """
                INSERT INTO Satislar (MusteriID, EserID, SatisTarihi)
                SELECT t.MusteriID, m.EserID, GETDATE()
                FROM Teklifler t
                JOIN Muzayede m ON t.MuzayedeID = m.MuzayedeID
                WHERE t.TeklifID = ?
            """;

                PreparedStatement stmt2 = conn.prepareStatement(satisSql);
                stmt2.setInt(1, teklifID);
                stmt2.executeUpdate();
            }

            conn.commit();
            return true;

        } catch (Exception ex) {
            ex.printStackTrace();
            return false;
        }
    }
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 400, Short.MAX_VALUE)
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 300, Short.MAX_VALUE)
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents


    // Variables declaration - do not modify//GEN-BEGIN:variables
    // End of variables declaration//GEN-END:variables
}
