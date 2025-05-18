using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GiyimOtomasyonuFinalProject.Models
{
    /// <summary>
    /// Sepet detaylarını tutan sınıf
    /// </summary>
    public class SepetDetay
    {
        /// <summary>
        /// Sepet Detay ID
        /// </summary>
        public int SepetDetayId { get; set; }
        
        /// <summary>
        /// Sepet ID
        /// </summary>
        public int SepetId { get; set; }
        
        /// <summary>
        /// Ürün ID
        /// </summary>
        public int UrunId { get; set; }
        
        /// <summary>
        /// Adet
        /// </summary>
        public int Adet { get; set; }

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
        /// Sepete göre sepet detaylarını getir
        /// </summary>
        /// <param name="sepetId">Sepet ID</param>
        /// <returns>SepetDetay listesi</returns>
        public static List<SepetDetay> SepeteGoreGetir(int sepetId)
        {
            List<SepetDetay> detaylar = new List<SepetDetay>();
            
            DataTable table = Database.ExecuteQuery(
                "SELECT sd.*, u.UrunAdi, u.Fiyat FROM SepetDetay sd " +
                "LEFT JOIN Urun u ON sd.UrunId = u.UrunId " +
                "WHERE sd.SepetId = @SepetId",
                new SqlParameter("@SepetId", sepetId));
            
            foreach (DataRow row in table.Rows)
            {
                SepetDetay detay = new SepetDetay
                {
                    SepetDetayId = Convert.ToInt32(row["SepetDetayId"]),
                    SepetId = Convert.ToInt32(row["SepetId"]),
                    UrunId = Convert.ToInt32(row["UrunId"]),
                    Adet = Convert.ToInt32(row["Adet"])
                };
                
                // Ürün bilgisi
                detay.Urun = new Urun
                {
                    UrunId = detay.UrunId,
                    UrunAdi = row["UrunAdi"].ToString(),
                    Fiyat = Convert.ToDecimal(row["Fiyat"])
                };
                
                detaylar.Add(detay);
            }
            
            return detaylar;
        }

        /// <summary>
        /// ID'ye göre sepet detayını getir
        /// </summary>
        /// <param name="sepetDetayId">Sepet Detay ID</param>
        /// <returns>SepetDetay nesnesi veya null</returns>
        public static SepetDetay IdIleGetir(int sepetDetayId)
        {
            DataTable table = Database.ExecuteQuery(
                "SELECT sd.*, u.UrunAdi, u.Fiyat FROM SepetDetay sd " +
                "LEFT JOIN Urun u ON sd.UrunId = u.UrunId " +
                "WHERE sd.SepetDetayId = @SepetDetayId",
                new SqlParameter("@SepetDetayId", sepetDetayId));
            
            if (table.Rows.Count == 0)
                return null;
                
            DataRow row = table.Rows[0];
            
            SepetDetay detay = new SepetDetay
            {
                SepetDetayId = Convert.ToInt32(row["SepetDetayId"]),
                SepetId = Convert.ToInt32(row["SepetId"]),
                UrunId = Convert.ToInt32(row["UrunId"]),
                Adet = Convert.ToInt32(row["Adet"])
            };
            
            // Ürün bilgisi
            detay.Urun = new Urun
            {
                UrunId = detay.UrunId,
                UrunAdi = row["UrunAdi"].ToString(),
                Fiyat = Convert.ToDecimal(row["Fiyat"])
            };
            
            return detay;
        }

        /// <summary>
        /// Yeni sepet detayı ekle
        /// </summary>
        /// <returns>Başarılı ise eklenen sepet detay ID'si, başarısız ise -1</returns>
        public int Ekle()
        {
            // Otomatik ID için son ID'yi alıp 1 artırıyoruz
            object sonId = Database.ExecuteScalar("SELECT MAX(SepetDetayId) FROM SepetDetay");
            int yeniId = sonId == DBNull.Value ? 1 : Convert.ToInt32(sonId) + 1;
            
            this.SepetDetayId = yeniId;
            
            int sonuc = Database.ExecuteNonQuery(
                "INSERT INTO SepetDetay (SepetDetayId, SepetId, UrunId, Adet) " +
                "VALUES (@SepetDetayId, @SepetId, @UrunId, @Adet)",
                new SqlParameter("@SepetDetayId", SepetDetayId),
                new SqlParameter("@SepetId", SepetId),
                new SqlParameter("@UrunId", UrunId),
                new SqlParameter("@Adet", Adet));
                
            return sonuc > 0 ? SepetDetayId : -1;
        }

        /// <summary>
        /// Sepet detayını güncelle
        /// </summary>
        /// <returns>Başarılı ise true, değilse false</returns>
        public bool Guncelle()
        {
            int sonuc = Database.ExecuteNonQuery(
                "UPDATE SepetDetay SET SepetId = @SepetId, UrunId = @UrunId, Adet = @Adet " +
                "WHERE SepetDetayId = @SepetDetayId",
                new SqlParameter("@SepetDetayId", SepetDetayId),
                new SqlParameter("@SepetId", SepetId),
                new SqlParameter("@UrunId", UrunId),
                new SqlParameter("@Adet", Adet));
                
            return sonuc > 0;
        }

        /// <summary>
        /// Sepet detayını sil
        /// </summary>
        /// <returns>Başarılı ise true, değilse false</returns>
        public bool Sil()
        {
            int sonuc = Database.ExecuteNonQuery(
                "DELETE FROM SepetDetay WHERE SepetDetayId = @SepetDetayId",
                new SqlParameter("@SepetDetayId", SepetDetayId));
                
            return sonuc > 0;
        }

        /// <summary>
        /// Satır toplamını hesapla
        /// </summary>
        /// <returns>Satır toplam tutarı</returns>
        public decimal SatirToplamHesapla()
        {
            if (Urun != null)
            {
                return Urun.Fiyat * Adet;
            }
            
            // Ürün bilgisi yoksa 0 döndür
            return 0;
        }
    }
} 