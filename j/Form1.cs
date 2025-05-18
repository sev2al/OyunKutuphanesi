using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace j
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			listBox1.Items.Clear();
			if(int.TryParse(textBox1.Text,out int sayi))
			{
				for(int i = 1;i<=sayi;i++)
				{
					if(i%2 == 0)
					{
						listBox1 .Items.Add(i);
					}
				}
			}
			else
			{
				listBox1.Items.Add("yanlış");
			}
		}
	}
}
