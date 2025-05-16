using OyunKutuphanesi;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace OyunKutuphanesi
{
    public partial class AdamAsmacaForm : Form
    {
        private OyunModu seciliMod;
        private string seciliKelime;
        private int kalanHak = 6;
        private HashSet<char> dogruHarfler = new HashSet<char>();
        private HashSet<char> yanlisHarfler = new HashSet<char>();
        private List<Label> harfKutucuklari = new List<Label>();
        private List<Image> adamGorselleri = new List<Image>();
        private int skor = 0;

        public AdamAsmacaForm()
        {
            InitializeComponent();
            AdamGorselleriniYukle();
            pbAdam.Image = adamGorselleri[0];
            cmbZorluk.SelectedIndex = 0;
        }

        private void AdamGorselleriniYukle()
        {
            // Projeye eklediğin görselleri Properties.Resources üzerinden ekle
            adamGorselleri.Clear();
            adamGorselleri.Add(Properties.Resources._1_png); // 1.png
            adamGorselleri.Add(Properties.Resources._2_png); // 2.png
            adamGorselleri.Add(Properties.Resources._3_png); // 3.png
            adamGorselleri.Add(Properties.Resources._4_png); // 4.png
            adamGorselleri.Add(Properties.Resources._5_png); // 5.png
            adamGorselleri.Add(Properties.Resources._6_png); // 6.png
            adamGorselleri.Add(Properties.Resources._7_png); // 7.png
        }

        private void btnBaslat_Click(object sender, EventArgs e)
        {
            // Zorluk seçimini veritabanına kaydet
            string zorluk = cmbZorluk.SelectedItem.ToString();
            AdamAsmacaAyarYonetici.ZorlukKaydet(zorluk);

            // Oyun modunu seç
            if (zorluk == "Kolay")
                seciliMod = new KolayMod();
            else if (zorluk == "Orta")
                seciliMod = new OrtaMod();
            else
                seciliMod = new ZorMod();

            // Rastgele kelime seç
            Random rnd = new Random();
            seciliKelime = seciliMod.Kelimeler[rnd.Next(seciliMod.Kelimeler.Count)].ToUpper();
            kalanHak = 6;
            dogruHarfler.Clear();
            yanlisHarfler.Clear();
            lblSonuc.Text = "";
            lblHak.Text = "Kalan Hak: 6";
            pbAdam.Image = adamGorselleri[0];
            txtHarf.Text = "";
            txtHarf.Enabled = true;
            btnTahmin.Enabled = true;
            HarfKutucuklariniOlustur();
            skor = 0;
            lblSkor.Text = "Skor: 0";
        }

        private void HarfKutucuklariniOlustur()
        {
            flpHarfler.Controls.Clear();
            harfKutucuklari.Clear();
            foreach (char harf in seciliKelime)
            {
                Label lbl = new Label();
                lbl.Text = "_";
                lbl.Font = new Font("Arial", 16, FontStyle.Bold);
                lbl.Width = 30;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                harfKutucuklari.Add(lbl);
                flpHarfler.Controls.Add(lbl);
            }
        }

        private void btnTahmin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHarf.Text)) return;
            char tahmin = char.ToUpper(txtHarf.Text[0]);
            txtHarf.Text = "";

            if (dogruHarfler.Contains(tahmin) || yanlisHarfler.Contains(tahmin))
            {
                MessageBox.Show("Bu harfi zaten denediniz.");
                return;
            }

            if (seciliKelime.Contains(tahmin))
            {
                dogruHarfler.Add(tahmin);
                int dogruAdet = 0;
                for (int i = 0; i < seciliKelime.Length; i++)
                {
                    if (seciliKelime[i] == tahmin)
                    {
                        harfKutucuklari[i].Text = tahmin.ToString();
                        dogruAdet++;
                    }
                }
                skor += dogruAdet * 5;
                lblSkor.Text = $"Skor: {skor}";
                if (TumHarflerBulundu())
                {
                    OyunSonu(true);
                }
            }
            else
            {
                yanlisHarfler.Add(tahmin);
                kalanHak--;
                lblHak.Text = $"Kalan Hak: {kalanHak}";
                pbAdam.Image = adamGorselleri[6 - kalanHak];
                if (kalanHak == 0)
                {
                    OyunSonu(false);
                }
            }
        }

        private bool TumHarflerBulundu()
        {
            foreach (char harf in seciliKelime)
            {
                if (!dogruHarfler.Contains(harf))
                    return false;
            }
            return true;
        }

        private void OyunSonu(bool kazandi)
        {
            txtHarf.Enabled = false;
            btnTahmin.Enabled = false;
            int kullaniciID = Program.GirisYapanKullaniciID;
            int oyunID = 1; // AdamAsmaca için sabit bir ID
            if (kazandi)
            {
                lblSonuc.Text = "Tebrikler, kazandınız!";
                AdamAsmacaAyarYonetici.SkorKaydet(kullaniciID, oyunID, skor);
            }
            else
            {
                lblSonuc.Text = $"Kaybettiniz! Kelime: {seciliKelime}";
                AdamAsmacaAyarYonetici.SkorKaydet(kullaniciID, oyunID, skor);
            }
        }
    }
} 