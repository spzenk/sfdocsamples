using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
           
        }


        void Calc()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            //String[] numbersA = textBox1.Text.Split(',');
            //String[] numbersB = textBox2.Text.Split(',');
            StringBuilder str = new StringBuilder();
            var commonNumbers = numbersA.Intersect(numbersB);

            foreach (object s in commonNumbers)
            {
                str.Append(s);
                str.Append(",");
            }

            txtIntersect.Text = str.ToString();


            str = new StringBuilder();
             commonNumbers = numbersA.Except(numbersB);

             foreach (object s in commonNumbers)
            {
                str.Append(s);
                str.Append(",");
            }

             txtFirst.Text = str.ToString();

             str = new StringBuilder();
             commonNumbers = numbersB.Except(numbersA);

             foreach (object s in commonNumbers)
             {
                 str.Append(s);
                 str.Append(",");
             }

             txtSecond.Text = str.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Calc();
        }
    }
}
