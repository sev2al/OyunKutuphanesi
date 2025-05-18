using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jj
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
			int sayi=int.Parse(textBox1.Text);

			for (int i = 1;i<= sayi;i++)
			{
				if (sayi % 1 == 0)
				{
					listBox1 .Items.Add(i);
				}
			}
		}
	}
}
