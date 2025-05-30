﻿using System;
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
    public partial class TisortForm : Form
    {
        private AnasayfaForm anasayfaForm;

        public TisortForm()
        {
            InitializeComponent();
        }

        public TisortForm(AnasayfaForm anasayfaForm)
        {
            InitializeComponent();
            this.anasayfaForm = anasayfaForm;
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
            if (anasayfaForm != null)
            {
                anasayfaForm.Show();
            }
            this.Close();
        }

        private void TisortForm_Load(object sender, EventArgs e)
        {

        }
    }
}
