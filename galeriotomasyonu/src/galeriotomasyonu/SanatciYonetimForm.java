package galeriotomasyonu;

import galeriotomasyonu.Sanatci;
import javax.swing.*;
import javax.swing.table.DefaultTableModel;
import java.awt.*;
import java.util.ArrayList;

public class SanatciYonetimForm extends JFrame {
    private JTextField txtAd, txtSoyad, txtUlke, txtDogumTarihi;
    private JTextArea txtBiyografi;
    private JTable table;
    private DefaultTableModel model;
    private SanatciManager manager = new SanatciManager();

    public SanatciYonetimForm() {
        setTitle("Sanatçı Yönetimi");
        setSize(800, 600);
        setLocationRelativeTo(null);
        setDefaultCloseOperation(DISPOSE_ON_CLOSE);
        setLayout(new BorderLayout());

        // Form Paneli
        JPanel formPanel = new JPanel(new GridLayout(6, 2, 10, 10));
        txtAd = new JTextField();
        txtSoyad = new JTextField();
        txtUlke = new JTextField();
        txtDogumTarihi = new JTextField();
        txtBiyografi = new JTextArea(3, 20);

        formPanel.add(new JLabel("Ad:")); formPanel.add(txtAd);
        formPanel.add(new JLabel("Soyad:")); formPanel.add(txtSoyad);
        formPanel.add(new JLabel("Ülke:")); formPanel.add(txtUlke);
        formPanel.add(new JLabel("Doğum Tarihi (YYYY-AA-GG):")); formPanel.add(txtDogumTarihi);
        formPanel.add(new JLabel("Biyografi:")); formPanel.add(new JScrollPane(txtBiyografi));

        // Buton Paneli
        JPanel btnPanel = new JPanel(new FlowLayout());
        JButton btnEkle = new JButton("Ekle");
        JButton btnGuncelle = new JButton("Güncelle");
        JButton btnSil = new JButton("Sil");

        btnPanel.add(btnEkle);
        btnPanel.add(btnGuncelle);
        btnPanel.add(btnSil);

        // Tablo
        String[] kolonlar = {"ID", "Ad", "Soyad", "Ülke", "Doğum Tarihi", "Biyografi"};
        model = new DefaultTableModel(kolonlar, 0);
        table = new JTable(model);
        JScrollPane scrollPane = new JScrollPane(table);

        // Ana Ekleme
        JPanel ustPanel = new JPanel(new BorderLayout());
        ustPanel.add(formPanel, BorderLayout.CENTER);
        ustPanel.add(btnPanel, BorderLayout.SOUTH);

        add(ustPanel, BorderLayout.NORTH);
        add(scrollPane, BorderLayout.CENTER);

        sanatcilariYukle();

        // Buton İşlevleri
        btnEkle.addActionListener(e -> {
            Sanatci s = new Sanatci(0, txtAd.getText(), txtSoyad.getText(), txtUlke.getText(),
                    txtDogumTarihi.getText(), txtBiyografi.getText());
            manager.ekle(s);
            JOptionPane.showMessageDialog(this, "Sanatçı eklendi!");
            sanatcilariYukle();
            temizle();
        });

        btnGuncelle.addActionListener(e -> {
            int secili = table.getSelectedRow();
            if (secili >= 0) {
                int id = (int) model.getValueAt(secili, 0);
                Sanatci s = new Sanatci(id, txtAd.getText(), txtSoyad.getText(), txtUlke.getText(),
                        txtDogumTarihi.getText(), txtBiyografi.getText());
                manager.guncelle(s);
                sanatcilariYukle();
                temizle();
            }
        });

        btnSil.addActionListener(e -> {
            int secili = table.getSelectedRow();
            if (secili >= 0) {
                int id = (int) model.getValueAt(secili, 0);
                manager.sil(id);
                sanatcilariYukle();
                temizle();
            }
        });

        table.getSelectionModel().addListSelectionListener(e -> {
            int secili = table.getSelectedRow();
            if (secili >= 0) {
                txtAd.setText((String) model.getValueAt(secili, 1));
                txtSoyad.setText((String) model.getValueAt(secili, 2));
                txtUlke.setText((String) model.getValueAt(secili, 3));
                txtDogumTarihi.setText((String) model.getValueAt(secili, 4));
                txtBiyografi.setText((String) model.getValueAt(secili, 5));
            }
        });
    }

    private void sanatcilariYukle() {
        model.setRowCount(0);
        for (Sanatci s : manager.listele()) {
            model.addRow(new Object[]{
                    s.getSanatciID(), s.getAd(), s.getSoyad(), s.getUlke(), s.getDogumTarihi(), s.getBiyografi()
            });
        }
    }

    private void temizle() {
        txtAd.setText("");
        txtSoyad.setText("");
        txtUlke.setText("");
        txtDogumTarihi.setText("");
        txtBiyografi.setText("");
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