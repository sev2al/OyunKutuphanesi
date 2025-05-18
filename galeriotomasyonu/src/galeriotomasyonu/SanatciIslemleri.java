/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package galeriotomasyonu;

import java.util.ArrayList;

public interface SanatciIslemleri {
    void ekle(Sanatci s);
    ArrayList<Sanatci> listele();
    Sanatci ara(int id);
    void guncelle(Sanatci s);
    void sil(int id);
}
