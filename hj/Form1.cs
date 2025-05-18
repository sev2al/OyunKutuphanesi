using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hj
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			decimal kur = 36.66m;

			if(decimal.TryParse(textBox1.Text,out decimal snc))
			{
				textBox2.Text=(kur*snc).ToString();
			}
			//else
			///{
				//textBox2.Text = "";
			//}
		}
	}
}
