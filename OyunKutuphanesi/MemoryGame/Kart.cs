using System;
using System.Drawing;
using System.Windows.Forms;

namespace OyunKutuphanesi.HafizaOyunu
{
    public class Kart : Button
    {
        public int Id { get; private set; }
        public Image Resim { get; private set; }
        public bool EslestiMi { get; set; }
        private bool acikMi;

        public Kart(int id, Image resim)
        {
            Id = id;
            Resim = resim;
            EslestiMi = false;
            acikMi = false;
            
            // Button özellikleri
            Size = new Size(80, 80);
            BackColor = Color.Gray;
            FlatStyle = FlatStyle.Flat;
            Margin = new Padding(4);
        }

        public bool AcikMi
        {
            get { return acikMi; }
            set
            {
                acikMi = value;
                if (acikMi)
                {
                    BackgroundImage = Resim;
                }
                else
                {
                    BackgroundImage = null;
                }
                BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        public void KartiGizle()
        {
            if (!EslestiMi)
            {
                AcikMi = false;
            }
        }

        public void KartiGoster()
        {
            if (!EslestiMi)
            {
                AcikMi = true;
            }
        }
    }
} 