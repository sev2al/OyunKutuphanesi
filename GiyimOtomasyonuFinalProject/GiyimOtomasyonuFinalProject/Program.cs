using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiyimOtomasyonuFinalProject
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Tabloyu oluştur (yoksa)
            GiyimOtomasyonuFinalProject.Models.Database.CreateMusteriPuanlariTable();
            // Bağlantı dizesini kontrol için konsola yaz
            Console.WriteLine($"Bağlantı dizesi: {GiyimOtomasyonuFinalProject.Models.Database.ConnectionString}");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
