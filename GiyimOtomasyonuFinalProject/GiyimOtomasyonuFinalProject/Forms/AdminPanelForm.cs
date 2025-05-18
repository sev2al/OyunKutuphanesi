using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using GiyimOtomasyonuFinalProject.Models;
using System.Data;
using System.Linq;

namespace GiyimOtomasyonuFinalProject
{
    /// <summary>
    /// Admin işlemleri için panel formu
    /// </summary>
    public partial class AdminPanelForm : Form
    {
        // Giriş yapan admin bilgisi
        private Musteri _girisYapanAdmin;
        // Seçilen fotoğraf yolu
        private string _seciliFotografYolu = null;

        /// <summary>
        /// Form yapıcı metodu
        /// </summary>
        /// <param name="admin">Giriş yapan admin</param>
        public AdminPanelForm(Musteri admin)
        {
            InitializeComponent();
            _girisYapanAdmin = admin;
        }
        
        /// <summary>
        /// Form yüklenirken çalışan metot
        /// </summary>
        private void AdminPanelForm_Load(object sender, EventArgs e)
        {
            // Form başlığını ayarla
            this.Text = $"Giyim Otomasyonu - Admin Paneli - {_girisYapanAdmin.TamAd}";
            
            // Admin bilgilerini göster
            lblAdminAd.Text = _girisYapanAdmin.TamAd;
            
            // Kategori listesini doldur
            KategorileriDoldur();
            
            // Ürünleri listele
            UrunleriListele();
            
            // Müşterileri listele
            MusterileriListele();
            
            // Satışları listele
            SatislariListele();
        }

        /// <summary>
        /// Kategorileri doldur
        /// </summary>
        private void KategorileriDoldur()
        {
            try
            {
                // Sadece ürünü olan kategorileri getir
                List<Kategori> kategoriler = Kategori.TumunuGetir();
                
                // ComboBox'a ekle
                cmbKategori.DisplayMember = "KategoriAdi";
                cmbKategori.ValueMember = "KategoriId";
                cmbKategori.DataSource = kategoriler;
                
                // ListBox'a da ekle (tüm kategoriler görünsün istiyorsan eski haliyle bırakabilirsin)
                lstKategoriler.DisplayMember = "KategoriAdi";
                lstKategoriler.ValueMember = "KategoriId";
                lstKategoriler.DataSource = kategoriler;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kategoriler yüklenirken bir hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Ürünleri listele
        /// </summary>
        private void UrunleriListele()
        {
            try
            {
                // Tüm ürünleri al
                List<Urun> urunler = Urun.TumunuGetir();
                
                // DataGridView özelliklerini ayarla
                dgvUrunler.AutoGenerateColumns = false;
                
                // Sütunları temizle
                dgvUrunler.Columns.Clear();
                
                // Sütunları ekle
                DataGridViewTextBoxColumn kolUrunId = new DataGridViewTextBoxColumn();
                kolUrunId.DataPropertyName = "UrunId";
                kolUrunId.HeaderText = "Ürün ID";
                kolUrunId.Width = 70;
                kolUrunId.ReadOnly = true;
                dgvUrunler.Columns.Add(kolUrunId);
                
                DataGridViewTextBoxColumn kolUrunAdi = new DataGridViewTextBoxColumn();
                kolUrunAdi.DataPropertyName = "UrunAdi";
                kolUrunAdi.HeaderText = "Ürün Adı";
                kolUrunAdi.Width = 200;
                kolUrunAdi.ReadOnly = true;
                dgvUrunler.Columns.Add(kolUrunAdi);
                
                DataGridViewTextBoxColumn kolFiyat = new DataGridViewTextBoxColumn();
                kolFiyat.DataPropertyName = "Fiyat";
                kolFiyat.HeaderText = "Fiyat";
                kolFiyat.Width = 100;
                kolFiyat.ReadOnly = true;
                kolFiyat.DefaultCellStyle.Format = "C2";
                dgvUrunler.Columns.Add(kolFiyat);
                
                DataGridViewTextBoxColumn kolStok = new DataGridViewTextBoxColumn();
                kolStok.DataPropertyName = "StokMiktari";
                kolStok.HeaderText = "Stok";
                kolStok.Width = 70;
                kolStok.ReadOnly = true;
                dgvUrunler.Columns.Add(kolStok);
                
                DataGridViewTextBoxColumn kolKategori = new DataGridViewTextBoxColumn();
                kolKategori.DataPropertyName = "Kategori.KategoriAdi";
                kolKategori.HeaderText = "Kategori";
                kolKategori.Width = 150;
                kolKategori.ReadOnly = true;
                dgvUrunler.Columns.Add(kolKategori);
                
                DataGridViewImageColumn kolResim = new DataGridViewImageColumn();
                kolResim.Name = "Resim";
                kolResim.HeaderText = "Resim";
                kolResim.Width = 80;
                kolResim.ReadOnly = true;
                kolResim.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dgvUrunler.Columns.Add(kolResim);
                
                // DataGridView'e ekle
                dgvUrunler.DataSource = urunler;
                
                // Resim sütununu doldur
                foreach (DataGridViewRow row in dgvUrunler.Rows)
                {
                    Urun urun = row.DataBoundItem as Urun;
                    if (urun != null && !string.IsNullOrEmpty(urun.FotografYolu))
                    {
                        string dosyaYolu = Path.Combine(Application.StartupPath, urun.FotografYolu);
                        if (File.Exists(dosyaYolu))
                        {
                            try
                            {
                                // Resmi yükle
                                using (FileStream stream = new FileStream(dosyaYolu, FileMode.Open, FileAccess.Read))
                                {
                                    row.Cells["Resim"].Value = Image.FromStream(stream);
                                }
                            }
                            catch
                            {
                                // Resim yüklenemezse devam et
                                row.Cells["Resim"].Value = null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürünler listelenirken bir hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Müşterileri listele
        /// </summary>
        private void MusterileriListele()
        {
            try
            {
                // Tüm müşterileri al
                List<Musteri> musteriler = Musteri.TumunuGetir();
                
                // DataGridView özelliklerini ayarla
                dgvMusteriler.AutoGenerateColumns = false;
                
                // Sütunları temizle
                dgvMusteriler.Columns.Clear();
                
                // Sütunları ekle
                DataGridViewTextBoxColumn kolMusteriId = new DataGridViewTextBoxColumn();
                kolMusteriId.DataPropertyName = "MusteriId";
                kolMusteriId.HeaderText = "Müşteri ID";
                kolMusteriId.Width = 80;
                dgvMusteriler.Columns.Add(kolMusteriId);

                DataGridViewTextBoxColumn kolAd = new DataGridViewTextBoxColumn();
                kolAd.DataPropertyName = "Ad";
                kolAd.HeaderText = "Ad";
                kolAd.Width = 100;
                dgvMusteriler.Columns.Add(kolAd);

                DataGridViewTextBoxColumn kolSoyad = new DataGridViewTextBoxColumn();
                kolSoyad.DataPropertyName = "Soyad";
                kolSoyad.HeaderText = "Soyad";
                kolSoyad.Width = 100;
                dgvMusteriler.Columns.Add(kolSoyad);

                DataGridViewTextBoxColumn kolEposta = new DataGridViewTextBoxColumn();
                kolEposta.DataPropertyName = "Eposta";
                kolEposta.HeaderText = "E-posta";
                kolEposta.Width = 150;
                dgvMusteriler.Columns.Add(kolEposta);

                DataGridViewTextBoxColumn kolPuan = new DataGridViewTextBoxColumn();
                kolPuan.DataPropertyName = "Puan";
                kolPuan.HeaderText = "Puan";
                kolPuan.Width = 80;
                dgvMusteriler.Columns.Add(kolPuan);

                DataGridViewTextBoxColumn kolRol = new DataGridViewTextBoxColumn();
                kolRol.DataPropertyName = "Rol";
                kolRol.HeaderText = "Rol";
                kolRol.Width = 80;
                dgvMusteriler.Columns.Add(kolRol);

                // Sadakat raporu için ek sütunlar
                if (chkSadakatRaporu.Checked)
                {
                    DataGridViewTextBoxColumn kolAlisverisSayisi = new DataGridViewTextBoxColumn();
                    kolAlisverisSayisi.DataPropertyName = "AlisverisSayisi";
                    kolAlisverisSayisi.HeaderText = "Alışveriş Sayısı";
                    kolAlisverisSayisi.Width = 100;
                    dgvMusteriler.Columns.Add(kolAlisverisSayisi);

                    DataGridViewTextBoxColumn kolToplamHarcama = new DataGridViewTextBoxColumn();
                    kolToplamHarcama.DataPropertyName = "ToplamHarcama";
                    kolToplamHarcama.HeaderText = "Toplam Harcama";
                    kolToplamHarcama.Width = 120;
                    kolToplamHarcama.DefaultCellStyle.Format = "C2";
                    dgvMusteriler.Columns.Add(kolToplamHarcama);

                    DataGridViewTextBoxColumn kolSonAlisveris = new DataGridViewTextBoxColumn();
                    kolSonAlisveris.DataPropertyName = "SonAlisverisTarihi";
                    kolSonAlisveris.HeaderText = "Son Alışveriş";
                    kolSonAlisveris.Width = 120;
                    dgvMusteriler.Columns.Add(kolSonAlisveris);

                    // Sadakat raporu sorgusu
                    string query = @"
                        SELECT 
                            m.MusteriId,
                            m.Ad,
                            m.Soyad,
                            m.Eposta,
                            m.Puan,
                            m.Rol,
                            COUNT(s.SatisId) as AlisverisSayisi,
                            ISNULL(SUM(s.ToplamTutar), 0) as ToplamHarcama,
                            MAX(s.Tarih) as SonAlisverisTarihi
                        FROM Musteri m
                        LEFT JOIN Satis s ON m.MusteriId = s.MusteriId
                        WHERE m.Rol != 'Admin'
                        GROUP BY m.MusteriId, m.Ad, m.Soyad, m.Eposta, m.Puan, m.Rol
                        ORDER BY AlisverisSayisi DESC";

                    DataTable table = Database.ExecuteQuery(query);
                    dgvMusteriler.DataSource = table;
                }
                else
                {
                    // Normal müşteri listesi - Admin olmayanları filtrele
                    var normalMusteriler = musteriler.Where(m => m.Rol != "Admin").ToList();
                    dgvMusteriler.DataSource = normalMusteriler;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Müşteriler listelenirken bir hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Satışları listele
        /// </summary>
        private void SatislariListele()
        {
            try
            {
                // Tüm satışları al
                List<Satis> satislar = Satis.TumunuGetir();
                // DataGridView özelliklerini ayarla
                dgvSatislar.AutoGenerateColumns = false;
                // Sütunları temizle
                dgvSatislar.Columns.Clear();
                // Sütunları ekle
                dgvSatislar.Columns.Add("SatisId", "Satış ID");
                dgvSatislar.Columns.Add("MusteriAd", "Müşteri");
                dgvSatislar.Columns.Add("Tarih", "Tarih");
                dgvSatislar.Columns.Add("ToplamTutar", "Tutar");
                dgvSatislar.Columns.Add("OdemeTuru", "Ödeme Türü");
                dgvSatislar.Columns.Add("KargoDurumu", "Kargo Durumu");
                // Satırları ekle
                dgvSatislar.Rows.Clear();
                foreach (var satis in satislar)
                {
                    int rowIdx = dgvSatislar.Rows.Add(
                        satis.SatisId,
                        satis.Musteri != null ? satis.Musteri.TamAd : "-",
                        satis.Tarih.ToString("dd.MM.yyyy HH:mm"),
                        satis.ToplamTutar.ToString("C2"),
                        satis.OdemeTuru,
                        satis.KargoDurumu
                    );
                    // Kargo durumuna göre renklendirme
                    var row = dgvSatislar.Rows[rowIdx];
                    if (satis.KargoDurumu == "Hazırlanıyor")
                    {
                        row.Cells["KargoDurumu"].Style.ForeColor = Color.DarkOrange;
                        row.Cells["KargoDurumu"].Style.Font = new Font(dgvSatislar.Font, FontStyle.Bold);
                    }
                    else if (satis.KargoDurumu == "Kargoya Verildi")
                    {
                        row.Cells["KargoDurumu"].Style.ForeColor = Color.Blue;
                        row.Cells["KargoDurumu"].Style.Font = new Font(dgvSatislar.Font, FontStyle.Bold);
                    }
                    else if (satis.KargoDurumu == "Teslim Edildi")
                    {
                        row.Cells["KargoDurumu"].Style.ForeColor = Color.Green;
                        row.Cells["KargoDurumu"].Style.Font = new Font(dgvSatislar.Font, FontStyle.Bold);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Satışlar listelenirken bir hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Yeni kategori ekle butonuna tıklandığında çalışan metot
        /// </summary>
        private void btnKategoriEkle_Click(object sender, EventArgs e)
        {
            try
            {
                string kategoriAdi = txtKategoriAdi.Text.Trim();
                
                // Boş alan kontrolü
                if (string.IsNullOrEmpty(kategoriAdi))
                {
                    MessageBox.Show("Kategori adı boş olamaz.", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                // Yeni kategori oluştur
                Kategori yeniKategori = new Kategori
                {
                    KategoriAdi = kategoriAdi
                };
                
                // Veritabanına ekle
                int kategoriId = yeniKategori.Ekle();
                
                if (kategoriId > 0)
                {
                    MessageBox.Show("Kategori başarıyla eklendi.", "Bilgi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    // Form elemanlarını güncelle
                    txtKategoriAdi.Clear();
                    KategorileriDoldur();
                }
                else
                {
                    MessageBox.Show("Kategori eklenirken bir hata oluştu.", "Hata", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İşlem sırasında bir hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Kategori düzenleme butonuna tıklandığında çalışan metot
        /// </summary>
        private void btnKategoriDuzenle_Click(object sender, EventArgs e)
        {
            // Seçili kategori kontrolü
            if (lstKategoriler.SelectedItem == null)
            {
                MessageBox.Show("Lütfen düzenlemek için bir kategori seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Kategori seciliKategori = (Kategori)lstKategoriler.SelectedItem;
            // Düzenleme formu oluştur
            Form duzenleForm = new Form
            {
                Width = 350,
                Height = 180,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                Text = "Kategori Düzenle",
                MaximizeBox = false,
                MinimizeBox = false
            };
            Label lblAd = new Label { Text = "Kategori Adı:", Location = new Point(20, 30), AutoSize = true };
            TextBox txtAd = new TextBox { Location = new Point(120, 30), Width = 180, Text = seciliKategori.KategoriAdi };
            Button btnKaydet = new Button { Text = "Kaydet", DialogResult = DialogResult.OK, Location = new Point(120, 70), Width = 80, Height = 30, BackColor = Color.ForestGreen, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            Button btnIptal = new Button { Text = "İptal", DialogResult = DialogResult.Cancel, Location = new Point(220, 70), Width = 80, Height = 30, BackColor = Color.FromArgb(189, 195, 199), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnKaydet.FlatAppearance.BorderSize = 0;
            btnIptal.FlatAppearance.BorderSize = 0;
            duzenleForm.Controls.Add(lblAd);
            duzenleForm.Controls.Add(txtAd);
            duzenleForm.Controls.Add(btnKaydet);
            duzenleForm.Controls.Add(btnIptal);
            duzenleForm.AcceptButton = btnKaydet;
            duzenleForm.CancelButton = btnIptal;
            if (duzenleForm.ShowDialog() == DialogResult.OK)
            {
                string yeniAd = txtAd.Text.Trim();
                if (string.IsNullOrEmpty(yeniAd))
                {
                    MessageBox.Show("Kategori adı boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                seciliKategori.KategoriAdi = yeniAd;
                bool sonuc = seciliKategori.Guncelle();
                if (sonuc)
                {
                    MessageBox.Show("Kategori başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    KategorileriDoldur();
                }
                else
                {
                    MessageBox.Show("Kategori güncellenirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Kategori silme butonuna tıklandığında çalışan metot
        /// </summary>
        private void btnKategoriSil_Click(object sender, EventArgs e)
        {
            // Seçili kategori kontrolü
            if (lstKategoriler.SelectedItem == null)
            {
                MessageBox.Show("Lütfen silmek için bir kategori seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Kategori seciliKategori = (Kategori)lstKategoriler.SelectedItem;
            DialogResult sonuc = MessageBox.Show($"{seciliKategori.KategoriAdi} kategorisini silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sonuc == DialogResult.Yes)
            {
                bool silindi = seciliKategori.Sil();
                if (silindi)
                {
                    MessageBox.Show("Kategori başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    KategorileriDoldur();
                }
                else
                {
                    MessageBox.Show("Kategori silinirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Resim seçme butonuna tıklandığında çalışan metot
        /// </summary>
        private void btnResimSec_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                dialog.Title = "Ürün Fotoğrafı Seçin";
                
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // Resmi PictureBox'a yükle
                    pictureBoxUrun.Image = Image.FromFile(dialog.FileName);
                    pictureBoxUrun.SizeMode = PictureBoxSizeMode.Zoom;
                    
                    // Daha sonra kaydederken kullanmak üzere dosya yolunu sakla
                    _seciliFotografYolu = dialog.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Resim yüklenirken bir hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Yeni ürün ekle butonuna tıklandığında çalışan metot (Güncellenmiş hali)
        /// </summary>
        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            try
            {
                // Form alanlarını doğrula
                if (string.IsNullOrEmpty(txtUrunAdi.Text) || 
                    cmbKategori.SelectedItem == null ||
                    string.IsNullOrEmpty(txtFiyat.Text) ||
                    string.IsNullOrEmpty(txtStok.Text))
                {
                    MessageBox.Show("Tüm alanları doldurunuz.", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                decimal fiyat;
                int stok;
                
                // Veri tipi kontrolü
                if (!decimal.TryParse(txtFiyat.Text, out fiyat) || fiyat <= 0)
                {
                    MessageBox.Show("Lütfen geçerli bir fiyat giriniz.", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                if (!int.TryParse(txtStok.Text, out stok) || stok < 0)
                {
                    MessageBox.Show("Lütfen geçerli bir stok miktarı giriniz.", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                // Seçili kategoriyi al
                Kategori secilenKategori = (Kategori)cmbKategori.SelectedItem;
                
                // Yeni ürün oluştur
                Urun yeniUrun = new Urun
                {
                    UrunAdi = txtUrunAdi.Text.Trim(),
                    KategoriId = secilenKategori.KategoriId,
                    Fiyat = fiyat,
                    StokMiktari = stok
                };
                
                // Veritabanına ekle
                int urunId = yeniUrun.Ekle();
                
                if (urunId > 0)
                {
                    // Fotoğraf işlemleri
                    if (_seciliFotografYolu != null)
                    {
                        try
                        {
                            // Uygulamanın bulunduğu klasördeki Fotograflar dizinine kaydet
                            string hedefKlasor = Path.Combine(Application.StartupPath, "Fotograflar");
                            
                            // Klasör yoksa oluştur
                            if (!Directory.Exists(hedefKlasor))
                                Directory.CreateDirectory(hedefKlasor);
                            
                            // Benzersiz dosya adı oluştur (UrunId_timestamp.jpg)
                            string dosyaAdi = $"{urunId}_{DateTime.Now.Ticks}.jpg";
                            string hedefYol = Path.Combine(hedefKlasor, dosyaAdi);
                            
                            // Resmi kopyala
                            File.Copy(_seciliFotografYolu, hedefYol, true);
                            
                            // Veritabanında ürünü güncelle (FotografYolu alanını güncelle)
                            yeniUrun.FotografYolu = $"Fotograflar/{dosyaAdi}";
                            yeniUrun.Guncelle();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Fotoğraf kaydedilirken bir hata oluştu: {ex.Message}\nÜrün kaydedildi ancak fotoğraf kaydedilemedi.", 
                                "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    
                    MessageBox.Show("Ürün başarıyla eklendi.", "Bilgi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    // Form elemanlarını temizle
                    txtUrunAdi.Clear();
                    txtFiyat.Clear();
                    txtStok.Clear();
                    cmbKategori.SelectedIndex = -1;
                    pictureBoxUrun.Image = null;
                    _seciliFotografYolu = null;
                    
                    // Ürünleri yeniden listele
                    UrunleriListele();
                }
                else
                {
                    MessageBox.Show("Ürün eklenirken bir hata oluştu.", "Hata", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İşlem sırasında bir hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Satış detayı butonuna tıklandığında çalışan metot
        /// </summary>
        private void btnSatisDetay_Click(object sender, EventArgs e)
        {
            try
            {
                // Seçili satış kontrolü
                if (dgvSatislar.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Lütfen detayını görmek için bir satış seçin.", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Seçili satışı al
                DataGridViewRow secilenSatir = dgvSatislar.SelectedRows[0];
                int satisId = Convert.ToInt32(secilenSatir.Cells["SatisId"].Value);
                Satis satis = Satis.IdIleGetir(satisId);
                // Sipariş detay formunu aç
                SiparisDetayForm detayForm = new SiparisDetayForm(satis);
                detayForm.ShowDialog();
                // Kargo durumu değişmiş olabilir, tabloyu güncelle
                SatislariListele();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İşlem sırasında bir hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Çıkış butonuna tıklandığında çalışan metot
        /// </summary>
        private void btnCikis_Click(object sender, EventArgs e)
        {
            // Formu kapat
            this.Close();
        }

        /// <summary>
        /// Ürün düzenleme butonuna tıklandığında çalışan metot
        /// </summary>
        private void btnUrunDuzenle_Click(object sender, EventArgs e)
        {
            if (dgvUrunler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen düzenlemek için bir ürün seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Urun seciliUrun = dgvUrunler.SelectedRows[0].DataBoundItem as Urun;
            if (seciliUrun == null) return;
            Form duzenleForm = new Form
            {
                Width = 400,
                Height = 300,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                Text = "Ürün Düzenle",
                MaximizeBox = false,
                MinimizeBox = false
            };
            Label lblAd = new Label { Text = "Ürün Adı:", Location = new Point(30, 30), AutoSize = true };
            TextBox txtAd = new TextBox { Location = new Point(120, 30), Width = 200, Text = seciliUrun.UrunAdi };
            Label lblKategori = new Label { Text = "Kategori:", Location = new Point(30, 70), AutoSize = true };
            ComboBox cmbKategori = new ComboBox { Location = new Point(120, 70), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbKategori.DataSource = Kategori.TumunuGetir();
            cmbKategori.DisplayMember = "KategoriAdi";
            cmbKategori.ValueMember = "KategoriId";
            cmbKategori.SelectedValue = seciliUrun.KategoriId;
            Label lblFiyat = new Label { Text = "Fiyat:", Location = new Point(30, 110), AutoSize = true };
            TextBox txtFiyat = new TextBox { Location = new Point(120, 110), Width = 200, Text = seciliUrun.Fiyat.ToString() };
            Label lblStok = new Label { Text = "Stok:", Location = new Point(30, 150), AutoSize = true };
            TextBox txtStok = new TextBox { Location = new Point(120, 150), Width = 200, Text = seciliUrun.StokMiktari.ToString() };
            Button btnKaydet = new Button { Text = "Kaydet", DialogResult = DialogResult.OK, Location = new Point(220, 200), Width = 100, Height = 35, BackColor = Color.ForestGreen, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            Button btnIptal = new Button { Text = "İptal", DialogResult = DialogResult.Cancel, Location = new Point(100, 200), Width = 100, Height = 35, BackColor = Color.FromArgb(189, 195, 199), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnKaydet.FlatAppearance.BorderSize = 0;
            btnIptal.FlatAppearance.BorderSize = 0;
            duzenleForm.Controls.Add(lblAd);
            duzenleForm.Controls.Add(txtAd);
            duzenleForm.Controls.Add(lblKategori);
            duzenleForm.Controls.Add(cmbKategori);
            duzenleForm.Controls.Add(lblFiyat);
            duzenleForm.Controls.Add(txtFiyat);
            duzenleForm.Controls.Add(lblStok);
            duzenleForm.Controls.Add(txtStok);
            duzenleForm.Controls.Add(btnKaydet);
            duzenleForm.Controls.Add(btnIptal);
            duzenleForm.AcceptButton = btnKaydet;
            duzenleForm.CancelButton = btnIptal;
            if (duzenleForm.ShowDialog() == DialogResult.OK)
            {
                string ad = txtAd.Text.Trim();
                decimal fiyat;
                int stok;
                if (string.IsNullOrEmpty(ad) || !decimal.TryParse(txtFiyat.Text, out fiyat) || !int.TryParse(txtStok.Text, out stok) || cmbKategori.SelectedItem == null)
                {
                    MessageBox.Show("Tüm alanları doğru doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                seciliUrun.UrunAdi = ad;
                seciliUrun.Fiyat = fiyat;
                seciliUrun.StokMiktari = stok;
                seciliUrun.KategoriId = ((Kategori)cmbKategori.SelectedItem).KategoriId;
                bool sonuc = seciliUrun.Guncelle();
                if (sonuc)
                {
                    MessageBox.Show("Ürün başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UrunleriListele();
                }
                else
                {
                    MessageBox.Show("Ürün güncellenirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Ürün silme butonuna tıklandığında çalışan metot
        /// </summary>
        private void btnUrunSil_Click(object sender, EventArgs e)
        {
            if (dgvUrunler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir ürün seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Urun seciliUrun = dgvUrunler.SelectedRows[0].DataBoundItem as Urun;
            if (seciliUrun == null) return;
            DialogResult sonuc = MessageBox.Show($"{seciliUrun.UrunAdi} adlı ürünü silmek istediğinize emin misiniz?\n(Eğer bu ürün satışlarda veya sepetlerde kullanıldıysa, ona bağlı tüm detaylar da silinecek.)", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sonuc == DialogResult.Yes)
            {
                // Önce bu ürüne bağlı tüm satış detaylarını sil
                Database.ExecuteNonQuery("DELETE FROM SatisDetay WHERE UrunId = @UrunId", new System.Data.SqlClient.SqlParameter("@UrunId", seciliUrun.UrunId));
                // Sonra bu ürüne bağlı tüm sepet detaylarını sil
                Database.ExecuteNonQuery("DELETE FROM SepetDetay WHERE UrunId = @UrunId", new System.Data.SqlClient.SqlParameter("@UrunId", seciliUrun.UrunId));
                // Sonra ürünü sil
                bool silindi = seciliUrun.Sil();
                if (silindi)
                {
                    MessageBox.Show("Ürün ve ona bağlı tüm detaylar başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UrunleriListele();
                }
                else
                {
                    MessageBox.Show("Ürün silinirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Müşteri ekle butonu tıklandığında çalışacak event
        private void btnMusteriEkle_Click(object sender, EventArgs e)
        {
            // Müşteri ekleme formu
            Form ekleForm = new Form
            {
                Width = 400,
                Height = 400,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                Text = "Müşteri Ekle",
                MaximizeBox = false,
                MinimizeBox = false
            };
            Label lblAd = new Label { Text = "Ad:", Location = new Point(30, 30), AutoSize = true };
            TextBox txtAd = new TextBox { Location = new Point(120, 30), Width = 200 };
            Label lblSoyad = new Label { Text = "Soyad:", Location = new Point(30, 70), AutoSize = true };
            TextBox txtSoyad = new TextBox { Location = new Point(120, 70), Width = 200 };
            Label lblPuan = new Label { Text = "Puan:", Location = new Point(30, 110), AutoSize = true };
            TextBox txtPuan = new TextBox { Location = new Point(120, 110), Width = 200, Text = "0" };
            Label lblEposta = new Label { Text = "E-posta:", Location = new Point(30, 150), AutoSize = true };
            TextBox txtEposta = new TextBox { Location = new Point(120, 150), Width = 200 };
            Label lblSifre = new Label { Text = "Şifre:", Location = new Point(30, 190), AutoSize = true };
            TextBox txtSifre = new TextBox { Location = new Point(120, 190), Width = 200, PasswordChar = '*' };
            Label lblRol = new Label { Text = "Rol:", Location = new Point(30, 230), AutoSize = true };
            ComboBox cmbRol = new ComboBox { Location = new Point(120, 230), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbRol.Items.AddRange(new string[] { "Musteri", "Admin" });
            cmbRol.SelectedIndex = 0;
            Button btnKaydet = new Button { Text = "Kaydet", DialogResult = DialogResult.OK, Location = new Point(220, 300), Width = 100, Height = 35, BackColor = Color.ForestGreen, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            Button btnIptal = new Button { Text = "İptal", DialogResult = DialogResult.Cancel, Location = new Point(100, 300), Width = 100, Height = 35, BackColor = Color.FromArgb(189, 195, 199), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnKaydet.FlatAppearance.BorderSize = 0;
            btnIptal.FlatAppearance.BorderSize = 0;
            ekleForm.Controls.Add(lblAd);
            ekleForm.Controls.Add(txtAd);
            ekleForm.Controls.Add(lblSoyad);
            ekleForm.Controls.Add(txtSoyad);
            ekleForm.Controls.Add(lblPuan);
            ekleForm.Controls.Add(txtPuan);
            ekleForm.Controls.Add(lblEposta);
            ekleForm.Controls.Add(txtEposta);
            ekleForm.Controls.Add(lblSifre);
            ekleForm.Controls.Add(txtSifre);
            ekleForm.Controls.Add(lblRol);
            ekleForm.Controls.Add(cmbRol);
            ekleForm.Controls.Add(btnKaydet);
            ekleForm.Controls.Add(btnIptal);
            ekleForm.AcceptButton = btnKaydet;
            ekleForm.CancelButton = btnIptal;
            if (ekleForm.ShowDialog() == DialogResult.OK)
            {
                string ad = txtAd.Text.Trim();
                string soyad = txtSoyad.Text.Trim();
                int puan;
                string eposta = txtEposta.Text.Trim();
                string sifre = txtSifre.Text.Trim();
                string rol = cmbRol.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(soyad) || !int.TryParse(txtPuan.Text, out puan) || string.IsNullOrEmpty(eposta) || string.IsNullOrEmpty(sifre) || string.IsNullOrEmpty(rol))
                {
                    MessageBox.Show("Tüm alanları doğru doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Musteri yeniMusteri = new Musteri { Ad = ad, Soyad = soyad, Puan = puan, Eposta = eposta, Sifre = sifre, Rol = rol };
                int sonuc = yeniMusteri.Ekle();
                if (sonuc > 0)
                {
                    MessageBox.Show("Müşteri başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MusterileriListele();
                }
                else
                {
                    MessageBox.Show("Müşteri eklenirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Müşteri düzenle butonu tıklandığında çalışacak event
        private void btnMusteriDuzenle_Click(object sender, EventArgs e)
        {
            if (dgvMusteriler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen düzenlemek için bir müşteri seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Musteri seciliMusteri = dgvMusteriler.SelectedRows[0].DataBoundItem as Musteri;
            if (seciliMusteri == null) return;
            Form duzenleForm = new Form
            {
                Width = 400,
                Height = 400,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                Text = "Müşteri Düzenle",
                MaximizeBox = false,
                MinimizeBox = false
            };
            Label lblAd = new Label { Text = "Ad:", Location = new Point(30, 30), AutoSize = true };
            TextBox txtAd = new TextBox { Location = new Point(120, 30), Width = 200, Text = seciliMusteri.Ad };
            Label lblSoyad = new Label { Text = "Soyad:", Location = new Point(30, 70), AutoSize = true };
            TextBox txtSoyad = new TextBox { Location = new Point(120, 70), Width = 200, Text = seciliMusteri.Soyad };
            Label lblPuan = new Label { Text = "Puan:", Location = new Point(30, 110), AutoSize = true };
            TextBox txtPuan = new TextBox { Location = new Point(120, 110), Width = 200, Text = seciliMusteri.Puan.ToString() };
            Label lblEposta = new Label { Text = "E-posta:", Location = new Point(30, 150), AutoSize = true };
            TextBox txtEposta = new TextBox { Location = new Point(120, 150), Width = 200, Text = seciliMusteri.Eposta };
            Label lblSifre = new Label { Text = "Şifre:", Location = new Point(30, 190), AutoSize = true };
            TextBox txtSifre = new TextBox { Location = new Point(120, 190), Width = 200, Text = seciliMusteri.Sifre, PasswordChar = '*' };
            Label lblRol = new Label { Text = "Rol:", Location = new Point(30, 230), AutoSize = true };
            ComboBox cmbRol = new ComboBox { Location = new Point(120, 230), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbRol.Items.AddRange(new string[] { "Musteri", "Admin" });
            cmbRol.SelectedItem = seciliMusteri.Rol;
            Button btnKaydet = new Button { Text = "Kaydet", DialogResult = DialogResult.OK, Location = new Point(220, 300), Width = 100, Height = 35, BackColor = Color.FromArgb(46, 204, 113), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            Button btnIptal = new Button { Text = "İptal", DialogResult = DialogResult.Cancel, Location = new Point(100, 300), Width = 100, Height = 35, BackColor = Color.FromArgb(189, 195, 199), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnKaydet.FlatAppearance.BorderSize = 0;
            btnIptal.FlatAppearance.BorderSize = 0;
            duzenleForm.Controls.Add(lblAd);
            duzenleForm.Controls.Add(txtAd);
            duzenleForm.Controls.Add(lblSoyad);
            duzenleForm.Controls.Add(txtSoyad);
            duzenleForm.Controls.Add(lblPuan);
            duzenleForm.Controls.Add(txtPuan);
            duzenleForm.Controls.Add(lblEposta);
            duzenleForm.Controls.Add(txtEposta);
            duzenleForm.Controls.Add(lblSifre);
            duzenleForm.Controls.Add(txtSifre);
            duzenleForm.Controls.Add(lblRol);
            duzenleForm.Controls.Add(cmbRol);
            duzenleForm.Controls.Add(btnKaydet);
            duzenleForm.Controls.Add(btnIptal);
            duzenleForm.AcceptButton = btnKaydet;
            duzenleForm.CancelButton = btnIptal;
            if (duzenleForm.ShowDialog() == DialogResult.OK)
            {
                string ad = txtAd.Text.Trim();
                string soyad = txtSoyad.Text.Trim();
                int puan;
                string eposta = txtEposta.Text.Trim();
                string sifre = txtSifre.Text.Trim();
                string rol = cmbRol.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(soyad) || !int.TryParse(txtPuan.Text, out puan) || string.IsNullOrEmpty(eposta) || string.IsNullOrEmpty(sifre) || string.IsNullOrEmpty(rol))
                {
                    MessageBox.Show("Tüm alanları doğru doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                seciliMusteri.Ad = ad;
                seciliMusteri.Soyad = soyad;
                seciliMusteri.Puan = puan;
                seciliMusteri.Eposta = eposta;
                seciliMusteri.Sifre = sifre;
                seciliMusteri.Rol = rol;
                bool sonuc = seciliMusteri.Guncelle();
                if (sonuc)
                {
                    MessageBox.Show("Müşteri başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MusterileriListele();
                }
                else
                {
                    MessageBox.Show("Müşteri güncellenirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Müşteri sil butonu tıklandığında çalışacak event
        private void btnMusteriSil_Click(object sender, EventArgs e)
        {
            if (dgvMusteriler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir müşteri seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Musteri seciliMusteri = dgvMusteriler.SelectedRows[0].DataBoundItem as Musteri;
            if (seciliMusteri == null) return;
            DialogResult sonuc = MessageBox.Show($"{seciliMusteri.TamAd} adlı müşteriyi ve müşteri adına kayıtlı bütün verileri silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sonuc == DialogResult.Yes)
            {
                bool silindi = seciliMusteri.Sil();
                if (silindi)
                {
                    MessageBox.Show("Müşteri başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MusterileriListele();
                }
                else
                {
                    MessageBox.Show("Müşteri silinirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kategori listesini doldur
            KategorileriDoldur();

            // Ürünleri listele
            UrunleriListele();

            // Müşterileri listele
            MusterileriListele();

            // Satışları listele
            SatislariListele();
        }

        private void chkSadakatRaporu_CheckedChanged(object sender, EventArgs e)
        {
            // Müşteri listesini güncelle
            MusterileriListele();
        }
    }
} 