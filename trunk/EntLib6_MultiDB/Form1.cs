using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace EntLib6_MultiDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(), false);
            //Database database = DatabaseFactory.CreateDatabase("epiron");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dac.Get(1,"epiron");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dac.Get(1, "xxx");
        }
    }
}
