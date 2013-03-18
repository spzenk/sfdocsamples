using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Performance_Timer_Tasks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            gridControl1.DataSource = engine1.Statistics;

            propertyGrid1.SelectedObject = engine1;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            engine1.Start();

            btnStart.Enabled = false;
            btnStop.Enabled = true;


        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            engine1.Stop();
            
            gridControl1.RefreshDataSource();
            engine1.Clear();

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            gridControl1.RefreshDataSource();
        }
    }
}
