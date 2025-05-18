using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sınav
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			double s1 = Convert.ToDouble(textBox2.Text);
			double s2= Convert.ToDouble(textBox3.Text);
			double snc = 0;

			if (textBox1.Text == "+")
			{
				snc = s1 + s2;
			}
			else if(textBox1.Text == "-")
			{
				snc= s1 - s2;
			}
			else if (textBox1.Text == "*")
			{
				snc = s1 * s2;
			}
			else if (textBox1.Text == "/")
			{
				if(s2 != 0 )
				{
					snc=s1 / s2;
				}
				else
				{
					MessageBox.Show("Payda 0 olamaz!");
				}
			}
			else
			{
				MessageBox.Show("Yanlış işlem!");
			}
			label4.Text=snc.ToString();
		}
	}
}
