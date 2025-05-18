using System;
using System.Drawing;
using System.Windows.Forms;
using GiyimOtomasyonuFinalProject.Models;

namespace GiyimOtomasyonuFinalProject
{
    /// <summary>
    /// Giriş ekranı formu
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Form yapıcı metodu
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form yüklenirken çalışan metot
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            // Form başlığını ayarla
            this.Text = "Giyim Otomasyonu - Giriş";
            
            // Şifre alanının şifrelenmiş görünmesini sağla
            txtSifre.PasswordChar = '*';
        }

        /// <summary>
        /// Giriş butonuna tıklandığında çalışan metot
        /// </summary>
        private void btnGiris_Click(object sender, EventArgs e)
        {
            string eposta = txtEposta.Text.Trim();
            string sifre = txtSifre.Text.Trim();
            
            // Boş alan kontrolü
            if (string.IsNullOrEmpty(eposta) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("E-posta ve şifre alanları boş bırakılamaz.", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            try
            {
                // Kullanıcı girişi kontrolü
                Musteri musteri = Musteri.Giris(eposta, sifre);
                
                if (musteri != null)
                {
                    // Giriş başarılı
                    MessageBox.Show($"Hoşgeldiniz {musteri.TamAd}", "Başarılı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Kullanıcı tipine göre farklı form aç
                    if (!string.IsNullOrEmpty(musteri.Rol))
                    {
                        if (musteri.Rol == "Admin")
                        {
                            // Admin paneline yönlendir
                            AdminPanelForm adminPanel = new AdminPanelForm(musteri);
                            this.Hide();
                            adminPanel.ShowDialog();
                            this.Show();
                        }
                        else
                        {
                            // Müşteri paneline yönlendir
                            if (musteri.MusteriId > 0 && !string.IsNullOrEmpty(musteri.Ad) && !string.IsNullOrEmpty(musteri.Soyad))
                            {
                                MusteriPanelForm musteriPanel = new MusteriPanelForm(musteri);
                                this.Hide();
                                musteriPanel.ShowDialog();
                                this.Show();
                            }
                            else
                            {
                                MessageBox.Show("Müşteri bilgisi eksik veya hatalı. Lütfen tekrar giriş yapın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı rolü bulunamadı. Lütfen sistem yöneticisine başvurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                    // Giriş alanlarını temizle
                    txtEposta.Clear();
                    txtSifre.Clear();
                }
                else
                {
                    // Giriş başarısız
                    MessageBox.Show("E-posta veya şifre hatalı.", "Hata", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda mesaj göster
                MessageBox.Show($"Giriş sırasında bir hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Yeni kayıt butonuna tıklandığında çalışan metot
        /// </summary>
        private void btnYeniKayit_Click(object sender, EventArgs e)
        {
            // Yeni kayıt formunu aç
            YeniKayitForm yeniKayitForm = new YeniKayitForm();
            this.Hide();
            yeniKayitForm.ShowDialog();
            this.Show();
        }

        /// <summary>
        /// Çıkış butonuna tıklandığında çalışan metot
        /// </summary>
        private void btnCikis_Click(object sender, EventArgs e)
        {
            // Uygulamadan çık
            Application.Exit();
        }
    }
}
