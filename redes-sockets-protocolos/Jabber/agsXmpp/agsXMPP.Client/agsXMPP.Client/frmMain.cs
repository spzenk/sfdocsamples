using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using agsXMPP;
using agsXMPP.protocol;
using agsXMPP.protocol.iq;
using agsXMPP.protocol.iq.disco;
using agsXMPP.protocol.iq.roster;
using agsXMPP.protocol.iq.version;
using agsXMPP.protocol.iq.oob;
using agsXMPP.protocol.client;
using agsXMPP.protocol.extensions.shim;
using agsXMPP.protocol.extensions.si;
using agsXMPP.protocol.extensions.bytestreams;
using agsXMPP.protocol.x;
using agsXMPP.protocol.x.data;
using agsXMPP.Xml;
using agsXMPP.Xml.Dom;
using agsXMPP.sasl;
using agsXMPP.ui;
using agsXMPP.ui.roster;
using System.Security.Cryptography;
using agsXMPP.protocol.stream.feature.compression;
using agsXMPP.Client.Properties;
using System.Reflection;
using System.IO;
using nJim;

namespace agsXMPP.Client
{
    public partial class frmMain : Form
    {
        delegate void OnPresenceDelegate(object sender, agsXMPP.protocol.client.Presence pres);

        int logCount = 0;
        static StringBuilder logs;
  
      
        

        public frmMain()
        {
            InitializeComponent();
            logs = new StringBuilder();
           
        }


        #region XmppCon Events
        void XmppCon_OnXmppConnectionStateChanged(object sender, XmppConnectionState state)
        {
            if (InvokeRequired)
            {
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
                BeginInvoke(new XmppConnectionStateHandler(XmppCon_OnXmppConnectionStateChanged), new object[] { sender, state });
                return;
            }
            AddLog("OnXmppConnectionStateChanged: " + state.ToString());
        }

        //void XmppCon_OnAuthError(object sender, Element e)
        //{
        //    if (InvokeRequired)
        //    {
        //        // Windows Forms are not Thread Safe, we need to invoke this :(
        //        // We're not in the UI thread, so we need to call BeginInvoke				
        //        BeginInvoke(new XmppElementHandler(XmppCon_OnAuthError), new object[] { sender,e });
        //        return;
        //    }


        //    AddLog(e.InnerXml);
        //}

        void XmppCon_OnError(object sender, Exception ex)
        {
            if (InvokeRequired)
            {
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
                BeginInvoke(new ErrorHandler(XmppCon_OnError), new object[] { sender, ex });
                return;
            }


            AddLog(ex.Message);

        }

        void XmppCon_OnClose(object sender)
        {
            if (InvokeRequired)
            {
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
                BeginInvoke(new ObjectHandler(XmppCon_OnClose), new object[] { sender });
                return;
            }

            AddLog("offline");

            RemoveEvents();
            btnLogIn.Enabled = true;
            btnLogOut.Enabled = false;
        }
     

        void XmppCon_OnLogin(object sender)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ObjectHandler(XmppCon_OnLogin), new object[] { sender });
                return;
            }

            AddLog("Online");
        }

        #region Message stanza

        void XmppCon_OnIq(object sender, IQ iq)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new IqHandler(XmppCon_OnIq), new object[] { sender, iq });
                return;
            }



            Util.XmppServices.SwitchIQ(iq);







        }

        /// <summary>
        /// Presence protocol;
        /// Usado principalmente en dos contextos:
        ///1) Presence update: actualización de la presencia debido a un cambio de estado del usuario.
        ///2) Presence subscription management: permite a los usuarios subscribirse a las actualizaciones de presencia de otros usuarios y
        ///controlar quien está accediendo a su propia presencia.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="pres"></param>
        void XmppCon_OnPresence(object sender, agsXMPP.protocol.client.Presence pres)
        {
            if (InvokeRequired)
            {
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
                BeginInvoke(new OnPresenceDelegate(XmppCon_OnPresence), new object[] { sender, pres });
                return;
            }
            AddLog(string.Concat(" Presence: type: ", pres.Type, " from: ", pres.From, " to: ", pres.To));



            Util.XmppServices.SwitchPresence(pres);


        }

        void XmppCon_OnMessage(object sender, agsXMPP.protocol.client.Message msg)
        {
            if (InvokeRequired)
            {
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
                BeginInvoke(new MessageHandler(XmppCon_OnMessage), new object[] { sender, msg });
                return;
            }

            Util.XmppServices.SwitchMessage(msg);
        }

        #endregion
        #endregion


        void XmppServices_OnLog(string msg)
        {
            AddLog(msg);
        }

      
        #region Roster Events
        private void XmppCon_OnRosterStart(object sender)
        {
            if (InvokeRequired)
            {		
                BeginInvoke(new ObjectHandler(XmppCon_OnRosterStart), new object[] { this });
                return;
            }
            // Disable redraw for faster updating
            rosterControl.BeginUpdate();
        }

        private void XmppCon_OnRosterEnd(object sender)
        {
            if (InvokeRequired)
            {			
                BeginInvoke(new ObjectHandler(XmppCon_OnRosterEnd), new object[] { this });
                return;
            }
            // enable redraw again
            rosterControl.EndUpdate();
            rosterControl.ExpandAll();


            //// Send our Online Presence now, this is done in the cboStatus SelectionChanges event
            //// after the next line
            //cboStatus.SelectedIndex = 5;
            // since 0.97 we don't need this anymore ==> AutoPresence property

            //cboStatus.Text = "online";
            //this.cboStatus.SelectedValueChanged += new System.EventHandler(this.cboStatus_SelectedValueChanged);
        }

        private void XmppCon_OnRosterItem(object sender, agsXMPP.protocol.iq.roster.RosterItem item)
        {
            if (InvokeRequired)
            {			
                BeginInvoke(new agsXMPP.XmppClientConnection.RosterHandler(XmppCon_OnRosterItem), new object[] { this, item });
                return;
            }

            if (item.Subscription != SubscriptionType.remove)
            {
                rosterControl.AddRosterItem(item);
            }
            else
            {
                rosterControl.RemoveRosterItem(item);
            }
        }

        private void rosterControl_SelectionChanged(object sender, EventArgs e)
        {
            RosterNode roster = Util.XmppServices.RosterControl.SelectedItem();
            if (roster.RosterItem != null)
            {
                txtTo.Text = roster.RosterItem.Jid.User;
                txtBare.Text = roster.RosterItem.Jid.Bare;
            }
            else
            {
                txtTo.Text = "";
                txtBare.Text = "";
            }
        }

        #endregion

     
       

        private void btnSendCommand_Click(object sender, EventArgs e)
        {
            RosterNode roster = Util.XmppServices.RosterControl.SelectedItem();
            if (roster == null) return;
            if (roster.RosterItem != null)
            {
                //IQ iq = new IQ(IqType.get, XmppCon.MyJID, roster.RosterItem.Jid);

                agsXMPP.protocol.client.Message msg = new agsXMPP.protocol.client.Message();
                msg.To = roster.RosterItem.Jid;
                
                agsXMPP.Client.Comand cmd = new  agsXMPP.Client.Comand();

                cmd.Type = "tipo 01";
                cmd.Value = Convert.ToInt32(txtCmdValue.Text);

                msg.AddChild(cmd);
                Util.XmppServices.XmppCon.Send(msg);
            }

        }





        private void frmMain_Load(object sender, EventArgs e)
        {
            Login();
        }
 

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (Util.XmppServices.XmppCon.XmppConnectionState != XmppConnectionState.Disconnected)
            {
                //Esta accion llama a OnCLose y se eliminan los eventos
                Util.XmppServices.XmppCon.Close();
            }
        }




        void Login()
        {
            Util.XmppServices.XmppCon = new XmppClientConnection();
            CreateEvents();
            using (frmAuthenticate frm = new frmAuthenticate(rosterControl))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    
                    btnLogIn.Enabled = false;
                }
                else
                {
                    btnLogIn.Enabled = true;
                }

            }
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {

        }

    

        public void CreateEvents()
        {



            Util.XmppServices.XmppCon.OnIq += new IqHandler(XmppCon_OnIq);
            Util.XmppServices.XmppCon.OnMessage += new MessageHandler(XmppCon_OnMessage);
            Util.XmppServices.XmppCon.OnLogin += new ObjectHandler(XmppCon_OnLogin);
            Util.XmppServices.XmppCon.OnClose += new ObjectHandler(XmppCon_OnClose);
            Util.XmppServices.XmppCon.OnError += new ErrorHandler(XmppCon_OnError);
            //Util.XmppServices.XmppCon.OnAuthError += new XmppElementHandler(XmppCon_OnAuthError);

            Util.XmppServices.XmppCon.OnRosterEnd += new ObjectHandler(XmppCon_OnRosterEnd);
            Util.XmppServices.XmppCon.OnRosterStart += new ObjectHandler(XmppCon_OnRosterStart);
            Util.XmppServices.XmppCon.OnRosterItem += new XmppClientConnection.RosterHandler(XmppCon_OnRosterItem);
            Util.XmppServices.XmppCon.OnXmppConnectionStateChanged += new XmppConnectionStateHandler(XmppCon_OnXmppConnectionStateChanged);
            Util.XmppServices.XmppCon.OnPresence += new PresenceHandler(XmppCon_OnPresence);




        }
        public void RemoveEvents()
        {
            Util.XmppServices.XmppCon.OnIq -= new IqHandler(XmppCon_OnIq);
            Util.XmppServices.XmppCon.OnMessage -= new MessageHandler(XmppCon_OnMessage);
            Util.XmppServices.XmppCon.OnLogin -= new ObjectHandler(XmppCon_OnLogin);
            Util.XmppServices.XmppCon.OnClose -= new ObjectHandler(XmppCon_OnClose);
            Util.XmppServices.XmppCon.OnError -= new ErrorHandler(XmppCon_OnError);
            //Util.XmppServices.XmppCon.OnAuthError -= new XmppElementHandler(XmppCon_OnAuthError);

            Util.XmppServices.XmppCon.OnRosterEnd -= new ObjectHandler(XmppCon_OnRosterEnd);
            Util.XmppServices.XmppCon.OnRosterStart -= new ObjectHandler(XmppCon_OnRosterStart);
            Util.XmppServices.XmppCon.OnRosterItem -= new XmppClientConnection.RosterHandler(XmppCon_OnRosterItem);
            Util.XmppServices.XmppCon.OnXmppConnectionStateChanged -= new XmppConnectionStateHandler(XmppCon_OnXmppConnectionStateChanged);
            Util.XmppServices.XmppCon.OnPresence -= new PresenceHandler(XmppCon_OnPresence);

            Util.XmppServices.RosterControl.Clear();
            Util.XmppServices.XmppCon = null;
        }
       
        void AddLog(string msg)
        {
            logs.AppendLine();
            logs.AppendLine(".................................");

            logs.AppendLine(string.Concat("(", logCount++, ")   t: ", System.DateTime.Now.ToLongTimeString()));
            logs.AppendLine(msg);
            logs.AppendLine(".................................");

            txtLogs.Text = logs.ToString();
        }
        private void LoadChatServers()
        {
            //treeGC.TreeViewNodeSorter = new TreeNodeSorter();

            //string fileName = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //fileName += @"\chatservers.xml";

            //Document doc = new Document();
            //doc.LoadFile(fileName);

            //// Get Servers
            //ElementList servers = doc.RootElement.SelectElements("Server");
            //foreach (Element server in servers)
            //{
            //    TreeNode n = new TreeNode(server.Value);
            //    n.Tag = "server";
            //    n.ImageIndex = n.SelectedImageIndex = IMAGE_SERVER;

            //    this.treeGC.Nodes.Add(n);
            //}
        }
      
    }
}
