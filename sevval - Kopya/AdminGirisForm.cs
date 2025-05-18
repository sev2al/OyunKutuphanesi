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
    public partial class AdminGirisForm : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=giyimotomasyon;Integrated Security=True");
        public AdminGirisForm()
        {
            InitializeComponent();
            button1.Click += AdminGirisbtn_Click;
        }

        private void AdminGirisbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(akullanicitxt.Text) || string.IsNullOrWhiteSpace(asifretxt.Text))
                {
                    MessageBox.Show("Lütfen kullanıcı adı ve şifrenizi giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (akullanicitxt.Text == "Admin" && asifretxt.Text == "admin1234")
                {
                    // Admin bilgilerini veritabanına kaydet
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("INSERT INTO Musteri (Ad, Soyad, Eposta, Sifre, Rol) VALUES (@ad, @soyad, @eposta, @sifre, @rol)", baglanti);
                    komut.Parameters.AddWithValue("@ad", "Admin");
                    komut.Parameters.AddWithValue("@soyad", "Admin");
                    komut.Parameters.AddWithValue("@eposta", "admin@admin.com");
                    komut.Parameters.AddWithValue("@sifre", "admin1234");
                    komut.Parameters.AddWithValue("@rol", "Admin");
                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    MessageBox.Show("Admin girişi başarılı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // AdminYonetimForm'a yönlendirme
                    AdminYonetimForm adminYonetimForm = new AdminYonetimForm();
                    adminYonetimForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
