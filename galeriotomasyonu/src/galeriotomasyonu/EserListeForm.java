package galeriotomasyonu;

import javax.swing.*;
import java.awt.*;
import java.util.ArrayList;

public class EserListeForm extends JFrame {
    private EserManager manager = new EserManager();

    public EserListeForm() {
        setTitle("Eser Galerisi");
        setSize(900, 600);
        setLocationRelativeTo(null);
        setDefaultCloseOperation(DISPOSE_ON_CLOSE);
        setLayout(new BorderLayout());

        JPanel galeriPanel = new JPanel(new GridLayout(0, 3, 15, 15));
        galeriPanel.setBorder(BorderFactory.createEmptyBorder(10, 10, 10, 10));

        JScrollPane scrollPane = new JScrollPane(galeriPanel);
        scrollPane.getVerticalScrollBar().setUnitIncrement(16);
        add(scrollPane, BorderLayout.CENTER);

        ArrayList<Eser> eserler = manager.listele();
        JOptionPane.showMessageDialog(null, "Eser sayısı: " + eserler.size()); // 💡 test

        for (Eser e : eserler) {
            JPanel kart = new JPanel(new BorderLayout());
            kart.setBorder(BorderFactory.createLineBorder(Color.GRAY));
            kart.setBackground(Color.WHITE);

            JLabel lblResim;
            if (e.getResimYolu() != null && !e.getResimYolu().isEmpty()) {
                ImageIcon icon = new ImageIcon(e.getResimYolu());
                Image scaled = icon.getImage().getScaledInstance(250, 200, Image.SCALE_SMOOTH);
                lblResim = new JLabel(new ImageIcon(scaled));
            } else {
                lblResim = new JLabel("Resim yok", SwingConstants.CENTER);
            }
            kart.add(lblResim, BorderLayout.NORTH);

            JTextArea info = new JTextArea(
                "Ad: " + e.getAd() + "\n" +
                "Tür: " + e.getTur() + "\n" +
                "Fiyat: " + e.getFiyat() + " TL"
            );
            info.setEditable(false);
            info.setBackground(Color.WHITE);
            kart.add(info, BorderLayout.CENTER);

            galeriPanel.add(kart);
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
