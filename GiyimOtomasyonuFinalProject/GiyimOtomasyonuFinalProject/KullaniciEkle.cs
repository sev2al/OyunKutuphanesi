using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GiyimOtomasyonuFinalProject
{
    public partial class KullaniciEkle : Form
    {
        private string connectionString = "Data Source=your_server;Initial Catalog=your_database;Integrated Security=True";

        public KullaniciEkle()
        {
            InitializeComponent();
        }

        private void KullaniciSil()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int kullaniciId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["KullaniciID"].Value);
                string kullaniciAdi = dataGridView1.SelectedRows[0].Cells["Ad"].Value.ToString() + " " + dataGridView1.SelectedRows[0].Cells["Soyad"].Value.ToString();

                DialogResult result = MessageBox.Show($"{kullaniciAdi} kullanıcısını silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                                    // Önce adresleri sil
                                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Adres WHERE MusteriId = @KullaniciID", connection, transaction))
                                    {
                                        cmd.Parameters.AddWithValue("@KullaniciID", kullaniciId);
                                        cmd.ExecuteNonQuery();
                                    }

                                    // Satış detaylarını sil
                                    using (SqlCommand cmd = new SqlCommand("DELETE FROM SatisDetaylari WHERE SatisID IN (SELECT SatisID FROM Satislar WHERE KullaniciID = @KullaniciID)", connection, transaction))
                                    {
                                        cmd.Parameters.AddWithValue("@KullaniciID", kullaniciId);
                                        cmd.ExecuteNonQuery();
                                    }

                                    // Satışları sil
                                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Satislar WHERE KullaniciID = @KullaniciID", connection, transaction))
                                    {
                                        cmd.Parameters.AddWithValue("@KullaniciID", kullaniciId);
                                        cmd.ExecuteNonQuery();
                                    }

                                    // Sepet detaylarını sil
                                    using (SqlCommand cmd = new SqlCommand("DELETE FROM SepetDetaylari WHERE SepetID IN (SELECT SepetID FROM Sepetler WHERE KullaniciID = @KullaniciID)", connection, transaction))
                                    {
                                        cmd.Parameters.AddWithValue("@KullaniciID", kullaniciId);
                                        cmd.ExecuteNonQuery();
                                    }

                                    // Sepetleri sil
                                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Sepetler WHERE KullaniciID = @KullaniciID", connection, transaction))
                                    {
                                        cmd.Parameters.AddWithValue("@KullaniciID", kullaniciId);
                                        cmd.ExecuteNonQuery();
                                    }

                                    // En son kullanıcıyı sil
                                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Kullanicilar WHERE KullaniciID = @KullaniciID", connection, transaction))
                                    {
                                        cmd.Parameters.AddWithValue("@KullaniciID", kullaniciId);
                                        cmd.ExecuteNonQuery();
                                    }

                                    transaction.Commit();
                                    MessageBox.Show("Kullanıcı başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    KullanicilariListele();
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
                MessageBox.Show("Lütfen silmek istediğiniz kullanıcıyı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
} 