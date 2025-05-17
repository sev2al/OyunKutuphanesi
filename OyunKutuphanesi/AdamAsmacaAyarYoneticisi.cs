using System;
using System.Data.SqlClient;

namespace OyunKutuphanesi
{
    public static class AdamAsmacaAyarYoneticisi
    {
        public static void SkorKaydet(int kullaniciID, int oyunID, int skor)
        {
            try
            {
                using (var baglanti = VeritabaniBaglantisi.BaglantiOlustur())
                {
                    string sorgu = @"INSERT INTO OyunSkorlari (KullaniciID, OyunID, Skor, OynananTarih) 
                                   VALUES (@KullaniciID, @OyunID, @Skor, GETDATE())";

                    using (var komut = new SqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@KullaniciID", kullaniciID);
                        komut.Parameters.AddWithValue("@OyunID", oyunID);
                        komut.Parameters.AddWithValue("@Skor", skor);
                        komut.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya bilgi ver
                System.Windows.Forms.MessageBox.Show(
                    "Skor kaydedilirken bir hata oluştu: " + ex.Message,
                    "Hata",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
    }
} 