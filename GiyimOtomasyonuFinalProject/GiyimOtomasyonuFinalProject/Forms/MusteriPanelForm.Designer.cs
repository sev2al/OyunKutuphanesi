namespace GiyimOtomasyonuFinalProject
{
    partial class MusteriPanelForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlSolMenu = new System.Windows.Forms.Panel();
            this.lblMusteriAd = new System.Windows.Forms.Label();
            this.lblPuan = new System.Windows.Forms.Label();
            this.btnCikis = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabUrunler = new System.Windows.Forms.TabPage();
            this.pnlUrunArama = new System.Windows.Forms.Panel();
            this.txtArama = new System.Windows.Forms.TextBox();
            this.btnAra = new System.Windows.Forms.Button();
            this.pnlKategori = new System.Windows.Forms.Panel();
            this.lstKategoriler = new System.Windows.Forms.ListBox();
            this.lblKategoriler = new System.Windows.Forms.Label();
            this.flowLayoutPanelUrunler = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlSepeteEkle = new System.Windows.Forms.Panel();
            this.txtAdet = new System.Windows.Forms.TextBox();
            this.lblAdet = new System.Windows.Forms.Label();
            this.btnSepeteEkle = new System.Windows.Forms.Button();
            this.pnlUrunDetay = new System.Windows.Forms.Panel();
            this.pictureBoxUrunDetay = new System.Windows.Forms.PictureBox();
            this.lblUrunDetayBaslik = new System.Windows.Forms.Label();
            this.tabSepet = new System.Windows.Forms.TabPage();
            this.pnlOdeme = new System.Windows.Forms.Panel();
            this.lblToplamTutar = new System.Windows.Forms.Label();
            this.btnSatinAl = new System.Windows.Forms.Button();
            this.btnSepettenCikar = new System.Windows.Forms.Button();
            this.dgvSepet = new System.Windows.Forms.DataGridView();
            this.tabSiparisler = new System.Windows.Forms.TabPage();
            this.dgvSiparisler = new System.Windows.Forms.DataGridView();
            this.pnlSolMenu.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabUrunler.SuspendLayout();
            this.pnlUrunArama.SuspendLayout();
            this.pnlKategori.SuspendLayout();
            this.pnlSepeteEkle.SuspendLayout();
            this.pnlUrunDetay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUrunDetay)).BeginInit();
            this.tabSepet.SuspendLayout();
            this.pnlOdeme.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSepet)).BeginInit();
            this.tabSiparisler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSiparisler)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSolMenu
            // 
            this.pnlSolMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.pnlSolMenu.Controls.Add(this.lblMusteriAd);
            this.pnlSolMenu.Controls.Add(this.lblPuan);
            this.pnlSolMenu.Controls.Add(this.btnCikis);
            this.pnlSolMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSolMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlSolMenu.Name = "pnlSolMenu";
            this.pnlSolMenu.Size = new System.Drawing.Size(200, 700);
            this.pnlSolMenu.TabIndex = 0;
            // 
            // lblMusteriAd
            // 
            this.lblMusteriAd.AutoSize = true;
            this.lblMusteriAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblMusteriAd.ForeColor = System.Drawing.Color.White;
            this.lblMusteriAd.Location = new System.Drawing.Point(12, 20);
            this.lblMusteriAd.Name = "lblMusteriAd";
            this.lblMusteriAd.Size = new System.Drawing.Size(99, 20);
            this.lblMusteriAd.TabIndex = 0;
            this.lblMusteriAd.Text = "Müşteri Adı";
            // 
            // lblPuan
            // 
            this.lblPuan.AutoSize = true;
            this.lblPuan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblPuan.ForeColor = System.Drawing.Color.White;
            this.lblPuan.Location = new System.Drawing.Point(12, 50);
            this.lblPuan.Name = "lblPuan";
            this.lblPuan.Size = new System.Drawing.Size(57, 17);
            this.lblPuan.TabIndex = 1;
            this.lblPuan.Text = "Puan: 0";
            // 
            // btnCikis
            // 
            this.btnCikis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCikis.BackColor = System.Drawing.Color.Red;
            this.btnCikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCikis.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnCikis.ForeColor = System.Drawing.Color.White;
            this.btnCikis.Location = new System.Drawing.Point(12, 650);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(175, 35);
            this.btnCikis.TabIndex = 2;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.UseVisualStyleBackColor = false;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabUrunler);
            this.tabControl.Controls.Add(this.tabSepet);
            this.tabControl.Controls.Add(this.tabSiparisler);
            this.tabControl.Location = new System.Drawing.Point(200, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1000, 700);
            this.tabControl.TabIndex = 1;
            // 
            // tabUrunler
            // 
            this.tabUrunler.Controls.Add(this.pnlUrunArama);
            this.tabUrunler.Controls.Add(this.pnlKategori);
            this.tabUrunler.Controls.Add(this.flowLayoutPanelUrunler);
            this.tabUrunler.Controls.Add(this.pnlSepeteEkle);
            this.tabUrunler.Controls.Add(this.pnlUrunDetay);
            this.tabUrunler.Location = new System.Drawing.Point(4, 25);
            this.tabUrunler.Name = "tabUrunler";
            this.tabUrunler.Padding = new System.Windows.Forms.Padding(3);
            this.tabUrunler.Size = new System.Drawing.Size(992, 671);
            this.tabUrunler.TabIndex = 0;
            this.tabUrunler.Text = "Ürünler";
            this.tabUrunler.UseVisualStyleBackColor = true;
            // 
            // pnlUrunArama
            // 
            this.pnlUrunArama.Controls.Add(this.txtArama);
            this.pnlUrunArama.Controls.Add(this.btnAra);
            this.pnlUrunArama.Location = new System.Drawing.Point(6, 6);
            this.pnlUrunArama.Name = "pnlUrunArama";
            this.pnlUrunArama.Size = new System.Drawing.Size(280, 50);
            this.pnlUrunArama.TabIndex = 0;
            // 
            // txtArama
            // 
            this.txtArama.Location = new System.Drawing.Point(3, 18);
            this.txtArama.Name = "txtArama";
            this.txtArama.Size = new System.Drawing.Size(200, 23);
            this.txtArama.TabIndex = 0;
            // 
            // btnAra
            // 
            this.btnAra.Location = new System.Drawing.Point(209, 15);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(75, 23);
            this.btnAra.TabIndex = 1;
            this.btnAra.Text = "Ara";
            this.btnAra.UseVisualStyleBackColor = true;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // pnlKategori
            // 
            this.pnlKategori.Controls.Add(this.lstKategoriler);
            this.pnlKategori.Controls.Add(this.lblKategoriler);
            this.pnlKategori.Location = new System.Drawing.Point(300, 6);
            this.pnlKategori.Name = "pnlKategori";
            this.pnlKategori.Size = new System.Drawing.Size(200, 50);
            this.pnlKategori.TabIndex = 1;
            // 
            // lstKategoriler
            // 
            this.lstKategoriler.FormattingEnabled = true;
            this.lstKategoriler.ItemHeight = 16;
            this.lstKategoriler.Location = new System.Drawing.Point(3, 18);
            this.lstKategoriler.Name = "lstKategoriler";
            this.lstKategoriler.Size = new System.Drawing.Size(194, 20);
            this.lstKategoriler.TabIndex = 0;
            // 
            // lblKategoriler
            // 
            this.lblKategoriler.AutoSize = true;
            this.lblKategoriler.Location = new System.Drawing.Point(3, 3);
            this.lblKategoriler.Name = "lblKategoriler";
            this.lblKategoriler.Size = new System.Drawing.Size(77, 17);
            this.lblKategoriler.TabIndex = 0;
            this.lblKategoriler.Text = "Kategoriler";
            // 
            // flowLayoutPanelUrunler
            // 
            this.flowLayoutPanelUrunler.AutoScroll = true;
            this.flowLayoutPanelUrunler.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelUrunler.Location = new System.Drawing.Point(6, 62);
            this.flowLayoutPanelUrunler.Name = "flowLayoutPanelUrunler";
            this.flowLayoutPanelUrunler.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanelUrunler.Size = new System.Drawing.Size(980, 300);
            this.flowLayoutPanelUrunler.TabIndex = 0;
            // 
            // pnlSepeteEkle
            // 
            this.pnlSepeteEkle.Controls.Add(this.txtAdet);
            this.pnlSepeteEkle.Controls.Add(this.lblAdet);
            this.pnlSepeteEkle.Controls.Add(this.btnSepeteEkle);
            this.pnlSepeteEkle.Location = new System.Drawing.Point(6, 368);
            this.pnlSepeteEkle.Name = "pnlSepeteEkle";
            this.pnlSepeteEkle.Size = new System.Drawing.Size(280, 50);
            this.pnlSepeteEkle.TabIndex = 2;
            // 
            // txtAdet
            // 
            this.txtAdet.Location = new System.Drawing.Point(3, 18);
            this.txtAdet.Name = "txtAdet";
            this.txtAdet.Size = new System.Drawing.Size(100, 23);
            this.txtAdet.TabIndex = 0;
            // 
            // lblAdet
            // 
            this.lblAdet.AutoSize = true;
            this.lblAdet.Location = new System.Drawing.Point(109, 18);
            this.lblAdet.Name = "lblAdet";
            this.lblAdet.Size = new System.Drawing.Size(37, 17);
            this.lblAdet.TabIndex = 1;
            this.lblAdet.Text = "Adet";
            // 
            // btnSepeteEkle
            // 
            this.btnSepeteEkle.Location = new System.Drawing.Point(197, 15);
            this.btnSepeteEkle.Name = "btnSepeteEkle";
            this.btnSepeteEkle.Size = new System.Drawing.Size(75, 23);
            this.btnSepeteEkle.TabIndex = 2;
            this.btnSepeteEkle.Text = "Sepete Ekle";
            this.btnSepeteEkle.UseVisualStyleBackColor = true;
            this.btnSepeteEkle.Click += new System.EventHandler(this.btnSepeteEkle_Click);
            // 
            // pnlUrunDetay
            // 
            this.pnlUrunDetay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlUrunDetay.Controls.Add(this.pictureBoxUrunDetay);
            this.pnlUrunDetay.Controls.Add(this.lblUrunDetayBaslik);
            this.pnlUrunDetay.Location = new System.Drawing.Point(600, 20);
            this.pnlUrunDetay.Name = "pnlUrunDetay";
            this.pnlUrunDetay.Size = new System.Drawing.Size(250, 300);
            this.pnlUrunDetay.TabIndex = 3;
            // 
            // pictureBoxUrunDetay
            // 
            this.pictureBoxUrunDetay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxUrunDetay.Location = new System.Drawing.Point(10, 60);
            this.pictureBoxUrunDetay.Name = "pictureBoxUrunDetay";
            this.pictureBoxUrunDetay.Size = new System.Drawing.Size(230, 230);
            this.pictureBoxUrunDetay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxUrunDetay.TabIndex = 1;
            this.pictureBoxUrunDetay.TabStop = false;
            // 
            // lblUrunDetayBaslik
            // 
            this.lblUrunDetayBaslik.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblUrunDetayBaslik.Location = new System.Drawing.Point(10, 10);
            this.lblUrunDetayBaslik.Name = "lblUrunDetayBaslik";
            this.lblUrunDetayBaslik.Size = new System.Drawing.Size(230, 40);
            this.lblUrunDetayBaslik.TabIndex = 0;
            this.lblUrunDetayBaslik.Text = "Ürün Adı";
            this.lblUrunDetayBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabSepet
            // 
            this.tabSepet.Controls.Add(this.pnlOdeme);
            this.tabSepet.Location = new System.Drawing.Point(4, 25);
            this.tabSepet.Name = "tabSepet";
            this.tabSepet.Padding = new System.Windows.Forms.Padding(3);
            this.tabSepet.Size = new System.Drawing.Size(992, 671);
            this.tabSepet.TabIndex = 1;
            this.tabSepet.Text = "Sepet";
            this.tabSepet.UseVisualStyleBackColor = true;
            // 
            // pnlOdeme
            // 
            this.pnlOdeme.Controls.Add(this.lblToplamTutar);
            this.pnlOdeme.Controls.Add(this.btnSatinAl);
            this.pnlOdeme.Controls.Add(this.btnSepettenCikar);
            this.pnlOdeme.Controls.Add(this.dgvSepet);
            this.pnlOdeme.Location = new System.Drawing.Point(6, 62);
            this.pnlOdeme.Name = "pnlOdeme";
            this.pnlOdeme.Size = new System.Drawing.Size(980, 300);
            this.pnlOdeme.TabIndex = 0;
            // 
            // lblToplamTutar
            // 
            this.lblToplamTutar.AutoSize = true;
            this.lblToplamTutar.Location = new System.Drawing.Point(3, 232);
            this.lblToplamTutar.Name = "lblToplamTutar";
            this.lblToplamTutar.Size = new System.Drawing.Size(109, 17);
            this.lblToplamTutar.TabIndex = 4;
            this.lblToplamTutar.Text = "Toplam Tutar: 0";
            // 
            // btnSatinAl
            // 
            this.btnSatinAl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSatinAl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSatinAl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSatinAl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnSatinAl.ForeColor = System.Drawing.Color.White;
            this.btnSatinAl.Location = new System.Drawing.Point(12, 252);
            this.btnSatinAl.Name = "btnSatinAl";
            this.btnSatinAl.Size = new System.Drawing.Size(100, 35);
            this.btnSatinAl.TabIndex = 5;
            this.btnSatinAl.Text = "Satın Al";
            this.btnSatinAl.UseVisualStyleBackColor = false;
            this.btnSatinAl.Click += new System.EventHandler(this.btnSatinAl_Click);
            // 
            // btnSepettenCikar
            // 
            this.btnSepettenCikar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnSepettenCikar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSepettenCikar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSepettenCikar.ForeColor = System.Drawing.Color.White;
            this.btnSepettenCikar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSepettenCikar.Location = new System.Drawing.Point(128, 252);
            this.btnSepettenCikar.Name = "btnSepettenCikar";
            this.btnSepettenCikar.Size = new System.Drawing.Size(120, 35);
            this.btnSepettenCikar.TabIndex = 6;
            this.btnSepettenCikar.Text = "Sepetten Çıkar";
            this.btnSepettenCikar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSepettenCikar.UseVisualStyleBackColor = false;
            this.btnSepettenCikar.Click += new System.EventHandler(this.btnSepettenCikar_Click);
            // 
            // dgvSepet
            // 
            this.dgvSepet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSepet.Location = new System.Drawing.Point(3, 3);
            this.dgvSepet.Name = "dgvSepet";
            this.dgvSepet.Size = new System.Drawing.Size(984, 223);
            this.dgvSepet.TabIndex = 7;
            // 
            // tabSiparisler
            // 
            this.tabSiparisler.Controls.Add(this.dgvSiparisler);
            this.tabSiparisler.Location = new System.Drawing.Point(4, 25);
            this.tabSiparisler.Name = "tabSiparisler";
            this.tabSiparisler.Padding = new System.Windows.Forms.Padding(3);
            this.tabSiparisler.Size = new System.Drawing.Size(992, 671);
            this.tabSiparisler.TabIndex = 2;
            this.tabSiparisler.Text = "Siparişler";
            this.tabSiparisler.UseVisualStyleBackColor = true;
            // 
            // dgvSiparisler
            // 
            this.dgvSiparisler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSiparisler.Location = new System.Drawing.Point(6, 6);
            this.dgvSiparisler.Name = "dgvSiparisler";
            this.dgvSiparisler.Size = new System.Drawing.Size(980, 659);
            this.dgvSiparisler.TabIndex = 1;
            // 
            // MusteriPanelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pnlSolMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MusteriPanelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giyim Otomasyonu - Müşteri Paneli";
            this.Load += new System.EventHandler(this.MusteriPanelForm_Load);
            this.pnlSolMenu.ResumeLayout(false);
            this.pnlSolMenu.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabUrunler.ResumeLayout(false);
            this.pnlUrunArama.ResumeLayout(false);
            this.pnlUrunArama.PerformLayout();
            this.pnlKategori.ResumeLayout(false);
            this.pnlKategori.PerformLayout();
            this.pnlSepeteEkle.ResumeLayout(false);
            this.pnlSepeteEkle.PerformLayout();
            this.pnlUrunDetay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUrunDetay)).EndInit();
            this.tabSepet.ResumeLayout(false);
            this.pnlOdeme.ResumeLayout(false);
            this.pnlOdeme.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSepet)).EndInit();
            this.tabSiparisler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSiparisler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSolMenu;
        private System.Windows.Forms.Label lblMusteriAd;
        private System.Windows.Forms.Label lblPuan;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabUrunler;
        private System.Windows.Forms.Panel pnlUrunArama;
        private System.Windows.Forms.TextBox txtArama;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.Panel pnlKategori;
        private System.Windows.Forms.ListBox lstKategoriler;
        private System.Windows.Forms.Label lblKategoriler;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelUrunler;
        private System.Windows.Forms.Panel pnlSepeteEkle;
        private System.Windows.Forms.TextBox txtAdet;
        private System.Windows.Forms.Label lblAdet;
        private System.Windows.Forms.Button btnSepeteEkle;
        private System.Windows.Forms.TabPage tabSepet;
        private System.Windows.Forms.Panel pnlOdeme;
        private System.Windows.Forms.Label lblToplamTutar;
        private System.Windows.Forms.Button btnSatinAl;
        private System.Windows.Forms.Button btnSepettenCikar;
        private System.Windows.Forms.DataGridView dgvSepet;
        private System.Windows.Forms.TabPage tabSiparisler;
        private System.Windows.Forms.DataGridView dgvSiparisler;
        private System.Windows.Forms.Panel pnlUrunDetay;
        private System.Windows.Forms.Label lblUrunDetayBaslik;
        private System.Windows.Forms.PictureBox pictureBoxUrunDetay;
    }
} 