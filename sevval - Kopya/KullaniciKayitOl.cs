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
    public partial class KullaniciKayitOl : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=giyimotomasyon;Integrated Security=True");
        public KullaniciKayitOl()
        {
            InitializeComponent();
            button1.Click += Kaydetbtn_Click;
        }

        private void Kaydetbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox4.Text) || 
                    string.IsNullOrWhiteSpace(textBox1.Text) ||
                    string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                baglanti.Open();
                SqlCommand komut = new SqlCommand("INSERT INTO Musteri (Ad, Soyad, Eposta, Sifre, Rol) VALUES (@ad, @soyad, @eposta, @sifre, @rol)", baglanti);
                komut.Parameters.AddWithValue("@ad", textBox1.Text);
                komut.Parameters.AddWithValue("@soyad", textBox2.Text);
                komut.Parameters.AddWithValue("@eposta", textBox3.Text);
                komut.Parameters.AddWithValue("@sifre", textBox4.Text);
                komut.Parameters.AddWithValue("@rol", "Musteri");
                komut.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Kayıt işlemi başarıyla tamamlandı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // AnasayfaForm'a yönlendirme
                AnasayfaForm anasayfaForm = new AnasayfaForm();
                anasayfaForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt işlemi sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
