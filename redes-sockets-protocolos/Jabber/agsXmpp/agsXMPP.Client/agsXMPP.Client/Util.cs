#region nms
using System;
using System.Collections;
using System.Collections.Generic;

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
using Fwk.Caching;
using System.Windows.Forms;
#endregion

namespace agsXMPP.Client
{
    /// <summary>
    /// Summary description for Util.
    /// </summary>
    public static class Util
    {
        public static  int IMAGE_PARTICIPANT = 3;
        public static  int IMAGE_CHATROOM = 4;
        public static  int IMAGE_SERVER = 5;
        public static XmppServices XmppServices;
        public static FwkSimpleStorageBase<JabberClient> storage = new FwkSimpleStorageBase<JabberClient>();

        static Util()
        {
            XmppServices = new XmppServices();
        }

        public static string AppPath
        {
            get
            {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            }
        }

        public static int GetRosterImageIndex(agsXMPP.protocol.client.Presence pres)
        {
            if (pres.Type == PresenceType.unavailable)
            {
                return 0;
            }
            else if (pres.Type == PresenceType.error)
            {
                // presence error, we dont care in the miniclient here
            }
            else
            {
                switch (pres.Show)
                {
                    case ShowType.NONE:
                        return 1;
                    case ShowType.away:
                        return 2;
                    case ShowType.chat:
                        return 4;
                    case ShowType.xa:
                        return 3;
                    case ShowType.dnd:
                        return 5;
                }
            }
            return 0;
        }

        public static TreeNode GetNodeByName(TreeNodeCollection t,string name)
        { 
            foreach(TreeNode child in  t)
            {
                if(child.Text.Equals(name))
                    return child;

            }

            return null;
        }
    }


    public delegate void OnLogHandler(string msg);
    public delegate void OnItemsLoadedHandler(agsXMPP.Client.IItems chatRooms);

    public class XmppServices
    {
        #region properties
        public event OnLogHandler OnLog;

        public static Dictionary<string, Form> ChatForms = new Dictionary<string, Form>();
        public static Dictionary<string, Form> GroupChatForms = new Dictionary<string, Form>();
        public List<Jid> Search = new List<Jid>();
        public List<Jid> Proxy = new List<Jid>();
        DiscoManager discoManager;
        agsXMPP.ui.roster.RosterControl rosterControl;
        XmppClientConnection xmppCon;

        public DiscoManager DiscoManager
        {
            get { return discoManager; }
            set { discoManager = value; }
        }

        public XmppClientConnection XmppCon
        {
            get { return xmppCon; }
            set { xmppCon = value; }
        }

        public agsXMPP.ui.roster.RosterControl RosterControl
        {
            get { return rosterControl; }
            set { rosterControl = value; }
        }
        #endregion


        #region << Switchers >>

        /// <summary>
        /// Se crea un formulario de chat
        /// Usauario A quiere chatear con usuario B
        /// </summary>
        /// <param name="fromJid">jabber id de A </param>
        /// <param name="nick">Nick de A</param>
        public void ChatWtichUser(Jid fromJid,string nick)
        {

              frmChat f = null;
              if (ChatForms.ContainsKey(fromJid.ToString()))
              {
                  f = (frmChat)ChatForms[fromJid.ToString()];
              }
              else
              {
                   f = new frmChat(fromJid, nick);

              }
              f.Show();
          
          
        }

        /// <summary>
        /// Al usuario B le llega un mensaje y levanta un formulario drmChat 
        /// </summary>
        /// <param name="msg">Message enviado por A</param>
        public void SwitchMessage(agsXMPP.protocol.client.Message msg)
        {
            if (msg.Body != null)//--> es un chat
            {
                frmChat f = null;
                if (ChatForms.ContainsKey(msg.From.Bare))
                {
                    f = (frmChat)ChatForms[msg.From.Bare];
                    f.Show();
                }
                else
                {
                    RosterNode rn = RosterControl.GetRosterItem(msg.From);
                    string nick = msg.From.Bare;
                    if (rn != null)
                        nick = rn.Text;

                    f = new frmChat(msg.From, nick);
                    f.Show();
                    f.IncomingMessage(msg);
                }


          

            }
            if (msg.HasTag(typeof(Comand)))
            {

            }
        }

        public void SwitchIQ(agsXMPP.protocol.client.IQ iq)
        {
            if (iq == null) return;


            // No Iq with query
            if (iq.HasTag(typeof(SI)))
            {
                if (iq.Type == IqType.set)
                {
                    SI si = iq.SelectSingleElement(typeof(SI)) as SI;

                    agsXMPP.protocol.extensions.filetransfer.File file = si.File;
                    if (file != null)
                    {
                        // somebody wants to send a file to us
                        AddLog(string.Concat("Alguien esta enviando un archivo Size:", file.Size.ToString(), " nombre: ", file.Name));

                        //frmFileTransfer frmFile = new frmFileTransfer(XmppCon, iq);
                        //frmFile.Show();
                    }
                }
            }



            if (iq.Type == IqType.get)
            {
                if (iq.Query != null)
                {
                    if (iq.Query is DiscoInfo)
                    {
                        //iq.SwitchDirection();
                        //iq.Type = IqType.result;
                        //DiscoInfo di = getDiscoInfo();
                        //iq.Query = di;
                        //XmppCon.Send(iq);
                    }
                    else if (iq.Query is DiscoItems)
                    {
                        //iq.SwitchDirection();
                        //iq.Type = IqType.error;
                        //iq.Error = new Error(ErrorType.cancel, ErrorCondition.FeatureNotImplemented);
                        //XmppCon.Send(iq);
                    }
                    else if (iq.Query is agsXMPP.protocol.iq.version.Version)
                    {
                        //Suichea  from y to
                        iq.SwitchDirection();
                        iq.Type = IqType.result;//indica retorno o respuesta

                        agsXMPP.protocol.iq.version.Version version = iq.Query as agsXMPP.protocol.iq.version.Version;
                        version.Name = Assembly.GetExecutingAssembly().GetName().Name;
                        version.Ver = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                        version.Os = Environment.OSVersion.ToString();
                        Util.XmppServices.XmppCon.Send(iq);
                        //frmMain.AddLog("IQ: tipo vesion");
                    }
                    else if (iq.Query is agsXMPP.protocol.iq.last.Last)
                    {
                        //iq.SwitchDirection();
                        //iq.Type = IqType.result;
                        //agsXMPP.protocol.iq.last.Last last = iq.Query as agsXMPP.protocol.iq.last.Last;
                        //last.Seconds = new TimeSpan(Jabber._presence.getLastActivityTicks()).Seconds;
                        //Jabber.xmpp.Send(iq);
                    }
                    else if (iq.Query is agsXMPP.protocol.iq.time.Time)
                    {
                        iq.SwitchDirection();
                        iq.Type = IqType.result;
                        agsXMPP.protocol.iq.time.Time time = iq.Query as agsXMPP.protocol.iq.time.Time;
                        time.Display = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
                        time.Tz = TimeZone.CurrentTimeZone.StandardName;
                        time.Utc = agsXMPP.util.Time.ISO_8601Date(DateTime.Now);
                        Util.XmppServices.XmppCon.Send(iq);
                    }
                    else if (iq.Query is agsXMPP.protocol.extensions.ping.Ping)
                    {
                        iq.SwitchDirection();
                        iq.Type = IqType.result;
                        agsXMPP.protocol.extensions.ping.Ping ping = iq.Query as agsXMPP.protocol.extensions.ping.Ping;
                        Util.XmppServices.XmppCon.Send(iq);
                    }
                    else if (iq.Query is agsXMPP.protocol.iq.avatar.Avatar)
                    {
                        iq.SwitchDirection();
                        iq.Type = IqType.result;
                        agsXMPP.protocol.iq.avatar.Avatar avatar = iq.Query as agsXMPP.protocol.iq.avatar.Avatar;
                        avatar.Data = null;
                        if (Jabber._identity.photo != null && Jabber._identity.photoFormat != null)
                        {
                            MemoryStream ms = new MemoryStream();
                            Jabber._identity.photo.Save(ms, Jabber._identity.photoFormat);
                            avatar.Data = ms.ToArray();
                            avatar.MimeType = "image/" + Jabber._identity.photoFormat.ToString();
                            ms.Close();
                            ms.Dispose();
                        }
                        Jabber.xmpp.Send(iq);
                    }
                    else if (iq.Query is agsXMPP.protocol.iq.vcard.Vcard)
                    {
                        iq.SwitchDirection();
                        iq.Type = IqType.result;
                        iq.Query = Jabber._identity.toVcard();
                        Jabber.xmpp.Send(iq);
                    }









                }
            }


        }

        public void SwitchPresence(agsXMPP.protocol.client.Presence pres)
        {
            switch (pres.Type)
            {
                //El usuario que lo envía desea suscribirse a la presencia del destinatario.
                case PresenceType.subscribe:
                    {
                        AceptSubscribe f = new AceptSubscribe(Util.XmppServices.XmppCon, pres.From);
                        f.Show();
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

        #endregion

        #region << Disco Server >>
        // Sending Disco request to the server we are connected to for discovering
        // the services runing on our server
        public void DiscoServer()
        {
            Util.XmppServices.DiscoManager.DiscoverItems(new Jid(Util.XmppServices.XmppCon.Server), new IqCB(OnDiscoServerResult), null);
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
                            Util.XmppServices.DiscoManager.DiscoverInformation(itm.Jid, new IqCB(OnDiscoInfoResult), itm);
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
                        if (!Util.XmppServices.Search.Contains(jid))
                            Util.XmppServices.Search.Add(jid);
                    }
                    else if (di.HasFeature(agsXMPP.Uri.BYTESTREAMS))
                    {
                        Jid jid = iq.From;
                        if (!Util.XmppServices.Proxy.Contains(jid))
                            Util.XmppServices.Proxy.Add(jid);
                    }
                }
            }
        }
        #endregion

        void AddLog(string msg)
        {
            if (OnLog != null)
            {
                OnLog(msg);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public  void FindChatRooms(string name)
        {
            //TreeNode node = treeGC.SelectedNode;
            //if (node == null || node.Level != 0)
            //    return;

            DiscoItemsIq discoIq = new DiscoItemsIq(IqType.get);
            discoIq.To = new Jid(name);
            this.XmppCon.IqGrabber.SendIq(discoIq, new IqCB(OnGetChatRooms), name);
        }
        public event OnItemsLoadedHandler OnRoomsLoadedEvent ;
        public event OnItemsLoadedHandler OnParticipantsLoadedEvent;
        /// <summary>
        /// Callback
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="iq"></param>
        /// <param name="data"></param>
        private void OnGetChatRooms(object sender, IQ iq, object data)
        {
         
            ChatRooms wChatRooms = new ChatRooms();
            DiscoItems items = iq.Query as DiscoItems;
            if (items == null)
                return;

            DiscoItem[] rooms = items.GetDiscoItems();
            foreach (DiscoItem item in rooms)
            {
                wChatRooms.Servername = data.ToString();
                wChatRooms.JidList.Add(item.Name,item.Jid);
                //TreeNode n = new TreeNode(item.Name);
                //n.Tag = item.Jid.ToString();
                //n.ImageIndex = n.SelectedImageIndex = Util.IMAGE_CHATROOM;
                //node.Nodes.Add(n);
            }
            if (OnRoomsLoadedEvent != null)
                OnRoomsLoadedEvent(wChatRooms);
        }
        private void FindParticipants(String roomName)
        {
            //TreeNode node = treeGC.SelectedNode;
            //if (node == null && node.Level != 1)
            //    return;

            DiscoItemsIq discoIq = new DiscoItemsIq(IqType.get);
            discoIq.To = new Jid((string)roomName);
            this.XmppCon.IqGrabber.SendIq(discoIq, new IqCB(OnGetParticipants), roomName);
        }

        private void OnGetParticipants(object sender, IQ iq, object data)
        {
            Partisipants part = new Partisipants();
            //TreeNode node = data as TreeNode;
            //node.Nodes.Clear();

            DiscoItems items = iq.Query as DiscoItems;
            if (items == null)
                return;

            DiscoItem[] rooms = items.GetDiscoItems();


            foreach (DiscoItem item in rooms)
            {
                part.Servername = data.ToString();
                part.JidList.Add(item.Jid.Resource, item.Jid);
            }

            if (OnParticipantsLoadedEvent != null)
                OnParticipantsLoadedEvent(part);



            //foreach (DiscoItem item in rooms)
            //{
            //    TreeNode n = new TreeNode(item.Jid.Resource);
            //    n.Tag = item.Jid.ToString();
            //    //n.ImageIndex = n.SelectedImageIndex = IMAGE_PARTICIPANT;
            //    node.Nodes.Add(n);
            //}
        }
    }


    public class TreeNodeSorter : IComparer
    {
        // Compare the length of the strings, or the strings
        // themselves, if they are the same length.
        public int Compare(object x, object y)
        {
            TreeNode tx = x as TreeNode;
            TreeNode ty = y as TreeNode;

            // If they are the same length, call Compare.
            return string.Compare(tx.Text, ty.Text);
        }
    }
}



