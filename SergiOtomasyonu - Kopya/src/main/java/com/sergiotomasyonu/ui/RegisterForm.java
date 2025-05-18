package main.java.com.sergiotomasyonu.ui;

import main.java.com.sergiotomasyonu.dao.KullaniciDAO;
import main.java.com.sergiotomasyonu.model.Kullanici;
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class RegisterForm extends JFrame {
    private JTextField txtUsername;
    private JTextField txtEmail;
    private JPasswordField txtPassword;
    private JPasswordField txtPasswordConfirm;
    private JButton btnRegister;
    private JButton btnBack;
    private JLabel lblUsername;
    private JLabel lblEmail;
    private JLabel lblPassword;
    private JLabel lblPasswordConfirm;
    private KullaniciDAO kullaniciDAO;
    
    public RegisterForm() {
        kullaniciDAO = new KullaniciDAO();
        initComponents();
        setupListeners();
    }
    
    private void initComponents() {
        setTitle("Sergi Otomasyonu - Kayıt");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setSize(400, 400);
        setLocationRelativeTo(null);
        
        // Panel oluştur
        JPanel panel = new JPanel();
        panel.setLayout(new GridBagLayout());
        GridBagConstraints gbc = new GridBagConstraints();
        gbc.insets = new Insets(5, 5, 5, 5);
        
        // Kullanıcı adı
        lblUsername = new JLabel("Kullanıcı Adı:");
        gbc.gridx = 0;
        gbc.gridy = 0;
        panel.add(lblUsername, gbc);
        
        txtUsername = new JTextField(20);
        gbc.gridx = 1;
        gbc.gridy = 0;
        panel.add(txtUsername, gbc);
        
        // E-posta
        lblEmail = new JLabel("E-posta:");
        gbc.gridx = 0;
        gbc.gridy = 1;
        panel.add(lblEmail, gbc);
        
        txtEmail = new JTextField(20);
        gbc.gridx = 1;
        gbc.gridy = 1;
        panel.add(txtEmail, gbc);
        
        // Şifre
        lblPassword = new JLabel("Şifre:");
        gbc.gridx = 0;
        gbc.gridy = 2;
        panel.add(lblPassword, gbc);
        
        txtPassword = new JPasswordField(20);
        gbc.gridx = 1;
        gbc.gridy = 2;
        panel.add(txtPassword, gbc);
        
        // Şifre Tekrar
        lblPasswordConfirm = new JLabel("Şifre Tekrar:");
        gbc.gridx = 0;
        gbc.gridy = 3;
        panel.add(lblPasswordConfirm, gbc);
        
        txtPasswordConfirm = new JPasswordField(20);
        gbc.gridx = 1;
        gbc.gridy = 3;
        panel.add(txtPasswordConfirm, gbc);
        
        // Butonlar
        JPanel buttonPanel = new JPanel();
        btnRegister = new JButton("Kayıt Ol");
        btnBack = new JButton("Geri");
        buttonPanel.add(btnRegister);
        buttonPanel.add(btnBack);
        
        gbc.gridx = 0;
        gbc.gridy = 4;
        gbc.gridwidth = 2;
        panel.add(buttonPanel, gbc);
        
        add(panel);
    }
    
    private void setupListeners() {
        btnRegister.addActionListener(e -> register());
        btnBack.addActionListener(e -> backToLogin());
    }
    
    private void register() {
        String username = txtUsername.getText();
        String email = txtEmail.getText();
        String password = new String(txtPassword.getPassword());
        String passwordConfirm = new String(txtPasswordConfirm.getPassword());
        
        // Validasyonlar
        if (username.isEmpty() || email.isEmpty() || password.isEmpty() || passwordConfirm.isEmpty()) {
            JOptionPane.showMessageDialog(this, 
                "Lütfen tüm alanları doldurunuz.", 
                "Hata", 
                JOptionPane.ERROR_MESSAGE);
            return;
        }
        
        if (!password.equals(passwordConfirm)) {
            JOptionPane.showMessageDialog(this, 
                "Şifreler eşleşmiyor!", 
                "Hata", 
                JOptionPane.ERROR_MESSAGE);
            return;
        }
        
        if (kullaniciDAO.isUsernameExists(username)) {
            JOptionPane.showMessageDialog(this, 
                "Bu kullanıcı adı zaten kullanılıyor!", 
                "Hata", 
                JOptionPane.ERROR_MESSAGE);
            return;
        }
        
        if (kullaniciDAO.isEmailExists(email)) {
            JOptionPane.showMessageDialog(this, 
                "Bu e-posta adresi zaten kullanılıyor!", 
                "Hata", 
                JOptionPane.ERROR_MESSAGE);
            return;
        }
        
        // Kullanıcıyı kaydet
        Kullanici kullanici = new Kullanici(username, email, password);
        if (kullaniciDAO.save(kullanici)) {
            JOptionPane.showMessageDialog(this, 
                "Kayıt başarılı! Giriş yapabilirsiniz.", 
                "Başarılı", 
                JOptionPane.INFORMATION_MESSAGE);
            backToLogin();
        } else {
            JOptionPane.showMessageDialog(this, 
                "Kayıt sırasında bir hata oluştu!", 
                "Hata", 
                JOptionPane.ERROR_MESSAGE);
        }
    }
    
    private void backToLogin() {
        LoginForm loginForm = new LoginForm();
        loginForm.setVisible(true);
        this.dispose();
    }
} 