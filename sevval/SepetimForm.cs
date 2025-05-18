using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sevval
{
    public partial class SepetimForm : Form
    {
        private static SepetimForm instance;
        public static SepetimForm Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new SepetimForm();
                }
                return instance;
            }
        } 

        private SepetimForm()
        {
            InitializeComponent();
            this.Size = new Size(400, 500);
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.ReadOnly = true;
            richTextBox1.Font = new Font("Arial", 12);
            richTextBox1.BackColor = Color.White;
            richTextBox1.ForeColor = Color.Black;
        }

        public void SepeteEkle(string urunAdi, string fiyat, Image urunResmi)
        {
            if (!this.Visible)
            {
                this.Show();
            }
            richTextBox1.AppendText($"{urunAdi} - {fiyat}\n");
            MessageBox.Show($"{urunAdi} sepete eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void SepetimForm_Load(object sender, EventArgs e)
        {

        }
    }
}
