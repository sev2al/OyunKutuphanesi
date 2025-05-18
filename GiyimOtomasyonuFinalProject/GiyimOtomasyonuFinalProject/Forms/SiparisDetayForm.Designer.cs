namespace GiyimOtomasyonuFinalProject
{
    partial class SiparisDetayForm
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
            this.pnlBaslik = new System.Windows.Forms.Panel();
            this.lblSiparisNo = new System.Windows.Forms.Label();
            this.lblTarih = new System.Windows.Forms.Label();
            this.lblToplamTutar = new System.Windows.Forms.Label();
            this.lblOdemeTuru = new System.Windows.Forms.Label();
            this.lblKargoDurumu = new System.Windows.Forms.Label();
            this.dgvSiparisDetay = new System.Windows.Forms.DataGridView();
            this.btnKapat = new System.Windows.Forms.Button();
            this.btnKargoyaVer = new System.Windows.Forms.Button();
            this.btnTeslimEdildi = new System.Windows.Forms.Button();
            
            // pnlBaslik
            this.pnlBaslik.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnlBaslik.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBaslik.Location = new System.Drawing.Point(0, 0);
            this.pnlBaslik.Name = "pnlBaslik";
            this.pnlBaslik.Size = new System.Drawing.Size(684, 100);
            this.pnlBaslik.TabIndex = 0;
            
            // lblSiparisNo
            this.lblSiparisNo.AutoSize = true;
            this.lblSiparisNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblSiparisNo.Location = new System.Drawing.Point(12, 20);
            this.lblSiparisNo.Name = "lblSiparisNo";
            this.lblSiparisNo.Size = new System.Drawing.Size(93, 20);
            this.lblSiparisNo.TabIndex = 0;
            this.lblSiparisNo.Text = "Sipariş No:";
            this.pnlBaslik.Controls.Add(this.lblSiparisNo);
            
            // lblTarih
            this.lblTarih.AutoSize = true;
            this.lblTarih.Location = new System.Drawing.Point(12, 50);
            this.lblTarih.Name = "lblTarih";
            this.lblTarih.Size = new System.Drawing.Size(44, 17);
            this.lblTarih.TabIndex = 1;
            this.lblTarih.Text = "Tarih:";
            this.pnlBaslik.Controls.Add(this.lblTarih);
            
            // lblToplamTutar
            this.lblToplamTutar.AutoSize = true;
            this.lblToplamTutar.Location = new System.Drawing.Point(300, 20);
            this.lblToplamTutar.Name = "lblToplamTutar";
            this.lblToplamTutar.Size = new System.Drawing.Size(102, 17);
            this.lblToplamTutar.TabIndex = 2;
            this.lblToplamTutar.Text = "Toplam Tutar:";
            this.pnlBaslik.Controls.Add(this.lblToplamTutar);
            
            // lblOdemeTuru
            this.lblOdemeTuru.AutoSize = true;
            this.lblOdemeTuru.Location = new System.Drawing.Point(300, 50);
            this.lblOdemeTuru.Name = "lblOdemeTuru";
            this.lblOdemeTuru.Size = new System.Drawing.Size(96, 17);
            this.lblOdemeTuru.TabIndex = 3;
            this.lblOdemeTuru.Text = "Ödeme Türü:";
            this.pnlBaslik.Controls.Add(this.lblOdemeTuru);
            
            // lblKargoDurumu
            this.lblKargoDurumu.AutoSize = true;
            this.lblKargoDurumu.Location = new System.Drawing.Point(12, 80);
            this.lblKargoDurumu.Name = "lblKargoDurumu";
            this.lblKargoDurumu.Size = new System.Drawing.Size(107, 17);
            this.lblKargoDurumu.TabIndex = 4;
            this.lblKargoDurumu.Text = "Kargo Durumu:";
            this.pnlBaslik.Controls.Add(this.lblKargoDurumu);
            
            // dgvSiparisDetay
            this.dgvSiparisDetay.AllowUserToAddRows = false;
            this.dgvSiparisDetay.AllowUserToDeleteRows = false;
            this.dgvSiparisDetay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSiparisDetay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSiparisDetay.BackgroundColor = System.Drawing.Color.White;
            this.dgvSiparisDetay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSiparisDetay.Location = new System.Drawing.Point(12, 118);
            this.dgvSiparisDetay.Name = "dgvSiparisDetay";
            this.dgvSiparisDetay.ReadOnly = true;
            this.dgvSiparisDetay.RowHeadersWidth = 51;
            this.dgvSiparisDetay.RowTemplate.Height = 24;
            this.dgvSiparisDetay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSiparisDetay.Size = new System.Drawing.Size(660, 320);
            this.dgvSiparisDetay.TabIndex = 1;
            
            // btnKapat
            this.btnKapat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKapat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnKapat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKapat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnKapat.ForeColor = System.Drawing.Color.White;
            this.btnKapat.Location = new System.Drawing.Point(572, 456);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(100, 35);
            this.btnKapat.TabIndex = 2;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = false;
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            
            // btnKargoyaVer
            this.btnKargoyaVer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKargoyaVer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnKargoyaVer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKargoyaVer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnKargoyaVer.ForeColor = System.Drawing.Color.White;
            this.btnKargoyaVer.Location = new System.Drawing.Point(352, 456);
            this.btnKargoyaVer.Name = "btnKargoyaVer";
            this.btnKargoyaVer.Size = new System.Drawing.Size(150, 35);
            this.btnKargoyaVer.TabIndex = 3;
            this.btnKargoyaVer.Text = "Kargoya Ver";
            this.btnKargoyaVer.UseVisualStyleBackColor = false;
            this.btnKargoyaVer.Click += new System.EventHandler(this.btnKargoyaVer_Click);
            
            // btnTeslimEdildi
            this.btnTeslimEdildi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTeslimEdildi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnTeslimEdildi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTeslimEdildi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnTeslimEdildi.ForeColor = System.Drawing.Color.White;
            this.btnTeslimEdildi.Location = new System.Drawing.Point(196, 456);
            this.btnTeslimEdildi.Name = "btnTeslimEdildi";
            this.btnTeslimEdildi.Size = new System.Drawing.Size(150, 35);
            this.btnTeslimEdildi.TabIndex = 4;
            this.btnTeslimEdildi.Text = "Teslim Edildi";
            this.btnTeslimEdildi.UseVisualStyleBackColor = false;
            this.btnTeslimEdildi.Click += new System.EventHandler(this.btnTeslimEdildi_Click);
            
            // SiparisDetayForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 503);
            this.Controls.Add(this.btnTeslimEdildi);
            this.Controls.Add(this.btnKargoyaVer);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.dgvSiparisDetay);
            this.Controls.Add(this.pnlBaslik);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimizeBox = false;
            this.Name = "SiparisDetayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sipariş Detayı";
            this.Load += new System.EventHandler(this.SiparisDetayForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSiparisDetay)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlBaslik;
        private System.Windows.Forms.Label lblSiparisNo;
        private System.Windows.Forms.Label lblTarih;
        private System.Windows.Forms.Label lblToplamTutar;
        private System.Windows.Forms.Label lblOdemeTuru;
        private System.Windows.Forms.Label lblKargoDurumu;
        private System.Windows.Forms.DataGridView dgvSiparisDetay;
        private System.Windows.Forms.Button btnKapat;
        private System.Windows.Forms.Button btnKargoyaVer;
        private System.Windows.Forms.Button btnTeslimEdildi;
    }
} 