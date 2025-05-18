package galeriotomasyonu;

public class SatinAlma {
    private String eserAdi;
    private String tarih;
    private double fiyat;

    public SatinAlma(String eserAdi, String tarih, double fiyat) {
        this.eserAdi = eserAdi;
        this.tarih = tarih;
        this.fiyat = fiyat;
    }

    public String getEserAdi() {
        return eserAdi;
    }

    public String getTarih() {
        return tarih;
    }

    public double getFiyat() {
        return fiyat;
    }
}