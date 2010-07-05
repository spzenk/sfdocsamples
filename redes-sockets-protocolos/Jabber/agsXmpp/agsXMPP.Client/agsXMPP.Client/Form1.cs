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

namespace agsXMPP.Client
{
    public partial class Form1 : Form
    {
        delegate void OnPresenceDelegate(object sender, Presence pres);
        Fwk.Caching.FwkSimpleStorageBase<JabberClient> storage = new Fwk.Caching.FwkSimpleStorageBase<JabberClient> ();
        StringBuilder logs;
        private XmppClientConnection XmppCon;
        //private DiscoHelper discoHelper;
        DiscoManager discoManager;

        public Form1()
        {
            InitializeComponent();
            logs = new StringBuilder();
            XmppCon = new XmppClientConnection();

            XmppCon.SocketConnectionType = agsXMPP.net.SocketConnectionType.Direct;
            XmppCon.OnIq += new IqHandler(XmppCon_OnIq);
            XmppCon.OnMessage += new MessageHandler(XmppCon_OnMessage);
            XmppCon.OnLogin += new ObjectHandler(XmppCon_OnLogin);
            XmppCon.OnClose += new ObjectHandler(XmppCon_OnClose);
            XmppCon.OnError += new ErrorHandler(XmppCon_OnError);
            XmppCon.OnAuthError += new XmppElementHandler(XmppCon_OnAuthError);

            XmppCon.OnRosterEnd +=new ObjectHandler(XmppCon_OnRosterEnd);
            XmppCon.OnRosterStart +=new ObjectHandler(XmppCon_OnRosterStart);
            XmppCon.OnRosterItem +=new XmppClientConnection.RosterHandler(XmppCon_OnRosterItem);


            XmppCon.OnPresence +=new PresenceHandler(XmppCon_OnPresence);



            discoManager = new DiscoManager(XmppCon);

            agsXMPP.Factory.ElementFactory.AddElementType("Login", null, typeof(Settings.Login));
        }

        void XmppCon_OnAuthError(object sender, Element e)
        {
            if (InvokeRequired)
            {
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
                BeginInvoke(new ObjectHandler(XmppCon_OnClose), new object[] { sender });
                return;
            }


            AddLog(e.InnerXml);
        }

        void XmppCon_OnError(object sender, Exception ex)
        {
            if (InvokeRequired)
            {
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
                BeginInvoke(new ObjectHandler(XmppCon_OnClose), new object[] { sender });
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
            
            //rosterControl.Clear();

        }
        void XmppCon_OnIq(object sender, IQ iq)
        {

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
        private void XmppCon_OnPresence(object sender, Presence pres)
        {
            if (InvokeRequired)
            {
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
                BeginInvoke(new OnPresenceDelegate(XmppCon_OnPresence), new object[] { sender, pres });
                return;
            }
            AddLog(string.Concat(" Presence: type: ", pres.Type, " from: ", pres.From, " to: ", pres.To));
            switch (pres.Type)
            {
                //El usuario que lo envía desea suscribirse a la presencia del destinatario.
                case PresenceType.subscribe:
                    {
                        //frmSubscribe f = new frmSubscribe(XmppCon, pres.From);
                        //f.Show();
                        break;
                    }
                //respuesta que recibirá un usuario que ha realizado una petición de suscripción, que indica el estado actual de la suscripción.
                case PresenceType.subscribed:
                    {
                        break;

                    }
                //respuesta que recibirá un usuario que ha realizado una petición de suscripción y le ha sido negada, o una petición de cancelación de la suscripción.
                case PresenceType.unsubscribed:
                    {
                        break;
                    }
                //cancelación de suscripción de presencia, el usuario que lo envía desea cancelar su suscripción a la presencia del destinatario.
                case PresenceType.unsubscribe:
                    {
                        break;
                    }
                //available: Indica que el usuario está listo para recibir mensajes.
                case PresenceType.available:
                //unavailable: Usuario no está disponible para recibir mensajes.
                case PresenceType.unavailable:
                //case PresenceType.probe:
                case PresenceType.error:
                    {
                        try
                        {
                            rosterControl.SetPresence(pres);
                        }
                        catch (Exception ex)
                        {
                            AddLog(ex.Message);
                        }
                        break;
                    }
            }



         

        }

        void XmppCon_OnMessage(object sender, agsXMPP.protocol.client.Message msg)
        {
            if (InvokeRequired)
            {
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
                BeginInvoke(new ObjectHandler(XmppCon_OnClose), new object[] { sender });
                return;
            }


            AddLog("XmppCon_OnMessage");
        }

        void XmppCon_OnLogin(object sender)
        {
            if (InvokeRequired)
            {
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
                BeginInvoke(new ObjectHandler(XmppCon_OnLogin), new object[] { sender });
                return;
            }

     

            AddLog("Online");
        }

        public void Connect()
        {
            //Jid jid = new Jid(storage.Text);
            SaveSettings();
            XmppCon.Server = storage.StorageObject.Server;
            XmppCon.Username = storage.StorageObject.User;
            XmppCon.Password = storage.StorageObject.Password;
            XmppCon.Resource = txtResource.Text;
            XmppCon.Priority = (int)numPriority.Value;
            XmppCon.Port = int.Parse(storage.StorageObject.Port);
            XmppCon.UseSSL = storage.StorageObject.UseSSL;
            XmppCon.AutoResolveConnectServer = true;
            XmppCon.UseCompression = false;

            

            //XmppCon.SocketConnectionType    = agsXMPP.net.SocketConnectionType.Bosh;
            //XmppCon.ConnectServer = "http://vm-2k:8080/http-bind/";            


            //if (chkRegister.Checked)
            //    _connection.RegisterAccount = true;
            //else
            //    _connection.RegisterAccount = false;


            // Caps
            XmppCon.EnableCapabilities = true;
            XmppCon.ClientVersion = "1.0";
            XmppCon.Capabilities.Node = "http://www.ag-software.de/miniclient/caps";


            // overwrite some settings for debugging
            //_connection.UseStartTLS     = false;
            //_connection.UseSSL          = false;

            // overwrite some settings for Polling Test
            //_connection.SocketConnectionType	      = agsXMPP.net.SocketConnectionType.HttpPolling;
            //XmppCon.UseCompression              = false;
            //XmppCon.UseStartTLS	              = false;
            //XmppCon.UseSSL                      = false;
            //_connecXmppContion.AutoResolveConnectServer    = false;
            //XmppCon.ConnectServer               = "http://vm-2000:5280/http-poll";


            SetDiscoInfo();

            this.DialogResult = DialogResult.OK;

            

            XmppCon.Open();
        }

        




        #region << Disco Server >>
        // Sending Disco request to the server we are connected to for discovering
        // the services runing on our server
        private void DiscoServer()
        {
            discoManager.DiscoverItems(new Jid(XmppCon.Server), new IqCB(OnDiscoServerResult), null);
        }

        /// <summary>
        /// Callback
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="iq"></param>
        /// <param name="data"></param>
        private void OnDiscoServerResult(object sender, IQ iq, object data)
        {
            if (iq.Type == IqType.result)
            {
                Element query = iq.Query;
                if (query != null && query.GetType() == typeof(DiscoItems))
                {
                    DiscoItems items = query as DiscoItems;
                    DiscoItem[] itms = items.GetDiscoItems();

                    foreach (DiscoItem itm in itms)
                    {
                        if (itm.Jid != null)
                            discoManager.DiscoverInformation(itm.Jid, new IqCB(OnDiscoInfoResult), itm);
                    }
                }
            }
        }

        private void OnDiscoInfoResult(object sender, IQ iq, object data)
        {
            // <iq from='proxy.cachet.myjabber.net' to='gnauck@jabber.org/Exodus' type='result' id='jcl_19'>
            //  <query xmlns='http://jabber.org/protocol/disco#info'>
            //      <identity category='proxy' name='SOCKS5 Bytestreams Service' type='bytestreams'/>
            //      <feature var='http://jabber.org/protocol/bytestreams'/>
            //      <feature var='http://jabber.org/protocol/disco#info'/>
            //  </query>
            // </iq>
            if (iq.Type == IqType.result)
            {
                if (iq.Query is DiscoInfo)
                {
                    DiscoInfo di = iq.Query as DiscoInfo;
                    if (di.HasFeature(agsXMPP.Uri.IQ_SEARCH))
                    {
                        Jid jid = iq.From;
                        //if (!Util.Services.Search.Contains(jid))
                        //    Util.Services.Search.Add(jid);
                    }
                    else if (di.HasFeature(agsXMPP.Uri.BYTESTREAMS))
                    {
                        Jid jid = iq.From;
                        //if (!Util.Services.Proxy.Contains(jid))
                        //    Util.Services.Proxy.Add(jid);
                    }
                }
            }
        }
        #endregion


        private void SetDiscoInfo()
        {
            XmppCon.DiscoInfo.AddIdentity(new DiscoIdentity("pc", "MiniClient", "client"));

            XmppCon.DiscoInfo.AddFeature(new DiscoFeature(agsXMPP.Uri.DISCO_INFO));
            XmppCon.DiscoInfo.AddFeature(new DiscoFeature(agsXMPP.Uri.DISCO_ITEMS));
            XmppCon.DiscoInfo.AddFeature(new DiscoFeature(agsXMPP.Uri.MUC));

            // for testing to bypass disco caches
            //_connection.DiscoInfo.AddFeature(new DiscoFeature(Guid.NewGuid().ToString())); 
        }
        void AddLog(string msg)
        {
            logs.AppendLine();
            logs.AppendLine(".................................");
            logs.AppendLine(System.DateTime.Now.ToString());
            logs.AppendLine(".................................");
            logs.AppendLine(msg);
            txtLogs.Text = logs.ToString();
        }
        private void cmdLogin_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            storage.Load();
            txtJid.Text = storage.StorageObject.User;
            txtPassword.Text = storage.StorageObject.Password;
            txtServer.Text = storage.StorageObject.Server;
            txtPort.Text = storage.StorageObject.Port;


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }


        void SaveSettings()
        {
            storage.StorageObject.User = txtJid.Text;
            storage.StorageObject.Password = txtPassword.Text;
            storage.StorageObject.Server = txtServer.Text;
            storage.StorageObject.Port = txtPort.Text;


            storage.Save();
        }


        #region Roster Events
        private void XmppCon_OnRosterStart(object sender)
        {
            if (InvokeRequired)
            {
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
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
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
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
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
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
		
        #endregion
    }
}
