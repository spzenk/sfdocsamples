﻿using System;
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


namespace agsXMPP.Client
{
    /// <summary>
    /// Summary description for Util.
    /// </summary>
    public static class Util
    {

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


    }


    public delegate void OnLogHandler(string msg);
    public class XmppServices
    {
        public event OnLogHandler OnLog;

        public static Dictionary<string, Form> ChatForms = new Dictionary<string, Form>();
        public static Dictionary<string, Form> GroupChatForms = new Dictionary<string, Form>();
        public List<Jid> Search = new List<Jid>();
        public List<Jid> Proxy = new List<Jid>();
        DiscoManager discoManager;
        agsXMPP.ui.roster.RosterControl rosterControl;

        public DiscoManager DiscoManager
        {
            get { return discoManager; }
            set { discoManager = value; }
        }
        XmppClientConnection xmppCon;

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
        public XmppServices()
        {
            //xmppCon = new XmppClientConnection();
        }


        #region << Switchers >>

        public void SwitchMessage(agsXMPP.protocol.client.Message msg)
        {
            if (msg.Body != null)//--> es un chat
            {
                if (!ChatForms.ContainsKey(msg.From.Bare))
                {
                    RosterNode rn = RosterControl.GetRosterItem(msg.From);
                    string nick = msg.From.Bare;
                    if (rn != null)
                        nick = rn.Text;

                    frmChat f = new frmChat(msg.From, xmppCon, nick);
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
    }
}



