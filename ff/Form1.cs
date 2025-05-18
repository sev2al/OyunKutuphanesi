using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ff
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Random rnd = new Random();
			int[] zarsayisi = new int[6];

			for (int i = 0; i < 100; i++)
			{
				int zar =rnd.Next(1,7);
				//zarsayisi[zar - 1]++;
			}
			richTextBox1.Clear();

			for (int i = 0;i < zarsayisi.Length;i++)
			{
				richTextBox1.AppendText((i + 1) + ": " + new string('*', zarsayisi[i]) +" "+ "\n");
			}
		}
	}
}
