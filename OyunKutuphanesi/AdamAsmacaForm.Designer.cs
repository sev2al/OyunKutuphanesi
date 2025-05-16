namespace OyunKutuphanesi
{
    partial class AdamAsmacaForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.cmbZorluk = new System.Windows.Forms.ComboBox();
            this.lblZorluk = new System.Windows.Forms.Label();
            this.btnBaslat = new System.Windows.Forms.Button();
            this.flpHarfler = new System.Windows.Forms.FlowLayoutPanel();
            this.txtHarf = new System.Windows.Forms.TextBox();
            this.btnTahmin = new System.Windows.Forms.Button();
            this.lblHak = new System.Windows.Forms.Label();
            this.lblSonuc = new System.Windows.Forms.Label();
            this.pbAdam = new System.Windows.Forms.PictureBox();
            this.lblSkor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdam)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbZorluk
            // 
            this.cmbZorluk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZorluk.FormattingEnabled = true;
            this.cmbZorluk.Items.AddRange(new object[] {
            "Kolay",
            "Orta",
            "Zor"});
            this.cmbZorluk.Location = new System.Drawing.Point(30, 30);
            this.cmbZorluk.Name = "cmbZorluk";
            this.cmbZorluk.Size = new System.Drawing.Size(121, 24);
            this.cmbZorluk.TabIndex = 0;
            // 
            // lblZorluk
            // 
            this.lblZorluk.AutoSize = true;
            this.lblZorluk.Location = new System.Drawing.Point(30, 10);
            this.lblZorluk.Name = "lblZorluk";
            this.lblZorluk.Size = new System.Drawing.Size(90, 16);
            this.lblZorluk.TabIndex = 1;
            this.lblZorluk.Text = "Zorluk Seviyesi";
            // 
            // btnBaslat
            // 
            this.btnBaslat.Location = new System.Drawing.Point(170, 30);
            this.btnBaslat.Name = "btnBaslat";
            this.btnBaslat.Size = new System.Drawing.Size(75, 24);
            this.btnBaslat.TabIndex = 2;
            this.btnBaslat.Text = "Başlat";
            this.btnBaslat.UseVisualStyleBackColor = true;
            this.btnBaslat.Click += new System.EventHandler(this.btnBaslat_Click);
            // 
            // flpHarfler
            // 
            this.flpHarfler.Location = new System.Drawing.Point(30, 70);
            this.flpHarfler.Name = "flpHarfler";
            this.flpHarfler.Size = new System.Drawing.Size(400, 40);
            this.flpHarfler.TabIndex = 3;
            // 
            // txtHarf
            // 
            this.txtHarf.Location = new System.Drawing.Point(30, 130);
            this.txtHarf.MaxLength = 1;
            this.txtHarf.Name = "txtHarf";
            this.txtHarf.Size = new System.Drawing.Size(40, 22);
            this.txtHarf.TabIndex = 4;
            // 
            // btnTahmin
            // 
            this.btnTahmin.Location = new System.Drawing.Point(80, 128);
            this.btnTahmin.Name = "btnTahmin";
            this.btnTahmin.Size = new System.Drawing.Size(75, 25);
            this.btnTahmin.TabIndex = 5;
            this.btnTahmin.Text = "Tahmin Et";
            this.btnTahmin.UseVisualStyleBackColor = true;
            this.btnTahmin.Click += new System.EventHandler(this.btnTahmin_Click);
            // 
            // lblHak
            // 
            this.lblHak.AutoSize = true;
            this.lblHak.Location = new System.Drawing.Point(30, 170);
            this.lblHak.Name = "lblHak";
            this.lblHak.Size = new System.Drawing.Size(80, 16);
            this.lblHak.TabIndex = 6;
            this.lblHak.Text = "Kalan Hak: 6";
            // 
            // lblSonuc
            // 
            this.lblSonuc.AutoSize = true;
            this.lblSonuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblSonuc.Location = new System.Drawing.Point(30, 200);
            this.lblSonuc.Name = "lblSonuc";
            this.lblSonuc.Size = new System.Drawing.Size(0, 20);
            this.lblSonuc.TabIndex = 7;
            // 
            // pbAdam
            // 
            this.pbAdam.Location = new System.Drawing.Point(300, 130);
            this.pbAdam.Name = "pbAdam";
            this.pbAdam.Size = new System.Drawing.Size(120, 140);
            this.pbAdam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAdam.TabIndex = 8;
            this.pbAdam.TabStop = false;
            // 
            // lblSkor
            // 
            this.lblSkor.AutoSize = true;
            this.lblSkor.Location = new System.Drawing.Point(30, 230);
            this.lblSkor.Name = "lblSkor";
            this.lblSkor.Size = new System.Drawing.Size(46, 17);
            this.lblSkor.TabIndex = 9;
            this.lblSkor.Text = "Skor: 0";
            // 
            // AdamAsmacaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 300);
            this.Controls.Add(this.lblSkor);
            this.Controls.Add(this.pbAdam);
            this.Controls.Add(this.lblSonuc);
            this.Controls.Add(this.lblHak);
            this.Controls.Add(this.btnTahmin);
            this.Controls.Add(this.txtHarf);
            this.Controls.Add(this.flpHarfler);
            this.Controls.Add(this.btnBaslat);
            this.Controls.Add(this.lblZorluk);
            this.Controls.Add(this.cmbZorluk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AdamAsmacaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adam Asmaca";
            ((System.ComponentModel.ISupportInitialize)(this.pbAdam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox cmbZorluk;
        private System.Windows.Forms.Label lblZorluk;
        private System.Windows.Forms.Button btnBaslat;
        private System.Windows.Forms.FlowLayoutPanel flpHarfler;
        private System.Windows.Forms.TextBox txtHarf;
        private System.Windows.Forms.Button btnTahmin;
        private System.Windows.Forms.Label lblHak;
        private System.Windows.Forms.Label lblSonuc;
        private System.Windows.Forms.PictureBox pbAdam;
        private System.Windows.Forms.Label lblSkor;
    }
} 