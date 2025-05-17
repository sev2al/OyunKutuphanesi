using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OyunKutuphanesi.HafizaOyunu
{
    public partial class HafizaOyunuForm : Form
    {
        private List<Kart> kartlar;
        private ZorlukSeviyesi zorlukSeviyesi;
        private Timer oyunSuresi;
        private int gecenSure;
        private int hamleSayisi;
        private Kart ilkSecilen;
        private int kullaniciId;
        private Label lblSure;
        private Label lblHamle;
        private ComboBox cmbZorluk;
        private Button btnYeniOyun;
        private FlowLayoutPanel pnlKartlar;

        public HafizaOyunuForm(int kullaniciId)
        {
            InitializeComponent();
            this.kullaniciId = kullaniciId;
            KontrolleriOlustur();
            OyunuBaslat(new KolayZorluk());
        }

        private void InitializeComponent()
        {
            this.Text = "Hafıza Oyunu";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void KontrolleriOlustur()
        {
            // Üst panel
            Panel pnlUst = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50
            };

            // Zorluk seviyesi seçimi
            cmbZorluk = new ComboBox
            {
                Location = new Point(10, 10),
                Size = new Size(120, 25)
            };
            cmbZorluk.Items.AddRange(new string[] { "Kolay", "Orta", "Zor" });
            cmbZorluk.SelectedIndex = 0;
            cmbZorluk.SelectedIndexChanged += CmbZorluk_SelectedIndexChanged;

            // Yeni oyun butonu
            btnYeniOyun = new Button
            {
                Text = "Yeni Oyun",
                Location = new Point(140, 10),
                Size = new Size(100, 25)
            };
            btnYeniOyun.Click += BtnYeniOyun_Click;

            // Süre etiketi
            lblSure = new Label
            {
                Text = "Süre: 0",
                Location = new Point(250, 15),
                AutoSize = true
            };

            // Hamle etiketi
            lblHamle = new Label
            {
                Text = "Hamle: 0",
                Location = new Point(350, 15),
                AutoSize = true
            };

            pnlUst.Controls.AddRange(new Control[] { cmbZorluk, btnYeniOyun, lblSure, lblHamle });
            this.Controls.Add(pnlUst);

            // Kartlar paneli
            pnlKartlar = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(10)
            };
            this.Controls.Add(pnlKartlar);

            // Oyun süresi sayacı
            oyunSuresi = new Timer
            {
                Interval = 1000
            };
            oyunSuresi.Tick += OyunSuresi_Tick;
        }

        private void OyunuBaslat(ZorlukSeviyesi zorluk)
        {
            this.zorlukSeviyesi = zorluk;
            gecenSure = 0;
            hamleSayisi = 0;
            ilkSecilen = null;
            kartlar = new List<Kart>();

            // Kartları oluştur
            KartlariOlustur();

            // Süre sayacını başlat
            oyunSuresi.Start();

            // Etiketleri güncelle
            lblSure.Text = "Süre: 0";
            lblHamle.Text = "Hamle: 0";
        }

        private void KartlariOlustur()
        {
            pnlKartlar.Controls.Clear();
            kartlar.Clear();

            // Kart çiftlerini oluştur
            for (int i = 0; i < zorlukSeviyesi.KartCiftSayisi; i++)
            {
                Image resim = Properties.Resources.ResourceManager.GetObject($"kart{i}") as Image;
                if (resim == null) continue;

                for (int j = 0; j < 2; j++)
                {
                    Kart kart = new Kart(i, resim);
                    kart.Click += Kart_Click;
                    kartlar.Add(kart);
                }
            }

            // Kartları karıştır
            Random rnd = new Random();
            kartlar = kartlar.OrderBy(x => rnd.Next()).ToList();

            // Kartları panele ekle
            foreach (var kart in kartlar)
            {
                pnlKartlar.Controls.Add(kart);
            }
        }

        private void Kart_Click(object sender, EventArgs e)
        {
            Kart secilenKart = sender as Kart;
            if (secilenKart == null || secilenKart.AcikMi || secilenKart.EslestiMi) return;

            secilenKart.KartiGoster();

            if (ilkSecilen == null)
            {
                ilkSecilen = secilenKart;
            }
            else
            {
                hamleSayisi++;
                lblHamle.Text = $"Hamle: {hamleSayisi}";

                if (ilkSecilen.Id == secilenKart.Id)
                {
                    ilkSecilen.EslestiMi = true;
                    secilenKart.EslestiMi = true;
                    ilkSecilen = null;

                    // Oyun bitti mi kontrol et
                    if (kartlar.All(k => k.EslestiMi))
                    {
                        OyunBitti();
                    }
                }
                else
                {
                    Timer kapatmaTimer = new Timer();
                    kapatmaTimer.Interval = 1000;
                    kapatmaTimer.Tick += (s, args) =>
                    {
                        ilkSecilen.KartiGizle();
                        secilenKart.KartiGizle();
                        ilkSecilen = null;
                        kapatmaTimer.Stop();
                    };
                    kapatmaTimer.Start();
                }
            }
        }

        private void OyunBitti()
        {
            oyunSuresi.Stop();
            int skor = zorlukSeviyesi.SkorHesapla(gecenSure, hamleSayisi);

            // Skoru veritabanına kaydet
            using (SqlConnection baglanti = VeritabaniBaglantisi.BaglantiOlustur())
            {
                string sorgu = @"INSERT INTO HafizaOyunuSkorlar (KullaniciID, Skor, ZorlukSeviyesi, OyunSuresi, EslesmeSayisi, OyunTarihi) 
                                VALUES (@KullaniciID, @Skor, @ZorlukSeviyesi, @OyunSuresi, @EslesmeSayisi, GETDATE())";

                using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@KullaniciID", kullaniciId);
                    komut.Parameters.AddWithValue("@Skor", skor);
                    komut.Parameters.AddWithValue("@ZorlukSeviyesi", zorlukSeviyesi.Ad);
                    komut.Parameters.AddWithValue("@OyunSuresi", gecenSure);
                    komut.Parameters.AddWithValue("@EslesmeSayisi", zorlukSeviyesi.KartCiftSayisi);
                    komut.ExecuteNonQuery();
                }
            }

            MessageBox.Show($"Tebrikler! Oyunu bitirdiniz!\nSkorunuz: {skor}\nSüre: {gecenSure} saniye\nHamle: {hamleSayisi}",
                          "Oyun Bitti", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OyunSuresi_Tick(object sender, EventArgs e)
        {
            gecenSure++;
            lblSure.Text = $"Süre: {gecenSure}";
        }

        private void CmbZorluk_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZorlukSeviyesi yeniZorluk;
            switch (cmbZorluk.SelectedIndex)
            {
                case 1:
                    yeniZorluk = new OrtaZorluk();
                    break;
                case 2:
                    yeniZorluk = new ZorZorluk();
                    break;
                default:
                    yeniZorluk = new KolayZorluk();
                    break;
            }
            OyunuBaslat(yeniZorluk);
        }

        private void BtnYeniOyun_Click(object sender, EventArgs e)
        {
            OyunuBaslat(zorlukSeviyesi);
        }
    }
} 