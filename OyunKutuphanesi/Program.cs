using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OyunKutuphanesi
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormGirisEkrani());
        }

        static Program()
        {
            Application.ApplicationExit += new EventHandler(OnApplicationExit);
        }

        private static void OnApplicationExit(object sender, EventArgs e)
        {
            try
            {
                if (GirisYapanKullaniciID > 0)
                {
                    using (var baglanti = VeritabaniBaglantisi.BaglantiOlustur())
                    {
                        string sorgu = "UPDATE Oturumlar SET CikisZamani = GETDATE() WHERE KullaniciID = @KullaniciID AND CikisZamani IS NULL";
                        using (var komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti))
                        {
                            komut.Parameters.AddWithValue("@KullaniciID", GirisYapanKullaniciID);
                            komut.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch { /* Hata olursa sessizce geç */ }
        }

        public static int GirisYapanKullaniciID { get; set; }
    }
}
