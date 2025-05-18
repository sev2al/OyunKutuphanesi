
package galeriotomasyonu;

import javax.swing.*;
import java.awt.*;

public class MusteriPanel extends JFrame {
    private JButton btnSanatcilar, btnEserler;
    private Kullanici girenKullanici;

    public MusteriPanel(Kullanici kullanici) {
        this.girenKullanici = kullanici;

        setTitle("Müşteri Paneli");
        setSize(400, 300);
        setDefaultCloseOperation(EXIT_ON_CLOSE);
        setLocationRelativeTo(null);
        setLayout(new BoxLayout(getContentPane(), BoxLayout.Y_AXIS));

        // Butonlar
        btnSanatcilar = new JButton("Sanatçıları Gör"); // ✅ düzeltilmiş yazım
        btnEserler = new JButton("Eserleri Gör");
        JButton btnSatinAlinanlar = new JButton("Satın Aldıklarım");
        JButton btnTeklifVer = new JButton("Teklif Ver");

        // Aksiyonlar
        btnSanatcilar.addActionListener(e -> new SanatciListeForm().setVisible(true));
        btnEserler.addActionListener(e -> new EserListeForm().setVisible(true));
        btnSatinAlinanlar.addActionListener(e -> new SatinAlinanlarForm(girenKullanici.getId()).setVisible(true));
        btnTeklifVer.addActionListener(e -> new TeklifVerForm(girenKullanici.getId()).setVisible(true));
        
        JButton btnEserler = new JButton("Eserleri Gör");
btnEserler.addActionListener(e -> new EserListeForm().setVisible(true));
add(btnEserler);


        // Ekle
        add(btnSanatcilar);
        add(btnEserler);
        add(btnSatinAlinanlar);
        add(btnTeklifVer);
        
        JButton btnProfil = new JButton("Profilimi Güncelle");
btnProfil.addActionListener(e -> new ProfilGuncelleForm(girenKullanici).setVisible(true));
add(btnProfil);

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