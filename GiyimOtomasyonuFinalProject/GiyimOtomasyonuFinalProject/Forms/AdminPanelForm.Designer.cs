namespace GiyimOtomasyonuFinalProject
{
    partial class AdminPanelForm
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
            this.lblAdminAd = new System.Windows.Forms.Label();
            this.btnCikis = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabKategoriler = new System.Windows.Forms.TabPage();
            this.pnlKategoriEkle = new System.Windows.Forms.Panel();
            this.btnKategoriSil = new System.Windows.Forms.Button();
            this.btnKategoriDuzenle = new System.Windows.Forms.Button();
            this.txtKategoriAdi = new System.Windows.Forms.TextBox();
            this.lblKategoriAdi = new System.Windows.Forms.Label();
            this.btnKategoriEkle = new System.Windows.Forms.Button();
            this.lstKategoriler = new System.Windows.Forms.ListBox();
            this.tabUrunler = new System.Windows.Forms.TabPage();
            this.pnlUrunEkle = new System.Windows.Forms.Panel();
            this.btnUrunSil = new System.Windows.Forms.Button();
            this.btnUrunDuzenle = new System.Windows.Forms.Button();
            this.txtUrunAdi = new System.Windows.Forms.TextBox();
            this.lblUrunAdi = new System.Windows.Forms.Label();
            this.cmbKategori = new System.Windows.Forms.ComboBox();
            this.lblKategori = new System.Windows.Forms.Label();
            this.txtFiyat = new System.Windows.Forms.TextBox();
            this.lblFiyat = new System.Windows.Forms.Label();
            this.txtStok = new System.Windows.Forms.TextBox();
            this.lblStok = new System.Windows.Forms.Label();
            this.btnUrunEkle = new System.Windows.Forms.Button();
            this.pictureBoxUrun = new System.Windows.Forms.PictureBox();
            this.btnResimSec = new System.Windows.Forms.Button();
            this.lblResim = new System.Windows.Forms.Label();
            this.dgvUrunler = new System.Windows.Forms.DataGridView();
            this.tabMusteriler = new System.Windows.Forms.TabPage();
            this.btnMusteriDuzenle = new System.Windows.Forms.Button();
            this.btnMusteriEkle = new System.Windows.Forms.Button();
            this.btnMusteriSil = new System.Windows.Forms.Button();
            this.dgvMusteriler = new System.Windows.Forms.DataGridView();
            this.chkSadakatRaporu = new System.Windows.Forms.CheckBox();
            this.tabSatislar = new System.Windows.Forms.TabPage();
            this.btnSatisDetay = new System.Windows.Forms.Button();
            this.dgvSatislar = new System.Windows.Forms.DataGridView();
            this.pnlSolMenu.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabKategoriler.SuspendLayout();
            this.pnlKategoriEkle.SuspendLayout();
            this.tabUrunler.SuspendLayout();
            this.pnlUrunEkle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUrun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrunler)).BeginInit();
            this.tabMusteriler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMusteriler)).BeginInit();
            this.tabSatislar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSatislar)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSolMenu
            // 
            this.pnlSolMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.pnlSolMenu.Controls.Add(this.lblAdminAd);
            this.pnlSolMenu.Controls.Add(this.btnCikis);
            this.pnlSolMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSolMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlSolMenu.Name = "pnlSolMenu";
            this.pnlSolMenu.Size = new System.Drawing.Size(200, 700);
            this.pnlSolMenu.TabIndex = 0;
            // 
            // lblAdminAd
            // 
            this.lblAdminAd.AutoSize = true;
            this.lblAdminAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblAdminAd.ForeColor = System.Drawing.Color.White;
            this.lblAdminAd.Location = new System.Drawing.Point(12, 20);
            this.lblAdminAd.Name = "lblAdminAd";
            this.lblAdminAd.Size = new System.Drawing.Size(90, 20);
            this.lblAdminAd.TabIndex = 0;
            this.lblAdminAd.Text = "Admin Adı";
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
            this.btnCikis.TabIndex = 1;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.UseVisualStyleBackColor = false;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabKategoriler);
            this.tabControl.Controls.Add(this.tabUrunler);
            this.tabControl.Controls.Add(this.tabMusteriler);
            this.tabControl.Controls.Add(this.tabSatislar);
            this.tabControl.Location = new System.Drawing.Point(201, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1000, 700);
            this.tabControl.TabIndex = 1;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabKategoriler
            // 
            this.tabKategoriler.Controls.Add(this.pnlKategoriEkle);
            this.tabKategoriler.Controls.Add(this.lstKategoriler);
            this.tabKategoriler.Location = new System.Drawing.Point(4, 25);
            this.tabKategoriler.Name = "tabKategoriler";
            this.tabKategoriler.Padding = new System.Windows.Forms.Padding(3);
            this.tabKategoriler.Size = new System.Drawing.Size(992, 671);
            this.tabKategoriler.TabIndex = 0;
            this.tabKategoriler.Text = "Kategoriler";
            this.tabKategoriler.UseVisualStyleBackColor = true;
            // 
            // pnlKategoriEkle
            // 
            this.pnlKategoriEkle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlKategoriEkle.Controls.Add(this.btnKategoriSil);
            this.pnlKategoriEkle.Controls.Add(this.btnKategoriDuzenle);
            this.pnlKategoriEkle.Controls.Add(this.txtKategoriAdi);
            this.pnlKategoriEkle.Controls.Add(this.lblKategoriAdi);
            this.pnlKategoriEkle.Controls.Add(this.btnKategoriEkle);
            this.pnlKategoriEkle.Location = new System.Drawing.Point(300, 20);
            this.pnlKategoriEkle.Name = "pnlKategoriEkle";
            this.pnlKategoriEkle.Size = new System.Drawing.Size(400, 162);
            this.pnlKategoriEkle.TabIndex = 1;
            // 
            // btnKategoriSil
            // 
            this.btnKategoriSil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKategoriSil.BackColor = System.Drawing.Color.Red;
            this.btnKategoriSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKategoriSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnKategoriSil.ForeColor = System.Drawing.Color.White;
            this.btnKategoriSil.Location = new System.Drawing.Point(255, 111);
            this.btnKategoriSil.Name = "btnKategoriSil";
            this.btnKategoriSil.Size = new System.Drawing.Size(115, 35);
            this.btnKategoriSil.TabIndex = 6;
            this.btnKategoriSil.Text = "Sil";
            this.btnKategoriSil.UseVisualStyleBackColor = false;
            this.btnKategoriSil.Click += new System.EventHandler(this.btnKategoriSil_Click);
            // 
            // btnKategoriDuzenle
            // 
            this.btnKategoriDuzenle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKategoriDuzenle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnKategoriDuzenle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKategoriDuzenle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnKategoriDuzenle.ForeColor = System.Drawing.Color.White;
            this.btnKategoriDuzenle.Location = new System.Drawing.Point(120, 111);
            this.btnKategoriDuzenle.Name = "btnKategoriDuzenle";
            this.btnKategoriDuzenle.Size = new System.Drawing.Size(115, 35);
            this.btnKategoriDuzenle.TabIndex = 5;
            this.btnKategoriDuzenle.Text = "Düzenle";
            this.btnKategoriDuzenle.UseVisualStyleBackColor = false;
            this.btnKategoriDuzenle.Click += new System.EventHandler(this.btnKategoriDuzenle_Click);
            // 
            // txtKategoriAdi
            // 
            this.txtKategoriAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtKategoriAdi.Location = new System.Drawing.Point(120, 30);
            this.txtKategoriAdi.Name = "txtKategoriAdi";
            this.txtKategoriAdi.Size = new System.Drawing.Size(250, 23);
            this.txtKategoriAdi.TabIndex = 0;
            // 
            // lblKategoriAdi
            // 
            this.lblKategoriAdi.AutoSize = true;
            this.lblKategoriAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblKategoriAdi.Location = new System.Drawing.Point(20, 33);
            this.lblKategoriAdi.Name = "lblKategoriAdi";
            this.lblKategoriAdi.Size = new System.Drawing.Size(89, 17);
            this.lblKategoriAdi.TabIndex = 1;
            this.lblKategoriAdi.Text = "Kategori Adı:";
            // 
            // btnKategoriEkle
            // 
            this.btnKategoriEkle.BackColor = System.Drawing.Color.ForestGreen;
            this.btnKategoriEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKategoriEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnKategoriEkle.ForeColor = System.Drawing.Color.White;
            this.btnKategoriEkle.Location = new System.Drawing.Point(120, 70);
            this.btnKategoriEkle.Name = "btnKategoriEkle";
            this.btnKategoriEkle.Size = new System.Drawing.Size(250, 35);
            this.btnKategoriEkle.TabIndex = 2;
            this.btnKategoriEkle.Text = "Kategori Ekle";
            this.btnKategoriEkle.UseVisualStyleBackColor = false;
            this.btnKategoriEkle.Click += new System.EventHandler(this.btnKategoriEkle_Click);
            // 
            // lstKategoriler
            // 
            this.lstKategoriler.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstKategoriler.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lstKategoriler.FormattingEnabled = true;
            this.lstKategoriler.ItemHeight = 16;
            this.lstKategoriler.Location = new System.Drawing.Point(20, 20);
            this.lstKategoriler.Name = "lstKategoriler";
            this.lstKategoriler.Size = new System.Drawing.Size(250, 628);
            this.lstKategoriler.TabIndex = 0;
            // 
            // tabUrunler
            // 
            this.tabUrunler.Controls.Add(this.pnlUrunEkle);
            this.tabUrunler.Controls.Add(this.dgvUrunler);
            this.tabUrunler.Location = new System.Drawing.Point(4, 25);
            this.tabUrunler.Name = "tabUrunler";
            this.tabUrunler.Padding = new System.Windows.Forms.Padding(3);
            this.tabUrunler.Size = new System.Drawing.Size(992, 671);
            this.tabUrunler.TabIndex = 1;
            this.tabUrunler.Text = "Ürünler";
            this.tabUrunler.UseVisualStyleBackColor = true;
            // 
            // pnlUrunEkle
            // 
            this.pnlUrunEkle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlUrunEkle.Controls.Add(this.btnUrunSil);
            this.pnlUrunEkle.Controls.Add(this.btnUrunDuzenle);
            this.pnlUrunEkle.Controls.Add(this.txtUrunAdi);
            this.pnlUrunEkle.Controls.Add(this.lblUrunAdi);
            this.pnlUrunEkle.Controls.Add(this.cmbKategori);
            this.pnlUrunEkle.Controls.Add(this.lblKategori);
            this.pnlUrunEkle.Controls.Add(this.txtFiyat);
            this.pnlUrunEkle.Controls.Add(this.lblFiyat);
            this.pnlUrunEkle.Controls.Add(this.txtStok);
            this.pnlUrunEkle.Controls.Add(this.lblStok);
            this.pnlUrunEkle.Controls.Add(this.btnUrunEkle);
            this.pnlUrunEkle.Controls.Add(this.pictureBoxUrun);
            this.pnlUrunEkle.Controls.Add(this.btnResimSec);
            this.pnlUrunEkle.Controls.Add(this.lblResim);
            this.pnlUrunEkle.Location = new System.Drawing.Point(20, 20);
            this.pnlUrunEkle.Name = "pnlUrunEkle";
            this.pnlUrunEkle.Size = new System.Drawing.Size(811, 250);
            this.pnlUrunEkle.TabIndex = 0;
            // 
            // btnUrunSil
            // 
            this.btnUrunSil.BackColor = System.Drawing.Color.Red;
            this.btnUrunSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUrunSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnUrunSil.ForeColor = System.Drawing.Color.White;
            this.btnUrunSil.Location = new System.Drawing.Point(620, 143);
            this.btnUrunSil.Name = "btnUrunSil";
            this.btnUrunSil.Size = new System.Drawing.Size(150, 35);
            this.btnUrunSil.TabIndex = 15;
            this.btnUrunSil.Text = "Sil";
            this.btnUrunSil.UseVisualStyleBackColor = false;
            this.btnUrunSil.Click += new System.EventHandler(this.btnUrunSil_Click);
            // 
            // btnUrunDuzenle
            // 
            this.btnUrunDuzenle.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnUrunDuzenle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUrunDuzenle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnUrunDuzenle.ForeColor = System.Drawing.Color.White;
            this.btnUrunDuzenle.Location = new System.Drawing.Point(620, 84);
            this.btnUrunDuzenle.Name = "btnUrunDuzenle";
            this.btnUrunDuzenle.Size = new System.Drawing.Size(150, 35);
            this.btnUrunDuzenle.TabIndex = 14;
            this.btnUrunDuzenle.Text = "Düzenle";
            this.btnUrunDuzenle.UseVisualStyleBackColor = false;
            this.btnUrunDuzenle.Click += new System.EventHandler(this.btnUrunDuzenle_Click);
            // 
            // txtUrunAdi
            // 
            this.txtUrunAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtUrunAdi.Location = new System.Drawing.Point(120, 30);
            this.txtUrunAdi.Name = "txtUrunAdi";
            this.txtUrunAdi.Size = new System.Drawing.Size(250, 23);
            this.txtUrunAdi.TabIndex = 0;
            // 
            // lblUrunAdi
            // 
            this.lblUrunAdi.AutoSize = true;
            this.lblUrunAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblUrunAdi.Location = new System.Drawing.Point(20, 33);
            this.lblUrunAdi.Name = "lblUrunAdi";
            this.lblUrunAdi.Size = new System.Drawing.Size(67, 17);
            this.lblUrunAdi.TabIndex = 1;
            this.lblUrunAdi.Text = "Ürün Adı:";
            // 
            // cmbKategori
            // 
            this.cmbKategori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKategori.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbKategori.FormattingEnabled = true;
            this.cmbKategori.Location = new System.Drawing.Point(120, 70);
            this.cmbKategori.Name = "cmbKategori";
            this.cmbKategori.Size = new System.Drawing.Size(250, 24);
            this.cmbKategori.TabIndex = 2;
            // 
            // lblKategori
            // 
            this.lblKategori.AutoSize = true;
            this.lblKategori.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblKategori.Location = new System.Drawing.Point(20, 73);
            this.lblKategori.Name = "lblKategori";
            this.lblKategori.Size = new System.Drawing.Size(65, 17);
            this.lblKategori.TabIndex = 3;
            this.lblKategori.Text = "Kategori:";
            // 
            // txtFiyat
            // 
            this.txtFiyat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtFiyat.Location = new System.Drawing.Point(120, 110);
            this.txtFiyat.Name = "txtFiyat";
            this.txtFiyat.Size = new System.Drawing.Size(250, 23);
            this.txtFiyat.TabIndex = 4;
            // 
            // lblFiyat
            // 
            this.lblFiyat.AutoSize = true;
            this.lblFiyat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblFiyat.Location = new System.Drawing.Point(20, 113);
            this.lblFiyat.Name = "lblFiyat";
            this.lblFiyat.Size = new System.Drawing.Size(42, 17);
            this.lblFiyat.TabIndex = 5;
            this.lblFiyat.Text = "Fiyat:";
            // 
            // txtStok
            // 
            this.txtStok.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtStok.Location = new System.Drawing.Point(120, 150);
            this.txtStok.Name = "txtStok";
            this.txtStok.Size = new System.Drawing.Size(250, 23);
            this.txtStok.TabIndex = 6;
            // 
            // lblStok
            // 
            this.lblStok.AutoSize = true;
            this.lblStok.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblStok.Location = new System.Drawing.Point(20, 153);
            this.lblStok.Name = "lblStok";
            this.lblStok.Size = new System.Drawing.Size(40, 17);
            this.lblStok.TabIndex = 7;
            this.lblStok.Text = "Stok:";
            // 
            // btnUrunEkle
            // 
            this.btnUrunEkle.BackColor = System.Drawing.Color.ForestGreen;
            this.btnUrunEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUrunEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnUrunEkle.ForeColor = System.Drawing.Color.White;
            this.btnUrunEkle.Location = new System.Drawing.Point(120, 190);
            this.btnUrunEkle.Name = "btnUrunEkle";
            this.btnUrunEkle.Size = new System.Drawing.Size(250, 35);
            this.btnUrunEkle.TabIndex = 8;
            this.btnUrunEkle.Text = "Ürün Ekle";
            this.btnUrunEkle.UseVisualStyleBackColor = false;
            this.btnUrunEkle.Click += new System.EventHandler(this.btnUrunEkle_Click);
            // 
            // pictureBoxUrun
            // 
            this.pictureBoxUrun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxUrun.Location = new System.Drawing.Point(450, 30);
            this.pictureBoxUrun.Name = "pictureBoxUrun";
            this.pictureBoxUrun.Size = new System.Drawing.Size(150, 150);
            this.pictureBoxUrun.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxUrun.TabIndex = 9;
            this.pictureBoxUrun.TabStop = false;
            // 
            // btnResimSec
            // 
            this.btnResimSec.BackColor = System.Drawing.Color.Gold;
            this.btnResimSec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResimSec.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnResimSec.ForeColor = System.Drawing.Color.White;
            this.btnResimSec.Location = new System.Drawing.Point(620, 30);
            this.btnResimSec.Name = "btnResimSec";
            this.btnResimSec.Size = new System.Drawing.Size(150, 35);
            this.btnResimSec.TabIndex = 13;
            this.btnResimSec.Text = "Resim Seç";
            this.btnResimSec.UseVisualStyleBackColor = false;
            this.btnResimSec.Click += new System.EventHandler(this.btnResimSec_Click);
            // 
            // lblResim
            // 
            this.lblResim.AutoSize = true;
            this.lblResim.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblResim.Location = new System.Drawing.Point(450, 10);
            this.lblResim.Name = "lblResim";
            this.lblResim.Size = new System.Drawing.Size(86, 17);
            this.lblResim.TabIndex = 11;
            this.lblResim.Text = "Ürün Resmi:";
            // 
            // dgvUrunler
            // 
            this.dgvUrunler.AllowUserToAddRows = false;
            this.dgvUrunler.AllowUserToDeleteRows = false;
            this.dgvUrunler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUrunler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUrunler.BackgroundColor = System.Drawing.Color.White;
            this.dgvUrunler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUrunler.Location = new System.Drawing.Point(20, 289);
            this.dgvUrunler.Name = "dgvUrunler";
            this.dgvUrunler.ReadOnly = true;
            this.dgvUrunler.RowHeadersWidth = 51;
            this.dgvUrunler.RowTemplate.Height = 24;
            this.dgvUrunler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUrunler.Size = new System.Drawing.Size(954, 371);
            this.dgvUrunler.TabIndex = 1;
            // 
            // tabMusteriler
            // 
            this.tabMusteriler.Controls.Add(this.btnMusteriDuzenle);
            this.tabMusteriler.Controls.Add(this.btnMusteriEkle);
            this.tabMusteriler.Controls.Add(this.btnMusteriSil);
            this.tabMusteriler.Controls.Add(this.dgvMusteriler);
            this.tabMusteriler.Controls.Add(this.chkSadakatRaporu);
            this.tabMusteriler.Location = new System.Drawing.Point(4, 25);
            this.tabMusteriler.Name = "tabMusteriler";
            this.tabMusteriler.Padding = new System.Windows.Forms.Padding(3);
            this.tabMusteriler.Size = new System.Drawing.Size(992, 671);
            this.tabMusteriler.TabIndex = 2;
            this.tabMusteriler.Text = "Müşteriler";
            this.tabMusteriler.UseVisualStyleBackColor = true;
            // 
            // btnMusteriDuzenle
            // 
            this.btnMusteriDuzenle.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnMusteriDuzenle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMusteriDuzenle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnMusteriDuzenle.ForeColor = System.Drawing.Color.White;
            this.btnMusteriDuzenle.Location = new System.Drawing.Point(406, 12);
            this.btnMusteriDuzenle.Name = "btnMusteriDuzenle";
            this.btnMusteriDuzenle.Size = new System.Drawing.Size(150, 35);
            this.btnMusteriDuzenle.TabIndex = 17;
            this.btnMusteriDuzenle.Text = "Düzenle";
            this.btnMusteriDuzenle.UseVisualStyleBackColor = false;
            this.btnMusteriDuzenle.Click += new System.EventHandler(this.btnMusteriDuzenle_Click);
            // 
            // btnMusteriEkle
            // 
            this.btnMusteriEkle.BackColor = System.Drawing.Color.ForestGreen;
            this.btnMusteriEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMusteriEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnMusteriEkle.ForeColor = System.Drawing.Color.White;
            this.btnMusteriEkle.Location = new System.Drawing.Point(239, 12);
            this.btnMusteriEkle.Name = "btnMusteriEkle";
            this.btnMusteriEkle.Size = new System.Drawing.Size(150, 35);
            this.btnMusteriEkle.TabIndex = 16;
            this.btnMusteriEkle.Text = "Ekle";
            this.btnMusteriEkle.UseVisualStyleBackColor = false;
            this.btnMusteriEkle.Click += new System.EventHandler(this.btnMusteriEkle_Click);
            // 
            // btnMusteriSil
            // 
            this.btnMusteriSil.BackColor = System.Drawing.Color.Red;
            this.btnMusteriSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMusteriSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnMusteriSil.ForeColor = System.Drawing.Color.White;
            this.btnMusteriSil.Location = new System.Drawing.Point(571, 12);
            this.btnMusteriSil.Name = "btnMusteriSil";
            this.btnMusteriSil.Size = new System.Drawing.Size(150, 35);
            this.btnMusteriSil.TabIndex = 15;
            this.btnMusteriSil.Text = "Sil";
            this.btnMusteriSil.UseVisualStyleBackColor = false;
            this.btnMusteriSil.Click += new System.EventHandler(this.btnMusteriSil_Click);
            // 
            // dgvMusteriler
            // 
            this.dgvMusteriler.AllowUserToAddRows = false;
            this.dgvMusteriler.AllowUserToDeleteRows = false;
            this.dgvMusteriler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMusteriler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMusteriler.BackgroundColor = System.Drawing.Color.White;
            this.dgvMusteriler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMusteriler.Location = new System.Drawing.Point(19, 66);
            this.dgvMusteriler.Name = "dgvMusteriler";
            this.dgvMusteriler.ReadOnly = true;
            this.dgvMusteriler.RowHeadersWidth = 51;
            this.dgvMusteriler.RowTemplate.Height = 24;
            this.dgvMusteriler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMusteriler.Size = new System.Drawing.Size(952, 276);
            this.dgvMusteriler.TabIndex = 0;
            // 
            // chkSadakatRaporu
            // 
            this.chkSadakatRaporu.AutoSize = true;
            this.chkSadakatRaporu.Location = new System.Drawing.Point(12, 12);
            this.chkSadakatRaporu.Name = "chkSadakatRaporu";
            this.chkSadakatRaporu.Size = new System.Drawing.Size(209, 21);
            this.chkSadakatRaporu.TabIndex = 0;
            this.chkSadakatRaporu.Text = "Müşterilerin sadakatlerini gör";
            this.chkSadakatRaporu.UseVisualStyleBackColor = true;
            this.chkSadakatRaporu.CheckedChanged += new System.EventHandler(this.chkSadakatRaporu_CheckedChanged);
            // 
            // tabSatislar
            // 
            this.tabSatislar.Controls.Add(this.btnSatisDetay);
            this.tabSatislar.Controls.Add(this.dgvSatislar);
            this.tabSatislar.Location = new System.Drawing.Point(4, 25);
            this.tabSatislar.Name = "tabSatislar";
            this.tabSatislar.Padding = new System.Windows.Forms.Padding(3);
            this.tabSatislar.Size = new System.Drawing.Size(992, 671);
            this.tabSatislar.TabIndex = 3;
            this.tabSatislar.Text = "Satışlar";
            this.tabSatislar.UseVisualStyleBackColor = true;
            // 
            // btnSatisDetay
            // 
            this.btnSatisDetay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSatisDetay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnSatisDetay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSatisDetay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnSatisDetay.ForeColor = System.Drawing.Color.White;
            this.btnSatisDetay.Location = new System.Drawing.Point(797, 617);
            this.btnSatisDetay.Name = "btnSatisDetay";
            this.btnSatisDetay.Size = new System.Drawing.Size(175, 35);
            this.btnSatisDetay.TabIndex = 1;
            this.btnSatisDetay.Text = "Satış Detayı";
            this.btnSatisDetay.UseVisualStyleBackColor = false;
            this.btnSatisDetay.Click += new System.EventHandler(this.btnSatisDetay_Click);
            // 
            // dgvSatislar
            // 
            this.dgvSatislar.AllowUserToAddRows = false;
            this.dgvSatislar.AllowUserToDeleteRows = false;
            this.dgvSatislar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSatislar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSatislar.BackgroundColor = System.Drawing.Color.White;
            this.dgvSatislar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSatislar.Location = new System.Drawing.Point(20, 25);
            this.dgvSatislar.Name = "dgvSatislar";
            this.dgvSatislar.ReadOnly = true;
            this.dgvSatislar.RowHeadersWidth = 51;
            this.dgvSatislar.RowTemplate.Height = 24;
            this.dgvSatislar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSatislar.Size = new System.Drawing.Size(952, 539);
            this.dgvSatislar.TabIndex = 0;
            // 
            // AdminPanelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pnlSolMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AdminPanelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giyim Otomasyonu - Admin Paneli";
            this.Load += new System.EventHandler(this.AdminPanelForm_Load);
            this.pnlSolMenu.ResumeLayout(false);
            this.pnlSolMenu.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabKategoriler.ResumeLayout(false);
            this.pnlKategoriEkle.ResumeLayout(false);
            this.pnlKategoriEkle.PerformLayout();
            this.tabUrunler.ResumeLayout(false);
            this.pnlUrunEkle.ResumeLayout(false);
            this.pnlUrunEkle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUrun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrunler)).EndInit();
            this.tabMusteriler.ResumeLayout(false);
            this.tabMusteriler.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMusteriler)).EndInit();
            this.tabSatislar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSatislar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSolMenu;
        private System.Windows.Forms.Label lblAdminAd;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabKategoriler;
        private System.Windows.Forms.Panel pnlKategoriEkle;
        private System.Windows.Forms.TextBox txtKategoriAdi;
        private System.Windows.Forms.Label lblKategoriAdi;
        private System.Windows.Forms.Button btnKategoriEkle;
        private System.Windows.Forms.ListBox lstKategoriler;
        private System.Windows.Forms.TabPage tabUrunler;
        private System.Windows.Forms.Panel pnlUrunEkle;
        private System.Windows.Forms.TextBox txtUrunAdi;
        private System.Windows.Forms.Label lblUrunAdi;
        private System.Windows.Forms.ComboBox cmbKategori;
        private System.Windows.Forms.Label lblKategori;
        private System.Windows.Forms.TextBox txtFiyat;
        private System.Windows.Forms.Label lblFiyat;
        private System.Windows.Forms.TextBox txtStok;
        private System.Windows.Forms.Label lblStok;
        private System.Windows.Forms.Button btnUrunEkle;
        private System.Windows.Forms.PictureBox pictureBoxUrun;
        private System.Windows.Forms.Button btnResimSec;
        private System.Windows.Forms.Label lblResim;
        private System.Windows.Forms.DataGridView dgvUrunler;
        private System.Windows.Forms.TabPage tabMusteriler;
        private System.Windows.Forms.DataGridView dgvMusteriler;
        private System.Windows.Forms.TabPage tabSatislar;
        private System.Windows.Forms.Button btnSatisDetay;
        private System.Windows.Forms.DataGridView dgvSatislar;
        private System.Windows.Forms.Button btnUrunDuzenle;
        private System.Windows.Forms.Button btnUrunSil;
        private System.Windows.Forms.Button btnMusteriSil;
        private System.Windows.Forms.Button btnMusteriEkle;
        private System.Windows.Forms.Button btnMusteriDuzenle;
        private System.Windows.Forms.Button btnKategoriDuzenle;
        private System.Windows.Forms.Button btnKategoriSil;
        private System.Windows.Forms.CheckBox chkSadakatRaporu;
    }
} 