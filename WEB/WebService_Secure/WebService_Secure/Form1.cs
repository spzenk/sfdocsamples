using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using Fwk.Bases.Connector;

namespace WebService_Secure
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _ICredentials = cr;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Net.NetworkCredential cr = new System.Net.NetworkCredential("moviedo", "3");
            System.Net.WebProxy pr = new System.Net.WebProxy("127.0.1.2", 80);

            gastosWs.SingleService2 svc = new WebService_Secure.gastosWs.SingleService2();
            string list;
            svc.Credentials = cr;
            //svc.Proxy = pr;
            try
            {

                // list = svc.GetServicesList("", false);
                using (gastosWs.SingleService2 wService = new gastosWs.SingleService2())
                {
                    wService.Credentials = cr;
                    wService.Url = "http://katy.sytes.net/gastosws/SingleService.asmx";
                    list = wService.GetServicesList("", true);
                }
                MessageBox.Show(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                WebServiceWrapper w = (WebServiceWrapper)Fwk.Bases.WrapperFactory.GetWrapper(string.Empty);
                System.Net.NetworkCredential cr = new System.Net.NetworkCredential("moviedo", "3");
                w.Credentials = cr;
                w.GetAllServices();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex));
            }
        }
        ICredentials _ICredentials;
        System.Net.NetworkCredential cr = new System.Net.NetworkCredential("moviedo", "3");
        private void button3_Click(object sender, EventArgs e)
        {



            string list;

            try
            {

                // list = svc.GetServicesList("", false);
                using (Fwk.Bases.Connector.singleservice.SingleService wService = new Fwk.Bases.Connector.singleservice.SingleService())
                {
                    wService.Credentials = _ICredentials;
                    wService.Url = "http://katy.sytes.net/gastosws/SingleService.asmx";
                    list = wService.GetServicesList("", true);
                }
                MessageBox.Show(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex));
            }
        }
    }
}
