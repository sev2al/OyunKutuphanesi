using System;
using System.Windows.Forms;
using GiyimOtomasyonuFinalProject.Models;

namespace GiyimOtomasyonuFinalProject
{
    /// <summary>
    /// Sipariş detaylarını gösteren form
    /// </summary>
    public partial class SiparisDetayForm : Form
    {
        private Satis _satis;

        /// <summary>
        /// Form yapıcı metodu
        /// </summary>
        /// <param name="satis">Görüntülenecek satış</param>
        public SiparisDetayForm(Satis satis)
        {
            InitializeComponent();
            _satis = satis;
        }

        /// <summary>
        /// Form yüklenirken çalışan metot
        /// </summary>
        private void SiparisDetayForm_Load(object sender, EventArgs e)
        {
            try 
            {
                // Form başlığını ayarla
                this.Text = $"Sipariş Detayı - No: {_satis.SatisId}";
                
                // Sipariş bilgilerini görüntüle
                lblSiparisNo.Text = $"Sipariş No: {_satis.SatisId}";
                lblTarih.Text = $"Tarih: {_satis.Tarih.ToString("dd.MM.yyyy HH:mm")}";
                lblToplamTutar.Text = $"Toplam Tutar: {_satis.ToplamTutar:C2}";
                lblOdemeTuru.Text = $"Ödeme Türü: {_satis.OdemeTuru}";
                lblKargoDurumu.Text = $"Kargo Durumu: {_satis.KargoDurumu}";
                
                // Kargo durumuna göre butonları etkinleştir/etkisizleştir
                ButonlariDurumaGoreGuncelle();
                
                // Sipariş detayları yoksa yeniden yükleyelim
                if (_satis.SatisDetaylari == null || _satis.SatisDetaylari.Count == 0)
                {
                    _satis.SatisDetaylari = SatisDetay.SatisaGoreGetir(_satis.SatisId);
                }
                
                // Satış detayı yoksa bilgi mesajı göster
                if (_satis.SatisDetaylari == null || _satis.SatisDetaylari.Count == 0)
                {
                    MessageBox.Show("Bu siparişe ait ürün detayı bulunamadı.", "Bilgi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                // DataGridView özelliklerini ayarla
                dgvSiparisDetay.AutoGenerateColumns = false;
                dgvSiparisDetay.Columns.Clear();
                
                // Sütunları ekle
                dgvSiparisDetay.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "UrunAdi",
                    HeaderText = "Ürün Adı",
                    Width = 200,
                    ReadOnly = true
                });
                dgvSiparisDetay.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Adet",
                    HeaderText = "Adet",
                    Width = 70,
                    ReadOnly = true
                });
                dgvSiparisDetay.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "BirimFiyat",
                    HeaderText = "Birim Fiyat",
                    Width = 100,
                    ReadOnly = true,
                    DefaultCellStyle = { Format = "C2" }
                });
                dgvSiparisDetay.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Tutar",
                    HeaderText = "Tutar",
                    Width = 100,
                    ReadOnly = true
                });
                
                // DataSource'u kaldırıp manuel olarak ekleyelim
                dgvSiparisDetay.Rows.Clear();
                
                // Her satış detayı için satır ekle
                foreach (SatisDetay detay in _satis.SatisDetaylari)
                {
                    // Ürün adını kontrol et ve hataya karşı koru
                    string urunAdi = "Bilinmeyen Ürün";
                    if (detay.Urun != null)
                    {
                        urunAdi = detay.Urun.UrunAdi;
                    }
                    
                    // Satır oluştur
                    int rowIndex = dgvSiparisDetay.Rows.Add();
                    DataGridViewRow row = dgvSiparisDetay.Rows[rowIndex];
                    
                    // Değerleri doldur
                    row.Cells["UrunAdi"].Value = urunAdi;
                    row.Cells["Adet"].Value = detay.Adet;
                    row.Cells["BirimFiyat"].Value = detay.BirimFiyat;
                    row.Cells["Tutar"].Value = detay.SatirToplam.ToString("C2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sipariş detayları yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Butonları kargo durumuna göre günceller
        /// </summary>
        private void ButonlariDurumaGoreGuncelle()
        {
            if (_satis.KargoDurumu == "Hazırlanıyor")
            {
                btnKargoyaVer.Enabled = true;
                btnTeslimEdildi.Enabled = false;
            }
            else if (_satis.KargoDurumu == "Kargoya Verildi")
            {
                btnKargoyaVer.Enabled = false;
                btnTeslimEdildi.Enabled = true;
            }
            else if (_satis.KargoDurumu == "Teslim Edildi")
            {
                btnKargoyaVer.Enabled = false;
                btnTeslimEdildi.Enabled = false;
            }
        }

        /// <summary>
        /// Kapat butonuna tıklandığında çalışan metot
        /// </summary>
        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        /// <summary>
        /// Kargoya Ver butonuna tıklandığında çalışan metot
        /// </summary>
        private void btnKargoyaVer_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult sonuc = MessageBox.Show(
                    $"{_satis.SatisId} numaralı siparişi kargoya vermek istediğinizden emin misiniz?",
                    "Onay",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                    
                if (sonuc == DialogResult.Yes)
                {
                    // Kargo durumunu güncelle
                    if (Satis.KargoDurumuGuncelle(_satis.SatisId, "Kargoya Verildi"))
                    {
                        _satis.KargoDurumu = "Kargoya Verildi";
                        lblKargoDurumu.Text = $"Kargo Durumu: {_satis.KargoDurumu}";
                        MessageBox.Show(
                            "Sipariş kargoya verildi olarak güncellendi.",
                            "Bilgi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                            
                        // Butonların durumunu güncelle
                        ButonlariDurumaGoreGuncelle();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Kargo durumu güncellenirken bir hata oluştu.",
                            "Hata",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"İşlem sırasında bir hata oluştu: {ex.Message}",
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Teslim Edildi butonuna tıklandığında çalışan metot
        /// </summary>
        private void btnTeslimEdildi_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult sonuc = MessageBox.Show(
                    $"{_satis.SatisId} numaralı siparişi teslim edildi olarak işaretlemek istediğinizden emin misiniz?",
                    "Onay",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                    
                if (sonuc == DialogResult.Yes)
                {
                    // Kargo durumunu güncelle
                    if (Satis.KargoDurumuGuncelle(_satis.SatisId, "Teslim Edildi"))
                    {
                        _satis.KargoDurumu = "Teslim Edildi";
                        lblKargoDurumu.Text = $"Kargo Durumu: {_satis.KargoDurumu}";
                        MessageBox.Show(
                            "Sipariş teslim edildi olarak güncellendi.",
                            "Bilgi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        // Sadece ilk kez teslim edildiğinde 10 puan ekle
                        if (!_satis.PuanEklendi)
                        {
                            Database.MusteriPuanGuncelle(_satis.MusteriId, 10);
                            _satis.PuanEklendi = true;
                            _satis.Guncelle();
                        }
                        // Butonların durumunu güncelle
                        ButonlariDurumaGoreGuncelle();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Kargo durumu güncellenirken bir hata oluştu.",
                            "Hata",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"İşlem sırasında bir hata oluştu: {ex.Message}",
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
} 