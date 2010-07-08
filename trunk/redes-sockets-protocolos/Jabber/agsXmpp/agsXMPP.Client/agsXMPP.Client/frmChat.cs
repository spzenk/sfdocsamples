using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using agsXMPP;
using agsXMPP.protocol;
using agsXMPP.protocol.client;
using agsXMPP.Collections;


namespace agsXMPP.Client
{
    public partial class frmChat : frmDialogBase
    {
        private XmppClientConnection _connection;
        private Jid m_Jid;
        private string _nickname;
        public frmChat(Jid jid, XmppClientConnection con, string nickname)
        {
            m_Jid = jid;
            _connection = con;
            _nickname = nickname;



            InitializeComponent();

            this.Text = "Chat with " + nickname;

            XmppServices.ChatForms.Add(m_Jid.Bare.ToLower(), this);

            // Setup new Message Callback
            con.MessageGrabber.Add(jid, new BareJidComparer(), new MessageCB(MessageCallback), null);
        }

        public frmChat(Jid jid, XmppClientConnection con, string nickname, bool privateChat)
        {
            m_Jid = jid;
            _connection = con;
            _nickname = nickname;



            InitializeComponent();

            this.Text = "Chat with " + nickname;

            XmppServices.ChatForms.Add(m_Jid.Bare.ToLower(), this);

            // Setup new Message Callback
            if (privateChat)
                con.MessageGrabber.Add(jid, new BareJidComparer(), new MessageCB(MessageCallback), null);
            else
                con.MessageGrabber.Add(jid, new FullJidComparer(), new MessageCB(MessageCallback), null);
        }


        private void OutgoingMessage(agsXMPP.protocol.client.Message msg)
        {
            rtfChat.SelectionColor = Color.Blue;
            rtfChat.AppendText("Me said: ");
            rtfChat.SelectionColor = Color.Black;
            rtfChat.AppendText(msg.Body);
            rtfChat.AppendText("\r\n");
        }

        public void IncomingMessage(agsXMPP.protocol.client.Message msg)
        {
            rtfChat.SelectionColor = Color.Red;
            rtfChat.AppendText(_nickname + " said: ");
            rtfChat.SelectionColor = Color.Black;
            rtfChat.AppendText(msg.Body);
            rtfChat.AppendText("\r\n");
        }

        
        private void MessageCallback(object sender, agsXMPP.protocol.client.Message msg, object data)
        {
            if (InvokeRequired)
            {
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
                BeginInvoke(new MessageCB(MessageCallback), new object[] { sender, msg, data });
                return;
            }

            if (msg.Body != null)
                IncomingMessage(msg);
        }

        private void rtfSend_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                agsXMPP.protocol.client.Message msg = new agsXMPP.protocol.client.Message();

                msg.Type = MessageType.chat;
                msg.To = m_Jid;
                msg.Body = rtfSend.Text;

                _connection.Send(msg);
                OutgoingMessage(msg);
                rtfSend.Text = "";
            }
        }


        private void cmdSend_Click(object sender, System.EventArgs e)
        {
            agsXMPP.protocol.client.Message msg = new agsXMPP.protocol.client.Message();

            msg.Type = MessageType.chat;
            msg.To = m_Jid;
            msg.Body = rtfSend.Text;

            _connection.Send(msg);
            OutgoingMessage(msg);
            rtfSend.Text = "";
        }

    }
}
