using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Globalization;
using System.Reflection;
using System.Threading;

namespace MUI_Application
{
    public partial class frmTest : Form
    {
        ResourceManager rm;
        string _cultura;
        public frmTest()
        {
            InitializeComponent();
        }
        public frmTest(string cultura)
        {
            InitializeComponent();

            _cultura = cultura;
        }
        void load2()
        {

            string baseName = @"strings";
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(_cultura); ;
            rm = new ResourceManager(baseName, Assembly.GetExecutingAssembly());

        }

        private void frmTest_Load(object sender, EventArgs e)
        {
            load2();

            lblVersion.Text = "Cultura" +  _cultura;

            lblTexto.Text = rm.GetString("Saludo");
        }
    }
}
