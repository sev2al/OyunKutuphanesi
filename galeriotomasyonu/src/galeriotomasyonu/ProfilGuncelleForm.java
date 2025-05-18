
package galeriotomasyonu;

import javax.swing.*;
import java.awt.*;

public class ProfilGuncelleForm extends JFrame {
    private JTextField txtAd, txtSoyad;
    private JPasswordField txtSifre;
    private JButton btnGuncelle;
    private Kullanici kullanici;

    public ProfilGuncelleForm(Kullanici kullanici) {
        this.kullanici = kullanici;

        setTitle("Profilimi Güncelle");
        setSize(350, 250);
        setLocationRelativeTo(null);
        setDefaultCloseOperation(DISPOSE_ON_CLOSE);
        setLayout(new GridLayout(4, 2, 10, 10));

        add(new JLabel("Ad:"));
        txtAd = new JTextField(kullanici.getAd());
        add(txtAd);

        add(new JLabel("Soyad:"));
        txtSoyad = new JTextField(kullanici.getSoyad());
        add(txtSoyad);

        add(new JLabel("Yeni Şifre:"));
        txtSifre = new JPasswordField(kullanici.getSifre());
        add(txtSifre);

        btnGuncelle = new JButton("Güncelle");
        add(btnGuncelle);

        btnGuncelle.addActionListener(e -> {
            kullanici.setAd(txtAd.getText());
            kullanici.setSoyad(txtSoyad.getText());
            kullanici.setSifre(new String(txtSifre.getPassword()));

            if (KullaniciDAO.guncelle(kullanici)) {
                JOptionPane.showMessageDialog(this, "Profil başarıyla güncellendi.");
                dispose();
            } else {
                JOptionPane.showMessageDialog(this, "Güncelleme başarısız.");
            }
        });

        // Placeholder boşluk
        add(new JLabel(""));
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
