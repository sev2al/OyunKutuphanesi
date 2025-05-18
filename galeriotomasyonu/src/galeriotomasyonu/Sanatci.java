/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package galeriotomasyonu;

public class Sanatci {
    private int sanatciID;
    private String ad;
    private String soyad;
    private String ulke;
    private String dogumTarihi;
    private String biyografi;

    // Constructor
    public Sanatci(int sanatciID, String ad, String soyad, String ulke, String dogumTarihi, String biyografi) {
        this.sanatciID = sanatciID;
        this.ad = ad;
        this.soyad = soyad;
        this.ulke = ulke;
        this.dogumTarihi = dogumTarihi;
        this.biyografi = biyografi;
    }

    // Getter metotlar (encapsulation gereği)
    public int getSanatciID() {
        return sanatciID;
    }

    public String getAd() {
        return ad;
    }

    public String getSoyad() {
        return soyad;
    }

    public String getUlke() {
        return ulke;
    }

    public String getDogumTarihi() {
        return dogumTarihi;
    }

    public String getBiyografi() {
        return biyografi;
    }
}

