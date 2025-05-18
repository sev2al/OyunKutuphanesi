
package galeriotomasyonu;


import galeriotomasyonu.Muzayede;
import galeriotomasyonu.MuzayedeDAO;
import javax.swing.*;
import javax.swing.table.DefaultTableModel;
import java.util.ArrayList;

public class MuzayedeListeForm extends JFrame {
    public MuzayedeListeForm() {
        setTitle("Açık Müzayedeler");
        setSize(700, 300);
        setLocationRelativeTo(null);

        ArrayList<Muzayede> muzayedeler = MuzayedeDAO.getMuzayedeler();
        String[] kolonlar = {"ID", "Eser Adı", "Başlangıç", "Bitiş", "Minimum Teklif"};
        DefaultTableModel model = new DefaultTableModel(kolonlar, 0);

        for (Muzayede m : muzayedeler) {
            model.addRow(new Object[]{
                    m.getMuzayedeID(), m.getEserAdi(), m.getBaslangicTarihi(),
                    m.getBitisTarihi(), m.getMinimumTeklif()
            });
        }

        JTable table = new JTable(model);
        JScrollPane scrollPane = new JScrollPane(table);
        add(scrollPane);
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