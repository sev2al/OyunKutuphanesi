using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static Oyun.Veritabanı;


namespace Oyun
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        private string kullaniciAdi;

        public Form1(string kullaniciAdi)
        {
            InitializeComponent();
            this.kullaniciAdi = kullaniciAdi;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
                try
                {
                    using (SqlConnection conn = new SqlConnection(Veritabani.connectionString))
                    {
                        conn.Open();
                    }
                }
                catch (Exception ex)
                {
                }

        }


        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            
            {
                AnaSayfaForm anaSayfa = new AnaSayfaForm();
                anaSayfa.Show();
                this.Hide();  
 
                string kullaniciAdi = txtKullaniciAdi.Text;
                string sifre = txtSifre.Text;

                using (SqlConnection conn = new SqlConnection(Veritabani.connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Kullanicilar WHERE KullaniciAdi = @kullaniciAdi AND Sifre = @sifre";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                    cmd.Parameters.AddWithValue("@sifre", sifre);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        MessageBox.Show("Giriş başarılı!");
                        // Ana ekranı aç
                        this.Hide();
                        Form1 anaEkran = new Form1(kullaniciAdi); 
                        anaEkran.Show();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre yanlış!");
                    }
                }
            }

        }
        private void btnKayit_Click(object sender, EventArgs e)
        {
            KayıtForm kayitForm = new KayıtForm();
            kayitForm.ShowDialog(); 
        }
    }
}
