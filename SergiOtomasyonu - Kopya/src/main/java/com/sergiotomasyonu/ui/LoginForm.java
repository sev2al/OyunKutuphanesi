package main.java.com.sergiotomasyonu.ui;

import main.java.com.sergiotomasyonu.dao.KullaniciDAO;
import main.java.com.sergiotomasyonu.model.Kullanici;
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class LoginForm extends JFrame {
    private JTextField txtUsername;
    private JPasswordField txtPassword;
    private JButton btnLogin;
    private JButton btnRegister;
    private JLabel lblUsername;
    private JLabel lblPassword;
    private KullaniciDAO kullaniciDAO;
    
    public LoginForm() {
        kullaniciDAO = new KullaniciDAO();
        initComponents();
        setupListeners();
    }
    
    private void initComponents() {
        setTitle("Sergi Otomasyonu - Giriş");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setSize(400, 300);
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
        
        // Şifre
        lblPassword = new JLabel("Şifre:");
        gbc.gridx = 0;
        gbc.gridy = 1;
        panel.add(lblPassword, gbc);
        
        txtPassword = new JPasswordField(20);
        gbc.gridx = 1;
        gbc.gridy = 1;
        panel.add(txtPassword, gbc);
        
        // Butonlar
        JPanel buttonPanel = new JPanel();
        btnLogin = new JButton("Giriş Yap");
        btnRegister = new JButton("Kayıt Ol");
        buttonPanel.add(btnLogin);
        buttonPanel.add(btnRegister);
        
        gbc.gridx = 0;
        gbc.gridy = 2;
        gbc.gridwidth = 2;
        panel.add(buttonPanel, gbc);
        
        add(panel);
    }
    
    private void setupListeners() {
        btnLogin.addActionListener(e -> login());
        btnRegister.addActionListener(e -> openRegisterForm());
        
        // Enter tuşu ile giriş
        txtPassword.addKeyListener(new KeyAdapter() {
            @Override
            public void keyPressed(KeyEvent e) {
                if (e.getKeyCode() == KeyEvent.VK_ENTER) {
                    login();
                }
            }
        });
    }
    
    private void login() {
        String username = txtUsername.getText();
        String password = new String(txtPassword.getPassword());
        
        if (username.isEmpty() || password.isEmpty()) {
            JOptionPane.showMessageDialog(this, 
                "Lütfen kullanıcı adı ve şifre giriniz.", 
                "Hata", 
                JOptionPane.ERROR_MESSAGE);
            return;
        }
        
        Kullanici kullanici = (Kullanici) kullaniciDAO.findByUsername(username);
        if (kullanici != null && kullanici.getParolaHash().equals(password)) {
            JOptionPane.showMessageDialog(this, 
                "Giriş başarılı!", 
                "Başarılı", 
                JOptionPane.INFORMATION_MESSAGE);
            // Ana menüyü aç
            // TODO: Ana menü formunu aç
        } else {
            JOptionPane.showMessageDialog(this, 
                "Kullanıcı adı veya şifre hatalı!", 
                "Hata", 
                JOptionPane.ERROR_MESSAGE);
        }
    }
    
    private void openRegisterForm() {
        RegisterForm registerForm = new RegisterForm();
        registerForm.setVisible(true);
        this.dispose();
    }
    
    public static void main(String[] args) {
        SwingUtilities.invokeLater(() -> {
            new LoginForm().setVisible(true);
        });
    }
} 