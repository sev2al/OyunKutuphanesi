using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nkjl
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		
		private void button1_Click(object sender, EventArgs e)
		{
			listBox1.Items.Clear();
			double vize =Convert.ToDouble(textBox1.Text);
			double odev=Convert.ToDouble(textBox2.Text);
			double final=Convert.ToDouble(textBox3.Text);
			double ort = 0;
			string durum = " ";

			ort = (vize * 0.4) + (odev * 0.3) + (final * 0.3);

			if (ort < 50)
			{
				durum= "kaldı ";
			}
			else
			{
				durum = "geçti";
			}
			listBox1.Items.Add(ort+"ortalama ile "+durum);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			textBox1.Focus();
		}
	}
}
