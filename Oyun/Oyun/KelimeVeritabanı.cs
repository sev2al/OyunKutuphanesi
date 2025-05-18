using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oyun
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class KelimeVeritabani
    {
        KelimeVeritabani kelimeVeritabani = new KelimeVeritabani();

        private List<string> kelimeListesi = new List<string>()
    {
        "masa", "kedi", "kitap", "telefon", "elma", "araba", "kalem", "defter",
        "bilgisayar", "pencere", "yastık", "bardak", "ayakkabı", "çorap", "gözlük",
        "fener", "çanta", "anahtar", "merdiven", "dolap", "çiçek", "sandalye", "duvar"
    };

        public string RastgeleKelimeGetir(string zorluk)
        {
            List<string> filtreli = new List<string>();

            if (zorluk == "Kolay")
                filtreli = kelimeListesi.Where(k => k.Length == 4).ToList();
            else if (zorluk == "Orta")
                filtreli = kelimeListesi.Where(k => k.Length == 5).ToList();
            else if (zorluk == "Zor")
                filtreli = kelimeListesi.Where(k => k.Length >= 6).ToList();
            else
                filtreli = kelimeListesi;

            if (filtreli.Count == 0)
                return "yok";

            Random rnd = new Random();
            return filtreli[rnd.Next(filtreli.Count)];
        }
    }


}

