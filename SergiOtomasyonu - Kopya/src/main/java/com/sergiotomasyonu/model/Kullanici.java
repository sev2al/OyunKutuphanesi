package main.java.com.sergiotomasyonu.model;

import java.util.Date;

public class Kullanici {
    private int kullaniciId;
    private String kullaniciAdi;
    private String eposta;
    private String parolaHash;
    private Date kayitTarihi;
    
    // Constructors
    public Kullanici() {}
    
    public Kullanici(String kullaniciAdi, String eposta, String parolaHash) {
        this.kullaniciAdi = kullaniciAdi;
        this.eposta = eposta;
        this.parolaHash = parolaHash;
        this.kayitTarihi = new Date();
    }
    
    // Getters and Setters
    public int getKullaniciId() {
        return kullaniciId;
    }
    
    public void setKullaniciId(int kullaniciId) {
        this.kullaniciId = kullaniciId;
    }
    
    public String getKullaniciAdi() {
        return kullaniciAdi;
    }
    
    public void setKullaniciAdi(String kullaniciAdi) {
        this.kullaniciAdi = kullaniciAdi;
    }
    
    public String getEposta() {
        return eposta;
    }
    
    public void setEposta(String eposta) {
        this.eposta = eposta;
    }
    
    public String getParolaHash() {
        return parolaHash;
    }
    
    public void setParolaHash(String parolaHash) {
        this.parolaHash = parolaHash;
    }
    
    public Date getKayitTarihi() {
        return kayitTarihi;
    }
    
    public void setKayitTarihi(Date kayitTarihi) {
        this.kayitTarihi = kayitTarihi;
    }
} 