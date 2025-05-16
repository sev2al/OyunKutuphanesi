namespace OyunKutuphanesi
{
    partial class YilanOyunuForm
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

        private void InitializeComponent()
        {
            this.lblSkor = new System.Windows.Forms.Label();
            this.btnBaslat = new System.Windows.Forms.Button();
            this.pnlOyunAlani = new System.Windows.Forms.Panel();
            this.lblZorluk = new System.Windows.Forms.Label();
            this.cmbZorluk = new System.Windows.Forms.ComboBox();
            this.lblYilanTuru = new System.Windows.Forms.Label();
            this.cmbYilanTuru = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblSkor
            // 
            this.lblSkor.AutoSize = true;
            this.lblSkor.Location = new System.Drawing.Point(15, 16);
            this.lblSkor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSkor.Name = "lblSkor";
            this.lblSkor.Size = new System.Drawing.Size(41, 13);
            this.lblSkor.TabIndex = 0;
            this.lblSkor.Text = "Skor: 0";
            // 
            // btnBaslat
            // 
            this.btnBaslat.Location = new System.Drawing.Point(75, 12);
            this.btnBaslat.Margin = new System.Windows.Forms.Padding(2);
            this.btnBaslat.Name = "btnBaslat";
            this.btnBaslat.Size = new System.Drawing.Size(56, 20);
            this.btnBaslat.TabIndex = 1;
            this.btnBaslat.TabStop = false;
            this.btnBaslat.Text = "Başlat";
            this.btnBaslat.UseVisualStyleBackColor = true;
            // 
            // pnlOyunAlani
            // 
            this.pnlOyunAlani.Location = new System.Drawing.Point(18, 77);
            this.pnlOyunAlani.Margin = new System.Windows.Forms.Padding(2);
            this.pnlOyunAlani.Name = "pnlOyunAlani";
            this.pnlOyunAlani.Size = new System.Drawing.Size(373, 353);
            this.pnlOyunAlani.TabIndex = 3;
            // 
            // lblZorluk
            // 
            this.lblZorluk.AutoSize = true;
            this.lblZorluk.Location = new System.Drawing.Point(144, 16);
            this.lblZorluk.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblZorluk.Name = "lblZorluk";
            this.lblZorluk.Size = new System.Drawing.Size(79, 13);
            this.lblZorluk.TabIndex = 4;
            this.lblZorluk.Text = "Zorluk Seviyesi";
            // 
            // cmbZorluk
            // 
            this.cmbZorluk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZorluk.FormattingEnabled = true;
            this.cmbZorluk.Items.AddRange(new object[] {
            "Kolay",
            "Orta",
            "Zor"});
            this.cmbZorluk.Location = new System.Drawing.Point(228, 13);
            this.cmbZorluk.Margin = new System.Windows.Forms.Padding(2);
            this.cmbZorluk.Name = "cmbZorluk";
            this.cmbZorluk.Size = new System.Drawing.Size(76, 21);
            this.cmbZorluk.TabIndex = 5;
            this.cmbZorluk.TabStop = false;
            // 
            // lblYilanTuru
            // 
            this.lblYilanTuru.AutoSize = true;
            this.lblYilanTuru.Location = new System.Drawing.Point(144, 38);
            this.lblYilanTuru.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblYilanTuru.Name = "lblYilanTuru";
            this.lblYilanTuru.Size = new System.Drawing.Size(55, 13);
            this.lblYilanTuru.TabIndex = 6;
            this.lblYilanTuru.Text = "Yılan Türü";
            // 
            // cmbYilanTuru
            // 
            this.cmbYilanTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYilanTuru.FormattingEnabled = true;
            this.cmbYilanTuru.Items.AddRange(new object[] {
            "Hızlı Yılan",
            "Yavaş Yılan"});
            this.cmbYilanTuru.Location = new System.Drawing.Point(228, 38);
            this.cmbYilanTuru.Margin = new System.Windows.Forms.Padding(2);
            this.cmbYilanTuru.Name = "cmbYilanTuru";
            this.cmbYilanTuru.Size = new System.Drawing.Size(91, 21);
            this.cmbYilanTuru.TabIndex = 7;
            this.cmbYilanTuru.TabStop = false;
            // 
            // YilanOyunuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 452);
            this.Controls.Add(this.pnlOyunAlani);
            this.Controls.Add(this.btnBaslat);
            this.Controls.Add(this.lblSkor);
            this.Controls.Add(this.lblZorluk);
            this.Controls.Add(this.cmbZorluk);
            this.Controls.Add(this.lblYilanTuru);
            this.Controls.Add(this.cmbYilanTuru);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "YilanOyunuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yılan Oyunu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSkor;
        private System.Windows.Forms.Button btnBaslat;
        private System.Windows.Forms.Panel pnlOyunAlani;
        private System.Windows.Forms.Label lblZorluk;
        private System.Windows.Forms.ComboBox cmbZorluk;
        private System.Windows.Forms.Label lblYilanTuru;
        private System.Windows.Forms.ComboBox cmbYilanTuru;
    }
} 