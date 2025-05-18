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
        public KullaniciKayitOl()
        {
            InitializeComponent();
            button1.Click += Kaydetbtn_Click;
        }

        private bool EpostaKontrol(string eposta)
        {
            try
            {
                Database.conn.Open();
                SqlCommand komut = new SqlCommand("SELECT COUNT(*) FROM Musteri WHERE Eposta = @eposta", Database.conn);
                komut.Parameters.AddWithValue("@eposta", eposta);
                int kayitSayisi = (int)komut.ExecuteScalar();
                return kayitSayisi > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("E-posta kontrolü sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true; // Hata durumunda güvenli tarafta kalmak için true döndürüyoruz
            }
            finally
            {
                if (Database.conn.State == ConnectionState.Open)
                    Database.conn.Close();
            }
        }

        private void Kaydetbtn_Click(object sender, EventArgs e)
        {
            if (!Database.TestConnection())
            {
                MessageBox.Show("Veritabanı bağlantısı kurulamadı. Lütfen SQL Server'ın çalıştığından emin olun.", "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

                // E-posta kontrolü
                if (EpostaKontrol(textBox3.Text))
                {
                    MessageBox.Show("Bu e-posta adresi zaten kayıtlı! Lütfen farklı bir e-posta adresi kullanın.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Database.conn.Open();
                SqlCommand komut = new SqlCommand("INSERT INTO Musteri (Ad, Soyad, Eposta, Sifre, Rol) VALUES (@ad, @soyad, @eposta, @sifre, @rol)", Database.conn);
                komut.Parameters.AddWithValue("@ad", textBox1.Text);
                komut.Parameters.AddWithValue("@soyad", textBox2.Text);
                komut.Parameters.AddWithValue("@eposta", textBox3.Text);
                komut.Parameters.AddWithValue("@sifre", textBox4.Text);
                komut.Parameters.AddWithValue("@rol", "Musteri");
                
                int result = komut.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Kayıt işlemi başarıyla tamamlandı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // AnasayfaForm'a yönlendirme
                    AnasayfaForm anasayfaForm = new AnasayfaForm();
                    anasayfaForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kayıt işlemi gerçekleştirilemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {
                string errorMessage = "Veritabanı hatası: ";
                switch (ex.Number)
                {
                    case 2627: // Unique constraint violation
                        errorMessage += "Bu e-posta adresi zaten kayıtlı.";
                        break;
                    case 547: // Constraint violation
                        errorMessage += "Geçersiz veri girişi.";
                        break;
                    default:
                        errorMessage += ex.Message;
                        break;
                }
                MessageBox.Show(errorMessage, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beklenmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (Database.conn.State == ConnectionState.Open)
                    Database.conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
