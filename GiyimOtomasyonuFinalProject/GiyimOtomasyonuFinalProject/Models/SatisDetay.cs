using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GiyimOtomasyonuFinalProject.Models
{
    /// <summary>
    /// Satış detaylarını tutan sınıf
    /// </summary>
    public class SatisDetay
    {
        /// <summary>
        /// Satış Detay ID
        /// </summary>
        public int SatisDetayId { get; set; }
        
        /// <summary>
        /// Satış ID
        /// </summary>
        public int SatisId { get; set; }
        
        /// <summary>
        /// Ürün ID
        /// </summary>
        public int UrunId { get; set; }
        
        /// <summary>
        /// Adet
        /// </summary>
        public int Adet { get; set; }
        
        /// <summary>
        /// Birim Fiyat
        /// </summary>
        public decimal BirimFiyat { get; set; }

        /// <summary>
        /// Ürün bilgisi (lazy loading)
        /// </summary>
        private Urun _urun;
        public Urun Urun 
        { 
            get 
            {
                if (_urun == null)
                    _urun = Urun.IdIleGetir(UrunId);
                return _urun;
            }
            set { _urun = value; }
        }

        /// <summary>
        /// Satır toplamını hesapla
        /// </summary>
        public decimal SatirToplam
        {
            get { return BirimFiyat * Adet; }
        }

        /// <summary>
        /// Satışa göre satış detaylarını getir
        /// </summary>
        /// <param name="satisId">Satış ID</param>
        /// <returns>SatisDetay listesi</returns>
        public static List<SatisDetay> SatisaGoreGetir(int satisId)
        {
            List<SatisDetay> detaylar = new List<SatisDetay>();
            
            try
            {
                // Daha fazla ürün bilgisi alacak şekilde sorguyu genişletelim
                DataTable table = Database.ExecuteQuery(
                    "SELECT sd.*, u.UrunAdi, u.StokMiktari, u.Fiyat, u.FotografYolu, k.KategoriAdi " +
                    "FROM SatisDetay sd " +
                    "LEFT JOIN Urun u ON sd.UrunId = u.UrunId " +
                    "LEFT JOIN Kategori k ON u.KategoriId = k.KategoriId " +
                    "WHERE sd.SatisId = @SatisId",
                    new SqlParameter("@SatisId", satisId));
                
                foreach (DataRow row in table.Rows)
                {
                    SatisDetay detay = new SatisDetay
                    {
                        SatisDetayId = Convert.ToInt32(row["SatisDetayId"]),
                        SatisId = Convert.ToInt32(row["SatisId"]),
                        UrunId = Convert.ToInt32(row["UrunId"]),
                        Adet = Convert.ToInt32(row["Adet"]),
                        BirimFiyat = Convert.ToDecimal(row["BirimFiyat"])
                    };
                    
                    // Ürün bilgisi daha detaylı dolduruluyor
                    detay.Urun = new Urun
                    {
                        UrunId = detay.UrunId,
                        UrunAdi = row["UrunAdi"].ToString(),
                        StokMiktari = row["StokMiktari"] != DBNull.Value ? Convert.ToInt32(row["StokMiktari"]) : 0,
                        Fiyat = row["Fiyat"] != DBNull.Value ? Convert.ToDecimal(row["Fiyat"]) : 0,
                        FotografYolu = row["FotografYolu"] != DBNull.Value ? row["FotografYolu"].ToString() : null
                    };
                    
                    detaylar.Add(detay);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Satış detayları getirilirken hata oluştu: {ex.Message}", "Veritabanı Hatası", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            return detaylar;
        }

        /// <summary>
        /// ID'ye göre satış detayını getir
        /// </summary>
        /// <param name="satisDetayId">Satış Detay ID</param>
        /// <returns>SatisDetay nesnesi veya null</returns>
        public static SatisDetay IdIleGetir(int satisDetayId)
        {
            DataTable table = Database.ExecuteQuery(
                "SELECT sd.*, u.UrunAdi FROM SatisDetay sd " +
                "LEFT JOIN Urun u ON sd.UrunId = u.UrunId " +
                "WHERE sd.SatisDetayId = @SatisDetayId",
                new SqlParameter("@SatisDetayId", satisDetayId));
            
            if (table.Rows.Count == 0)
                return null;
                
            DataRow row = table.Rows[0];
            
            SatisDetay detay = new SatisDetay
            {
                SatisDetayId = Convert.ToInt32(row["SatisDetayId"]),
                SatisId = Convert.ToInt32(row["SatisId"]),
                UrunId = Convert.ToInt32(row["UrunId"]),
                Adet = Convert.ToInt32(row["Adet"]),
                BirimFiyat = Convert.ToDecimal(row["BirimFiyat"])
            };
            
            // Ürün bilgisi
            detay.Urun = new Urun
            {
                UrunId = detay.UrunId,
                UrunAdi = row["UrunAdi"].ToString()
            };
            
            return detay;
        }

        /// <summary>
        /// Yeni satış detayı ekle
        /// </summary>
        /// <returns>Başarılı ise eklenen satış detay ID'si, başarısız ise -1</returns>
        public int Ekle()
        {
            // Otomatik ID için son ID'yi alıp 1 artırıyoruz
            object sonId = Database.ExecuteScalar("SELECT MAX(SatisDetayId) FROM SatisDetay");
            int yeniId = sonId == DBNull.Value ? 1 : Convert.ToInt32(sonId) + 1;
            
            this.SatisDetayId = yeniId;
            
            int sonuc = Database.ExecuteNonQuery(
                "INSERT INTO SatisDetay (SatisDetayId, SatisId, UrunId, Adet, BirimFiyat) " +
                "VALUES (@SatisDetayId, @SatisId, @UrunId, @Adet, @BirimFiyat)",
                new SqlParameter("@SatisDetayId", SatisDetayId),
                new SqlParameter("@SatisId", SatisId),
                new SqlParameter("@UrunId", UrunId),
                new SqlParameter("@Adet", Adet),
                new SqlParameter("@BirimFiyat", BirimFiyat));
                
            return sonuc > 0 ? SatisDetayId : -1;
        }

        /// <summary>
        /// Satış detayını güncelle
        /// </summary>
        /// <returns>Başarılı ise true, değilse false</returns>
        public bool Guncelle()
        {
            int sonuc = Database.ExecuteNonQuery(
                "UPDATE SatisDetay SET SatisId = @SatisId, UrunId = @UrunId, " +
                "Adet = @Adet, BirimFiyat = @BirimFiyat WHERE SatisDetayId = @SatisDetayId",
                new SqlParameter("@SatisDetayId", SatisDetayId),
                new SqlParameter("@SatisId", SatisId),
                new SqlParameter("@UrunId", UrunId),
                new SqlParameter("@Adet", Adet),
                new SqlParameter("@BirimFiyat", BirimFiyat));
                
            return sonuc > 0;
        }

        /// <summary>
        /// Satış detayını sil
        /// </summary>
        /// <returns>Başarılı ise true, değilse false</returns>
        public bool Sil()
        {
            int sonuc = Database.ExecuteNonQuery(
                "DELETE FROM SatisDetay WHERE SatisDetayId = @SatisDetayId",
                new SqlParameter("@SatisDetayId", SatisDetayId));
                
            return sonuc > 0;
        }

        /// <summary>
        /// Bir ürünün satışlarda kullanılıp kullanılmadığını kontrol eder
        /// </summary>
        /// <param name="urunId">Ürün ID</param>
        /// <returns>Kullanılıyorsa true, kullanılmıyorsa false</returns>
        public static bool UrunKullaniliyorMu(int urunId)
        {
            DataTable table = Database.ExecuteQuery(
                "SELECT COUNT(*) FROM SatisDetay WHERE UrunId = @UrunId",
                new SqlParameter("@UrunId", urunId));
            if (table.Rows.Count > 0 && Convert.ToInt32(table.Rows[0][0]) > 0)
                return true;
            return false;
        }
    }
} 