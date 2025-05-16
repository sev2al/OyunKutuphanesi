using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunKutuphanesi
{
    public class VeritabaniBaglantisi
    {
        private static readonly string BaglantiDizesi = ConfigurationManager.ConnectionStrings["OyunBaglantisi"].ConnectionString;

        /// <summary>
        /// SQL bağlantısını açar ve döndürür.
        /// </summary>
        /// <returns>Açık bir SQL bağlantısı.</returns>
        public static SqlConnection BaglantiOlustur()
        {
            SqlConnection baglanti = new SqlConnection(BaglantiDizesi);
            if (baglanti.State != ConnectionState.Open)
            {
                baglanti.Open();
            }
            return baglanti;
        }

        /// <summary>
        /// Verilen bağlantıyı kapatır.
        /// </summary>
        /// <param name="baglanti">Kapatılacak bağlantı.</param>
        public static void BaglantiKapat(SqlConnection baglanti)
        {
            if (baglanti != null && baglanti.State != ConnectionState.Closed)
            {
                baglanti.Close();
            }
        }

        /// <summary>
        /// SQL sorgusu çalıştırır ve veri tablosunu döndürür.
        /// </summary>
        /// <param name="sorgu">Çalıştırılacak SQL sorgusu.</param>
        /// <returns>Sorgu sonucunu içeren veri tablosu.</returns>
        public static DataTable VeriGetir(string sorgu)
        {
            DataTable dt = new DataTable();
            SqlConnection baglanti = BaglantiOlustur();
            
            try
            {
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                // Hata yönetimi burada yapılabilir
                Console.WriteLine("Veri getirme hatası: " + ex.Message);
            }
            finally
            {
                BaglantiKapat(baglanti);
            }
            
            return dt;
        }

        /// <summary>
        /// Ekleme, güncelleme veya silme SQL komutlarını çalıştırır.
        /// </summary>
        /// <param name="sorgu">Çalıştırılacak SQL komutu.</param>
        /// <returns>Etkilenen satır sayısı.</returns>
        public static int KomutCalistir(string sorgu)
        {
            int sonuc = 0;
            SqlConnection baglanti = BaglantiOlustur();
            
            try
            {
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                sonuc = komut.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Hata yönetimi burada yapılabilir
                Console.WriteLine("Komut çalıştırma hatası: " + ex.Message);
            }
            finally
            {
                BaglantiKapat(baglanti);
            }
            
            return sonuc;
        }
    }
} 