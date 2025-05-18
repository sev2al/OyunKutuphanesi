using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace marketotomasyonu2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void hesaplabtn_Click(object sender, EventArgs e)
        {
            int toplam = 0;

            toplam += Convert.ToInt32(elmatxt.Text) * 25;

            if (cipscb.SelectedItem != null)
            {
                string scips = cipscb.SelectedItem.ToString();
                if (scips.Contains("Lays")) toplam += 35;
                else if (scips.Contains("Ruffles")) toplam += 25;
                else if (scips.Contains("Patos")) toplam += 30;
                else if (scips.Contains("Çerazza")) toplam += 20;
                else if (scips.Contains("Pringles")) toplam += 50;
            }

            if (cikolatacb.SelectedItem != null)
            {
                string sciko = cikolatacb.SelectedItem.ToString();
                if (sciko.Contains("Albeni")) toplam += 15;
                else if (sciko.Contains("Dido")) toplam += 12;
                else if (sciko.Contains("Nutymax")) toplam += 25;
                else if (sciko.Contains("Karam")) toplam += 10;
            }

            if (yumurtacb.SelectedItem != null)
            {
                string sy = yumurtacb.SelectedItem.ToString();
                if (sy.Contains("Köy yumurtası")) toplam += 200;
                else if (sy.Contains("Gezen tavuk yumurtası")) toplam += 150;
                else if (sy.Contains("Normal yumurta")) toplam += 110;
            }
            toplam += Convert.ToInt32(sakiztxt.Text) * 12;

            tutar.Text = toplam + "TL";
        }
    }
}
