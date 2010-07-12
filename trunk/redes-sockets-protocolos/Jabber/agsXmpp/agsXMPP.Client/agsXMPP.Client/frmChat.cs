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
     
        /// <summary>
        /// JID de A. El creador del chat
        /// </summary>
        private Jid ownewrJid;
        /// <summary>
        /// Nick name de A
        /// </summary>
        private string _nickname;

        /// <summary>
        /// A chateara con B
        /// </summary>
        /// <param name="jid">A</param>
        /// <param name="nickname">Nock de A</param>
        public frmChat(Jid jid, string nickname)
        {
            ownewrJid = jid;

            _nickname = nickname;



            InitializeComponent();

            this.Text = "Chat with " + nickname;

            XmppServices.ChatForms.Add(ownewrJid.Bare.ToLower(), this);

            Util.XmppServices.XmppCon.MessageGrabber.Add(jid, new BareJidComparer(), new MessageCB(MessageCallback), null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jid"></param>
        /// <param name="nickname"></param>
        /// <param name="privateChat"></param>
        public frmChat(Jid jid,  string nickname, bool privateChat)
        {

            _nickname = nickname;



            InitializeComponent();

            this.Text = "Chat with " + nickname;

            XmppServices.ChatForms.Add(ownewrJid.Bare.ToLower(), this);

            // Setup new Message Callback
            if (privateChat)
                 Util.XmppServices.XmppCon.MessageGrabber.Add(jid, new BareJidComparer(), new MessageCB(MessageCallback), null);
            else
                Util.XmppServices.XmppCon.MessageGrabber.Add(jid, new FullJidComparer(), new MessageCB(MessageCallback), null);
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
            rtfChat.AppendText(_nickname + ": ");
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
                msg.To = ownewrJid;
                msg.Body = rtfSend.Text;

                Util.XmppServices.XmppCon.Send(msg);
                OutgoingMessage(msg);
                rtfSend.Text = "";
            }
        }


        private void cmdSend_Click(object sender, System.EventArgs e)
        {
            agsXMPP.protocol.client.Message msg = new agsXMPP.protocol.client.Message();

            msg.Type = MessageType.chat;
            msg.To = ownewrJid;
            msg.Body = rtfSend.Text;

            Util.XmppServices.XmppCon.Send(msg);
            OutgoingMessage(msg);
            rtfSend.Text = "";
        }

        private void frmChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            Util.XmppServices.XmppCon.MessageGrabber.Remove(ownewrJid);
            XmppServices.ChatForms.Remove(ownewrJid.Bare.ToLower());
        }

    }
}
