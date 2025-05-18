using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Oyun
{
    public partial class AdamAsmacaForm : Form
    {
        private OyunTemel oyun;
        string secilenKelime = "";
        string gosterilenKelime = "";
        int kalanHak = 6;
        List<char> yanlisHarfler = new List<char>();
        

        public AdamAsmacaForm()
        {
            InitializeComponent();
        }
        private void GorselGuncelle(int yanlisSayisi)
        {
            switch (yanlisSayisi)
            {
                case 0:
                    pictureBox1.Image = Properties.Resources._0;
                    break;
                case 1:
                    pictureBox1.Image = Properties.Resources._1;
                    break;
                case 2:
                    pictureBox1.Image = Properties.Resources._2;
                    break;
                case 3:
                    pictureBox1.Image = Properties.Resources._3;
                    break;
                case 4:
                    pictureBox1.Image = Properties.Resources._4;
                    break;
                case 5:
                    pictureBox1.Image = Properties.Resources._5;
                    break;
                case 6:
                    pictureBox1.Image = Properties.Resources._6;
                    break;
            }
        }

        private void btnTahmin_Click(object sender, EventArgs e)
        {
            {
                if (string.IsNullOrWhiteSpace(txtHarf.Text)) return;

                char harf = txtHarf.Text.ToLower()[0];
                txtHarf.Clear();

                if (secilenKelime.Contains(harf))
                {
                    char[] gosterilen = gosterilenKelime.ToCharArray();
                    for (int i = 0; i < secilenKelime.Length; i++)
                    {
                        if (secilenKelime[i] == harf)
                            gosterilen[i] = harf;
                    }
                    gosterilenKelime = new string(gosterilen);
                    label1.Text = gosterilenKelime;
                }
                else
                {
                    if (!yanlisHarfler.Contains(harf))
                    {
                        yanlisHarfler.Add(harf);
                        kalanHak--;
                        label2.Text = $"Kalan Hakkınız: {kalanHak}";
                        listBox1.Items.Add(harf);
                        GorselGuncelle(yanlisHarfler.Count);
                    }
                }

                if (!gosterilenKelime.Contains('_'))
                {
                    MessageBox.Show("Kazandınız!");
                }
                else if (kalanHak <= 0)
                {
                    MessageBox.Show($"Kaybettiniz! Kelime: {secilenKelime}");
                }


            }


        }

        private void btnBasla_Click(object sender, EventArgs e)
        {
            {
                

                List<string> kolayKelimeler = new List<string> { "masa", "kedi", "elma", "çorap", "fener" };
                List<string> ortaKelimeler = new List<string> { "kitap", "kalem", "bardak", "merdiven" };
                List<string> zorKelimeler = new List<string> { "bilgisayar", "telefon", "ayakkabı", "anahtar", "pencere" };

                string zorluk = comboBox1.SelectedItem?.ToString();

                Random rnd = new Random();
                if (zorluk == "Kolay")
                    secilenKelime = kolayKelimeler[rnd.Next(kolayKelimeler.Count)];
                else if (zorluk == "Orta")
                    secilenKelime = ortaKelimeler[rnd.Next(ortaKelimeler.Count)];
                else if (zorluk == "Zor")
                    secilenKelime = zorKelimeler[rnd.Next(zorKelimeler.Count)];
                else
                    secilenKelime = "masa"; // varsayılan

                kalanHak = 6;
                yanlisHarfler.Clear();
                gosterilenKelime = new string('_', secilenKelime.Length);

                label1.Text = gosterilenKelime;
                label2.Text = $"Kalan Hakkınız: {kalanHak}";
                listBox1.Items.Clear();
                GorselGuncelle(0);
            }


        }

        private void btnAnaSayfa_Click(object sender, EventArgs e)
        {
            AnaSayfaForm anaSayfa = new AnaSayfaForm();
            anaSayfa.Show();
            this.Hide();  // AdamAsmaca formunu gizle

        }
    }
}
