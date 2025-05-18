package galeriotomasyonu;

import javax.swing.*;
import javax.swing.table.DefaultTableModel;
import java.util.ArrayList;

public class SanatciListeForm extends JFrame {
    public SanatciListeForm() {
        setTitle("Sanatçılar");
        setSize(600, 300);
        setLocationRelativeTo(null);
        setDefaultCloseOperation(DISPOSE_ON_CLOSE); // ❗️ekle

        ArrayList<Sanatci> sanatcilar = SanatciDAO.getSanatcilar();
        String[] kolonlar = {"ID", "Ad", "Soyad", "Ülke", "Doğum Tarihi", "Biyografi"};
        DefaultTableModel model = new DefaultTableModel(kolonlar, 0);

        for (Sanatci s : sanatcilar) {
            model.addRow(new Object[]{
                    s.getSanatciID(), s.getAd(), s.getSoyad(), s.getUlke(),
                    s.getDogumTarihi(), s.getBiyografi()
            });
        }

        JTable table = new JTable(model);
        JScrollPane scrollPane = new JScrollPane(table);
        add(scrollPane);

        pack(); // ❗️ekle - tablonun kendini boyutlamasını sağlar

        JOptionPane.showMessageDialog(null, "Sanatçı formu açıldı, " + sanatcilar.size() + " kayıt bulundu.");
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
