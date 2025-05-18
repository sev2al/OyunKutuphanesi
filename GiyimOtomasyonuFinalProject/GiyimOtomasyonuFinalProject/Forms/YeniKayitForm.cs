using System;
using System.Drawing;
using System.Windows.Forms;
using GiyimOtomasyonuFinalProject.Models;

namespace GiyimOtomasyonuFinalProject
{
    /// <summary>
    /// Yeni kullanıcı kaydı formu
    /// </summary>
    public partial class YeniKayitForm : Form
    {
        /// <summary>
        /// Form yapıcı metodu
        /// </summary>
        public YeniKayitForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form yüklenirken çalışan metot
        /// </summary>
        private void YeniKayitForm_Load(object sender, EventArgs e)
        {
            // Form başlığını ayarla
            this.Text = "Giyim Otomasyonu - Yeni Üyelik";
            
            // Şifre alanlarının şifrelenmiş görünmesini sağla
            txtSifre.PasswordChar = '*';
            txtSifreTekrar.PasswordChar = '*';
        }

        /// <summary>
        /// Kaydet butonuna tıklandığında çalışan metot
        /// </summary>
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // Form alanlarını doğrula
            if (!FormAlanlariGecerli())
                return;
                
            try
            {
                // Yeni müşteri nesnesi oluştur
                Musteri yeniMusteri = new Musteri
                {
                    Ad = txtAd.Text.Trim(),
                    Soyad = txtSoyad.Text.Trim(),
                    Eposta = txtEposta.Text.Trim(),
                    Sifre = txtSifre.Text.Trim(), // Gerçek bir uygulamada şifreyi hashleyerek saklamamız gerekir
                    Puan = 0,
                    Rol = "Musteri" // Varsayılan olarak müşteri rolü ata
                };
                
                // Veritabanına ekle
                int musteriId = yeniMusteri.Ekle();
                
                if (musteriId > 0)
                {
                    // Adres kaydı
                    Adres adres = new Adres
                    {
                        MusteriId = musteriId,
                        AdresBilgisi = txtAdres.Text.Trim(),
                        Sehir = txtSehir.Text.Trim(),
                        Ilce = txtIlce.Text.Trim(),
                        PostaKodu = txtPostaKodu.Text.Trim()
                    };
                    
                    adres.Ekle();
                    
                    MessageBox.Show("Kaydınız başarıyla tamamlandı!", "Başarılı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    // Kayıt başarılı olduğunda formu kapat
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Kayıt işlemi sırasında bir hata oluştu.", "Hata", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kayıt sırasında bir hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// İptal butonuna tıklandığında çalışan metot
        /// </summary>
        private void btnIptal_Click(object sender, EventArgs e)
        {
            // İptal edildiğinde formu kapat
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Form alanlarının geçerliliğini kontrol eder
        /// </summary>
        /// <returns>Tüm alanlar geçerli ise true, değilse false</returns>
        private bool FormAlanlariGecerli()
        {
            // Boş alan kontrolü
            if (string.IsNullOrEmpty(txtAd.Text) || string.IsNullOrEmpty(txtSoyad.Text) ||
                string.IsNullOrEmpty(txtEposta.Text) || string.IsNullOrEmpty(txtSifre.Text) ||
                string.IsNullOrEmpty(txtSifreTekrar.Text) || string.IsNullOrEmpty(txtAdres.Text) ||
                string.IsNullOrEmpty(txtSehir.Text) || string.IsNullOrEmpty(txtIlce.Text) ||
                string.IsNullOrEmpty(txtPostaKodu.Text))
            {
                MessageBox.Show("Tüm alanları doldurunuz.", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            // E-posta formatı kontrolü
            if (!txtEposta.Text.Contains("@") || !txtEposta.Text.Contains("."))
            {
                MessageBox.Show("Geçerli bir e-posta adresi giriniz.", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            // Şifre uzunluğu kontrolü
            if (txtSifre.Text.Length < 6)
            {
                MessageBox.Show("Şifre en az 6 karakter olmalıdır.", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            // Şifre tekrarı kontrolü
            if (txtSifre.Text != txtSifreTekrar.Text)
            {
                MessageBox.Show("Şifreler eşleşmiyor.", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            return true;
        }
    }
} 