using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GiyimOtomasyonuFinalProject.Models
{
    /// <summary>
    /// Ürün bilgilerini tutan sınıf
    /// </summary>
    public class Urun
    {
        /// <summary>
        /// Ürün ID
        /// </summary>
        public int UrunId { get; set; }
        
        /// <summary>
        /// Kategori ID
        /// </summary>
        public int KategoriId { get; set; }
        
        /// <summary>
        /// Ürün Adı
        /// </summary>
        public string UrunAdi { get; set; }
        
        /// <summary>
        /// Stok Miktarı
        /// </summary>
        public int StokMiktari { get; set; }
        
        /// <summary>
        /// Ürün Fiyatı
        /// </summary>
        public decimal Fiyat { get; set; }

        /// <summary>
/// Ürün fotoğraf yolu
/// </summary>
public string FotografYolu { get; set; }

        /// <summary>
        /// Ürünün kategorisi (lazy loading)
        /// </summary>
        private Kategori _kategori;
        public Kategori Kategori 
        { 
            get 
            {
                if (_kategori == null)
                    _kategori = Kategori.IdIleGetir(KategoriId);
                return _kategori;
            }
            set { _kategori = value; }
        }

        /// <summary>
        /// Veritabanından tüm ürünleri getir
        /// </summary>
        /// <returns>Ürün listesi</returns>
        public static List<Urun> TumunuGetir()
        {
            List<Urun> urunler = new List<Urun>();
            
            DataTable table = Database.ExecuteQuery(
                "SELECT u.*, k.KategoriAdi FROM Urun u " +
                "LEFT JOIN Kategori k ON u.KategoriId = k.KategoriId");
            
            foreach (DataRow row in table.Rows)
            {
                Urun urun = new Urun
                {
                    UrunId = Convert.ToInt32(row["UrunId"]),
                    KategoriId = Convert.ToInt32(row["KategoriId"]),
                    UrunAdi = row["UrunAdi"].ToString(),
                    StokMiktari = Convert.ToInt32(row["StokMiktari"]),
                    Fiyat = Convert.ToDecimal(row["Fiyat"]),
                    FotografYolu = row["FotografYolu"] != DBNull.Value ? row["FotografYolu"].ToString() : null
                };
                
                // Kategori bilgisi
                urun.Kategori = new Kategori
                {
                    KategoriId = urun.KategoriId,
                    KategoriAdi = row["KategoriAdi"].ToString()
                };
                
                urunler.Add(urun);
            }
            
            return urunler;
        }

        /// <summary>
        /// Kategoriye göre ürünleri getir
        /// </summary>
        /// <param name="kategoriId">Kategori ID</param>
        /// <returns>Ürün listesi</returns>
        public static List<Urun> KategoriyeGoreGetir(int kategoriId)
        {
            List<Urun> urunler = new List<Urun>();
            
            DataTable table = Database.ExecuteQuery(
                "SELECT u.*, k.KategoriAdi FROM Urun u " +
                "LEFT JOIN Kategori k ON u.KategoriId = k.KategoriId " +
                "WHERE u.KategoriId = @KategoriId",
                new SqlParameter("@KategoriId", kategoriId));
            
            foreach (DataRow row in table.Rows)
            {
                Urun urun = new Urun
                {
                    UrunId = Convert.ToInt32(row["UrunId"]),
                    KategoriId = Convert.ToInt32(row["KategoriId"]),
                    UrunAdi = row["UrunAdi"].ToString(),
                    StokMiktari = Convert.ToInt32(row["StokMiktari"]),
                    Fiyat = Convert.ToDecimal(row["Fiyat"]),
                    FotografYolu = row["FotografYolu"] != DBNull.Value ? row["FotografYolu"].ToString() : null
                };
                
                // Kategori bilgisi
                urun.Kategori = new Kategori
                {
                    KategoriId = urun.KategoriId,
                    KategoriAdi = row["KategoriAdi"].ToString()
                };
                
                urunler.Add(urun);
            }
            
            return urunler;
        }

        /// <summary>
        /// ID'ye göre ürünü getir
        /// </summary>
        /// <param name="urunId">Ürün ID</param>
        /// <returns>Ürün nesnesi veya null</returns>
        public static Urun IdIleGetir(int urunId)
        {
            DataTable table = Database.ExecuteQuery(
                "SELECT u.*, k.KategoriAdi FROM Urun u " +
                "LEFT JOIN Kategori k ON u.KategoriId = k.KategoriId " +
                "WHERE u.UrunId = @UrunId",
                new SqlParameter("@UrunId", urunId));
            
            if (table.Rows.Count == 0)
                return null;
                
            DataRow row = table.Rows[0];
            
            Urun urun = new Urun
            {
                UrunId = Convert.ToInt32(row["UrunId"]),
                KategoriId = Convert.ToInt32(row["KategoriId"]),
                UrunAdi = row["UrunAdi"].ToString(),
                StokMiktari = Convert.ToInt32(row["StokMiktari"]),
                Fiyat = Convert.ToDecimal(row["Fiyat"]),
                FotografYolu = row["FotografYolu"] != DBNull.Value ? row["FotografYolu"].ToString() : null
            };
            
            // Kategori bilgisi
            urun.Kategori = new Kategori
            {
                KategoriId = urun.KategoriId,
                KategoriAdi = row["KategoriAdi"].ToString()
            };
            
            return urun;
        }

        /// <summary>
        /// Ürün adına göre arama yap
        /// </summary>
        /// <param name="aramaMetni">Arama metni</param>
        /// <returns>Ürün listesi</returns>
        public static List<Urun> Ara(string aramaMetni)
        {
            List<Urun> urunler = new List<Urun>();
            
            DataTable table = Database.ExecuteQuery(
                "SELECT u.*, k.KategoriAdi FROM Urun u " +
                "LEFT JOIN Kategori k ON u.KategoriId = k.KategoriId " +
                "WHERE u.UrunAdi LIKE @AramaMetni",
                new SqlParameter("@AramaMetni", "%" + aramaMetni + "%"));
            
            foreach (DataRow row in table.Rows)
            {
                Urun urun = new Urun
                {
                    UrunId = Convert.ToInt32(row["UrunId"]),
                    KategoriId = Convert.ToInt32(row["KategoriId"]),
                    UrunAdi = row["UrunAdi"].ToString(),
                    StokMiktari = Convert.ToInt32(row["StokMiktari"]),
                    Fiyat = Convert.ToDecimal(row["Fiyat"]),
                    FotografYolu = row["FotografYolu"] != DBNull.Value ? row["FotografYolu"].ToString() : null
                };
                
                // Kategori bilgisi
                urun.Kategori = new Kategori
                {
                    KategoriId = urun.KategoriId,
                    KategoriAdi = row["KategoriAdi"].ToString()
                };
                
                urunler.Add(urun);
            }
            
            return urunler;
        }

        /// <summary>
        /// Yeni ürün ekle
        /// </summary>
        /// <returns>Başarılı ise eklenen ürün ID'si, başarısız ise -1</returns>
        public int Ekle()
        {
            // Otomatik ID için son ID'yi alıp 1 artırıyoruz
            object sonId = Database.ExecuteScalar("SELECT MAX(UrunId) FROM Urun");
            int yeniId = sonId == DBNull.Value ? 1 : Convert.ToInt32(sonId) + 1;
            
            this.UrunId = yeniId;
            
            int sonuc = Database.ExecuteNonQuery(
                "INSERT INTO Urun (UrunId, KategoriId, UrunAdi, StokMiktari, Fiyat, FotografYolu) " +
                "VALUES (@UrunId, @KategoriId, @UrunAdi, @StokMiktari, @Fiyat, @FotografYolu)",
                new SqlParameter("@UrunId", UrunId),
                new SqlParameter("@KategoriId", KategoriId),
                new SqlParameter("@UrunAdi", UrunAdi),
                new SqlParameter("@StokMiktari", StokMiktari),
                new SqlParameter("@Fiyat", Fiyat),
                new SqlParameter("@FotografYolu", (object)FotografYolu ?? DBNull.Value));
                
            return sonuc > 0 ? UrunId : -1;
        }

        /// <summary>
        /// Ürün bilgilerini güncelle
        /// </summary>
        /// <returns>Başarılı ise true, değilse false</returns>
        public bool Guncelle()
        {
            int sonuc = Database.ExecuteNonQuery(
                "UPDATE Urun SET KategoriId = @KategoriId, UrunAdi = @UrunAdi, " +
                "StokMiktari = @StokMiktari, Fiyat = @Fiyat, FotografYolu = @FotografYolu " +
                "WHERE UrunId = @UrunId",
                new SqlParameter("@UrunId", UrunId),
                new SqlParameter("@KategoriId", KategoriId),
                new SqlParameter("@UrunAdi", UrunAdi),
                new SqlParameter("@StokMiktari", StokMiktari),
                new SqlParameter("@Fiyat", Fiyat),
                new SqlParameter("@FotografYolu", (object)FotografYolu ?? DBNull.Value));
                
            return sonuc > 0;
        }

        /// <summary>
        /// Ürünü sil
        /// </summary>
        /// <returns>Başarılı ise true, değilse false</returns>
        public bool Sil()
        {
            int sonuc = Database.ExecuteNonQuery(
                "DELETE FROM Urun WHERE UrunId = @UrunId",
                new SqlParameter("@UrunId", UrunId));
                
            return sonuc > 0;
        }

        /// <summary>
        /// Stok miktarını güncelle (artır/azalt)
        /// </summary>
        /// <param name="miktar">Değişim miktarı (artış için pozitif, azalış için negatif)</param>
        /// <returns>Başarılı ise true, değilse false</returns>
        public bool StokGuncelle(int miktar)
        {
            int yeniStok = StokMiktari + miktar;
            if (yeniStok < 0)
                return false;
                
            StokMiktari = yeniStok;
            return Guncelle();
        }
    }
} 