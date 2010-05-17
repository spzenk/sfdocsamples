using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;
using System.Globalization;
using System.Threading;
using MUI_Application.Properties;

namespace MUI_Application
{
    public partial class Form1 : Form
    {
        string _Saludo;
        public Form1()
        {
            InitializeComponent();
        }
        ResourceManager rm  ;
        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = 0;
            load2();
            _Saludo = rm.GetString("Saludo");
            label1.Text = rm.GetString("Saludo");
            
        }

    

        void load2()
        {
            
            string baseName = @"strings";
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(listBox1.Text); ;
            rm = new ResourceManager(baseName, Assembly.GetExecutingAssembly());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            load2();
            _Saludo = rm.GetString("Saludo");
            label1.Text = rm.GetString("Saludo"); 
        }


        void load1()
        {
            string baseName = @"strings.en-US";


            CultureInfo cultura = new CultureInfo("es-EN");

            Thread.CurrentThread.CurrentUICulture = cultura;
            ResourceManager rm = ResourceManager.CreateFileBasedResourceManager(baseName, @"D:\Projects\DocEjemplos\MUI\MUI_Application\MUI_Application\bin\Debug\en-US\", null);

            _Saludo = rm.GetString("Saludo");
            label1.Text = rm.GetString("Saludo");

        }
    }
}
