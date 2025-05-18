package galeriotomasyonu;

public class Kullanici {
    private int kullaniciID;
    private String ad, soyad, email, sifre, rol;
    
public Kullanici() {
    
}

    public Kullanici(int kullaniciID, String ad, String soyad, String email, String sifre, String rol) {
        this.kullaniciID = kullaniciID;
        this.ad = ad;
        this.soyad = soyad;
        this.email = email;
        this.sifre = sifre;
        this.rol = rol;
    }

    public int getId() {
        return kullaniciID;
    }

    public String getAd() {
        return ad;
    }

    public String getSoyad() {
        return soyad;
    }

    public String getEmail() {
        return email;
    }

    public String getSifre() {
        return sifre;
    }

    public String getRol() {
        return rol;
    }

public void setId(int id) {
    this.kullaniciID = id;
}

public void setAd(String ad) {
    this.ad = ad;
}
 
public void setSoyad(String soyad) {
    this.soyad = soyad;
}

public void setSifre(String sifre) {
    this.sifre = sifre;
}


}



