using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace OyunKutuphanesi
{
    public partial class HafizaOyunuSkorTablosuForm : Form
    {
        private DataGridView skorGrid;
        private ComboBox zorlukSecici;

        public HafizaOyunuSkorTablosuForm()
        {
            InitializeComponent();
            KontrolleriOlustur();
            SkorlariYukle();
        }

        private void KontrolleriOlustur()
        {
            this.Text = "Hafıza Oyunu - Skor Tablosu";
            this.Size = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterParent;
            this.MinimumSize = new Size(500, 300);

            // Üst panel
            Panel ustPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.LightSteelBlue
            };

            // Zorluk seviyesi seçici
            zorlukSecici = new ComboBox
            {
                Location = new Point(10, 15),
                Size = new Size(120, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            zorlukSecici.Items.AddRange(new string[] { "Tüm Zorluklar", "Kolay", "Orta", "Zor" });
            zorlukSecici.SelectedIndex = 0;
            zorlukSecici.SelectedIndexChanged += ZorlukSecici_SelectedIndexChanged;

            Label zorlukLabel = new Label
            {
                Text = "Zorluk Seviyesi:",
                Location = new Point(10, 0),
                AutoSize = true
            };

            // Skor grid
            skorGrid = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackgroundColor = Color.White,
                RowHeadersVisible = false
            };

            // Kontrolleri forma ekle
            ustPanel.Controls.Add(zorlukLabel);
            ustPanel.Controls.Add(zorlukSecici);
            this.Controls.Add(ustPanel);
            this.Controls.Add(skorGrid);
        }

        private void SkorlariYukle()
        {
            try
            {
                string zorlukKosulu = zorlukSecici.SelectedIndex switch
                {
                    0 => "",  // Tüm zorluklar
                    1 => " AND ZorlukSeviyesi = 'Kolay'",
                    2 => " AND ZorlukSeviyesi = 'Orta'",
                    3 => " AND ZorlukSeviyesi = 'Zor'",
                    _ => ""
                };

                string sorgu = @"
                    SELECT 
                        ROW_NUMBER() OVER (ORDER BY s.Skor DESC) as Sıra,
                        k.KullaniciAdi as 'Kullanıcı Adı',
                        CASE 
                            WHEN s.OyunID = 1 THEN 'Kolay'
                            WHEN s.OyunID = 2 THEN 'Orta'
                            WHEN s.OyunID = 3 THEN 'Zor'
                        END as 'Zorluk',
                        s.Skor as 'Skor',
                        s.OynananTarih as 'Tarih'
                    FROM OyunSkorlari s
                    INNER JOIN Kullanicilar k ON s.KullaniciID = k.KullaniciID
                    WHERE s.OyunID IN (1, 2, 3)" + zorlukKosulu + @"
                    ORDER BY s.Skor DESC";

                using (var baglanti = VeritabaniBaglantisi.BaglantiOlustur())
                {
                    DataTable dt = new DataTable();
                    using (var adapter = new System.Data.SqlClient.SqlDataAdapter(sorgu, baglanti))
                    {
                        adapter.Fill(dt);
                    }
                    skorGrid.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Skorlar yüklenirken bir hata oluştu: " + ex.Message,
                              "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ZorlukSecici_SelectedIndexChanged(object sender, EventArgs e)
        {
            SkorlariYukle();
        }
    }
} 