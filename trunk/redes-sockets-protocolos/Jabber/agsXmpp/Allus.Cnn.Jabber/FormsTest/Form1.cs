using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Allus.Cnn.Common.Reports;
using Allus.Cnn.Common;

namespace FormsTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            WeatherConfig wFrm = new WeatherConfig();
            wFrm.ShowDialog();
        }
    }
}
