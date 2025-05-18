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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            adminbtn.Click += Adminbtn_Click;
            kullanicibtn.Click += Kullanicibtn_Click;
        }

        private void Adminbtn_Click(object sender, EventArgs e)
        {
            AdminGirisForm adminGirisForm = new AdminGirisForm();
            adminGirisForm.Show();
            this.Hide();
        }

        private void Kullanicibtn_Click(object sender, EventArgs e)
        {
            KullaniciGirisForm kullaniciGirisForm = new KullaniciGirisForm();
            kullaniciGirisForm.Show();
            this.Hide();
        }
    }
}
