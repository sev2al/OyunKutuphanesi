using System;
using System.Data;
using System.Data.SqlClient;

namespace OyunKutuphanesi
{
    // OyunAyarları tablosu ile zorluk seviyesi okuma/yazma işlemleri
    public class AdamAsmacaAyarYonetici
    {
        // Zorluk seviyesini veritabanına kaydet
        public static void ZorlukKaydet(string zorluk)
        {
            using (SqlConnection baglanti = VeritabaniBaglantisi.BaglantiOlustur())
            {
                // Eğer tablo boşsa ekle, varsa güncelle
                string kontrolSorgu = "SELECT COUNT(*) FROM OyunAyarlari WHERE OyunAdi = 'AdamAsmaca'";
                SqlCommand kontrolKomut = new SqlCommand(kontrolSorgu, baglanti);
                int kayitVarMi = (int)kontrolKomut.ExecuteScalar();

                if (kayitVarMi == 0)
                {
                    string ekleSorgu = "INSERT INTO OyunAyarlari (OyunAdi, Zorluk) VALUES ('AdamAsmaca', @Zorluk)";
                    SqlCommand ekleKomut = new SqlCommand(ekleSorgu, baglanti);
                    ekleKomut.Parameters.AddWithValue("@Zorluk", zorluk);
                    ekleKomut.ExecuteNonQuery();
                }
                else
                {
                    string guncelleSorgu = "UPDATE OyunAyarlari SET Zorluk = @Zorluk WHERE OyunAdi = 'AdamAsmaca'";
                    SqlCommand guncelleKomut = new SqlCommand(guncelleSorgu, baglanti);
                    guncelleKomut.Parameters.AddWithValue("@Zorluk", zorluk);
                    guncelleKomut.ExecuteNonQuery();
                }
            }
        }

        // Zorluk seviyesini veritabanından oku
        public static string ZorlukOku()
        {
            using (SqlConnection baglanti = VeritabaniBaglantisi.BaglantiOlustur())
            {
                string sorgu = "SELECT Zorluk FROM OyunAyarlari WHERE OyunAdi = 'AdamAsmaca'";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                object sonuc = komut.ExecuteScalar();
                return sonuc != null ? sonuc.ToString() : "Kolay";
            }
        }

        public static void SkorKaydet(int? kullaniciID, int oyunID, int skor)
        {
            using (SqlConnection baglanti = VeritabaniBaglantisi.BaglantiOlustur())
            {
                string sorgu = "INSERT INTO Skorlar (KullaniciID, OyunID, Skor, OynanmaTarihi) VALUES (@KullaniciID, @OyunID, @Skor, GETDATE())";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@KullaniciID", (object)kullaniciID ?? DBNull.Value);
                komut.Parameters.AddWithValue("@OyunID", oyunID);
                komut.Parameters.AddWithValue("@Skor", skor);
                komut.ExecuteNonQuery();
            }
        }

        public static void ZorlukKaydetYilanOyunu(string zorluk)
        {
            using (SqlConnection baglanti = VeritabaniBaglantisi.BaglantiOlustur())
            {
                string kontrolSorgu = "SELECT COUNT(*) FROM OyunAyarlari WHERE OyunAdi = 'YilanOyunu'";
                SqlCommand kontrolKomut = new SqlCommand(kontrolSorgu, baglanti);
                int kayitVarMi = (int)kontrolKomut.ExecuteScalar();
                if (kayitVarMi == 0)
                {
                    string ekleSorgu = "INSERT INTO OyunAyarlari (OyunAdi, Zorluk) VALUES ('YilanOyunu', @Zorluk)";
                    SqlCommand ekleKomut = new SqlCommand(ekleSorgu, baglanti);
                    ekleKomut.Parameters.AddWithValue("@Zorluk", zorluk);
                    ekleKomut.ExecuteNonQuery();
                }
                else
                {
                    string guncelleSorgu = "UPDATE OyunAyarlari SET Zorluk = @Zorluk WHERE OyunAdi = 'YilanOyunu'";
                    SqlCommand guncelleKomut = new SqlCommand(guncelleSorgu, baglanti);
                    guncelleKomut.Parameters.AddWithValue("@Zorluk", zorluk);
                    guncelleKomut.ExecuteNonQuery();
                }
            }
        }

        public static string ZorlukOkuYilanOyunu()
        {
            using (SqlConnection baglanti = VeritabaniBaglantisi.BaglantiOlustur())
            {
                string sorgu = "SELECT Zorluk FROM OyunAyarlari WHERE OyunAdi = 'YilanOyunu'";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                object sonuc = komut.ExecuteScalar();
                return sonuc != null ? sonuc.ToString() : "Kolay";
            }
        }
    }
} 