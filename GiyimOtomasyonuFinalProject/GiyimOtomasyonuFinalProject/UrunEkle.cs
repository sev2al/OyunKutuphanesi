using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GiyimOtomasyonuFinalProject
{
    public partial class UrunEkle : Form
    {
        private string connectionString = "Data Source=your_server;Initial Catalog=your_database;Integrated Security=True";

        public UrunEkle()
        {
            InitializeComponent();
        }

        private void UrunSil()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int urunId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["UrunID"].Value);
                string urunAdi = dataGridView1.SelectedRows[0].Cells["UrunAdi"].Value.ToString();
                int kategoriId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["KategoriID"].Value);

                DialogResult result = MessageBox.Show($"{urunAdi} ürününü silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            using (SqlTransaction transaction = connection.BeginTransaction())
                            {
                                try
                                {
                                    // Önce satış detaylarını sil
                                    using (SqlCommand cmd = new SqlCommand("DELETE FROM SatisDetaylari WHERE UrunID = @UrunID", connection, transaction))
                                    {
                                        cmd.Parameters.AddWithValue("@UrunID", urunId);
                                        cmd.ExecuteNonQuery();
                                    }

                                    // Sonra sepet detaylarını sil
                                    using (SqlCommand cmd = new SqlCommand("DELETE FROM SepetDetaylari WHERE UrunID = @UrunID", connection, transaction))
                                    {
                                        cmd.Parameters.AddWithValue("@UrunID", urunId);
                                        cmd.ExecuteNonQuery();
                                    }

                                    // En son ürünü sil
                                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Urunler WHERE UrunID = @UrunID", connection, transaction))
                                    {
                                        cmd.Parameters.AddWithValue("@UrunID", urunId);
                                        cmd.ExecuteNonQuery();
                                    }

                                    // Kategori kontrolü yap
                                    KategoriKontrol(kategoriId, connection, transaction);

                                    transaction.Commit();
                                    MessageBox.Show("Ürün başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    UrunleriListele();
                                }
                                catch (Exception ex)
                                {
                                    transaction.Rollback();
                                    MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz ürünü seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void KategoriKontrol(int kategoriId, SqlConnection connection, SqlTransaction transaction)
        {
            // Kategorideki ürün sayısını kontrol et
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Urunler WHERE KategoriID = @KategoriID", connection, transaction))
            {
                cmd.Parameters.AddWithValue("@KategoriID", kategoriId);
                int urunSayisi = (int)cmd.ExecuteScalar();

                // Eğer kategoride ürün kalmadıysa kategoriyi sil
                if (urunSayisi == 0)
                {
                    using (SqlCommand deleteCmd = new SqlCommand("DELETE FROM Kategoriler WHERE KategoriID = @KategoriID", connection, transaction))
                    {
                        deleteCmd.Parameters.AddWithValue("@KategoriID", kategoriId);
                        deleteCmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private void UrunleriListele()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT u.UrunID, u.UrunAdi, u.Fiyat, u.Stok, u.Resim, k.KategoriAdi, k.KategoriID
                        FROM Urunler u
                        INNER JOIN Kategoriler k ON u.KategoriID = k.KategoriID", connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
                KategorileriYukle();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürünler listelenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KategorileriYukle()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT DISTINCT k.KategoriID, k.KategoriAdi
                        FROM Kategoriler k
                        INNER JOIN Urunler u ON k.KategoriID = u.KategoriID
                        WHERE EXISTS (SELECT 1 FROM Urunler WHERE KategoriID = k.KategoriID)", connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            comboBox1.DataSource = dt;
                            comboBox1.DisplayMember = "KategoriAdi";
                            comboBox1.ValueMember = "KategoriID";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kategoriler yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
} 