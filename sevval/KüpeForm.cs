using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sevval
{
    public partial class KüpeForm : Form
    {
        private AnasayfaForm anasayfaForm;

        public KüpeForm(AnasayfaForm form)
        {
            InitializeComponent();
            anasayfaForm = form;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SepetimForm.Instance.SepeteEkle(label6.Text, label2.Text, pictureBox1.Image);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SepetimForm.Instance.SepeteEkle(label7.Text, label3.Text, pictureBox2.Image);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SepetimForm.Instance.SepeteEkle(label8.Text, label4.Text, pictureBox3.Image);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SepetimForm.Instance.SepeteEkle(label9.Text, label5.Text, pictureBox4.Image);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            anasayfaForm.Show();
            this.Close();
        }
    }
}
