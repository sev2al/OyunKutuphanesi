using System;
using System.Drawing;
using System.Windows.Forms;
using OyunKutuphanesi;
using System.Collections.Generic;

namespace OyunKutuphanesi
{
    public partial class YilanOyunuForm : Form
    {
        private Timer oyunTimer;
        private OyunAlani oyunAlani;
        private ZorlukModu zorlukModu;
        private int hucreBoyutu = 20;
        private bool oyunDevamEdiyor = false;
        private Random rnd = new Random();

        public YilanOyunuForm(ZorlukModu zorluk)
        {
            InitializeComponent();
            this.zorlukModu = zorluk;
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Width = zorluk.AlanGenisligi * hucreBoyutu + 40;
            this.Height = zorluk.AlanYuksekligi * hucreBoyutu + 100;
            oyunAlani = new OyunAlani
            {
                Genislik = zorluk.AlanGenisligi,
                Yukseklik = zorluk.AlanYuksekligi,
                Yilan = new StandartYilan(),
                Yemek = new Yemek(),
                Skor = 0
            };
            btnBaslat.Click += BtnBaslat_Click;
            pnlOyunAlani.Paint += pnlOyunAlani_Paint;
            this.KeyDown += YilanOyunuForm_KeyDown;
            pnlOyunAlani.TabStop = false;
            oyunTimer = new Timer();
            oyunTimer.Interval = zorluk.Hiz;
            oyunTimer.Tick += OyunTimer_Tick;
            OyunHazirla();
            this.ActiveControl = null;
            this.Focus();
        }

        private void OyunHazirla()
        {
            oyunAlani.Yilan.Govde.Clear();
            int baslangicX = oyunAlani.Genislik / 2;
            int baslangicY = oyunAlani.Yukseklik / 2;
            int uzunluk = 3; // Kolay mod
            if (zorlukModu is YilanOrtaMod) uzunluk = 5;
            else if (zorlukModu is YilanZorMod) uzunluk = 7;
            for (int i = 0; i < uzunluk; i++)
            {
                oyunAlani.Yilan.Govde.Add(new Point(baslangicX - i, baslangicY));
            }
            oyunAlani.Yilan.Yon = "Sag";
            oyunAlani.Skor = 0;
            lblSkor.Text = "Skor: 0";
            pnlOyunAlani.Left = 20;
            pnlOyunAlani.Top = 60;
            pnlOyunAlani.Width = oyunAlani.Genislik * hucreBoyutu;
            pnlOyunAlani.Height = oyunAlani.Yukseklik * hucreBoyutu;
            this.ClientSize = new System.Drawing.Size(pnlOyunAlani.Left + pnlOyunAlani.Width + 20, pnlOyunAlani.Top + pnlOyunAlani.Height + 20);
            YeniYemek();
            pnlOyunAlani.Invalidate();
        }

        private void BtnBaslat_Click(object sender, EventArgs e)
        {
            // Zorluk seçimini al
            string zorluk = cmbZorluk.SelectedItem.ToString();
            AdamAsmacaAyarYonetici.ZorlukKaydetYilanOyunu(zorluk);
            if (zorluk == "Kolay")
            {
                zorlukModu = new YilanKolayMod();
            }
            else if (zorluk == "Orta")
            {
                zorlukModu = new YilanOrtaMod();
            }
            else
            {
                zorlukModu = new YilanZorMod();
            }

            this.Width = zorlukModu.AlanGenisligi * hucreBoyutu + 40;
            this.Height = zorlukModu.AlanYuksekligi * hucreBoyutu + 100;
            oyunAlani.Genislik = zorlukModu.AlanGenisligi;
            oyunAlani.Yukseklik = zorlukModu.AlanYuksekligi;

            // Yılan türü seçimini al ve yeni nesne oluştur
            string yilanTuru = cmbYilanTuru.SelectedItem.ToString();
            if (yilanTuru == "Hızlı Yılan")
            {
                oyunAlani.Yilan = new HizliYilan();
                oyunTimer.Interval = 60;
            }
            else if (yilanTuru == "Yavaş Yılan")
            {
                oyunAlani.Yilan = new YavasYilan();
                oyunTimer.Interval = 200;
            }
            else
            {
                oyunAlani.Yilan = new StandartYilan();
                oyunTimer.Interval = 120;
            }

            OyunHazirla();
            oyunDevamEdiyor = true;
            oyunTimer.Start();
            this.ActiveControl = null;
            this.Focus();
        }

        private void OyunTimer_Tick(object sender, EventArgs e)
        {
            if (!oyunDevamEdiyor) return;
            // Polimorfik hareket
            oyunAlani.Yilan.HareketEt();
            YilanHareketEt();
            pnlOyunAlani.Invalidate();
            this.Focus();
        }

        private void YilanHareketEt()
        {
            Point bas = oyunAlani.Yilan.Govde[0];
            int[] dx = { 1, -1, 0, 0 };
            int[] dy = { 0, 0, 1, -1 };
            bool hareketVar = false;
            for (int i = 0; i < 4; i++)
            {
                int nx = bas.X + dx[i];
                int ny = bas.Y + dy[i];
                Point np = new Point(nx, ny);
                if (nx >= 0 && ny >= 0 && nx < oyunAlani.Genislik && ny < oyunAlani.Yukseklik && !oyunAlani.Yilan.Govde.Contains(np))
                {
                    hareketVar = true;
                    break;
                }
            }
            if (!hareketVar)
            {
                OyunBitti();
                return;
            }
            Point yeniBas = bas;
            switch (oyunAlani.Yilan.Yon)
            {
                case "Sag": yeniBas.X += 1; break;
                case "Sol": yeniBas.X -= 1; break;
                case "Yukari": yeniBas.Y -= 1; break;
                case "Asagi": yeniBas.Y += 1; break;
            }
            if (yeniBas.X < 0 || yeniBas.Y < 0 || yeniBas.X >= oyunAlani.Genislik || yeniBas.Y >= oyunAlani.Yukseklik)
            {
                OyunBitti();
                return;
            }
            if (oyunAlani.Yilan.Govde.Contains(yeniBas))
            {
                OyunBitti();
                return;
            }
            oyunAlani.Yilan.Govde.Insert(0, yeniBas);
            if (yeniBas == oyunAlani.Yemek.Konum)
            {
                int skorArtis = 10; // Kolay mod
                if (zorlukModu is YilanOrtaMod) skorArtis = 5;
                else if (zorlukModu is YilanZorMod) skorArtis = 1;
                oyunAlani.Skor += skorArtis;
                lblSkor.Text = $"Skor: {oyunAlani.Skor}";
                oyunAlani.Yilan.Buyu();
                YeniYemek();
            }
            else
            {
                oyunAlani.Yilan.Govde.RemoveAt(oyunAlani.Yilan.Govde.Count - 1);
            }
        }

        private void YeniYemek()
        {
            List<Point> bosAlanlar = new List<Point>();
            for (int x = 0; x < oyunAlani.Genislik; x++)
            {
                for (int y = 0; y < oyunAlani.Yukseklik; y++)
                {
                    Point p = new Point(x, y);
                    if (!oyunAlani.Yilan.Govde.Contains(p))
                        bosAlanlar.Add(p);
                }
            }
            if (bosAlanlar.Count == 0)
            {
                oyunDevamEdiyor = false;
                oyunTimer.Stop();
                MessageBox.Show($"Tebrikler! Tüm alanı doldurdunuz. Skorunuz: {oyunAlani.Skor}");
                return;
            }
            oyunAlani.Yemek.Konum = bosAlanlar[rnd.Next(bosAlanlar.Count)];
        }

        private void pnlOyunAlani_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            // Yılanı çiz
            foreach (var p in oyunAlani.Yilan.Govde)
            {
                g.FillRectangle(Brushes.Green, p.X * hucreBoyutu, p.Y * hucreBoyutu, hucreBoyutu, hucreBoyutu);
            }
            // Yemi çiz
            g.FillEllipse(Brushes.Red, oyunAlani.Yemek.Konum.X * hucreBoyutu, oyunAlani.Yemek.Konum.Y * hucreBoyutu, hucreBoyutu, hucreBoyutu);
        }

        private void YilanOyunuForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!oyunDevamEdiyor) return;
            switch (e.KeyCode)
            {
                case Keys.Right:
                    if (oyunAlani.Yilan.Yon != "Sol") oyunAlani.Yilan.Yon = "Sag";
                    break;
                case Keys.Left:
                    if (oyunAlani.Yilan.Yon != "Sag") oyunAlani.Yilan.Yon = "Sol";
                    break;
                case Keys.Up:
                    if (oyunAlani.Yilan.Yon != "Asagi") oyunAlani.Yilan.Yon = "Yukari";
                    break;
                case Keys.Down:
                    if (oyunAlani.Yilan.Yon != "Yukari") oyunAlani.Yilan.Yon = "Asagi";
                    break;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!oyunDevamEdiyor) return base.ProcessCmdKey(ref msg, keyData);
            switch (keyData)
            {
                case Keys.Right:
                    if (oyunAlani.Yilan.Yon != "Sol") oyunAlani.Yilan.Yon = "Sag";
                    return true;
                case Keys.Left:
                    if (oyunAlani.Yilan.Yon != "Sag") oyunAlani.Yilan.Yon = "Sol";
                    return true;
                case Keys.Up:
                    if (oyunAlani.Yilan.Yon != "Asagi") oyunAlani.Yilan.Yon = "Yukari";
                    return true;
                case Keys.Down:
                    if (oyunAlani.Yilan.Yon != "Yukari") oyunAlani.Yilan.Yon = "Asagi";
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void OyunBitti()
        {
            oyunDevamEdiyor = false;
            oyunTimer.Stop();
            MessageBox.Show($"Oyun Bitti! Skorunuz: {oyunAlani.Skor}");
        }

       
    }
} 