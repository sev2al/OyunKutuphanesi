package galeriotomasyonu;

import javax.swing.*;
import javax.swing.table.DefaultTableModel;
import java.util.ArrayList;

public class SatinAlinanlarForm extends JFrame {
    public SatinAlinanlarForm(int musteriID) {
        setTitle("Satın Alınan Eserlerim");
        setSize(600, 300);
        setDefaultCloseOperation(DISPOSE_ON_CLOSE); // ✔️
        setLocationRelativeTo(null); // ortala

     
ArrayList<SatinAlma> liste = SatisDAO.getSatinAlinanlar(musteriID);

System.out.println("Satın alınan kayıt sayısı: " + liste.size());
for (SatinAlma s : liste) {
    System.out.println(s.getEserAdi() + " - " + s.getTarih());
}

String[] kolonlar = {"Eser Adı", "Satın Alma Tarihi", "Fiyat"};
DefaultTableModel model = new DefaultTableModel(kolonlar, 0);

for (SatinAlma s : liste) {
    model.addRow(new Object[]{
        s.getEserAdi(),
        s.getTarih(),
        s.getFiyat()
    });
}

JTable table = new JTable(model);
JScrollPane scrollPane = new JScrollPane(table);
add(scrollPane);
        
        
        
        JOptionPane.showMessageDialog(null, "Satın alınan eser sayısı: " + liste.size());
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
