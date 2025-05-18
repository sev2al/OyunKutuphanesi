using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GiyimOtomasyonuFinalProject.Models
{
    /// <summary>
    /// Ürün kategorilerini tutan sınıf
    /// </summary>
    public class Kategori
    {
        /// <summary>
        /// Kategori ID
        /// </summary>
        public int KategoriId { get; set; }
        
        /// <summary>
        /// Kategori Adı
        /// </summary>
        public string KategoriAdi { get; set; }

        /// <summary>
        /// Veritabanından tüm kategorileri getir
        /// </summary>
        /// <returns>Kategori listesi</returns>
        public static List<Kategori> TumunuGetir()
        {
            List<Kategori> kategoriler = new List<Kategori>();
            
            DataTable table = Database.ExecuteQuery("SELECT * FROM Kategori");
            
            foreach (DataRow row in table.Rows)
            {
                kategoriler.Add(new Kategori
                {
                    KategoriId = Convert.ToInt32(row["KategoriId"]),
                    KategoriAdi = row["KategoriAdi"].ToString()
                });
            }
            
            return kategoriler;
        }

        /// <summary>
        /// ID'ye göre kategoriyi getir
        /// </summary>
        /// <param name="kategoriId">Kategori ID</param>
        /// <returns>Kategori nesnesi veya null</returns>
        public static Kategori IdIleGetir(int kategoriId)
        {
            DataTable table = Database.ExecuteQuery("SELECT * FROM Kategori WHERE KategoriId = @KategoriId",
                new SqlParameter("@KategoriId", kategoriId));
            
            if (table.Rows.Count == 0)
                return null;
                
            DataRow row = table.Rows[0];
            
            return new Kategori
            {
                KategoriId = Convert.ToInt32(row["KategoriId"]),
                KategoriAdi = row["KategoriAdi"].ToString()
            };
        }

        /// <summary>
        /// Yeni kategori ekle
        /// </summary>
        /// <returns>Başarılı ise eklenen kategori ID'si, başarısız ise -1</returns>
        public int Ekle()
        {
            // Otomatik ID için son ID'yi alıp 1 artırıyoruz
            object sonId = Database.ExecuteScalar("SELECT MAX(KategoriId) FROM Kategori");
            int yeniId = sonId == DBNull.Value ? 1 : Convert.ToInt32(sonId) + 1;
            
            this.KategoriId = yeniId;
            
            int sonuc = Database.ExecuteNonQuery(
                "INSERT INTO Kategori (KategoriId, KategoriAdi) VALUES (@KategoriId, @KategoriAdi)",
                new SqlParameter("@KategoriId", KategoriId),
                new SqlParameter("@KategoriAdi", KategoriAdi));
                
            return sonuc > 0 ? KategoriId : -1;
        }

        /// <summary>
        /// Kategori bilgilerini güncelle
        /// </summary>
        /// <returns>Başarılı ise true, değilse false</returns>
        public bool Guncelle()
        {
            int sonuc = Database.ExecuteNonQuery(
                "UPDATE Kategori SET KategoriAdi = @KategoriAdi WHERE KategoriId = @KategoriId",
                new SqlParameter("@KategoriId", KategoriId),
                new SqlParameter("@KategoriAdi", KategoriAdi));
                
            return sonuc > 0;
        }

        /// <summary>
        /// Kategoriyi sil
        /// </summary>
        /// <returns>Başarılı ise true, değilse false</returns>
        public bool Sil()
        {
            int sonuc = Database.ExecuteNonQuery(
                "DELETE FROM Kategori WHERE KategoriId = @KategoriId",
                new SqlParameter("@KategoriId", KategoriId));
                
            return sonuc > 0;
        }

        /// <summary>
        /// ToString metodu için kategori adını döndür
        /// </summary>
        public override string ToString()
        {
            return KategoriAdi;
        }

        /// <summary>
        /// En az bir ürünü olan kategorileri getir
        /// </summary>
        /// <returns>Kategori listesi</returns>
        public static List<Kategori> UrunuOlanlariGetir()
        {
            List<Kategori> kategoriler = new List<Kategori>();
            using (SqlConnection conn = new SqlConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(
                    @"SELECT k.KategoriId, k.KategoriAdi
                      FROM Kategori k
                      WHERE EXISTS (SELECT 1 FROM Urun u WHERE u.KategoriId = k.KategoriId)", conn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            kategoriler.Add(new Kategori
                            {
                                KategoriId = Convert.ToInt32(dr["KategoriId"]),
                                KategoriAdi = dr["KategoriAdi"].ToString()
                            });
                        }
                    }
                }
            }
            return kategoriler;
        }
    }
} 