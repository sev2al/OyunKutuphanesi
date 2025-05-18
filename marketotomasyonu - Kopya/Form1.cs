using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace marketotomasyonu
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }


        private void hesaplabtn_Click(object sender, EventArgs e)
        {
            double toplam = 0;
            
            toplam += Convert.ToDouble(ekmektxt.Text)*12;
            toplam += Convert.ToDouble(yumurtatxt.Text) * 2;
            toplam += Convert.ToDouble(peynirtxt.Text) * 57;
            toplam += Convert.ToDouble(domatestxt.Text) * 15;
            toplam += Convert.ToDouble(zeytintxt.Text) * 275;
            toplam += Convert.ToDouble(mandalinatxt.Text) * 23;
            toplam += Convert.ToDouble(pirinctxt.Text) * 72;
            toplam += Convert.ToDouble(petibortxt.Text) * 32;
            toplam += Convert.ToDouble(cokonattxt.Text) * 15;

            tutar.Text = toplam + "TL";
        }
    }
}
