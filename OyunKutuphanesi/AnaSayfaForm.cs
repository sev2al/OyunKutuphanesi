using System;
using System.Drawing;
using System.Windows.Forms;

namespace OyunKutuphanesi
{
    public partial class AnaSayfaForm : Form
    {
        private Button hafizaOyunuButon;
        private Label baslikLabel;

        public AnaSayfaForm()
        {
            InitializeComponent();
            KontrolleriOlustur();
        }

        private void KontrolleriOlustur()
        {
            // Form özellikleri
            this.Text = "Oyun Kütüphanesi";
            this.Size = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 240, 240);

            // Başlık
            baslikLabel = new Label
            {
                Text = "Oyun Kütüphanesi",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.DarkSlateBlue,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 100
            };

            // Hafıza Oyunu Butonu
            hafizaOyunuButon = new Button
            {
                Text = "Hafıza Oyunu",
                Size = new Size(200, 60),
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                BackColor = Color.CornflowerBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            hafizaOyunuButon.FlatAppearance.BorderSize = 0;
            hafizaOyunuButon.Location = new Point(
                (this.ClientSize.Width - hafizaOyunuButon.Width) / 2,
                (this.ClientSize.Height - hafizaOyunuButon.Height) / 2
            );

            // Hover efekti
            hafizaOyunuButon.MouseEnter += (s, e) => 
            {
                hafizaOyunuButon.BackColor = Color.RoyalBlue;
            };
            hafizaOyunuButon.MouseLeave += (s, e) => 
            {
                hafizaOyunuButon.BackColor = Color.CornflowerBlue;
            };

            // Tıklama olayı
            hafizaOyunuButon.Click += HafizaOyunuButon_Click;

            // Kontrolleri forma ekle
            this.Controls.AddRange(new Control[] { baslikLabel, hafizaOyunuButon });

            // Form yeniden boyutlandırıldığında butonun konumunu güncelle
            this.Resize += (s, e) =>
            {
                hafizaOyunuButon.Location = new Point(
                    (this.ClientSize.Width - hafizaOyunuButon.Width) / 2,
                    (this.ClientSize.Height - hafizaOyunuButon.Height) / 2
                );
            };
        }

        private void HafizaOyunuButon_Click(object sender, EventArgs e)
        {
            // Hafıza oyunu formunu aç
            using (var hafizaOyunu = new HafizaOyunuForm())
            {
                this.Hide();
                hafizaOyunu.ShowDialog();
                this.Show();
            }
        }
    }
} 