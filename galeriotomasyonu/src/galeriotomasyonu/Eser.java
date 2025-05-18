package galeriotomasyonu;
public class Eser {
    private int eserID;
    private String ad;
    private String tur;
    private int sanatciID;
    private double fiyat;
    private String resimYolu;
    private int yil;
    // Boş constructor
    public Eser() {
    }
    // Parametreli constructor
    public Eser(int eserID, String ad, String tur, int sanatciID, double fiyat, String resimYolu, int yil) {
    this.eserID = eserID;
    this.ad = ad;
    this.tur = tur;
    this.sanatciID = sanatciID;
    this.fiyat = fiyat;
    this.resimYolu = resimYolu;
    this.yil = yil;
}
    
    // Getter ve Setter'lar
    public int getEserID() {
        return eserID;
    }
    public void setEserID(int eserID) {
        this.eserID = eserID;
    }
    public String getAd() {
        return ad;
    }
    public void setAd(String ad) {
        this.ad = ad;
    }
    public String getTur() {
        return tur;
    }
    public void setTur(String tur) {
        this.tur = tur;
    }
    public int getSanatciID() {
        return sanatciID;
    }
    public void setSanatciID(int sanatciID) {
        this.sanatciID = sanatciID;
    }
    public double getFiyat() {
        return fiyat;
    }
    public void setFiyat(double fiyat) {
        this.fiyat = fiyat;
    }
    public String getResimYolu() {
        return resimYolu;
    }
    public void setResimYolu(String resimYolu) {
        this.resimYolu = resimYolu;
    }
    // ComboBox'ta eser adı gösterilsin diye:
    @Override
public String toString() {
    return eserID + " - " + ad;
}
    
public int getYil() {
    return yil;
}
public void setYil(int yil) {
    this.yil = yil;
}
}