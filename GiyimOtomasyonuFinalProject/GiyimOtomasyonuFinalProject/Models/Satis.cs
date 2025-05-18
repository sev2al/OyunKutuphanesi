using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GiyimOtomasyonuFinalProject.Models
{
    /// <summary>
    /// Satış bilgilerini tutan sınıf
    /// </summary>
    public class Satis
    {
        /// <summary>
        /// Satış ID
        /// </summary>
        public int SatisId { get; set; }
        
        /// <summary>
        /// Müşteri ID
        /// </summary>
        public int MusteriId { get; set; }
        
        /// <summary>
        /// Satış Tarihi
        /// </summary>
        public DateTime Tarih { get; set; }
        
        /// <summary>
        /// Toplam Tutar
        /// </summary>
        public decimal ToplamTutar { get; set; }
        
        /// <summary>
        /// Ödeme Türü
        /// </summary>
        public string OdemeTuru { get; set; }

        /// <summary>
        /// Kargo Durumu (veritabanında Durum sütunu olarak saklanır)
        /// </summary>
        public string KargoDurumu { get; set; } = "Hazırlanıyor";

        /// <summary>
        /// Puan eklenip eklenmediğini belirten özellik
        /// </summary>
        public bool PuanEklendi { get; set; }

        /// <summary>
        /// Satış detayları
        /// </summary>
        public List<SatisDetay> SatisDetaylari { get; set; }

        /// <summary>
        /// Müşteri bilgisi (lazy loading)
        /// </summary>
        private Musteri _musteri;
        public Musteri Musteri 
        { 
            get 
            {
                if (_musteri == null)
                    _musteri = Musteri.IdIleGetir(MusteriId);
                return _musteri;
            }
            set { _musteri = value; }
        }

        /// <summary>
        /// Veritabanından tüm satışları getir
        /// </summary>
        /// <returns>Satış listesi</returns>
        public static List<Satis> TumunuGetir()
        {
            List<Satis> satislar = new List<Satis>();
            
            try 
            {
                DataTable table = Database.ExecuteQuery(
                    "SELECT s.*, m.Ad, m.Soyad FROM Satis s " +
                    "LEFT JOIN Musteri m ON s.MusteriId = m.MusteriId " +
                    "ORDER BY s.Tarih DESC");
                
                foreach (DataRow row in table.Rows)
                {
                    Satis satis = new Satis
                    {
                        SatisId = Convert.ToInt32(row["SatisId"]),
                        MusteriId = Convert.ToInt32(row["MusteriId"]),
                        Tarih = Convert.ToDateTime(row["Tarih"]),
                        ToplamTutar = Convert.ToDecimal(row["ToplamTutar"]),
                        OdemeTuru = row["OdemeTuru"].ToString(),
                        // Durum sütununu kontrol et ve KargoDurumu alanına ata
                        KargoDurumu = row["Durum"] != DBNull.Value ? row["Durum"].ToString() : "Hazırlanıyor",
                        SatisDetaylari = new List<SatisDetay>()
                    };
                    
                    // Müşteri bilgisi
                    satis.Musteri = new Musteri
                    {
                        MusteriId = satis.MusteriId,
                        Ad = row["Ad"].ToString(),
                        Soyad = row["Soyad"].ToString()
                    };
                    
                    // Satış detaylarını getir
                    satis.SatisDetaylari = SatisDetay.SatisaGoreGetir(satis.SatisId);
                    
                    satislar.Add(satis);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                    $"Satışlar getirilirken hata oluştu: {ex.Message}",
                    "Veritabanı Hatası",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
            
            return satislar;
        }

        /// <summary>
        /// Müşterinin satışlarını getir
        /// </summary>
        /// <param name="musteriId">Müşteri ID</param>
        /// <returns>Satış listesi</returns>
        public static List<Satis> MusteriyeGoreGetir(int musteriId)
        {
            List<Satis> satislar = new List<Satis>();
            
            try
            {
                DataTable table = Database.ExecuteQuery(
                    "SELECT s.*, m.Ad, m.Soyad FROM Satis s " +
                    "LEFT JOIN Musteri m ON s.MusteriId = m.MusteriId " +
                    "WHERE s.MusteriId = @MusteriId " +
                    "ORDER BY s.Tarih DESC",
                    new SqlParameter("@MusteriId", musteriId));
                
                foreach (DataRow row in table.Rows)
                {
                    Satis satis = new Satis
                    {
                        SatisId = Convert.ToInt32(row["SatisId"]),
                        MusteriId = Convert.ToInt32(row["MusteriId"]),
                        Tarih = Convert.ToDateTime(row["Tarih"]),
                        ToplamTutar = Convert.ToDecimal(row["ToplamTutar"]),
                        OdemeTuru = row["OdemeTuru"].ToString(),
                        // Durum sütununu kontrol et ve KargoDurumu alanına ata
                        KargoDurumu = row["Durum"] != DBNull.Value ? row["Durum"].ToString() : "Hazırlanıyor",
                        SatisDetaylari = new List<SatisDetay>()
                    };
                    
                    // Müşteri bilgisi
                    satis.Musteri = new Musteri
                    {
                        MusteriId = satis.MusteriId,
                        Ad = row["Ad"].ToString(),
                        Soyad = row["Soyad"].ToString()
                    };
                    
                    // Satış detaylarını getir
                    satis.SatisDetaylari = SatisDetay.SatisaGoreGetir(satis.SatisId);
                    
                    satislar.Add(satis);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                    $"Müşterinin satışları getirilirken hata oluştu: {ex.Message}",
                    "Veritabanı Hatası",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
            
            return satislar;
        }

        /// <summary>
        /// ID'ye göre satışı getir
        /// </summary>
        /// <param name="satisId">Satış ID</param>
        /// <returns>Satış nesnesi veya null</returns>
        public static Satis IdIleGetir(int satisId)
        {
            try
            {
                DataTable table = Database.ExecuteQuery(
                    "SELECT s.*, m.Ad, m.Soyad FROM Satis s " +
                    "LEFT JOIN Musteri m ON s.MusteriId = m.MusteriId " +
                    "WHERE s.SatisId = @SatisId",
                    new SqlParameter("@SatisId", satisId));
                
                if (table.Rows.Count == 0)
                    return null;
                    
                DataRow row = table.Rows[0];
                
                Satis satis = new Satis
                {
                    SatisId = Convert.ToInt32(row["SatisId"]),
                    MusteriId = Convert.ToInt32(row["MusteriId"]),
                    Tarih = Convert.ToDateTime(row["Tarih"]),
                    ToplamTutar = Convert.ToDecimal(row["ToplamTutar"]),
                    OdemeTuru = row["OdemeTuru"].ToString(),
                    // Durum sütununu kontrol et ve KargoDurumu alanına ata
                    KargoDurumu = row["Durum"] != DBNull.Value ? row["Durum"].ToString() : "Hazırlanıyor",
                    SatisDetaylari = new List<SatisDetay>()
                };
                
                // Müşteri bilgisi
                satis.Musteri = new Musteri
                {
                    MusteriId = satis.MusteriId,
                    Ad = row["Ad"].ToString(),
                    Soyad = row["Soyad"].ToString()
                };
                
                // Satış detaylarını getir
                satis.SatisDetaylari = SatisDetay.SatisaGoreGetir(satis.SatisId);
                
                return satis;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                    $"Satış bilgisi getirilirken hata oluştu: {ex.Message}",
                    "Veritabanı Hatası",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Yeni satış ekle
        /// </summary>
        /// <returns>Başarılı ise eklenen satış ID'si, başarısız ise -1</returns>
        public int Ekle()
        {
            try
            {
                // Otomatik ID için son ID'yi alıp 1 artırıyoruz
                object sonId = Database.ExecuteScalar("SELECT MAX(SatisId) FROM Satis");
                int yeniId = sonId == DBNull.Value ? 1 : Convert.ToInt32(sonId) + 1;
                
                this.SatisId = yeniId;
                
                // KargoDurumu yerine Durum sütununa yazmak için SQL sorgusunu değiştirdik
                int sonuc = Database.ExecuteNonQuery(
                    "INSERT INTO Satis (SatisId, MusteriId, Tarih, ToplamTutar, OdemeTuru, Durum) " +
                    "VALUES (@SatisId, @MusteriId, @Tarih, @ToplamTutar, @OdemeTuru, @Durum)",
                    new SqlParameter("@SatisId", SatisId),
                    new SqlParameter("@MusteriId", MusteriId),
                    new SqlParameter("@Tarih", Tarih),
                    new SqlParameter("@ToplamTutar", ToplamTutar),
                    new SqlParameter("@OdemeTuru", OdemeTuru),
                    new SqlParameter("@Durum", KargoDurumu ?? "Hazırlanıyor"));
                    
                if (sonuc <= 0)
                    return -1;
                    
                // Satış detaylarını ekle
                if (SatisDetaylari != null)
                {
                    foreach (SatisDetay detay in SatisDetaylari)
                    {
                        detay.SatisId = this.SatisId;
                        int detaySonuc = detay.Ekle();
                        
                        if (detaySonuc <= 0)
                            return -1;
                    }
                }
                
                return SatisId;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                    $"Satış eklenirken hata oluştu: {ex.Message}",
                    "Veritabanı Hatası",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
                return -1;
            }
        }

        /// <summary>
        /// Sepeti satışa dönüştür
        /// </summary>
        /// <param name="sepet">Sepet</param>
        /// <param name="odemeTuru">Ödeme Türü</param>
        /// <returns>Oluşturulan satış nesnesi, başarısız ise null</returns>
        public static Satis SepettenSatisOlustur(Sepet sepet, string odemeTuru)
        {
            if (sepet == null || sepet.SepetDetaylari == null || sepet.SepetDetaylari.Count == 0)
                return null;
            
            // Satış nesnesi oluştur
            Satis satis = new Satis
            {
                MusteriId = sepet.MusteriId,
                Tarih = DateTime.Now,
                ToplamTutar = sepet.ToplamTutarHesapla(),
                OdemeTuru = odemeTuru,
                KargoDurumu = "Hazırlanıyor",
                SatisDetaylari = new List<SatisDetay>()
            };
            
            // Sepet detaylarını satış detaylarına dönüştür
            foreach (SepetDetay sepetDetay in sepet.SepetDetaylari)
            {
                Urun urun = Urun.IdIleGetir(sepetDetay.UrunId);
                if (urun == null)
                    continue;
                
                SatisDetay satisDetay = new SatisDetay
                {
                    UrunId = sepetDetay.UrunId,
                    Adet = sepetDetay.Adet,
                    BirimFiyat = urun.Fiyat
                };
                
                satis.SatisDetaylari.Add(satisDetay);
                
                // Stok güncelleme
                urun.StokGuncelle(-sepetDetay.Adet);
            }
            
            // Satışı veritabanına ekle
            int satisId = satis.Ekle();
            if (satisId <= 0)
                return null;
            
            // Satış başarılıysa sepeti temizle
            if (satisId > 0)
            {
                sepet.Sil();
            }
            
            return satis;
        }

        /// <summary>
        /// Satışı sil
        /// </summary>
        /// <returns>Başarılı ise true, değilse false</returns>
        public bool Sil()
        {
            // Önce satış detaylarını sil
            Database.ExecuteNonQuery(
                "DELETE FROM SatisDetay WHERE SatisId = @SatisId",
                new SqlParameter("@SatisId", SatisId));
                
            // Satışı sil
            int sonuc = Database.ExecuteNonQuery(
                "DELETE FROM Satis WHERE SatisId = @SatisId",
                new SqlParameter("@SatisId", SatisId));
                
            return sonuc > 0;
        }

        /// <summary>
        /// Kargo durumunu günceller
        /// </summary>
        /// <param name="satisId">Satış ID</param>
        /// <param name="durum">Yeni durum</param>
        /// <returns>Başarılı ise true, değilse false</returns>
        public static bool KargoDurumuGuncelle(int satisId, string durum)
        {
            try
            {
                // KargoDurumu yerine Durum sütununu güncelliyoruz
                int sonuc = Database.ExecuteNonQuery(
                    "UPDATE Satis SET Durum = @Durum WHERE SatisId = @SatisId",
                    new SqlParameter("@Durum", durum),
                    new SqlParameter("@SatisId", satisId));
                    
                return sonuc > 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                    $"Kargo durumu güncellenirken hata oluştu: {ex.Message}",
                    "Veritabanı Hatası",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Satışı günceller
        /// </summary>
        /// <returns>Başarılı ise true, değilse false</returns>
        public bool Guncelle()
        {
            try
            {
                string query = @"
                    UPDATE Satis 
                    SET Durum = @KargoDurumu,
                        PuanEklendi = @PuanEklendi
                    WHERE SatisId = @SatisId";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@SatisId", SatisId),
                    new SqlParameter("@KargoDurumu", KargoDurumu),
                    new SqlParameter("@PuanEklendi", PuanEklendi)
                };

                int result = Database.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                    $"Satış güncellenirken hata oluştu: {ex.Message}",
                    "Veritabanı Hatası",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }
    }
} 