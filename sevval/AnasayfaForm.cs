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
    public partial class AnasayfaForm : Form
    {
        public AnasayfaForm()
        {
            InitializeComponent();
            tisortms.Click += new EventHandler(tisortms_Click);
            gomlekms.Click += new EventHandler(gomlekms_Click);
            montkabanms.Click += new EventHandler(montkabanms_Click);
            pantolonsortms.Click += new EventHandler(pantolonsortms_Click);
            etekms.Click += new EventHandler(etekms_Click);
            kolyems.Click += new EventHandler(kolyems_Click);
            bileklikms.Click += new EventHandler(bileklikms_Click);
            kupems.Click += new EventHandler(kupems_Click);
            ayakkabims.Click += new EventHandler(ayakkabims_Click);
            cikisyapms.Click += Cikisyapms_Click;
            sepetimms.Click += Sepetimms_Click;
        }

        private void Sepetimms_Click(object sender, EventArgs e)
        {
            SepetimForm.Instance.Show();
            SepetimForm.Instance.BringToFront();
        }

        private void tisortms_Click(object sender, EventArgs e)
        {
            TisortForm tisortForm = new TisortForm(this);
            tisortForm.Show();
            this.Hide();
        }

        private void gomlekms_Click(object sender, EventArgs e)
        {
            GomlekForm gomlekForm = new GomlekForm(this);
            gomlekForm.Show();
            this.Hide();
        }

        private void montkabanms_Click(object sender, EventArgs e)
        {
            MontKabanForm montKabanForm = new MontKabanForm(this);
            montKabanForm.Show();
            this.Hide();
        }

        private void pantolonsortms_Click(object sender, EventArgs e)
        {
            PantolonSortForm pantolonSortForm = new PantolonSortForm(this);
            pantolonSortForm.Show();
            this.Hide();
        }

        private void etekms_Click(object sender, EventArgs e)
        {
            EtekForm etekForm = new EtekForm(this);
            etekForm.Show();
            this.Hide();
        }

        private void kolyems_Click(object sender, EventArgs e)
        {
            KolyeForm kolyeForm = new KolyeForm(this);
            kolyeForm.Show();
            this.Hide();
        }

        private void bileklikms_Click(object sender, EventArgs e)
        {
            BileklikForm bileklikForm = new BileklikForm(this);
            bileklikForm.Show();
            this.Hide();
        }

        private void kupems_Click(object sender, EventArgs e)
        {
            KüpeForm küpeForm = new KüpeForm(this);
            küpeForm.Show();
            this.Hide();
        }

        private void ayakkabims_Click(object sender, EventArgs e)
        {
            AyakkabiForm ayakkabiForm = new AyakkabiForm(this);
            ayakkabiForm.Show();
            this.Hide();
        }

        private void Cikisyapms_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
