using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sevval
{
    public partial class AdminGirisForm : Form
    {
        private const string ADMIN_EMAIL = "Admin";
        private const string ADMIN_PASSWORD = "admin123";

        public AdminGirisForm()
        {
            InitializeComponent();
            button1.Click += AdminGirisbtn_Click;
        }

        private void AdminGirisbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(akullanicitxt.Text) || string.IsNullOrWhiteSpace(asifretxt.Text))
                {
                    MessageBox.Show("Lütfen kullanıcı adı ve şifrenizi giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Sabit admin bilgileriyle kontrol
                if (akullanicitxt.Text == ADMIN_EMAIL && asifretxt.Text == ADMIN_PASSWORD)
                {
                    MessageBox.Show("Admin girişi başarılı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // AdminYonetimForm'a yönlendirme
                    AdminYonetimForm adminYonetimForm = new AdminYonetimForm();
                    adminYonetimForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giriş işlemi sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
