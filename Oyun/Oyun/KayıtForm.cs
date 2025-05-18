using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oyun
{
    public partial class KayıtForm : Form
    {
        public KayıtForm()
        {
            InitializeComponent();
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            {
                string kullaniciAdi = txtKullaniciAdi.Text;
                string sifre = txtSifre.Text;

                if (kullaniciAdi == "" || sifre == "")
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun.");
                    return;
                }

                SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-IM6U7KIP ;Initial Catalog=Oyun;Integrated Security=True");
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO Kullanicilar (KullaniciAdi, Sifre) VALUES (@adi, @sifre)", conn);
                cmd.Parameters.AddWithValue("@adi", kullaniciAdi);
                cmd.Parameters.AddWithValue("@sifre", sifre);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kayıt başarılı! Giriş ekranına yönlendiriliyorsunuz.");
                    this.Close();  // Form kapanır, kullanıcı giriş ekranına döner
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }

                conn.Close();
            }

        }
    }
}
