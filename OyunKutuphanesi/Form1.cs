using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OyunKutuphanesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnAdamAsmaca.Click += BtnAdamAsmaca_Click;
            btnYilan.Click += BtnYilan_Click;
            btnLabirent.Click += BtnLabirent_Click;
        }

        private void BtnAdamAsmaca_Click(object sender, EventArgs e)
        {
            AdamAsmacaForm frm = new AdamAsmacaForm();
            frm.ShowDialog();
        }

        private void BtnYilan_Click(object sender, EventArgs e)
        {
            YilanOyunuForm frm = new YilanOyunuForm(new YilanKolayMod());
            frm.ShowDialog();
        }

        private void BtnLabirent_Click(object sender, EventArgs e)
        {
            using (Form zorlukForm = new Form())
            {
                zorlukForm.Text = "Zorluk Seçimi";
                zorlukForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                zorlukForm.StartPosition = FormStartPosition.CenterParent;
                zorlukForm.Width = 300;
                zorlukForm.Height = 150;
                Label lbl = new Label() { Text = "Zorluk seçiniz:", Left = 20, Top = 20, Width = 100 };
                ComboBox cmb = new ComboBox() { Left = 130, Top = 18, Width = 120, DropDownStyle = ComboBoxStyle.DropDownList };
                cmb.Items.AddRange(new string[] { "Kolay", "Orta", "Zor" });
                cmb.SelectedIndex = 0;
                Button btnTamam = new Button() { Text = "Tamam", Left = 100, Width = 80, Top = 60, DialogResult = DialogResult.OK };
                zorlukForm.Controls.Add(lbl);
                zorlukForm.Controls.Add(cmb);
                zorlukForm.Controls.Add(btnTamam);
                zorlukForm.AcceptButton = btnTamam;
                if (zorlukForm.ShowDialog() == DialogResult.OK)
                {
                    string seciliZorluk = cmb.SelectedItem.ToString();
                    LabirentForm frm = new LabirentForm(seciliZorluk);
                    frm.ShowDialog();
                }
            }
        }
    }
}
