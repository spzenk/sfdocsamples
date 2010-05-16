using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;

using fwk;
namespace MSMQ_WCF_Client
{
    public partial class Form1 : Form
    {

        InstanceContext call = null;
        SendMailClient _SendMailClient = null;
        MailMessage mailMessage = null;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           call = new InstanceContext(new SendMailCallback(this));
            mailMessage = new MailMessage();
            _SendMailClient = new SendMailClient(call);

            mailMessage.FromAddress = "moviedo@gmail.com";
            mailMessage.Subject = "analisis de WCF";
            mailMessage.ToAddress = "marcelo@gmail.com";
            _SendMailClient.SubmitMessage(mailMessage);
            
        }

       

    }

    public class SendMailCallback : ISendMailCallback
    {
        Form1 parent;
        public SendMailCallback(Form1 parent)
        {
            this.parent = parent;
        }


        #region ISendMailCallback Members

        public void Resived(int location)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginResived(int location, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndResived(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
