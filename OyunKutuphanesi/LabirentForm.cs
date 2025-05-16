using System;
using System.Drawing;
using System.Windows.Forms;
using OyunKutuphanesi;

namespace OyunKutuphanesi
{
    public partial class LabirentForm : Form
    {
        private LabirentZorlukModu zorlukModu;
        private Oyuncu oyuncu;
        private int kutuBoyutu = 40;
        private Timer sureTimer;
        private int gecenSaniye = 0;
        private int skor = 0;
        private Label lblSkor;

        public LabirentForm(string zorluk)
        {
            InitializeComponent();
            this.Text = "Labirent Oyunu";
            this.ClientSize = new Size(500, 500);
            this.DoubleBuffered = true;
            LabirentVeOyuncuOlustur(zorluk);
            this.KeyPreview = true;
            this.KeyDown += LabirentForm_KeyDown;
            SkorLabelOlustur();
            TimerBaslat();
        }

        private void SkorLabelOlustur()
        {
            lblSkor = new Label();
            lblSkor.AutoSize = true;
            lblSkor.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblSkor.Location = new Point(10, 10);
            lblSkor.BackColor = Color.Transparent;
            lblSkor.ForeColor = Color.DarkBlue;
            lblSkor.Text = "Süre: 0 sn | Skor: 1000";
            this.Controls.Add(lblSkor);
        }

        private void TimerBaslat()
        {
            sureTimer = new Timer();
            sureTimer.Interval = 1000;
            sureTimer.Tick += SureTimer_Tick;
            sureTimer.Start();
        }

        private void SureTimer_Tick(object sender, EventArgs e)
        {
            gecenSaniye++;
            skor = Math.Max(100 - gecenSaniye * 10, 0);
            lblSkor.Text = $"Süre: {gecenSaniye} sn | Skor: {skor}";
        }

        private void LabirentVeOyuncuOlustur(string zorluk)
        {
            switch (zorluk)
            {
                case "Kolay":
                    zorlukModu = new KolayLabirentMod();
                    break;
                case "Orta":
                    zorlukModu = new OrtaLabirentMod();
                    break;
                case "Zor":
                    zorlukModu = new ZorLabirentMod();
                    break;
                default:
                    zorlukModu = new KolayLabirentMod();
                    break;
            }
            oyuncu = new Oyuncu(zorlukModu.BaslangicNoktasi.x, zorlukModu.BaslangicNoktasi.y);
            this.ClientSize = new Size(zorlukModu.SutunSayisi * kutuBoyutu, zorlukModu.SatirSayisi * kutuBoyutu);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            for (int i = 0; i < zorlukModu.SatirSayisi; i++)
            {
                for (int j = 0; j < zorlukModu.SutunSayisi; j++)
                {
                    Rectangle rect = new Rectangle(j * kutuBoyutu, i * kutuBoyutu, kutuBoyutu, kutuBoyutu);
                    if (zorlukModu.Harita[i, j] == 1)
                        e.Graphics.FillRectangle(Brushes.Black, rect); // Duvar
                    else if (zorlukModu.Harita[i, j] == 2)
                        e.Graphics.FillRectangle(Brushes.Green, rect); // Çıkış
                    else
                        e.Graphics.FillRectangle(Brushes.White, rect); // Boş
                    e.Graphics.DrawRectangle(Pens.Gray, rect);
                }
            }
            // Oyuncu
            Rectangle oyuncuRect = new Rectangle(oyuncu.Y * kutuBoyutu, oyuncu.X * kutuBoyutu, kutuBoyutu, kutuBoyutu);
            e.Graphics.FillEllipse(Brushes.Blue, oyuncuRect);
        }

        private void LabirentForm_KeyDown(object sender, KeyEventArgs e)
        {
            int dx = 0, dy = 0;
            if (e.KeyCode == Keys.Up) dx = -1;
            else if (e.KeyCode == Keys.Down) dx = 1;
            else if (e.KeyCode == Keys.Left) dy = -1;
            else if (e.KeyCode == Keys.Right) dy = 1;
            int yeniX = oyuncu.X + dx;
            int yeniY = oyuncu.Y + dy;
            if (yeniX >= 0 && yeniX < zorlukModu.SatirSayisi && yeniY >= 0 && yeniY < zorlukModu.SutunSayisi)
            {
                if (zorlukModu.Harita[yeniX, yeniY] != 1)
                {
                    oyuncu.X = yeniX;
                    oyuncu.Y = yeniY;
                }
            }
            if (zorlukModu.Harita[oyuncu.X, oyuncu.Y] == 2)
            {
                sureTimer.Stop();
                MessageBox.Show($"Tebrikler! Çıkışa ulaştınız.\nSüre: {gecenSaniye} sn\nSkor: {skor}", "Oyun Bitti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Veritabanına skor kaydı burada eklenecek
                this.Close();
            }
            this.Invalidate();
        }
    }
} 