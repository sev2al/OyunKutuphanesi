package galeriotomasyonu;

import javax.swing.*;
import java.awt.*;

public class AdminPanel extends JFrame {
    public AdminPanel() {
        setTitle("Admin Paneli");
        setSize(400, 350);
        setDefaultCloseOperation(EXIT_ON_CLOSE);
        setLocationRelativeTo(null);
        setLayout(new GridLayout(4, 1, 10, 10)); // 4 buton için 4 satır

        JButton btnSanatci = new JButton("Sanatçı Yönetimi");
        JButton btnEser = new JButton("Eser Yönetimi");
        JButton btnMuzayede = new JButton("Müzayede Oluştur");
        JButton btnTeklifGecmisi = new JButton("Teklif Geçmişi");

        btnSanatci.addActionListener(e -> new SanatciYonetimForm().setVisible(true));
        btnEser.addActionListener(e -> new EserYonetimForm().setVisible(true));
        btnMuzayede.addActionListener(e -> new MuzayedeEkleForm().setVisible(true));
        btnTeklifGecmisi.addActionListener(e -> new TeklifGecmisiForm().setVisible(true));

        // Sıralı ekleniyor
        add(btnSanatci);
        add(btnEser);
        add(btnMuzayede);
        add(btnTeklifGecmisi); 
    }
}


