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
    public partial class FormGirisEkrani : Form
    {
        public FormGirisEkrani()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            try
            {
                string kullaniciAdi = txtKullaniciAdi.Text.Trim();
                string sifre = txtSifre.Text.Trim();

                if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
                {
                    MessageBox.Show("Kullanıcı adı ve şifre alanları boş bırakılamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection baglanti = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["OyunBaglantisi"].ConnectionString))
                {
                    baglanti.Open();
                    string sorgu = "SELECT * FROM Kullanicilar WHERE KullaniciAdi = @KullaniciAdi AND Sifre = @Sifre";
                    
                    using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                        komut.Parameters.AddWithValue("@Sifre", sifre);
                        
                        using (SqlDataAdapter adapter = new SqlDataAdapter(komut))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            
                            if (dt.Rows.Count > 0)
                            {
                                int kullaniciID = Convert.ToInt32(dt.Rows[0]["KullaniciID"]);
                                Program.GirisYapanKullaniciID = kullaniciID;
                                // Oturumlar tablosuna giriş kaydı ekle
                                using (SqlConnection baglantiOturumlar = VeritabaniBaglantisi.BaglantiOlustur())
                                {
                                    string sorguOturumlar = "INSERT INTO Oturumlar (KullaniciID, GirisZamani) VALUES (@KullaniciID, GETDATE())";
                                    SqlCommand komutOturumlar = new SqlCommand(sorguOturumlar, baglantiOturumlar);
                                    komutOturumlar.Parameters.AddWithValue("@KullaniciID", kullaniciID);
                                    komutOturumlar.ExecuteNonQuery();
                                }
                                MessageBox.Show("Giriş başarılı! Hoş geldiniz.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                
                                // Ana sayfa formunu aç
                                Form1 anaSayfa = new Form1();
                                this.Hide();
                                anaSayfa.ShowDialog();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void lnkKayitOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormKayitOl kayitForm = new FormKayitOl();
            this.Hide();
            kayitForm.ShowDialog();
            this.Show();
        }
    }
} 