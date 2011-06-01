using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace WebService_Secure
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Net.NetworkCredential cr = new System.Net.NetworkCredential("moviedo", "3");
            System.Net.WebProxy pr = new System.Net.WebProxy("127.0.1.2", 80);
      
            gastosWs.SingleService svc = new WebService_Secure.gastosWs.SingleService();

            svc.Credentials = cr;
            svc.Proxy = pr;
            try
            {

                string list = svc.GetServicesList("", false);

                MessageBox.Show(list);
            }
            catch (Exception ex)
            {
                 MessageBox.Show(Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex));
            }
        }
    }
}
