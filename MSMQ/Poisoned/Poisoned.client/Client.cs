using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Poisoned.WcfService;

namespace Poisoned
{

    /// <summary>
    /// http://moviedo:8000/SysEventDaemon/SystemEvent/
    /// </summary>
    public partial class Client : Form
    {
         
        public Client()
        {
            InitializeComponent();
        }



        void Insert(int? count)
        {
            Poisoned.Proxy.SystemEventClient svc = new Poisoned.Proxy.SystemEventClient("NetMsmqBinding_ISystemEvent");
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            if (count == null) count = 1;
            for (int i = 0; i < count; i++)
            {
                SysEventMessage msg = CreateMsg(i);

                svc.SubmitMessage_Queue(encoding.GetBytes(msg.GetXml()), DateTime.Now);
            }
        }

        SysEventMessage CreateMsg(int? seed)
        {
            SysEventMessage m = new SysEventMessage();

            m.EventDate = DateTime.Now;
            m.HostName = Environment.MachineName;
               m.UserLogin = Environment.UserName;

               if (seed == null)
                   m.IdEvent = m.EventDate.Millisecond;
               else
                   m.IdEvent = seed.Value;

            m.HostNotification =  m.EventDate; 
            m.MACAddress = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
            m.SerialNumber = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
            m.EventDescription = string.Concat("descripcion ",seed.ToString());

            m.EventValue = Convert.ToDecimal(1232.56);
            return m;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Insert(Convert.ToInt32(textEdit1.Text));
        }
    }
}
