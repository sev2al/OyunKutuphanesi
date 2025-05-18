package galeriotomasyonu;

public class Teklif {
    private int teklifID;
    private String musteriAdSoyad;
    private String eserAdi;
    private double teklifTutari;
    private String teklifTarihi;
    private String durum;

    public Teklif(int teklifID, String musteriAdSoyad, String eserAdi, double teklifTutari, String teklifTarihi, String durum) {
        this.teklifID = teklifID;
        this.musteriAdSoyad = musteriAdSoyad;
        this.eserAdi = eserAdi;
        this.teklifTutari = teklifTutari;
        this.teklifTarihi = teklifTarihi;
        this.durum = durum;
    }
    
    

    public int getTeklifID() {
        return teklifID;
    }

    public String getMusteriAdSoyad() {
        return musteriAdSoyad;
    }

    public String getEserAdi() {
        return eserAdi;
    }

    public double getTeklifTutari() {
        return teklifTutari;
    }

    public String getTeklifTarihi() {
        return teklifTarihi;
    }

    public String getDurum() {
        return durum;
    }
}
