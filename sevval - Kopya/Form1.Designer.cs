namespace sevval
{
    partial class Form1
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
            this.adminbtn = new System.Windows.Forms.Button();
            this.kullanicibtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // adminbtn
            // 
            this.adminbtn.Location = new System.Drawing.Point(94, 136);
            this.adminbtn.Name = "adminbtn";
            this.adminbtn.Size = new System.Drawing.Size(109, 59);
            this.adminbtn.TabIndex = 0;
            this.adminbtn.Text = "Admin Giriş";
            this.adminbtn.UseVisualStyleBackColor = true;
            // 
            // kullanicibtn
            // 
            this.kullanicibtn.Location = new System.Drawing.Point(247, 136);
            this.kullanicibtn.Name = "kullanicibtn";
            this.kullanicibtn.Size = new System.Drawing.Size(109, 59);
            this.kullanicibtn.TabIndex = 1;
            this.kullanicibtn.Text = "Kullanıcı Giriş";
            this.kullanicibtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kullanicibtn);
            this.Controls.Add(this.adminbtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button adminbtn;
        private System.Windows.Forms.Button kullanicibtn;
    }
}

