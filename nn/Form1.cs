﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nn
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void richTextBox1_TextChanged(object sender, EventArgs e)
		{
			
		}

		private void button1_Click(object sender, EventArgs e)
		{
for (int i = 1;i <= 10;i++)
			{
				richTextBox1.AppendText(new string('*',i)+"\n");
			}
		}
	}
}
