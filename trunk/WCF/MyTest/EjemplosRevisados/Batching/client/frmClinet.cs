using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Microsoft.ServiceModel.Samples
{
	public partial class frmClinet: Form
	{
		public frmClinet()
		{
			InitializeComponent();
		}

        private void button1_Click(object sender, EventArgs e)
        {
            Procesar.Execute(Convert.ToInt32 (textBox1.Text));
        }
	}
}
