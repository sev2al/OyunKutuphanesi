package galeriotomasyonu;

import javax.swing.*;
import javax.swing.table.DefaultTableModel;
import java.awt.*;

public class EserYonetimForm extends JFrame {
    private JTextField txtSanatciID, txtAd, txtTur, txtYil, txtFiyat, txtResimYolu;
    private JTable table;
    private DefaultTableModel model;
    private EserManager manager = new EserManager();

    public EserYonetimForm() {
        setTitle("Eser Yönetimi");
        setSize(800, 600);
        setLocationRelativeTo(null);
        setDefaultCloseOperation(DISPOSE_ON_CLOSE);
        setLayout(new BorderLayout());

        // Form alanları
        JPanel formPanel = new JPanel(new GridLayout(7, 2, 10, 10));
        txtSanatciID = new JTextField();
        txtAd = new JTextField();
        txtTur = new JTextField();
        txtYil = new JTextField();
        txtFiyat = new JTextField();
        txtResimYolu = new JTextField();

        formPanel.add(new JLabel("Sanatçı ID:")); formPanel.add(txtSanatciID);
        formPanel.add(new JLabel("Eser Adı:")); formPanel.add(txtAd);
        formPanel.add(new JLabel("Tür:")); formPanel.add(txtTur);
        formPanel.add(new JLabel("Yıl:")); formPanel.add(txtYil);
        formPanel.add(new JLabel("Fiyat:")); formPanel.add(txtFiyat);
        formPanel.add(new JLabel("Resim Yolu:")); formPanel.add(txtResimYolu);

        JButton btnDosyaSec = new JButton("Dosya Seç");
        btnDosyaSec.addActionListener(e -> {
            JFileChooser fc = new JFileChooser();
            int sonuc = fc.showOpenDialog(this);
            if (sonuc == JFileChooser.APPROVE_OPTION) {
                txtResimYolu.setText(fc.getSelectedFile().getAbsolutePath());
            }
        });
        formPanel.add(btnDosyaSec);
        formPanel.add(new JLabel());

        // Butonlar
        JPanel btnPanel = new JPanel(new FlowLayout());
        JButton btnEkle = new JButton("Ekle");
        JButton btnGuncelle = new JButton("Güncelle");
        JButton btnSil = new JButton("Sil");
        btnPanel.add(btnEkle);
        btnPanel.add(btnGuncelle);
        btnPanel.add(btnSil);

        // Tablo
        String[] kolonlar = {"ID", "Sanatçı ID", "Ad", "Tür", "Yıl", "Fiyat", "Resim Yolu"};
        model = new DefaultTableModel(kolonlar, 0);
        table = new JTable(model);
        JScrollPane scrollPane = new JScrollPane(table);

        // Panel yerleşimi
        JPanel ustPanel = new JPanel(new BorderLayout());
        ustPanel.add(formPanel, BorderLayout.CENTER);
        ustPanel.add(btnPanel, BorderLayout.SOUTH);
        add(ustPanel, BorderLayout.NORTH);
        add(scrollPane, BorderLayout.CENTER);

        eserleriYukle();

        // Buton aksiyonları
        btnEkle.addActionListener(e -> {
            Eser eser = new Eser(
    0,
    txtAd.getText(),                         
    txtTur.getText(),                        
    Integer.parseInt(txtSanatciID.getText()), 
    Double.parseDouble(txtFiyat.getText()),   
    txtResimYolu.getText(),                 
    Integer.parseInt(txtYil.getText())       
);

            manager.ekle(eser);
            JOptionPane.showMessageDialog(this, "Eser başarıyla eklendi!");
            eserleriYukle();
            temizle();
        });

        btnGuncelle.addActionListener(e -> {
            int secili = table.getSelectedRow();
            if (secili >= 0) {
                int id = (int) model.getValueAt(secili, 0);
   Eser eser = new Eser(
    id,
    txtAd.getText(),
    txtTur.getText(),
    Integer.parseInt(txtSanatciID.getText()),
    Double.parseDouble(txtFiyat.getText()),
    txtResimYolu.getText(),
    Integer.parseInt(txtYil.getText())
);

                manager.guncelle(eser);
                eserleriYukle();
                temizle();
            }
        });

        btnSil.addActionListener(e -> {
            int secili = table.getSelectedRow();
            if (secili >= 0) {
                int id = (int) model.getValueAt(secili, 0);
                manager.sil(id);
                eserleriYukle();
                temizle();
            }
        });

        table.getSelectionModel().addListSelectionListener(e -> {
            int secili = table.getSelectedRow();
            if (secili >= 0) {
                txtSanatciID.setText(String.valueOf(model.getValueAt(secili, 1)));
                txtAd.setText((String) model.getValueAt(secili, 2));
                txtTur.setText((String) model.getValueAt(secili, 3));
                txtYil.setText(String.valueOf(model.getValueAt(secili, 4)));
                txtFiyat.setText(String.valueOf(model.getValueAt(secili, 5)));
                txtResimYolu.setText((String) model.getValueAt(secili, 6));
            }
        });
    }

    private void eserleriYukle() {
        model.setRowCount(0);
        for (Eser e : manager.listele()) {
            model.addRow(new Object[]{
                e.getEserID(), e.getSanatciID(), e.getAd(), e.getTur(),
                e.getYil(), e.getFiyat(), e.getResimYolu()
            });
        }
    }

    private void temizle() {
        txtSanatciID.setText("");
        txtAd.setText("");
        txtTur.setText("");
        txtYil.setText("");
        txtFiyat.setText("");
        txtResimYolu.setText("");
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