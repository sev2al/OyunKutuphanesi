package galeriotomasyonu;

import galeriotomasyonu.Kullanici;
import galeriotomasyonu.KullaniciDAO;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;

public class KayitForm extends JFrame {
    private JTextField adField, soyadField, emailField;
    private JPasswordField sifreField;
    private JComboBox<String> rolCombo;
    private JButton kayitButton, geriButton;

    public KayitForm() {
        setTitle("Kullanıcı Kayıt");
        setSize(400, 320);
        setLocationRelativeTo(null);
        setDefaultCloseOperation(EXIT_ON_CLOSE);
        setLayout(new GridLayout(7, 2, 10, 10)); // Satır sayısı 7 oldu

        // Form bileşenleri
        add(new JLabel("Ad:"));
        adField = new JTextField();
        add(adField);

        add(new JLabel("Soyad:"));
        soyadField = new JTextField();
        add(soyadField);

        add(new JLabel("Email:"));
        emailField = new JTextField();
        add(emailField);

        add(new JLabel("Şifre:"));
        sifreField = new JPasswordField();
        add(sifreField);

        add(new JLabel("Rol:"));
        rolCombo = new JComboBox<>(new String[]{"Admin", "Musteri"});
        add(rolCombo);

        kayitButton = new JButton("Kayıt Ol");
        geriButton = new JButton("Geri Dön");
        add(kayitButton);
        add(geriButton);

        // Buton işlemleri
        kayitButton.addActionListener((ActionEvent e) -> kullaniciKaydet());

        geriButton.addActionListener((ActionEvent e) -> {
            dispose(); // kayıt formunu kapat
            new GirisForm().setVisible(true); // giriş formunu aç
        });
    }

    private void kullaniciKaydet() {
        String ad = adField.getText();
        String soyad = soyadField.getText();
        String email = emailField.getText();
        String sifre = new String(sifreField.getPassword());
        String rol = (String) rolCombo.getSelectedItem();

        Kullanici kullanici = new Kullanici(0, ad, soyad, email, sifre, rol);
        boolean basarili = KullaniciDAO.kullaniciEkle(kullanici);

        if (basarili) {
            JOptionPane.showMessageDialog(this, "Kayıt başarılı!");
            dispose();
            new GirisForm().setVisible(true);
        } else {
            JOptionPane.showMessageDialog(this, "Kayıt başarısız. Bu e-mail zaten kayıtlı olabilir.");
        }
    }

    public static void main(String[] args) {
        SwingUtilities.invokeLater(() -> new KayitForm().setVisible(true));
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
