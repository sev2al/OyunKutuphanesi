package galeriotomasyonu;

import galeriotomasyonu.KullaniciDAO;
import galeriotomasyonu.Kullanici;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;

public class GirisForm extends JFrame {
    private JTextField emailField;
    private JPasswordField sifreField;
    private JButton girisButton;
    private JButton kayitButton;

    public GirisForm() {
        setTitle("Kullanıcı Giriş");
        setSize(350, 220);
        setLocationRelativeTo(null);
        setDefaultCloseOperation(EXIT_ON_CLOSE);
        setLayout(new GridLayout(4, 2, 10, 10));

        add(new JLabel("Email:"));
        emailField = new JTextField();
        add(emailField);

        add(new JLabel("Şifre:"));
        sifreField = new JPasswordField();
        add(sifreField);

        girisButton = new JButton("Giriş Yap");
        kayitButton = new JButton("Kayıt Ol");
        add(girisButton);
        add(kayitButton);

        girisButton.addActionListener((ActionEvent e) -> kullaniciGiris());

        kayitButton.addActionListener((ActionEvent e) -> {
            new KayitForm().setVisible(true);
        });
    }

    private void kullaniciGiris() {
    String email = emailField.getText();
    String sifre = new String(sifreField.getPassword());
    
    System.out.println(email + " " + sifre);

    Kullanici girenKullanici = KullaniciDAO.girisYap(email, sifre);

    if (girenKullanici != null) {
        JOptionPane.showMessageDialog(this, "Hoş geldiniz, " + girenKullanici.getAd() + " (" + girenKullanici.getRol() + ")");
        dispose(); // formu kapat

        // Giriş sonrası yönlendirme (panel açma)
        if (girenKullanici.getRol().equalsIgnoreCase("Admin")) {
            new AdminPanel().setVisible(true);
        } else if (girenKullanici.getRol().equalsIgnoreCase("Musteri")) {
            new MusteriPanel(girenKullanici).setVisible(true); // ✅ SADECE NESNEYİ GÖNDERİYORUZ
        }

    } else {
        JOptionPane.showMessageDialog(this, "Hatalı giriş. Lütfen bilgileri kontrol edin.");
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
