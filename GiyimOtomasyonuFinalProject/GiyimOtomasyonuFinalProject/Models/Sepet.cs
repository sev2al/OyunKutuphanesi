using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GiyimOtomasyonuFinalProject.Models
{
    /// <summary>
    /// Sepet bilgilerini tutan sınıf
    /// </summary>
    public class Sepet
    {
        /// <summary>
        /// Sepet ID
        /// </summary>
        public int SepetId { get; set; }
        
        /// <summary>
        /// Müşteri ID
        /// </summary>
        public int MusteriId { get; set; }
        
        /// <summary>
        /// Oluşturma Tarihi
        /// </summary>
        public DateTime OlusturmaTarihi { get; set; }

        /// <summary>
        /// Sepet Detayları
        /// </summary>
        public List<SepetDetay> SepetDetaylari { get; set; }

        /// <summary>
        /// Müşterinin sepetini getir
        /// </summary>
        /// <param name="musteriId">Müşteri ID</param>
        /// <returns>Sepet nesnesi veya null</returns>
        public static Sepet MusterininSepetiniGetir(int musteriId)
        {
            DataTable table = Database.ExecuteQuery(
                "SELECT * FROM Sepet WHERE MusteriId = @MusteriId",
                new SqlParameter("@MusteriId", musteriId));
            
            if (table.Rows.Count == 0)
                return null;
                
            DataRow row = table.Rows[0];
            
            Sepet sepet = new Sepet
            {
                SepetId = Convert.ToInt32(row["SepetId"]),
                MusteriId = Convert.ToInt32(row["MusteriId"]),
                OlusturmaTarihi = Convert.ToDateTime(row["OlusturmaTarihi"]),
                SepetDetaylari = new List<SepetDetay>()
            };
            
            // Sepet detaylarını getir
            sepet.SepetDetaylari = SepetDetay.SepeteGoreGetir(sepet.SepetId);
            
            return sepet;
        }

        /// <summary>
        /// ID'ye göre sepeti getir
        /// </summary>
        /// <param name="sepetId">Sepet ID</param>
        /// <returns>Sepet nesnesi veya null</returns>
        public static Sepet IdIleGetir(int sepetId)
        {
            DataTable table = Database.ExecuteQuery(
                "SELECT * FROM Sepet WHERE SepetId = @SepetId",
                new SqlParameter("@SepetId", sepetId));
            
            if (table.Rows.Count == 0)
                return null;
                
            DataRow row = table.Rows[0];
            
            Sepet sepet = new Sepet
            {
                SepetId = Convert.ToInt32(row["SepetId"]),
                MusteriId = Convert.ToInt32(row["MusteriId"]),
                OlusturmaTarihi = Convert.ToDateTime(row["OlusturmaTarihi"]),
                SepetDetaylari = new List<SepetDetay>()
            };
            
            // Sepet detaylarını getir
            sepet.SepetDetaylari = SepetDetay.SepeteGoreGetir(sepet.SepetId);
            
            return sepet;
        }

        /// <summary>
        /// Yeni sepet oluştur
        /// </summary>
        /// <returns>Başarılı ise eklenen sepet ID'si, başarısız ise -1</returns>
        public int Olustur()
        {
            // Otomatik ID için son ID'yi alıp 1 artırıyoruz
            object sonId = Database.ExecuteScalar("SELECT MAX(SepetId) FROM Sepet");
            int yeniId = sonId == DBNull.Value ? 1 : Convert.ToInt32(sonId) + 1;
            
            this.SepetId = yeniId;
            this.OlusturmaTarihi = DateTime.Now;
            
            int sonuc = Database.ExecuteNonQuery(
                "INSERT INTO Sepet (SepetId, MusteriId, OlusturmaTarihi) " +
                "VALUES (@SepetId, @MusteriId, @OlusturmaTarihi)",
                new SqlParameter("@SepetId", SepetId),
                new SqlParameter("@MusteriId", MusteriId),
                new SqlParameter("@OlusturmaTarihi", OlusturmaTarihi));
                
            return sonuc > 0 ? SepetId : -1;
        }

        /// <summary>
        /// Sepeti sil
        /// </summary>
        /// <returns>Başarılı ise true, değilse false</returns>
        public bool Sil()
        {
            // Önce sepet detaylarını sil
            Database.ExecuteNonQuery(
                "DELETE FROM SepetDetay WHERE SepetId = @SepetId",
                new SqlParameter("@SepetId", SepetId));
                
            // Sepeti sil
            int sonuc = Database.ExecuteNonQuery(
                "DELETE FROM Sepet WHERE SepetId = @SepetId",
                new SqlParameter("@SepetId", SepetId));
                
            return sonuc > 0;
        }

        /// <summary>
        /// Sepete ürün ekle
        /// </summary>
        /// <param name="urunId">Ürün ID</param>
        /// <param name="adet">Adet</param>
        /// <returns>Başarılı ise true, değilse false</returns>
        public bool UrunEkle(int urunId, int adet)
        {
            if (adet <= 0)
                return false;
            
            // Ürünü getir
            Urun urun = Urun.IdIleGetir(urunId);
            if (urun == null)
                return false;
            
            // Sepette aynı ürün var mı kontrol et
            SepetDetay mevcutDetay = SepetDetaylari.Find(d => d.UrunId == urunId);
            
            // Toplam talep edilecek adet
            int toplamAdet = adet;
            if (mevcutDetay != null)
            {
                toplamAdet += mevcutDetay.Adet;
            }
            
            // Stok kontrolü
            if (urun.StokMiktari < toplamAdet)
                return false;
            
            if (mevcutDetay != null)
            {
                // Varsa adeti güncelle
                mevcutDetay.Adet = toplamAdet;
                return mevcutDetay.Guncelle();
            }
            else
            {
                // Yoksa yeni ekle
                SepetDetay yeniDetay = new SepetDetay
                {
                    SepetId = this.SepetId,
                    UrunId = urunId,
                    Adet = adet
                };
                
                int eklenenId = yeniDetay.Ekle();
                
                if (eklenenId > 0)
                {
                    // Başarılı eklendiyse listeye ekle
                    SepetDetaylari.Add(yeniDetay);
                    return true;
                }
                
                return false;
            }
        }

        /// <summary>
        /// Sepete ürün ekle (Urun nesnesi ile)
        /// </summary>
        /// <param name="urun">Ürün nesnesi</param>
        /// <param name="adet">Adet</param>
        /// <returns>Başarılı ise true, değilse false</returns>
        public bool UrunEkle(Urun urun, int adet)
        {
            if (urun == null || adet <= 0)
                return false;
            
            return UrunEkle(urun.UrunId, adet);
        }

        /// <summary>
        /// Sepetten ürün çıkar
        /// </summary>
        /// <param name="urunId">Ürün ID</param>
        /// <returns>Başarılı ise true, değilse false</returns>
        public bool UrunCikar(int urunId)
        {
            SepetDetay silinecekDetay = SepetDetaylari.Find(d => d.UrunId == urunId);
            
            if (silinecekDetay == null)
                return false;
            
            bool sonuc = silinecekDetay.Sil();
            
            if (sonuc)
            {
                SepetDetaylari.Remove(silinecekDetay);
            }
            
            return sonuc;
        }

        /// <summary>
        /// Sepetteki ürün adetini güncelle
        /// </summary>
        /// <param name="urunId">Ürün ID</param>
        /// <param name="yeniAdet">Yeni adet</param>
        /// <returns>Başarılı ise true, değilse false</returns>
        public bool UrunAdetGuncelle(int urunId, int yeniAdet)
        {
            if (yeniAdet <= 0)
                return UrunCikar(urunId);
            
            SepetDetay guncellenecekDetay = SepetDetaylari.Find(d => d.UrunId == urunId);
            
            if (guncellenecekDetay == null)
                return false;
            
            // Ürünün stokta olup olmadığını kontrol et
            Urun urun = Urun.IdIleGetir(urunId);
            if (urun == null || urun.StokMiktari < yeniAdet)
                return false;
            
            guncellenecekDetay.Adet = yeniAdet;
            return guncellenecekDetay.Guncelle();
        }

        /// <summary>
        /// Sepet toplamını hesapla
        /// </summary>
        /// <returns>Sepet toplam tutarı</returns>
        public decimal ToplamTutarHesapla()
        {
            decimal toplam = 0;
            
            foreach (SepetDetay detay in SepetDetaylari)
            {
                Urun urun = Urun.IdIleGetir(detay.UrunId);
                if (urun != null)
                {
                    toplam += urun.Fiyat * detay.Adet;
                }
            }
            
            return toplam;
        }
    }
} 