using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GiyimOtomasyonuFinalProject.Models
{
    /// <summary>
    /// Müşteri bilgilerini tutan sınıf
    /// </summary>
    public class Musteri
    {
        /// <summary>
        /// Müşteri ID
        /// </summary>
        public int MusteriId { get; set; }
        
        /// <summary>
        /// Müşteri Adı
        /// </summary>
        public string Ad { get; set; }
        
        /// <summary>
        /// Müşteri Soyadı
        /// </summary>
        public string Soyad { get; set; }
        
        /// <summary>
        /// Müşteri Puanı
        /// </summary>
        public int Puan { get; set; }
        
        /// <summary>
        /// Müşteri E-posta Adresi
        /// </summary>
        public string Eposta { get; set; }
        
        /// <summary>
        /// Müşteri Şifresi (hash olarak saklanır)
        /// </summary>
        public string Sifre { get; set; }
        
        /// <summary>
        /// Müşteri Rolü (Admin, Musteri vb.)
        /// </summary>
        public string Rol { get; set; }

        /// <summary>
        /// Müşterinin adresleri
        /// </summary>
        public List<Adres> Adresler { get; set; }

        /// <summary>
        /// Müşteri tam adını döndürür
        /// </summary>
        public string TamAd
        {
            get { return $"{Ad} {Soyad}"; }
        }

        /// <summary>
        /// Veritabanından tüm müşterileri getir
        /// </summary>
        /// <returns>Müşteri listesi</returns>
        public static List<Musteri> TumunuGetir()
        {
            List<Musteri> musteriler = new List<Musteri>();
            
            DataTable table = Database.ExecuteQuery("SELECT * FROM Musteri");
            
            foreach (DataRow row in table.Rows)
            {
                musteriler.Add(new Musteri
                {
                    MusteriId = Convert.ToInt32(row["MusteriId"]),
                    Ad = row["Ad"].ToString(),
                    Soyad = row["Soyad"].ToString(),
                    Puan = Convert.ToInt32(row["Puan"]),
                    Eposta = row["Eposta"].ToString(),
                    Sifre = row["Sifre"].ToString(),
                    Rol = row["Rol"].ToString()
                });
            }
            
            return musteriler;
        }

        /// <summary>
        /// ID'ye göre müşteriyi getir
        /// </summary>
        /// <param name="musteriId">Müşteri ID</param>
        /// <returns>Müşteri nesnesi veya null</returns>
        public static Musteri IdIleGetir(int musteriId)
        {
            DataTable table = Database.ExecuteQuery("SELECT * FROM Musteri WHERE MusteriId = @MusteriId",
                new SqlParameter("@MusteriId", musteriId));
            
            if (table.Rows.Count == 0)
                return null;
                
            DataRow row = table.Rows[0];
            
            return new Musteri
            {
                MusteriId = Convert.ToInt32(row["MusteriId"]),
                Ad = row["Ad"].ToString(),
                Soyad = row["Soyad"].ToString(),
                Puan = Convert.ToInt32(row["Puan"]),
                Eposta = row["Eposta"].ToString(),
                Sifre = row["Sifre"].ToString(),
                Rol = row["Rol"].ToString()
            };
        }

        /// <summary>
        /// E-posta ve şifreyle müşteri girişi
        /// </summary>
        /// <param name="eposta">E-posta</param>
        /// <param name="sifre">Şifre</param>
        /// <returns>Müşteri nesnesi veya null</returns>
        public static Musteri Giris(string eposta, string sifre)
        {
            DataTable table = Database.ExecuteQuery(
                "SELECT * FROM Musteri WHERE Eposta = @Eposta AND Sifre = @Sifre",
                new SqlParameter("@Eposta", eposta),
                new SqlParameter("@Sifre", sifre));
            
            if (table.Rows.Count == 0)
                return null;
                
            DataRow row = table.Rows[0];
            
            return new Musteri
            {
                MusteriId = Convert.ToInt32(row["MusteriId"]),
                Ad = row["Ad"].ToString(),
                Soyad = row["Soyad"].ToString(),
                Puan = Convert.ToInt32(row["Puan"]),
                Eposta = row["Eposta"].ToString(),
                Sifre = row["Sifre"].ToString(),
                Rol = row["Rol"].ToString()
            };
        }

        /// <summary>
        /// Yeni müşteri ekle
        /// </summary>
        /// <returns>Başarılı ise eklenen müşteri ID'si, başarısız ise -1</returns>
        public int Ekle()
        {
            // Otomatik ID için son ID'yi alıp 1 artırıyoruz
            object sonId = Database.ExecuteScalar("SELECT MAX(MusteriId) FROM Musteri");
            int yeniId = sonId == DBNull.Value ? 1 : Convert.ToInt32(sonId) + 1;
            
            this.MusteriId = yeniId;
            
            int sonuc = Database.ExecuteNonQuery(
                "INSERT INTO Musteri (MusteriId, Ad, Soyad, Puan, Eposta, Sifre, Rol) " +
                "VALUES (@MusteriId, @Ad, @Soyad, @Puan, @Eposta, @Sifre, @Rol)",
                new SqlParameter("@MusteriId", MusteriId),
                new SqlParameter("@Ad", Ad),
                new SqlParameter("@Soyad", Soyad),
                new SqlParameter("@Puan", Puan),
                new SqlParameter("@Eposta", Eposta),
                new SqlParameter("@Sifre", Sifre),
                new SqlParameter("@Rol", Rol));
                
            return sonuc > 0 ? MusteriId : -1;
        }

        /// <summary>
        /// Müşteri bilgilerini güncelle
        /// </summary>
        /// <returns>Başarılı ise true, değilse false</returns>
        public bool Guncelle()
        {
            try
            {
                int sonuc = Database.ExecuteNonQuery(
                    "UPDATE Musteri SET Ad = @Ad, Soyad = @Soyad, Puan = @Puan, " +
                    "Eposta = @Eposta, Sifre = @Sifre, Rol = @Rol WHERE MusteriId = @MusteriId",
                    new SqlParameter("@MusteriId", MusteriId),
                    new SqlParameter("@Ad", Ad),
                    new SqlParameter("@Soyad", Soyad),
                    new SqlParameter("@Puan", Puan),
                    new SqlParameter("@Eposta", Eposta),
                    new SqlParameter("@Sifre", Sifre),
                    new SqlParameter("@Rol", Rol));
                    
                return sonuc > 0;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Müşteriyi sil
        /// </summary>
        /// <returns>Başarılı ise true, değilse false</returns>
        public bool Sil()
        {
            try
            {
                // İlişkili tablolardaki kayıtları sil
                // 1. Müşteri puanlarını sil
                Database.ExecuteNonQuery(
                    "DELETE FROM MusteriPuanlari WHERE MusteriID = @MusteriId",
                    new SqlParameter("@MusteriId", MusteriId));

                // 2. Müşterinin sepetini ve sepet detaylarını sil
                Database.ExecuteNonQuery(
                    "DELETE FROM SepetDetay WHERE SepetId IN (SELECT SepetId FROM Sepet WHERE MusteriId = @MusteriId)",
                    new SqlParameter("@MusteriId", MusteriId));
                Database.ExecuteNonQuery(
                    "DELETE FROM Sepet WHERE MusteriId = @MusteriId",
                    new SqlParameter("@MusteriId", MusteriId));

                // 3. Müşterinin satış detaylarını ve satışlarını sil
                Database.ExecuteNonQuery(
                    "DELETE FROM SatisDetay WHERE SatisId IN (SELECT SatisId FROM Satis WHERE MusteriId = @MusteriId)",
                    new SqlParameter("@MusteriId", MusteriId));
                Database.ExecuteNonQuery(
                    "DELETE FROM Satis WHERE MusteriId = @MusteriId",
                    new SqlParameter("@MusteriId", MusteriId));

                // 4. Müşterinin adreslerini sil
                Database.ExecuteNonQuery(
                    "DELETE FROM Adres WHERE MusteriId = @MusteriId",
                    new SqlParameter("@MusteriId", MusteriId));

                // 5. Son olarak müşteriyi sil
                int sonuc = Database.ExecuteNonQuery(
                    "DELETE FROM Musteri WHERE MusteriId = @MusteriId",
                    new SqlParameter("@MusteriId", MusteriId));
                    
                return sonuc > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
} 