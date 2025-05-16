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

namespace OyunKutuphanesi
{
    public partial class FormKayitOl : Form
    {
        public FormKayitOl()
        {
            InitializeComponent();
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            try
            {
                string kullaniciAdi = txtKullaniciAdi.Text.Trim();
                string sifre = txtSifre.Text.Trim();
                string sifreOnay = txtSifreOnay.Text.Trim();
                string adi = txtAd.Text.Trim();
                string soyadi = txtSoyad.Text.Trim();

                // Validasyon kontrolleri
                if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre) || string.IsNullOrEmpty(sifreOnay) || string.IsNullOrEmpty(adi) || string.IsNullOrEmpty(soyadi))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (sifre != sifreOnay)
                {
                    MessageBox.Show("Şifreler eşleşmiyor!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection baglanti = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["OyunBaglantisi"].ConnectionString))
                {
                    baglanti.Open();

                    // Kullanıcı adı kontrolü
                    string kontrolSorgu = "SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciAdi = @KullaniciAdi";
                    using (SqlCommand kontrolKomut = new SqlCommand(kontrolSorgu, baglanti))
                    {
                        kontrolKomut.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                        int kullaniciSayisi = (int)kontrolKomut.ExecuteScalar();

                        if (kullaniciSayisi > 0)
                        {
                            MessageBox.Show("Bu kullanıcı adı zaten kayıtlı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Kayıt işlemi
                        string kayitSorgu = @"INSERT INTO Kullanicilar (KullaniciAdi, Sifre, Ad, Soyad) 
                                   VALUES (@KullaniciAdi, @Sifre,  @Ad, @Soyad)";

                        using (SqlCommand kayitKomut = new SqlCommand(kayitSorgu, baglanti))
                        {
                            kayitKomut.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                            kayitKomut.Parameters.AddWithValue("@Sifre", sifre);
                            kayitKomut.Parameters.AddWithValue("@Ad", adi);
                            kayitKomut.Parameters.AddWithValue("@Soyad", soyadi);

                            int sonuc = kayitKomut.ExecuteNonQuery();

                            if (sonuc > 0)
                            {
                                MessageBox.Show("Kayıt işlemi başarılı! Giriş yapabilirsiniz.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Kayıt sırasında bir hata oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
} 