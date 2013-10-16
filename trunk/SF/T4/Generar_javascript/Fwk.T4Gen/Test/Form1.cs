using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.T4Gen;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //jsObservables t4 = new jsObservables();
            //String s = t4.TransformText();

            jsObservables t = new jsObservables();
         
           textBox1.Text=t.TransformText();
        }
    }
}
