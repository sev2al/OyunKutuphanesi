package galeriotomasyonu;

import galeriotomasyonu.TeklifDAO;
import javax.swing.*;
import javax.swing.table.DefaultTableModel;
import java.awt.*;
import java.util.ArrayList;

public class TeklifVerForm extends JFrame {
    private JTable table;
    private DefaultTableModel model;
    private JTextField txtTeklif;
    private JButton btnTeklifVer;
    private ArrayList<Muzayede> muzayedeler;
    private int musteriID;

    public TeklifVerForm(int musteriID) {
        this.musteriID = musteriID;

        setTitle("Teklif Ver");
        setSize(800, 400);
        setLocationRelativeTo(null);
        setDefaultCloseOperation(DISPOSE_ON_CLOSE);
        setLayout(new BorderLayout());

        // Tablo başlıkları
        String[] kolonlar = {"Müzayede ID", "Eser Adı", "Başlangıç", "Bitiş", "Minimum Teklif"};
        model = new DefaultTableModel(kolonlar, 0);
        table = new JTable(model);
        JScrollPane scrollPane = new JScrollPane(table);
        add(scrollPane, BorderLayout.CENTER);

        // Teklif alanı paneli
        JPanel teklifPanel = new JPanel();
        teklifPanel.add(new JLabel("Teklifiniz:"));
        txtTeklif = new JTextField(10);
        btnTeklifVer = new JButton("Teklif Ver");
        teklifPanel.add(txtTeklif);
        teklifPanel.add(btnTeklifVer);
        add(teklifPanel, BorderLayout.SOUTH);

        // Buton aksiyonu
        btnTeklifVer.addActionListener(e -> teklifVer());

        // Müzayedeleri yükle
        muzayedeleriYukle();
    }

    private void muzayedeleriYukle() {
        model.setRowCount(0);
        muzayedeler = MuzayedeDAO.getTeklifVerilebilirler(musteriID);

        for (Muzayede m : muzayedeler) {
            String eserAdi = EserDAO.getEserByID(m.getEserID()).getAd();
            model.addRow(new Object[]{
                    m.getMuzayedeID(),
                    eserAdi,
                    m.getBaslangicTarihi(),
                    m.getBitisTarihi(),
                    m.getMinimumTeklif()
            });
        }
    }

    private void teklifVer() {
        int secili = table.getSelectedRow();
        if (secili < 0) {
            JOptionPane.showMessageDialog(this, "Lütfen bir müzayede seçin!");
            return;
        }

        try {
            double teklif = Double.parseDouble(txtTeklif.getText());
            double minimum = (double) model.getValueAt(secili, 4);

            if (teklif < minimum) {
                JOptionPane.showMessageDialog(this, "Teklif minimum tekliften düşük olamaz!");
                return;
            }

            int muzayedeID = (int) model.getValueAt(secili, 0);

            boolean kayit = TeklifDAO.teklifKaydet(musteriID, muzayedeID, teklif);

            if (kayit) {
                JOptionPane.showMessageDialog(this, "Teklifiniz alınmıştır.");
                txtTeklif.setText("");
            } else {
                JOptionPane.showMessageDialog(this, "Teklif kaydedilemedi.");
            }

        } catch (NumberFormatException ex) {
            JOptionPane.showMessageDialog(this, "Lütfen geçerli bir sayı girin!");
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