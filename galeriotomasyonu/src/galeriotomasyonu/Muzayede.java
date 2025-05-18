package galeriotomasyonu;

public class Muzayede {
    private int muzayedeID;
    private int eserID;
    private String eserAdi;
    private String baslangicTarihi;
    private String bitisTarihi;
    private double minimumTeklif;

    // Tam parametreli constructor
    public Muzayede(int muzayedeID, int eserID, String eserAdi, String baslangicTarihi, String bitisTarihi, double minimumTeklif) {
        this.muzayedeID = muzayedeID;
        this.eserID = eserID;
        this.eserAdi = eserAdi;
        this.baslangicTarihi = baslangicTarihi;
        this.bitisTarihi = bitisTarihi;
        this.minimumTeklif = minimumTeklif;
    }

    // Boş constructor
    public Muzayede() {
    }

    // Getter metodları
    public int getMuzayedeID() {
        return muzayedeID;
    }

    public int getEserID() {
        return eserID;
    }

    public String getEserAdi() {
        return eserAdi;
    }

    public String getBaslangicTarihi() {
        return baslangicTarihi;
    }

    public String getBitisTarihi() {
        return bitisTarihi;
    }

    public double getMinimumTeklif() {
        return minimumTeklif;
    }

    // Setter metodları
    public void setMuzayedeID(int muzayedeID) {
        this.muzayedeID = muzayedeID;
    }

    public void setEserID(int eserID) {
        this.eserID = eserID;
    }

    public void setEserAdi(String eserAdi) {
        this.eserAdi = eserAdi;
    }

    public void setBaslangicTarihi(String baslangicTarihi) {
        this.baslangicTarihi = baslangicTarihi;
    }

    public void setBitisTarihi(String bitisTarihi) {
        this.bitisTarihi = bitisTarihi;
    }

    public void setMinimumTeklif(double minimumTeklif) {
        this.minimumTeklif = minimumTeklif;
    }

    // Opsiyonel: ComboBox ya da debug için
    @Override
    public String toString() {
        return "Müzayede #" + muzayedeID + " - Eser: " + eserAdi;
    }
}