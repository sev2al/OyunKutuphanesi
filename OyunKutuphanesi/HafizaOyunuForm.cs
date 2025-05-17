using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace OyunKutuphanesi
{
    public partial class HafizaOyunuForm : Form
    {
        private ZorlukSeviyesi mevcutZorluk;
        private List<Kart> kartlar;
        private Timer oyunZamanlayici;
        private int gecenSure;
        private int hamleSayisi;
        private Kart ilkSecilenKart;
        private bool oyunDevamEdiyor;

        // UI Controls
        private Panel ustPanel;
        private ComboBox zorlukSecici;
        private Button yeniOyunButonu;
        private Button skorTablosuButonu;
        private Label zamanLabel;
        private Label hamleLabel;
        private FlowLayoutPanel kartlarPanel;

        public HafizaOyunuForm()
        {
            InitializeComponent();
            KontrolleriOlustur();
            OyunuSifirla();
        }

        private void KontrolleriOlustur()
        {
            // Form özellikleri
            this.Text = "Hafıza Oyunu";
            this.Size = new Size(800, 600);
            this.MinimumSize = new Size(600, 400);

            // Üst panel
            ustPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.LightSteelBlue
            };

            // Zorluk seviyesi seçici
            zorlukSecici = new ComboBox
            {
                Location = new Point(10, 20),
                Size = new Size(120, 25)
            };
            zorlukSecici.Items.AddRange(new string[] { "Kolay", "Orta", "Zor" });
            zorlukSecici.SelectedIndex = 0;
            zorlukSecici.SelectedIndexChanged += ZorlukSecici_SelectedIndexChanged;

            // Yeni oyun butonu
            yeniOyunButonu = new Button
            {
                Location = new Point(140, 20),
                Size = new Size(100, 25),
                Text = "Yeni Oyun"
            };
            yeniOyunButonu.Click += YeniOyunButonu_Click;

            // Skor Tablosu butonu
            skorTablosuButonu = new Button
            {
                Location = new Point(520, 20),
                Size = new Size(100, 25),
                Text = "Skor Tablosu",
                BackColor = Color.LightGreen,
                FlatStyle = FlatStyle.Flat
            };
            skorTablosuButonu.Click += SkorTablosuButonu_Click;

            // Zaman göstergesi
            zamanLabel = new Label
            {
                Location = new Point(250, 20),
                Size = new Size(150, 25),
                Text = "Süre: 0:00",
                TextAlign = ContentAlignment.MiddleLeft
            };

            // Hamle sayısı göstergesi
            hamleLabel = new Label
            {
                Location = new Point(410, 20),
                Size = new Size(150, 25),
                Text = "Hamle: 0",
                TextAlign = ContentAlignment.MiddleLeft
            };

            // Kartlar paneli
            kartlarPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.WhiteSmoke,
                Padding = new Padding(10)
            };

            // Zamanlayıcı
            oyunZamanlayici = new Timer
            {
                Interval = 1000
            };
            oyunZamanlayici.Tick += OyunZamanlayici_Tick;

            // Kontrolleri forma ekle
            ustPanel.Controls.AddRange(new Control[] { zorlukSecici, yeniOyunButonu, zamanLabel, hamleLabel, skorTablosuButonu });
            this.Controls.AddRange(new Control[] { ustPanel, kartlarPanel });
        }

        private void OyunuSifirla()
        {
            // Mevcut oyunu temizle
            kartlarPanel.Controls.Clear();
            if (kartlar != null)
            {
                foreach (var kart in kartlar)
                {
                    kart.Dispose();
                }
            }

            // Yeni oyun değişkenlerini ayarla
            gecenSure = 0;
            hamleSayisi = 0;
            ilkSecilenKart = null;
            oyunDevamEdiyor = false;
            zamanLabel.Text = "Süre: 0:00";
            hamleLabel.Text = "Hamle: 0";

            // Zorluk seviyesini ayarla
            switch (zorlukSecici.SelectedIndex)
            {
                case 0:
                    mevcutZorluk = new KolayZorluk();
                    break;
                case 1:
                    mevcutZorluk = new OrtaZorluk();
                    break;
                case 2:
                    mevcutZorluk = new ZorZorluk();
                    break;
            }

            KartlariOlustur();
            oyunDevamEdiyor = true;
            oyunZamanlayici.Start();
        }

        private void KartlariOlustur()
        {
            kartlar = new List<Kart>();
            // Kart çiftlerini oluştur
            for (int i = 0; i < mevcutZorluk.KartCiftSayisi; i++)
            {
                // Her çift için aynı resmi kullan
                Image resim = OyunResimleriOlustur(i);
                
                // Her çiftten iki kart oluştur
                for (int j = 0; j < 2; j++)
                {
                    Kart yeniKart = new Kart(i, resim);
                    yeniKart.Click += Kart_Click;
                    kartlar.Add(yeniKart);
                }
            }

            // Kartları karıştır
            KartlariKaristir();

            // Kartları panele ekle
            foreach (var kart in kartlar)
            {
                kartlarPanel.Controls.Add(kart);
            }
        }

        private Image OyunResimleriOlustur(int index)
        {
            // Basit renkli kareler oluştur
            Bitmap resim = new Bitmap(100, 100);
            using (Graphics g = Graphics.FromImage(resim))
            {
                // Her kart çifti için farklı bir renk kullan
                Color[] renkler = { Color.Red, Color.Blue, Color.Green, Color.Yellow, 
                                  Color.Purple, Color.Orange, Color.Pink, Color.Brown };
                
                g.Clear(renkler[index % renkler.Length]);
                
                // Kartın üzerine numara ekle
                using (Font font = new Font("Arial", 32, FontStyle.Bold))
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    g.DrawString((index + 1).ToString(), font, Brushes.White, 
                               new RectangleF(0, 0, 100, 100), sf);
                }
            }
            return resim;
        }

        private void KartlariKaristir()
        {
            Random rnd = new Random();
            int n = kartlar.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                Kart temp = kartlar[k];
                kartlar[k] = kartlar[n];
                kartlar[n] = temp;
            }
        }

        private void Kart_Click(object sender, EventArgs e)
        {
            if (!oyunDevamEdiyor) return;

            Kart secilenKart = sender as Kart;
            if (secilenKart == null || secilenKart.AcikMi || secilenKart.EslestiMi) return;

            secilenKart.KartiGoster();

            if (ilkSecilenKart == null)
            {
                ilkSecilenKart = secilenKart;
            }
            else
            {
                hamleSayisi++;
                hamleLabel.Text = $"Hamle: {hamleSayisi}";

                if (ilkSecilenKart.Id == secilenKart.Id)
                {
                    // Eşleşme bulundu
                    ilkSecilenKart.KartiEslestir();
                    secilenKart.KartiEslestir();
                    ilkSecilenKart = null;

                    // Oyun bitti mi kontrol et
                    if (OyunBittiMi())
                    {
                        OyunuBitir();
                    }
                }
                else
                {
                    // Eşleşme bulunamadı
                    Timer kapatmaZamanlayici = new Timer();
                    kapatmaZamanlayici.Interval = 1000;
                    kapatmaZamanlayici.Tick += (s, args) =>
                    {
                        ilkSecilenKart.KartiGizle();
                        secilenKart.KartiGizle();
                        ilkSecilenKart = null;
                        kapatmaZamanlayici.Stop();
                        kapatmaZamanlayici.Dispose();
                    };
                    kapatmaZamanlayici.Start();
                }
            }
        }

        private bool OyunBittiMi()
        {
            return kartlar.All(k => k.EslestiMi);
        }

        private void OyunuBitir()
        {
            oyunDevamEdiyor = false;
            oyunZamanlayici.Stop();
            int skor = mevcutZorluk.SkorHesapla(gecenSure, hamleSayisi);
            
            // Skoru veritabanına kaydet
            AdamAsmacaAyarYonetici.SkorKaydet(Program.GirisYapanKullaniciID, 1, skor);
            
            MessageBox.Show($"Tebrikler!\nSüre: {gecenSure} saniye\nHamle: {hamleSayisi}\nSkor: {skor}", 
                          "Oyun Bitti", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OyunZamanlayici_Tick(object sender, EventArgs e)
        {
            gecenSure++;
            TimeSpan sure = TimeSpan.FromSeconds(gecenSure);
            zamanLabel.Text = $"Süre: {sure.Minutes}:{sure.Seconds:00}";
        }

        private void YeniOyunButonu_Click(object sender, EventArgs e)
        {
            oyunZamanlayici.Stop();
            OyunuSifirla();
        }

        private void SkorTablosuButonu_Click(object sender, EventArgs e)
        {
            using (var skorTablosu = new HafizaOyunuSkorTablosuForm())
            {
                skorTablosu.ShowDialog();
            }
        }

        private void ZorlukSecici_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (oyunDevamEdiyor)
            {
                DialogResult result = MessageBox.Show("Aktif oyunu bitirmek istediğinize emin misiniz?",
                    "Yeni Oyun", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    OyunuSifirla();
                }
                else
                {
                    zorlukSecici.SelectedIndexChanged -= ZorlukSecici_SelectedIndexChanged;
                    int yeniIndex = 0;
                    if (mevcutZorluk is KolayZorluk)
                        yeniIndex = 0;
                    else if (mevcutZorluk is OrtaZorluk)
                        yeniIndex = 1;
                    else if (mevcutZorluk is ZorZorluk)
                        yeniIndex = 2;
                    zorlukSecici.SelectedIndex = yeniIndex;
                    zorlukSecici.SelectedIndexChanged += ZorlukSecici_SelectedIndexChanged;
                }
            }
            else
            {
                OyunuSifirla();
            }
        }
    }
} 