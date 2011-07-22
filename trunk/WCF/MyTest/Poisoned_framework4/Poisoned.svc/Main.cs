using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Poisoned.WcfService;

namespace Poisoned.svc
{
    public partial class Main : Form
    {
        StringBuilder str = new StringBuilder();
        MessageQueueProcess_MSMQ svc = new MessageQueueProcess_MSMQ();
        public Main()
        {
            InitializeComponent();
            svc.OnLogEvent += new EventHandler(svc_OnLogEvent);
        }

        void svc_OnLogEvent(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                
                this.BeginInvoke(new EventHandler(svc_OnLogEvent), new object[] { sender, e });
                return;
            }
            str.AppendLine("-----------------------------------------------");
            str.AppendLine(sender.ToString());
            memoEdit1.Text = str.ToString();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                svc.StartResiveMessage();
                btnStop.Enabled = true;
                btnStart.Enabled = false;
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                svc.StopResiveMessage();
                btnStop.Enabled = false;
                btnStart.Enabled = true;
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

        void LogError(Exception ex)
        {
            str.AppendLine("-----------------------------------------------");
            str.AppendLine(Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex));
            memoEdit1.Text = str.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                svc.StartResivePoisonedMessage();
                //btnStop.Enabled = true;
                button1.Enabled = false;
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

    }
}
