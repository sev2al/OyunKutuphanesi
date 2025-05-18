using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace asd
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Random rnd= new Random();
			double eb = 0;
			double ek = 100;
			double top= 0;

			for(int i = 0; i < 10; i++)
			{
				int not = rnd.Next(0,101);
				richTextBox1.AppendText(not + "\n");

				top += not;

				if(not>eb)
				{
					eb = not;
				}
				if(not< ek) 
				{
					ek = not;
				}
			}
			label2.Text = "en büyük"+eb;
			label4.Text = "en küçük" + ek;
			label6.Text = "ort" + (top / 10);
		}
	}
}
