using System;
using System.Drawing;
using System.Windows.Forms;

namespace OyunKutuphanesi
{
    public class Kart : Button
    {
        private int id;
        private Image resim;
        private bool acikMi;
        private bool eslestiMi;
        private Image arkaPlanResmi;

        public int Id => id;
        public bool AcikMi => acikMi;
        public bool EslestiMi => eslestiMi;

        public Kart(int id, Image resim)
        {
            this.id = id;
            this.resim = resim;
            this.acikMi = false;
            this.eslestiMi = false;

            // Button özellikleri
            this.Size = new Size(100, 100);
            this.Margin = new Padding(5);
            this.BackColor = Color.CornflowerBlue;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;

            // Varsayılan arka plan resmi (kart kapalıyken)
            this.arkaPlanResmi = new Bitmap(100, 100);
            using (Graphics g = Graphics.FromImage(arkaPlanResmi))
            {
                g.Clear(Color.CornflowerBlue);
                // Kart desenini çiz
                using (Pen pen = new Pen(Color.White, 2))
                {
                    g.DrawRectangle(pen, 10, 10, 80, 80);
                    g.DrawLine(pen, 10, 10, 90, 90);
                    g.DrawLine(pen, 90, 10, 10, 90);
                }
            }

            this.BackgroundImage = arkaPlanResmi;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        public void KartiGoster()
        {
            if (!eslestiMi)
            {
                acikMi = true;
                this.BackgroundImage = resim;
            }
        }

        public void KartiGizle()
        {
            if (!eslestiMi)
            {
                acikMi = false;
                this.BackgroundImage = arkaPlanResmi;
            }
        }

        public void KartiEslestir()
        {
            eslestiMi = true;
            acikMi = true;
            this.Enabled = false;
            this.BackColor = Color.WhiteSmoke;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (resim != null) resim.Dispose();
                if (arkaPlanResmi != null) arkaPlanResmi.Dispose();
            }
            base.Dispose(disposing);
        }
    }
} 