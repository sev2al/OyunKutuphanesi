package galeriotomasyonu;

import javax.swing.*;
import java.awt.*;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.util.ArrayList;

public class MuzayedeEkleForm extends JFrame {

    private JComboBox<Eser> comboEser;
    private JTextField txtBaslangic, txtBitis, txtMinTeklif;

    public MuzayedeEkleForm() {
        setTitle("Müzayede Oluştur");
        setSize(400, 300);
        setLocationRelativeTo(null);
        setDefaultCloseOperation(DISPOSE_ON_CLOSE);
        setLayout(new GridLayout(5, 2, 10, 10));

        // Eser seçimi
        add(new JLabel("Eser Seç:"));
        comboEser = new JComboBox<>();
        add(comboEser);
        eserleriYukle(); 

        // Başlangıç tarihi
        add(new JLabel("Başlangıç Tarihi (YYYY-MM-DD HH:MM):"));
        txtBaslangic = new JTextField();
        add(txtBaslangic);

        // Bitiş tarihi
        add(new JLabel("Bitiş Tarihi (YYYY-MM-DD HH:MM):"));
        txtBitis = new JTextField();
        add(txtBitis);

        // Minimum teklif
        add(new JLabel("Minimum Teklif:"));
        txtMinTeklif = new JTextField();
        add(txtMinTeklif);

        // Buton
        JButton btnOlustur = new JButton("Müzayedeyi Başlat");
        btnOlustur.addActionListener(e -> muzayedeEkle());
        add(btnOlustur);
        add(new JLabel()); // boşluk için

        setVisible(true); // GUI açıldığında görünür olsun
    }

    private void eserleriYukle() {
        ArrayList<Eser> eserler = EserDAO.getTumEserler();

        if (eserler.isEmpty()) {
            JOptionPane.showMessageDialog(this, "Veritabanında hiç eser bulunamadı!");
        }

        for (Eser e : eserler) {
            comboEser.addItem(e);
        }
    }

    private void muzayedeEkle() {
        try {
            Eser secilenEser = (Eser) comboEser.getSelectedItem();
            if (secilenEser == null) {
                JOptionPane.showMessageDialog(this, "Lütfen bir eser seçin!");
                return;
            }

            int eserID = secilenEser.getEserID();
            String baslangic = txtBaslangic.getText();
            String bitis = txtBitis.getText();
            double minTeklif = Double.parseDouble(txtMinTeklif.getText());

            String sql = "INSERT INTO Muzayede (EserID, BaslangicTarihi, BitisTarihi, MinimumTeklif) VALUES (?, ?, ?, ?)";

            Connection conn = DBConnection.getConnection();
            PreparedStatement stmt = conn.prepareStatement(sql);
            stmt.setInt(1, eserID);
            stmt.setString(2, baslangic);
            stmt.setString(3, bitis);
            stmt.setDouble(4, minTeklif);
            stmt.executeUpdate();

            JOptionPane.showMessageDialog(this, "Müzayede başarıyla oluşturuldu!");
            dispose();

        } catch (Exception ex) {
            ex.printStackTrace();
            JOptionPane.showMessageDialog(this, "Hata oluştu: " + ex.getMessage());
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