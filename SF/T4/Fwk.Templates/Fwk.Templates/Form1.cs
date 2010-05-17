using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;

namespace Fwk.CodeGenerator
{
    public partial class Form1 : Form
    {
        string DataBaseName = "Northwind";
        public Form1()
        {
            InitializeComponent();

         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString);


            Microsoft.SqlServer.Management.Common.ServerConnection serverConnection =
                  new Microsoft.SqlServer.Management.Common.ServerConnection(sqlConnection);
        
            Server server = new Server(serverConnection);
            Database database = new Database(server, this.DataBaseName);
            database.Refresh();

           Table _table = new Table(database, txtName.Text.Trim(), txtSchemma.Text.Trim());
           _table.Refresh();
           foreach (Column c in _table.Columns)
           {
              string prop = FwkGeneratorHelper.GetCsharpProperty(c.Name,c.DataType.Name);
           }
        }
    }
}
