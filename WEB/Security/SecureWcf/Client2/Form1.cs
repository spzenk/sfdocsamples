using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Client2.ServiceReference1;
using System.Net;

namespace Client2
{
    public partial class Form1 : Form
    {
     //   string usr = "administrador";
        string usr = "securewcf";
        string pwd = "1234";
        //No importa el dominio cuando el  iis no esta agragada a ningun dominio
        string domain = "192.168.1.116";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                CoreSecurityClient clientProxy = new ServiceReference1.CoreSecurityClient("ws");

                //clientProxy.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.None;
                   // clientProxy.ChannelFactory.Credentials.Windows.ClientCredential.UserName = usr;
                    //clientProxy.ChannelFactory.Credentials.Windows.ClientCredential.Password = pwd;
                    ////clientProxy.ChannelFactory.Credentials.Windows.ClientCredential.Domain = domain;

                //clientProxy.ClientCredentials.UserName.UserName = usr;
                //clientProxy.ClientCredentials.UserName.Password = pwd;

                clientProxy.ClientCredentials.Windows.ClientCredential.UserName = usr;
                clientProxy.ClientCredentials.Windows.ClientCredential.Password = pwd;
                clientProxy.ClientCredentials.Windows.ClientCredential.Domain = domain;

                WebProxy proxy = new WebProxy("http://proxy:3128", false);
                proxy.Credentials = new NetworkCredential("moviedo", "Lincelin4","allus-ar");
                WebRequest.DefaultWebProxy = proxy;
                
                
                
                
                
                string wGetDataResult = clientProxy.GetData(123);

                MessageBox.Show(wGetDataResult);
            }
            catch (Exception err)
            {

                textBox1.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(err);
            }
        }
    }
}
