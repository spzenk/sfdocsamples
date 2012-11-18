using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Client.ServiceReference1;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                CoreSecurityClient clientProxy = new ServiceReference1.CoreSecurityClient("ws");
                //GetDataRequest req = new GetDataRequest();
                //req.value = 123;
                //GetDataResponse res = clientProxy.GetData(req);

                //MessageBox.Show(res.GetDataResult);
            }
            catch (Exception err) { MessageBox.Show(err.Message); }
        }
    }
}
