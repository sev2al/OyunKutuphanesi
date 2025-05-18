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

namespace sevval
{
    public partial class KullaniciGirisForm : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=giyimotomasyon;Integrated Security=True");
        public KullaniciGirisForm()
        {
            InitializeComponent();
            kayitbtn.Click += Kayitbtn_Click;
            girisbtn.Click += Girisbtn_Click;
        }

        private void Kayitbtn_Click(object sender, EventArgs e)
        {
            KullaniciKayitOl kullaniciKayitOl = new KullaniciKayitOl();
            kullaniciKayitOl.Show();
            this.Hide();
        }

        private void Girisbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(kullanicitxt.Text) || string.IsNullOrWhiteSpace(sifretxt.Text))
                {
                    MessageBox.Show("Lütfen e-posta ve şifrenizi giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT * FROM Musteri WHERE Eposta=@eposta AND Sifre=@sifre", baglanti);
                komut.Parameters.AddWithValue("@eposta", kullanicitxt.Text);
                komut.Parameters.AddWithValue("@sifre", sifretxt.Text);
                SqlDataReader dr = komut.ExecuteReader();

                if (dr.Read())
                {
                    MessageBox.Show("Giriş başarılı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // AnasayfaForm'a yönlendirme
                    AnasayfaForm anasayfaForm = new AnasayfaForm();
                    anasayfaForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("E-posta veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giriş işlemi sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
            }
        }
    }
}
