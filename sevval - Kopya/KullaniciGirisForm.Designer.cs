namespace sevval
{
    partial class KullaniciGirisForm
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
            this.sifretxt = new System.Windows.Forms.TextBox();
            this.kullanicitxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.girisbtn = new System.Windows.Forms.Button();
            this.kayitbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sifretxt
            // 
            this.sifretxt.Location = new System.Drawing.Point(403, 215);
            this.sifretxt.Name = "sifretxt";
            this.sifretxt.Size = new System.Drawing.Size(100, 20);
            this.sifretxt.TabIndex = 9;
            // 
            // kullanicitxt
            // 
            this.kullanicitxt.Location = new System.Drawing.Point(403, 165);
            this.kullanicitxt.Name = "kullanicitxt";
            this.kullanicitxt.Size = new System.Drawing.Size(100, 20);
            this.kullanicitxt.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(309, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Şifre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(309, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Kullanıcı E-posta:";
            // 
            // girisbtn
            // 
            this.girisbtn.Location = new System.Drawing.Point(312, 268);
            this.girisbtn.Name = "girisbtn";
            this.girisbtn.Size = new System.Drawing.Size(75, 23);
            this.girisbtn.TabIndex = 5;
            this.girisbtn.Text = "Giriş";
            this.girisbtn.UseVisualStyleBackColor = true;
            // 
            // kayitbtn
            // 
            this.kayitbtn.Location = new System.Drawing.Point(428, 268);
            this.kayitbtn.Name = "kayitbtn";
            this.kayitbtn.Size = new System.Drawing.Size(75, 23);
            this.kayitbtn.TabIndex = 10;
            this.kayitbtn.Text = "Kayıt Ol";
            this.kayitbtn.UseVisualStyleBackColor = true;
            // 
            // KullaniciGirisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kayitbtn);
            this.Controls.Add(this.sifretxt);
            this.Controls.Add(this.kullanicitxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.girisbtn);
            this.Name = "KullaniciGirisForm";
            this.Text = "KullaniciGirisForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sifretxt;
        private System.Windows.Forms.TextBox kullanicitxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button girisbtn;
        private System.Windows.Forms.Button kayitbtn;
    }
}