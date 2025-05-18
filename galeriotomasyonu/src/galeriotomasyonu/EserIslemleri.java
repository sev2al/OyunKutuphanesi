/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package galeriotomasyonu;

import java.util.ArrayList;

public interface EserIslemleri {
    void ekle(Eser e);
    ArrayList<Eser> listele();
    Eser ara(int id);
    void guncelle(Eser e);
    void sil(int id);
}

