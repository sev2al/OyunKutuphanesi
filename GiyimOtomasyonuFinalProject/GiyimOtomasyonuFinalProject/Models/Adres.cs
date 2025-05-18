using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GiyimOtomasyonuFinalProject.Models
{
    /// <summary>
    /// Müşteri adres bilgilerini tutan sınıf
    /// </summary>
    public class Adres
    {
        /// <summary>
        /// Adres ID
        /// </summary>
        public int AdresId { get; set; }
        
        /// <summary>
        /// Müşteri ID
        /// </summary>
        public int MusteriId { get; set; }
        
        /// <summary>
        /// Adres Bilgisi
        /// </summary>
        public string AdresBilgisi { get; set; }
        
        /// <summary>
        /// Şehir
        /// </summary>
        public string Sehir { get; set; }
        
        /// <summary>
        /// İlçe
        /// </summary>
        public string Ilce { get; set; }
        
        /// <summary>
        /// Posta Kodu
        /// </summary>
        public string PostaKodu { get; set; }

        /// <summary>
        /// Adresi düzenlenmiş format olarak döndürür
        /// </summary>
        public string TamAdres
        {
            get { return $"{AdresBilgisi}, {Ilce}/{Sehir} {PostaKodu}"; }
        }

        /// <summary>
        /// Müşteriye ait tüm adresleri getir
        /// </summary>
        /// <param name="musteriId">Müşteri ID</param>
        /// <returns>Adres listesi</returns>
        public static List<Adres> MusteriyeGoreGetir(int musteriId)
        {
            List<Adres> adresler = new List<Adres>();
            
            DataTable table = Database.ExecuteQuery("SELECT * FROM Adres WHERE MusteriId = @MusteriId",
                new SqlParameter("@MusteriId", musteriId));
            
            foreach (DataRow row in table.Rows)
            {
                adresler.Add(new Adres
                {
                    AdresId = Convert.ToInt32(row["AdresId"]),
                    MusteriId = Convert.ToInt32(row["MusteriId"]),
                    AdresBilgisi = row["Adres"].ToString(),
                    Sehir = row["Sehir"].ToString(),
                    Ilce = row["Ilce"].ToString(),
                    PostaKodu = row["PostaKodu"].ToString()
                });
            }
            
            return adresler;
        }

        /// <summary>
        /// ID'ye göre adresi getir
        /// </summary>
        /// <param name="adresId">Adres ID</param>
        /// <returns>Adres nesnesi veya null</returns>
        public static Adres IdIleGetir(int adresId)
        {
            DataTable table = Database.ExecuteQuery("SELECT * FROM Adres WHERE AdresId = @AdresId",
                new SqlParameter("@AdresId", adresId));
            
            if (table.Rows.Count == 0)
                return null;
                
            DataRow row = table.Rows[0];
            
            return new Adres
            {
                AdresId = Convert.ToInt32(row["AdresId"]),
                MusteriId = Convert.ToInt32(row["MusteriId"]),
                AdresBilgisi = row["Adres"].ToString(),
                Sehir = row["Sehir"].ToString(),
                Ilce = row["Ilce"].ToString(),
                PostaKodu = row["PostaKodu"].ToString()
            };
        }

        /// <summary>
        /// Yeni adres ekle
        /// </summary>
        /// <returns>Başarılı ise eklenen adres ID'si, başarısız ise -1</returns>
        public int Ekle()
        {
            // Otomatik ID için son ID'yi alıp 1 artırıyoruz
            object sonId = Database.ExecuteScalar("SELECT MAX(AdresId) FROM Adres");
            int yeniId = sonId == DBNull.Value ? 1 : Convert.ToInt32(sonId) + 1;
            
            this.AdresId = yeniId;
            
            int sonuc = Database.ExecuteNonQuery(
                "INSERT INTO Adres (AdresId, MusteriId, Adres, Sehir, Ilce, PostaKodu) " +
                "VALUES (@AdresId, @MusteriId, @Adres, @Sehir, @Ilce, @PostaKodu)",
                new SqlParameter("@AdresId", AdresId),
                new SqlParameter("@MusteriId", MusteriId),
                new SqlParameter("@Adres", AdresBilgisi),
                new SqlParameter("@Sehir", Sehir),
                new SqlParameter("@Ilce", Ilce),
                new SqlParameter("@PostaKodu", PostaKodu));
                
            return sonuc > 0 ? AdresId : -1;
        }

        /// <summary>
        /// Adres bilgilerini güncelle
        /// </summary>
        /// <returns>Başarılı ise true, değilse false</returns>
        public bool Guncelle()
        {
            int sonuc = Database.ExecuteNonQuery(
                "UPDATE Adres SET MusteriId = @MusteriId, Adres = @Adres, " +
                "Sehir = @Sehir, Ilce = @Ilce, PostaKodu = @PostaKodu WHERE AdresId = @AdresId",
                new SqlParameter("@AdresId", AdresId),
                new SqlParameter("@MusteriId", MusteriId),
                new SqlParameter("@Adres", AdresBilgisi),
                new SqlParameter("@Sehir", Sehir),
                new SqlParameter("@Ilce", Ilce),
                new SqlParameter("@PostaKodu", PostaKodu));
                
            return sonuc > 0;
        }

        /// <summary>
        /// Adresi sil
        /// </summary>
        /// <returns>Başarılı ise true, değilse false</returns>
        public bool Sil()
        {
            int sonuc = Database.ExecuteNonQuery(
                "DELETE FROM Adres WHERE AdresId = @AdresId",
                new SqlParameter("@AdresId", AdresId));
                
            return sonuc > 0;
        }
    }
} 