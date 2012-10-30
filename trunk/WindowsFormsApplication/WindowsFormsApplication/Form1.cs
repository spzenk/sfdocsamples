using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
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

        private void button1_Click(object sender, EventArgs e)
        {
            int[] A = new int[] { 1, 2, 3 };
            int[] B = new int[] { 2, 3, 5 };
            StringBuilder str = new StringBuilder();

            str.AppendLine(string.Concat("A = ", get_strinh(A)));
            str.AppendLine(string.Concat("B = ", get_strinh(B)));
            var B_A = B.Except<int>(A);


            var A_B = A.Except<int>(B);

            str.AppendLine(string.Concat("B-A = ", get_strinh(B_A.ToArray<int>())));
            str.AppendLine(string.Concat("A-B = ", get_strinh(A_B.ToArray<int>())));
            textBox1.Text = str.ToString();
        }

        string get_strinh(int[] x)
        {
            StringBuilder str = new StringBuilder();

            foreach (int i in x)
            {
                str.Append(i.ToString());
                str.Append(",");
            }
            return str.ToString();
        }
        StringBuilder r = new StringBuilder();
        private void button2_Click(object sender, EventArgs e)
        {


            DateTime fecha = new DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day, 7, 0, 0);
            GetR(fecha);
            fecha = new DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day, 8, 0, 0);
            GetR(fecha);
            fecha = new DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day, 11, 0, 0);
            GetR(fecha);



            textBox1.Text = r.ToString();


        }



        void GetR(DateTime fecha)
        {

            long ticks1 = fecha.Ticks;
            long ticks2 = fecha.AddMinutes(30).Ticks;
            TimeSpan t1 = new TimeSpan(ticks1);
            TimeSpan t2 = new TimeSpan(ticks2);
            TimeSpan now = new TimeSpan(System.DateTime.Now.Ticks);
            TimeSpan tr = (now - t2);

            long rl = System.DateTime.Now.Ticks - ticks2;

            r.AppendLine(string.Concat("(ahora - t2) = ", rl.ToString()));

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = "Hoa {0} hoy es un gran {1}";
            MessageBox.Show(String.Format(str, new string[] { "Angelina", "año" }));

            Fwk.Exceptions.FunctionalException fw = new Fwk.Exceptions.FunctionalException(null, "clave", new string[] { "Angelina", "año" });
            fw.ConfigProviderName = "asdasdsad";

            MessageBox.Show(fw.Message);
        }
    }
}
