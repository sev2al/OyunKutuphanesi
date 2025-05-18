using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using GiyimOtomasyonuFinalProject.Models;
using System.Linq;

namespace GiyimOtomasyonuFinalProject
{
    /// <summary>
    /// Müşteri işlemleri için panel formu
    /// </summary>
    public partial class MusteriPanelForm : Form
    {
        // Giriş yapan müşteri bilgisi
        private Musteri _girisYapanMusteri;
        // Aktif sepet
        private Sepet _aktifSepet;
        // Seçili ürün
        private Urun _secilenUrun;

        /// <summary>
        /// Form yapıcı metodu
        /// </summary>
        /// <param name="musteri">Giriş yapan müşteri</param>
        public MusteriPanelForm(Musteri musteri)
        {
            InitializeComponent();
            _girisYapanMusteri = musteri;
        }

        /// <summary>
        /// Form yüklenirken çalışan metot
        /// </summary>
        private void MusteriPanelForm_Load(object sender, EventArgs e)
        {
            // Form başlığını ayarla
            this.Text = $"Giyim Otomasyonu - Müşteri Paneli - {_girisYapanMusteri.TamAd}";
            
            // Müşteri bilgilerini göster
            lblMusteriAd.Text = _girisYapanMusteri.TamAd;
            
            // Müşteri puan kaydı yoksa ekle (her zaman güvenli)
            Database.MusteriPuanGuncelle(_girisYapanMusteri.MusteriId, 0);
            // Müşteri puanını veritabanından al ve göster
            int musteriPuan = Database.GetMusteriPuan(_girisYapanMusteri.MusteriId);
            lblPuan.Text = $"Puan: {musteriPuan}";
            
            // Kategori listesini doldur
            KategorileriDoldur();
            
            // Ürünleri listele
            UrunleriListele();
            
            // Sepeti kontrol et veya oluştur
            SepetiKontrolEt();
            
            // Önceki siparişleri getir
            SiparisleriGetir();
        }

        /// <summary>
        /// Ürün görselini göster
        /// </summary>
        private void UrunGorseliniGoster(Urun urun)
        {
            try
            {
                if (urun != null && !string.IsNullOrEmpty(urun.FotografYolu))
                {
                    string dosyaYolu = Path.Combine(Application.StartupPath, urun.FotografYolu);
                    if (File.Exists(dosyaYolu))
                    {
                        // Resmi yükle
                        using (FileStream stream = new FileStream(dosyaYolu, FileMode.Open, FileAccess.Read))
                        {
                            pictureBoxUrunDetay.Image = Image.FromStream(stream);
                        }
                    }
                    else
                    {
                        pictureBoxUrunDetay.Image = null;
                    }
                }
                else
                {
                    pictureBoxUrunDetay.Image = null;
                }
            }
            catch
            {
                // Resim yüklenemezse sessizce devam et
                pictureBoxUrunDetay.Image = null;
            }
        }

        /// <summary>
        /// Kategorileri doldur
        /// </summary>
        private void KategorileriDoldur()
        {
            try
            {
                // Tüm kategorileri al
                List<Kategori> kategoriler = Kategori.TumunuGetir();
                
                // ListBox'a ekle
                lstKategoriler.DisplayMember = "KategoriAdi";
                lstKategoriler.ValueMember = "KategoriId";
                
                // Tümü seçeneği ekle
                Kategori tumKategoriler = new Kategori { KategoriId = 0, KategoriAdi = "Tüm Kategoriler" };
                lstKategoriler.Items.Add(tumKategoriler);
                
                // Diğer kategorileri ekle
                foreach (Kategori kategori in kategoriler)
                {
                    lstKategoriler.Items.Add(kategori);
                }
                
                // Varsayılan olarak "Tümü" seç
                lstKategoriler.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kategoriler yüklenirken bir hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Kategori seçildiğinde çalışan metot
        /// </summary>
        private void lstKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            UrunleriListele();
        }

        /// <summary>
        /// Ürünleri listele
        /// </summary>
        private void UrunleriListele()
        {
            try
            {
                // Önceki ürün kartlarını temizle
                flowLayoutPanelUrunler.Controls.Clear();
                
                // Ürünleri al ve filtrele
                List<Urun> urunler;
                
                // Seçili kategori kontrolü
                if (lstKategoriler.SelectedIndex > 0)
                {
                    // Seçili kategoriye göre ürünleri getir
                    Kategori secilenKategori = (Kategori)lstKategoriler.SelectedItem;
                    urunler = Urun.KategoriyeGoreGetir(secilenKategori.KategoriId);
                }
                else
                {
                    // Tüm ürünleri getir
                    urunler = Urun.TumunuGetir();
                }
                
                // Ürün kartlarını oluştur
                foreach (Urun urun in urunler)
                {
                    // Ürün kartını oluştur ve FlowLayoutPanel'e ekle
                    Panel urunKarti = UrunKartiOlustur(urun);
                    flowLayoutPanelUrunler.Controls.Add(urunKarti);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürünler listelenirken bir hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Ürün kartı oluştur
        /// </summary>
        /// <param name="urun">Kart için ürün bilgisi</param>
        /// <returns>Ürün kartı paneli</returns>
        private Panel UrunKartiOlustur(Urun urun)
        {
            // Ana panel
            Panel urunPanel = new Panel();
            urunPanel.Width = 200;
            urunPanel.Height = 280;
            urunPanel.Margin = new Padding(10);
            urunPanel.BackColor = Color.White;
            urunPanel.BorderStyle = BorderStyle.FixedSingle;
            urunPanel.Tag = urun; // Ürün bilgisini Tag'de saklayalım
            
            // Ürün bileşenlerini ekleyelim:
            
            // 1. Ürün resmi
            PictureBox urunResim = new PictureBox();
            urunResim.Width = 180;
            urunResim.Height = 150;
            urunResim.Location = new Point(10, 10);
            urunResim.SizeMode = PictureBoxSizeMode.Zoom;
            urunResim.BorderStyle = BorderStyle.FixedSingle;
            urunResim.Tag = urun;
            
            // Ürün resmini ayarla
            if (!string.IsNullOrEmpty(urun.FotografYolu))
            {
                string dosyaYolu = Path.Combine(Application.StartupPath, urun.FotografYolu);
                if (File.Exists(dosyaYolu))
                {
                    try
                    {
                        using (FileStream stream = new FileStream(dosyaYolu, FileMode.Open, FileAccess.Read))
                        {
                            urunResim.Image = Image.FromStream(stream);
                        }
                    }
                    catch
                    {
                        // Resim yüklenemezse varsayılan resim
                        urunResim.Image = null;
                    }
                }
            }
            
            // 2. Ürün Adı
            Label lblUrunAdi = new Label();
            lblUrunAdi.Text = urun.UrunAdi;
            lblUrunAdi.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblUrunAdi.AutoSize = false;
            lblUrunAdi.TextAlign = ContentAlignment.MiddleCenter;
            lblUrunAdi.Width = 180;
            lblUrunAdi.Height = 30;
            lblUrunAdi.Location = new Point(10, 170);
            
            // 3. Ürün Fiyatı
            Label lblFiyat = new Label();
            lblFiyat.Text = $"{urun.Fiyat:C2}";
            lblFiyat.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblFiyat.ForeColor = Color.DarkGreen;
            lblFiyat.AutoSize = false;
            lblFiyat.TextAlign = ContentAlignment.MiddleCenter;
            lblFiyat.Width = 180;
            lblFiyat.Height = 20;
            lblFiyat.Location = new Point(10, 200);
            
            // 4. Stok Durumu
            Label lblStok = new Label();
            lblStok.Text = $"Stok: {urun.StokMiktari}";
            lblStok.Font = new Font("Segoe UI", 8);
            lblStok.AutoSize = false;
            lblStok.TextAlign = ContentAlignment.MiddleCenter;
            lblStok.Width = 180;
            lblStok.Height = 20;
            lblStok.Location = new Point(10, 220);
            
            // 5. Kategori
            Label lblKategori = new Label();
            lblKategori.Text = urun.Kategori.KategoriAdi;
            lblKategori.Font = new Font("Segoe UI", 8, FontStyle.Italic);
            lblKategori.AutoSize = false;
            lblKategori.TextAlign = ContentAlignment.MiddleCenter;
            lblKategori.Width = 180;
            lblKategori.Height = 20;
            lblKategori.Location = new Point(10, 240);
            
            // Tıklama olaylarını ekle
            urunPanel.Click += UrunKarti_Click;
            urunResim.Click += UrunKarti_Click;
            lblUrunAdi.Click += UrunKarti_Click;
            lblFiyat.Click += UrunKarti_Click;
            lblStok.Click += UrunKarti_Click;
            lblKategori.Click += UrunKarti_Click;
            
            // Bileşenleri panele ekle
            urunPanel.Controls.Add(urunResim);
            urunPanel.Controls.Add(lblUrunAdi);
            urunPanel.Controls.Add(lblFiyat);
            urunPanel.Controls.Add(lblStok);
            urunPanel.Controls.Add(lblKategori);
            
            return urunPanel;
        }

        /// <summary>
        /// Ürün kartı tıklama olayı
        /// </summary>
        private void UrunKarti_Click(object sender, EventArgs e)
        {
            try
            {
                // Tıklanan kontrolü al
                Control tiklananKontrol = sender as Control;
                if (tiklananKontrol == null) return;
                
                // Eğer tıklanan kontrol bir alt kontrolse, parent'ını al
                Panel urunPanel = tiklananKontrol as Panel;
                if (urunPanel == null)
                {
                    urunPanel = tiklananKontrol.Parent as Panel;
                    if (urunPanel == null) return;
                }
                
                // Tag'de saklanan ürün bilgisini al
                _secilenUrun = urunPanel.Tag as Urun;
                if (_secilenUrun == null) return;
                
                // Seçilen ürünün detaylarını göster
                lblUrunDetayBaslik.Text = _secilenUrun.UrunAdi;
                UrunGorseliniGoster(_secilenUrun);
                
                // Tüm kartların seçim stilini sıfırla
                foreach (Control kontrol in flowLayoutPanelUrunler.Controls)
                {
                    if (kontrol is Panel panel)
                    {
                        panel.BackColor = Color.White;
                    }
                }
                
                // Seçilen kartın stilini değiştir
                urunPanel.BackColor = Color.LightSkyBlue;
                
                // Adet girişi alanını odakla ve varsayılan değer olarak 1 ata
                txtAdet.Text = "1";
                txtAdet.Focus();
                
                // Sepete Ekle butonunu vurgula
                btnSepeteEkle.BackColor = Color.LightGreen;
                btnSepeteEkle.ForeColor = Color.DarkGreen;
                btnSepeteEkle.Font = new Font(btnSepeteEkle.Font, FontStyle.Bold);
            }
            catch (Exception ex)
            {
                // Sessiz hata - kullanıcıya gösterilmeyecek
                Console.WriteLine("Ürün seçiminde hata: " + ex.Message);
            }
        }

        /// <summary>
        /// Sepeti kontrol et veya yeni sepet oluştur
        /// </summary>
        private void SepetiKontrolEt()
        {
            try
            {
                // Müşterinin aktif sepetini kontrol et
                _aktifSepet = Sepet.MusterininSepetiniGetir(_girisYapanMusteri.MusteriId);
                
                // Aktif sepet yoksa yeni oluştur
                if (_aktifSepet == null)
                {
                    _aktifSepet = new Sepet
                    {
                        MusteriId = _girisYapanMusteri.MusteriId,
                        SepetDetaylari = new List<SepetDetay>()
                    };
                    
                    _aktifSepet.Olustur();
                }
                
                // Sepeti listele
                SepetiListele();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sepet kontrol edilirken bir hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sepet içeriğini listele
        /// </summary>
        private void SepetiListele()
        {
            try
            {
                // DataGridView özelliklerini ayarla
                dgvSepet.AutoGenerateColumns = false;
                
                // Sütunları temizle
                dgvSepet.Columns.Clear();
                
                // Sütunları ekle
                DataGridViewTextBoxColumn kolUrunAdi = new DataGridViewTextBoxColumn();
                kolUrunAdi.Name = "UrunAdi";
                kolUrunAdi.HeaderText = "Ürün Adı";
                kolUrunAdi.Width = 300;
                kolUrunAdi.ReadOnly = true;
                dgvSepet.Columns.Add(kolUrunAdi);
                
                DataGridViewTextBoxColumn kolAdet = new DataGridViewTextBoxColumn();
                kolAdet.Name = "Adet";
                kolAdet.HeaderText = "Adet";
                kolAdet.Width = 70;
                kolAdet.ReadOnly = true;
                dgvSepet.Columns.Add(kolAdet);
                
                DataGridViewTextBoxColumn kolTutar = new DataGridViewTextBoxColumn();
                kolTutar.Name = "Tutar";
                kolTutar.HeaderText = "Tutar";
                kolTutar.Width = 100;
                kolTutar.ReadOnly = true;
                kolTutar.DefaultCellStyle.Format = "C2";
                dgvSepet.Columns.Add(kolTutar);
                
                // Sepet detaylarını al
                List<SepetDetay> sepetDetaylari = _aktifSepet.SepetDetaylari;
                
                // DataSource olarak ata
                dgvSepet.DataSource = null;
                dgvSepet.Rows.Clear();
                
                // Her bir sepet detayı için satır ekle
                foreach (SepetDetay detay in sepetDetaylari)
                {
                    int rowIndex = dgvSepet.Rows.Add();
                    dgvSepet.Rows[rowIndex].Cells["UrunAdi"].Value = detay.Urun.UrunAdi;
                    dgvSepet.Rows[rowIndex].Cells["Adet"].Value = detay.Adet.ToString();
                    dgvSepet.Rows[rowIndex].Cells["Tutar"].Value = (detay.Adet * detay.Urun.Fiyat).ToString("C2");
                }
                
                // Toplam tutarı hesapla
                decimal toplamTutar = 0;
                foreach (SepetDetay detay in sepetDetaylari)
                {
                    toplamTutar += detay.Adet * detay.Urun.Fiyat;
                }
                
                // Tutar gösterimini güncelle
                lblToplamTutar.Text = $"Toplam Tutar: {toplamTutar:C2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sepet listelenirken bir hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sepete ürün ekle
        /// </summary>
        private void btnSepeteEkle_Click(object sender, EventArgs e)
        {
            try
            {
                // Seçili ürün kontrolü
                if (_secilenUrun == null)
                {
                    MessageBox.Show("Lütfen sepete eklemek için bir ürün seçin", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                // Adet kontrolü
                if (string.IsNullOrWhiteSpace(txtAdet.Text))
                {
                    MessageBox.Show("Lütfen adet girişi yapın", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAdet.Focus();
                    return;
                }
                
                int adet;
                if (!int.TryParse(txtAdet.Text, out adet) || adet <= 0)
                {
                    MessageBox.Show("Lütfen geçerli bir adet girişi yapın", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAdet.Focus();
                    return;
                }
                
                // Sepette aynı üründen kaç adet var kontrolü
                int sepettekiMevcutAdet = 0;
                SepetDetay mevcutUrun = _aktifSepet.SepetDetaylari.Find(d => d.UrunId == _secilenUrun.UrunId);
                if (mevcutUrun != null)
                {
                    sepettekiMevcutAdet = mevcutUrun.Adet;
                }
                
                // Toplam adet stok kontrolü
                int toplamIstenecekAdet = sepettekiMevcutAdet + adet;
                
                if (toplamIstenecekAdet > _secilenUrun.StokMiktari)
                {
                    string mesaj;
                    if (sepettekiMevcutAdet > 0)
                    {
                        mesaj = $"Bu üründen sepetinizde zaten {sepettekiMevcutAdet} adet var. " +
                                $"Toplam talep ettiğiniz {toplamIstenecekAdet} adet, mevcut stok miktarı olan {_secilenUrun.StokMiktari} adedi aşıyor.";
                    }
                    else
                    {
                        mesaj = $"Stokta yeterli ürün yok. Mevcut stok: {_secilenUrun.StokMiktari}";
                    }
                    
                    MessageBox.Show(mesaj, "Stok Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAdet.Focus();
                    return;
                }
                
                // Sepete ekle
                bool sonuc = _aktifSepet.UrunEkle(_secilenUrun, adet);
                
                if (sonuc)
                {
                    MessageBox.Show($"{_secilenUrun.UrunAdi} ürünü sepete eklendi", "Bilgi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Ürünleri yeniden listeleme
                    UrunleriListele();
                    
                    // Sepeti listeleme
                    SepetiListele();
                    
                    // Adet alanını sıfırla
                    txtAdet.Text = "";
                    
                    // Sepete Ekle butonunu normal haline getir
                    btnSepeteEkle.BackColor = SystemColors.Control;
                    btnSepeteEkle.ForeColor = SystemColors.ControlText;
                    btnSepeteEkle.Font = new Font(btnSepeteEkle.Font.FontFamily, btnSepeteEkle.Font.Size, FontStyle.Regular);
                    
                    // Seçili ürünü sıfırla
                    _secilenUrun = null;
                    lblUrunDetayBaslik.Text = "Ürün Adı";
                    pictureBoxUrunDetay.Image = null;
                }
                else
                {
                    MessageBox.Show("Ürün sepete eklenemedi", "Hata", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sepete ekleme işleminde hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Satın al butonuna tıklandığında çalışan metot
        /// </summary>
        private void btnSatinAl_Click(object sender, EventArgs e)
        {
            try
            {
                // Sepet boş mu kontrolü
                if (_aktifSepet.SepetDetaylari.Count == 0)
                {
                    MessageBox.Show("Sepetiniz boş. Lütfen önce sepete ürün ekleyin.", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Sipariş özeti açılmadan önce puanı güncelle
                _girisYapanMusteri.Puan = Database.GetMusteriPuan(_girisYapanMusteri.MusteriId);
                // Sepet özetini göster
                decimal toplamTutar = _aktifSepet.ToplamTutarHesapla();
                decimal indirimMiktari = 0;
                decimal odenecekTutar = toplamTutar;
                bool puanKullanilacak = false;

                // Sepet özet formunu oluştur
                Form ozetForm = new Form
                {
                    Width = 450,
                    Height = 400,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    StartPosition = FormStartPosition.CenterParent,
                    Text = "Sipariş Özeti",
                    MaximizeBox = false,
                    MinimizeBox = false
                };

                // Başlık
                Label lblBaslik = new Label
                {
                    Text = "SİPARİŞ ÖZETİ",
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Width = 430,
                    Height = 30,
                    Location = new Point(10, 10),
                    Font = new Font("Segoe UI", 12, FontStyle.Bold)
                };
                ozetForm.Controls.Add(lblBaslik);

                // Ürünler için panel
                Panel pnlUrunler = new Panel
                {
                    Width = 430,
                    Height = 200,
                    Location = new Point(10, 50),
                    BorderStyle = BorderStyle.FixedSingle,
                    AutoScroll = true
                };
                ozetForm.Controls.Add(pnlUrunler);

                // Ürünleri panele ekle
                int y = 10;
                foreach (SepetDetay detay in _aktifSepet.SepetDetaylari)
                {
                    Label lblUrun = new Label
                    {
                        Text = $"{detay.Urun.UrunAdi} - {detay.Adet} adet x {detay.Urun.Fiyat:C2} = {detay.SatirToplamHesapla():C2}",
                        AutoSize = false,
                        Width = 400,
                        Height = 20,
                        Location = new Point(5, y)
                    };
                    pnlUrunler.Controls.Add(lblUrun);
                    y += 25;
                }

                // Toplam tutar
                Label lblToplam = new Label
                {
                    Text = $"Toplam Tutar: {toplamTutar:C2}",
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Width = 200,
                    Height = 25,
                    Location = new Point(10, 260),
                    Font = new Font("Segoe UI", 10)
                };
                ozetForm.Controls.Add(lblToplam);

                // İndirim
                Label lblIndirim = new Label
                {
                    Text = $"İndirim: {indirimMiktari:C2}",
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Width = 200,
                    Height = 25,
                    Location = new Point(10, 315),
                    Font = new Font("Segoe UI", 10),
                    ForeColor = Color.FromArgb(231, 76, 60)
                };
                ozetForm.Controls.Add(lblIndirim);

                // Ödenecek tutar
                Label lblOdenecek = new Label
                {
                    Text = $"Ödenecek Tutar: {odenecekTutar:C2}",
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Width = 200,
                    Height = 25,
                    Location = new Point(10, 340),
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };
                ozetForm.Controls.Add(lblOdenecek);

                // Puan kullanım checkbox
                CheckBox chkPuanKullan = new CheckBox
                {
                    Text = $"Puanlarımı Kullan ({_girisYapanMusteri.Puan} puan = {_girisYapanMusteri.Puan} TL indirim)",
                    AutoSize = true,
                    Location = new Point(10, 290),
                    Enabled = _girisYapanMusteri.Puan > 0
                };
                chkPuanKullan.CheckedChanged += (s, args) =>
                {
                    // Her zaman güncel puan ile hesapla
                    _girisYapanMusteri.Puan = Database.GetMusteriPuan(_girisYapanMusteri.MusteriId);
                    if (_girisYapanMusteri.Puan <= 0)
                    {
                        chkPuanKullan.Checked = false;
                        return;
                    }
                    puanKullanilacak = chkPuanKullan.Checked;
                    if (puanKullanilacak)
                    {
                        indirimMiktari = Math.Min(_girisYapanMusteri.Puan, toplamTutar);
                        odenecekTutar = toplamTutar - indirimMiktari;
                    }
                    else
                    {
                        indirimMiktari = 0;
                        odenecekTutar = toplamTutar;
                    }
                    lblIndirim.Text = $"İndirim: {indirimMiktari:C2}";
                    lblOdenecek.Text = $"Ödenecek Tutar: {odenecekTutar:C2}";
                };
                ozetForm.Controls.Add(chkPuanKullan);

                // Ödeme türü seçimi bölümü
                Label lblOdemeTuruSecim = new Label
                {
                    Text = "Ödeme Türü:",
                    AutoSize = true,
                    Location = new Point(230, 260),
                    Font = new Font("Segoe UI", 10)
                };
                ozetForm.Controls.Add(lblOdemeTuruSecim);

                ComboBox cmbOdemeTuruSecim = new ComboBox
                {
                    Width = 150,
                    Location = new Point(230, 285),
                    DropDownStyle = ComboBoxStyle.DropDownList
                };
                cmbOdemeTuruSecim.Items.AddRange(new string[] { "Kredi Kartı", "Havale", "Kapıda Ödeme" });
                cmbOdemeTuruSecim.SelectedIndex = 0;
                ozetForm.Controls.Add(cmbOdemeTuruSecim);

                // İptal butonu
                Button btnIptal = new Button
                {
                    Text = "İptal",
                    DialogResult = DialogResult.Cancel,
                    Width = 100,
                    Height = 35,
                    Location = new Point(230, 320),
                    BackColor = Color.FromArgb(189, 195, 199),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };
                btnIptal.FlatAppearance.BorderSize = 0;
                ozetForm.Controls.Add(btnIptal);

                // Onay butonu
                Button btnOdemeOnayla = new Button
                {
                    Text = "Ödemeye Geç",
                    DialogResult = DialogResult.OK,
                    Width = 120,
                    Height = 35,
                    Location = new Point(330, 320),
                    BackColor = Color.FromArgb(46, 204, 113),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold)
                };
                btnOdemeOnayla.FlatAppearance.BorderSize = 0;
                ozetForm.Controls.Add(btnOdemeOnayla);

                ozetForm.AcceptButton = btnOdemeOnayla;
                ozetForm.CancelButton = btnIptal;

                // Formu göster
                DialogResult sonuc = ozetForm.ShowDialog();

                if (sonuc == DialogResult.OK)
                {
                    string secilenOdemeTuru = cmbOdemeTuruSecim.SelectedItem.ToString();

                    // Satış oluştur
                    Satis yeniSatis = Satis.SepettenSatisOlustur(_aktifSepet, secilenOdemeTuru);

                    if (yeniSatis != null)
                    {
                        // Eğer puanlar kullanıldıysa puanları düş
                        if (puanKullanilacak && indirimMiktari > 0)
                        {
                            int kullanilacakPuan = (int)indirimMiktari;
                            if (_girisYapanMusteri.Puan >= kullanilacakPuan)
                            {
                                _girisYapanMusteri.Puan -= kullanilacakPuan;
                            }
                            else
                            {
                                _girisYapanMusteri.Puan = 0;
                            }
                            _girisYapanMusteri.Guncelle();
                            // Ayrıca veritabanında puanı sıfırla
                            Database.MusteriPuanGuncelle(_girisYapanMusteri.MusteriId, -Database.GetMusteriPuan(_girisYapanMusteri.MusteriId));
                            // Müşteri puanını güncelle
                            lblPuan.Text = $"Puan: 0";
                        }

                        // Başarılı sipariş mesajı
                        MessageBox.Show($"Siparişiniz başarıyla oluşturuldu.\nSipariş No: {yeniSatis.SatisId}", "Başarılı",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Yeni sepet oluştur
                        SepetiKontrolEt();

                        // Siparişleri güncelle
                        SiparisleriGetir();
                    }
                    else if (sonuc == DialogResult.Cancel)
                    {
                        // Kullanıcı iptal ettiğinde sepeti korumak için bilgi mesajı göster
                        MessageBox.Show("Sipariş işlemi iptal edildi. Sepetiniz korunmuştur.", "Bilgi",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İşlem sırasında bir hata oluştu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Siparişleri getir ve listele
        /// </summary>
        private void SiparisleriGetir()
        {
            try
            {
                // Siparişler tablosu için kolonları bir kere ekle
                if (dgvSiparisler.Columns.Count == 0)
                {
                    dgvSiparisler.Columns.Add("SatisId", "Sipariş No");
                    dgvSiparisler.Columns.Add("Tarih", "Tarih");
                    dgvSiparisler.Columns.Add("ToplamTutar", "Tutar");
                    dgvSiparisler.Columns.Add("KargoDurumu", "Kargo Durumu");
                }
                // Siparişleri getir
                List<Satis> satislar = Satis.MusteriyeGoreGetir(_girisYapanMusteri.MusteriId);
                // DataGridView'ı temizle
                dgvSiparisler.Rows.Clear();
                // Siparişleri listele
                foreach (Satis satis in satislar)
                {
                    dgvSiparisler.Rows.Add(
                        satis.SatisId,
                        satis.Tarih.ToString("dd.MM.yyyy HH:mm"),
                        satis.ToplamTutar.ToString("C2"),
                        satis.KargoDurumu
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Siparişler yüklenirken bir hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sipariş detayı butonuna tıklandığında çalışan metot
        /// </summary>
        private void btnSiparisDetay_Click(object sender, EventArgs e)
        {
            try
            {
                // Seçili sipariş kontrolü
                if (dgvSiparisler.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Lütfen detayını görmek için bir sipariş seçin.", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                // Seçili siparişi al
                DataGridViewRow secilenSatir = dgvSiparisler.SelectedRows[0];
                Satis satis = (Satis)secilenSatir.DataBoundItem;
                
                // Sipariş detay formunu aç
                SiparisDetayForm detayForm = new SiparisDetayForm(satis);
                detayForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İşlem sırasında bir hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Arama butonuna tıklandığında çalışan metot
        /// </summary>
        private void btnAra_Click(object sender, EventArgs e)
        {
            try
            {
                string aramaMetni = txtArama.Text.Trim();
                
                if (string.IsNullOrEmpty(aramaMetni))
                {
                    // Arama metni boşsa tüm ürünleri listele
                    UrunleriListele();
                    return;
                }
                
                // Önceki ürün kartlarını temizle
                flowLayoutPanelUrunler.Controls.Clear();
                
                // Ürünleri ara
                List<Urun> urunler = Urun.Ara(aramaMetni);
                
                // Ürün kartlarını oluştur
                foreach (Urun urun in urunler)
                {
                    // Ürün kartını oluştur ve FlowLayoutPanel'e ekle
                    Panel urunKarti = UrunKartiOlustur(urun);
                    flowLayoutPanelUrunler.Controls.Add(urunKarti);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Arama işlemi sırasında bir hata oluştu: {ex.Message}", "Hata", 
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
        /// Sepetten ürün çıkar butonuna tıklandığında çalışan metot
        /// </summary>
        private void btnSepettenCikar_Click(object sender, EventArgs e)
        {
            try
            {
                // Seçili ürün kontrolü
                if (dgvSepet.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Lütfen sepetten çıkarmak için bir ürün seçin.", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                // Seçili ürünü al
                DataGridViewRow secilenSatir = dgvSepet.SelectedRows[0];
                SepetDetay detay = (SepetDetay)secilenSatir.DataBoundItem;
                
                // Onay sor
                DialogResult sonuc = MessageBox.Show($"{detay.Urun.UrunAdi} ürününü sepetten çıkarmak istediğinizden emin misiniz?", 
                    "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (sonuc == DialogResult.Yes)
                {
                    // Sepetten çıkar
                    bool islemSonucu = _aktifSepet.UrunCikar(detay.UrunId);
                    
                    if (islemSonucu)
                    {
                        MessageBox.Show($"{detay.Urun.UrunAdi} ürünü sepetten çıkarıldı.", "Bilgi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Sepeti güncelle
                        SepetiListele();
                    }
                    else
                    {
                        MessageBox.Show("Ürün sepetten çıkarılırken bir hata oluştu.", "Hata", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürün sepetten çıkarılırken bir hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
} 