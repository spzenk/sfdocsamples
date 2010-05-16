using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Common;
using WPFChatter;

namespace Win32Charter
{
    public partial class ChatControl : UserControl
    {

        #region Instance Fields
        Person currentPerson;
        Person otherPerson;
        private Proxy_Singleton ProxySingleton = Proxy_Singleton.GetInstance();
        #endregion

        public ChatControl()
        {
            InitializeComponent();
        }

        private void btnSay_Click(object sender, EventArgs e)
        {
            SayAndClear("", txtMessage.Text, false);
            txtMessage.Focus();
        }
        /// <summary>
        /// Simply calls the <see cref="Proxy_Singleton">
        /// Proxy.SayAndClear()</see> method passing it these
        /// input parameters
        /// </summary>
        /// <param name="to">The chatter name to send messager to</param>
        /// <param name="msg">The message to send</param>
        /// <param name="pvt">True means its a private 1 to 1 message</param>
        private void SayAndClear(string to, string msg, bool pvt)
        {
            if (msg != "")
            {
                try
                {
                    ProxySingleton.SayAndClear(to, msg, pvt);
                    txtMessage.Text = "";
                }
                catch
                {
                    AbortProxyAndUpdateUI();
                    AppendText("Disconnected at " + DateTime.Now.ToString() + Environment.NewLine);
                    Error("Error: Connection to chat server lost!");
                }
            }
        }

        private void AppendText(string p)
        {
            this.txtMessages.Text +=  p;
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Shows an error message and calls the <see cref="Proxy_Singleton">
        /// Proxy.AbortProxy()</see> method
        /// </summary>
        private void AbortProxyAndUpdateUI()
        {
            ProxySingleton.AbortProxy();
            MessageBox.Show("An error occurred, Disconnecting");
        }

        /// <summary>
        /// Shows an error message and calls the <see cref="Proxy_Singleton">
        /// Proxy.ExitChatSession()</see> method
        /// </summary>
        /// <param name="errMessage">The error message to display</param>
        private void Error(string errMessage)
        {
            ProxySingleton.ExitChatSession();
            MessageBox.Show(errMessage, "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
