using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using agsXMPP;
using agsXMPP.Collections;
using agsXMPP.protocol;
using agsXMPP.protocol.client;
using agsXMPP.protocol.x.muc;

namespace agsXMPP.Client
{
    public partial class frmGroupChat : Form
    {
        /// <summary>
        /// Reprecenta la sala de chat
        /// </summary>
        private Jid _RoomJid;
  
        private string m_Nickname;

        #region << Constructors >>        
        public frmGroupChat(Jid roomJid, string Nickname)
        {
            InitializeComponent();
            _RoomJid = roomJid;
  
            m_Nickname = Nickname;

            XmppServices.GroupChatForms.Add(roomJid.Bare.ToLower(), this);
            
            //Aqui capturo todos los mensajes de la sala
            Util.XmppServices.XmppCon.MessageGrabber.Add(roomJid, new BareJidComparer(), new MessageCB(MessageCallback), null);
            
            // Aqui capturo todos mensajes de precence-protocol para detectar abandonos de sala e ingresos
            Util.XmppServices.XmppCon.PresenceGrabber.Add(roomJid, new BareJidComparer(), new PresenceCB(PresenceCallback), null);

        }
        #endregion

 
        /// <summary>
        /// Se envia la precencia a la sala
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmGroupChat_Load(object sender, EventArgs e)
        {
            if (_RoomJid != null)
            {
                Presence pres = new Presence();

                Jid to = new Jid(_RoomJid.ToString());
                to.Resource = m_Nickname;
                pres.To = to;
                Util.XmppServices.XmppCon.Send(pres);
            }
        }


        /// <summary>
        /// Envio una precencia de aviso de abandono de sala
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmGroupChat_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_RoomJid != null)
            {
                Presence pres = new Presence();
                pres.To = _RoomJid;
                pres.Type = PresenceType.unavailable;
                Util.XmppServices.XmppCon.Send(pres);
            }
        }
       
        /// <summary>
        /// Aqui capturo todos los mensajes de la sala
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="msg"></param>
        /// <param name="data"></param>
        private void MessageCallback(object sender, agsXMPP.protocol.client.Message msg, object data)
        {
            if (InvokeRequired)
            {
		
                BeginInvoke(new MessageCB(MessageCallback), new object[] { sender, msg, data });
                return;
            }
            
            if (msg.Type == MessageType.groupchat)
                IncomingMessage(msg);
        }

        /// <summary>
        ///  Aqui capturo todos mensajes de precence-protocol para detectar abandonos de sala e ingresos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="pres"></param>
        /// <param name="data"></param>
        private void PresenceCallback(object sender, agsXMPP.protocol.client.Presence pres, object data)
        {
            if (InvokeRequired)
            {
		
                BeginInvoke(new PresenceCB(PresenceCallback), new object[] { sender, pres, data });
                return;
            }

            ListViewItem lvi = FindListViewItem(pres.From);
            if (lvi != null)
            {
                if (pres.Type == PresenceType.unavailable)
                {
                    lvi.Remove();
                }
                else
                {
                    int imageIdx = Util.GetRosterImageIndex(pres);
                    lvi.ImageIndex = imageIdx;
                    lvi.SubItems[1].Text = (pres.Status == null ? "" : pres.Status);
                    User u = pres.SelectSingleElement(typeof(User)) as User;
                    if (u != null)
                    {
                        lvi.SubItems[2].Text = u.Item.Affiliation.ToString();
                        lvi.SubItems[3].Text = u.Item.Role.ToString();
                    }
                }
            }
            else
            {
                int imageIdx = Util.GetRosterImageIndex(pres);
                
                ListViewItem lv = new ListViewItem(pres.From.Resource);               

                lv.Tag = pres.From.ToString();
                lv.SubItems.Add(pres.Status == null ? "" : pres.Status);
                User u = pres.SelectSingleElement(typeof(User)) as User;
                if (u != null)
                {
                    lv.SubItems.Add(u.Item.Affiliation.ToString());
                    lv.SubItems.Add(u.Item.Role.ToString());
                }
                lv.ImageIndex = imageIdx;
                lvwRoster.Items.Add(lv);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jid"></param>
        /// <returns></returns>
        private ListViewItem FindListViewItem(Jid jid)
        {
            foreach (ListViewItem lvi in lvwRoster.Items)
            {
                if (jid.ToString().ToLower().Equals(lvi.Tag.ToString().ToLower()))
                    return lvi;
            }
            return null;
        }

        /// <summary>
        /// Procesar llegada de mensaje
        /// </summary>
        /// <param name="msg"></param>
        private void IncomingMessage(agsXMPP.protocol.client.Message msg)
        {
            if (msg.Type == MessageType.error)
            {
                //TODO: HAY QUE MANEJAR EL ERROR AQUI
                return;
            }

            if (msg.Subject != null)//------------> SI CAMBIA EL ASUNTO
            {
                txtSubject.Text = msg.Subject;

                rtfChat.SelectionColor = Color.DarkGreen;
                // El Nickname del que envia esta en el GroupChat, en el Jid.Resource
                rtfChat.AppendText(msg.From.Resource + " changed subject: ");
                rtfChat.SelectionColor = Color.Black;                
                rtfChat.AppendText(msg.Subject);
                rtfChat.AppendText("\r\n");
            }
            else
            {
                if (msg.Body == null)
                    return;

                rtfChat.SelectionColor = Color.Red;
                // The Nickname of the sender is in GroupChat in the Resource of the Jid
                rtfChat.AppendText(msg.From.Resource + " said: ");
                rtfChat.SelectionColor = Color.Black;
                rtfChat.AppendText(msg.Body);
                rtfChat.AppendText("\r\n");
            }
        }

        private void cmdSend_Click(object sender, EventArgs e)
        {
   
            if (rtfSend.Text.Length > 0)
            {
                agsXMPP.protocol.client.Message msg = new agsXMPP.protocol.client.Message();

                msg.Type = MessageType.groupchat;
                msg.To = _RoomJid;
                msg.Body = rtfSend.Text;

                Util.XmppServices.XmppCon.Send(msg);

                rtfSend.Text = "";
            }
        }

        /// <summary>
        /// Cambia el asunto del la sala:
        /// in MUC rooms this could return an error when you are a normal user and not allowed
        /// to change the subject.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdChangeSubject_Click(object sender, EventArgs e)
        {
            agsXMPP.protocol.client.Message msg = new agsXMPP.protocol.client.Message();

            msg.Type = MessageType.groupchat;
            msg.To = _RoomJid;
            msg.Subject = txtSubject.Text;

            Util.XmppServices.XmppCon.Send(msg);
        }

        private void rtfSend_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                agsXMPP.protocol.client.Message msg = new agsXMPP.protocol.client.Message();

                msg.Type = MessageType.groupchat;
                msg.To = _RoomJid;
                msg.Body = rtfSend.Text;

                Util.XmppServices.XmppCon.Send(msg);
                rtfSend.Text = "";
            }
        }

        

    }
}