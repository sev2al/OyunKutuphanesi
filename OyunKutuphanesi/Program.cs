using System;
using System.Windows.Forms;

namespace OyunKutuphanesi
{
    static class Program
    {
        /// <summary>
        /// Giriş yapan kullanıcının ID'si
        /// </summary>
        public static int GirisYapanKullaniciID { get; set; }

        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormGirisEkrani());



        }
    }
}
