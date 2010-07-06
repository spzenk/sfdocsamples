using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

using agsXMPP;
using agsXMPP.net;
using agsXMPP.protocol.iq.disco;
using agsXMPP.protocol.iq.privacy;
using agsXMPP.protocol.iq.roster;

namespace nJim
{

    /// <summary>
    /// Classe principale
    /// </summary>
    public class Jabber : IDisposable
    {

        /// <summary>
        /// Acc�s direct � la connexion XMPP
        /// </summary>
        protected static internal XmppClientConnection xmpp = new XmppClientConnection();

        /// <summary>
        /// Gestion des requ�tes entrantes
        /// </summary>
        private Queries _queries = null;

        /// <summary>
        /// Vrai si le serveur accepte PubSub et les �v�nements
        /// </summary>
        protected static internal bool _pepCapable = false;

        #region Events

        /// <summary>
        /// Se produit lorsque l'utilisateur est connact� et identifi�
        /// </summary>
        public event NeutralHandler Connected;
        private void OnConnected()
        {
            try
            {
                Connected(this);
            }
            catch { }
        }

        /// <summary>
        /// Se produit lorsque l'utilisateur est d�connect�
        /// </summary>
        public event NeutralHandler Disconnected;
        private void OnDisconnected()
        {
            try
            {
                Disconnected(this);
            }
            catch { }
        }

        /// <summary>
        /// Le Roster va �tre modifi�
        /// </summary>
        public event NeutralHandler RosterStartUpdate;
        private void OnRosterStartUpdate()
        {
            try
            {
                RosterStartUpdate(this);
            }
            catch { }
        }

        /// <summary>
        /// Le Roster viend d'�tre modifi�
        /// </summary>
        public event NeutralHandler RosterEndUpdate;
        private void OnRosterEndUpdate()
        {
            try
            {
                RosterEndUpdate(this);
            }
            catch { }
        }

        /// <summary>
        /// Le mot de passe viend �tre modifi�
        /// </summary>
        public event NeutralHandler PasswordChanged;
        private void OnPasswordChanged()
        {
            try
            {
                PasswordChanged(this);
            }
            catch { }
        }

        /// <summary>
        /// Le compte a bien �t� enregistr�
        /// </summary>
        public event NeutralHandler Registered;
        private void OnRegistred()
        {
            try
            {
                Registered(this);
            }
            catch { }
        }

        #endregion

        #region Properties

        private bool _debug = false;
        /// <summary>
        /// Indique si on est en mode DEBUG
        /// </summary>
        public bool debug
        {
            get { return _debug; }
            set { _debug = value; }
        }

        /// <summary>
        /// Propri�t� de configuration avant connexion - Type de connexion
        /// </summary>
        public Enumerations.SocketConnectionType socketConnectionType
        {
            get { return Enumerations.SocketConnectionTypeConverter(xmpp.SocketConnectionType); }
            set
            {
                if (xmpp.XmppConnectionState != XmppConnectionState.Disconnected) { return; }
                xmpp.SocketConnectionType = Enumerations.SocketConnectionTypeConverter(value);
            }
        }

        /// <summary> 
        /// Fiche d'identit� (acc�s interne)
        /// </summary>
        protected static internal Identity _identity = null;
        /// <summary>
        /// Fiche d'identit�
        /// </summary>
        public Identity identity
        {
            get { return _identity; }
        }

        /// <summary>
        /// Liste des contacts (acc�s interne)
        /// </summary>
        protected static internal nJim.Roster _roster = null;
        /// <summary>
        /// Liste des contacts
        /// </summary>
        public Roster roster
        {
            get { return _roster; }
        }

        /// <summary>
        /// Gestion des erreurs (acc�s interne)
        /// </summary>
        protected static internal ErrorManager _errors = new ErrorManager();
        /// <summary>
        /// Gestion des erreurs
        /// </summary>
        public ErrorManager errors
        {
            get { return _errors; }
        }

        /// <summary>
        /// Gestion de sa Presence (acc�s interne)
        /// </summary>
        protected static internal Presence _presence = null;
        /// <summary>
        /// Gestion de sa Presence
        /// </summary>
        public Presence presence
        {
            get { return _presence; }
        }

        /// <summary>
        /// Gestion des listes priv�es (acc�s interne)
        /// </summary>
        protected static internal Privacy _privacy = null;
        /// <summary>
        /// Gestion des listes priv�es
        /// </summary>
        public Privacy privacy
        {
            get { return _privacy; }
        }

        /// <summary>
        /// Gestion des marques ta page! (acc�s interne)
        /// </summary>
        protected static internal Bookmarks _bookmarks = null;
        /// <summary>
        /// Gestion des marques ta page!
        /// </summary>
        public Bookmarks bookmarks
        {
            get { return _bookmarks; }
        }

        /// <summary>
        /// Nom d'utilisateur
        /// </summary>
        public string username
        {
            get { return xmpp.Username; }
            set
            {
                if (value.Trim() != string.Empty && xmpp.Username != value && xmpp.XmppConnectionState == XmppConnectionState.Disconnected)
                {
                    xmpp.Username = value.Trim();
                }
            }
        }

        /// <summary>
        /// Mot de passe
        /// </summary>
        public string password
        {
            get { return xmpp.Password; }
            set
            {
                if (value.Trim() != string.Empty && xmpp.Password != value && xmpp.XmppConnectionState == XmppConnectionState.Disconnected)
                {
                    xmpp.Password = value;
                }
            }
        }

        /// <summary>
        /// Domaine
        /// </summary>
        public string server
        {
            get { return xmpp.Server; }
            set
            {
                if (value.Trim() != string.Empty && xmpp.Server != value && xmpp.XmppConnectionState == XmppConnectionState.Disconnected)
                {
                    xmpp.Server = value;
                }
            }
        }

        /// <summary>
        /// Port accessible du serveur
        /// </summary>
        public int port
        {
            get { return xmpp.Port; }
            set
            {
                if (value >= 0 && value <= 65535 && xmpp.Port != value && xmpp.XmppConnectionState == XmppConnectionState.Disconnected)
                {
                    xmpp.Port = value;
                }
            }
        }

        /// <summary>
        /// Resoud automatiquement l'adresse du serveur pour la connexion
        /// </summary>
        public bool autoResolveConnectServer
        {
            get { return xmpp.AutoResolveConnectServer; }
            set
            {
                if (value != xmpp.AutoResolveConnectServer && xmpp.XmppConnectionState == XmppConnectionState.Disconnected)
                {
                    xmpp.AutoResolveConnectServer = value;
                }
            }
        }

        /// <summary>
        /// Serveur pour la connexion
        /// </summary>
        public string connectServer
        {
            get { return xmpp.ConnectServer; }
            set
            {
                if (value != xmpp.ConnectServer && xmpp.XmppConnectionState == XmppConnectionState.Disconnected)
                {
                    xmpp.ConnectServer = value;
                }
            }
        }

        /// <summary>
        /// S�curiser le flux avec l'ancienne m�thode
        /// </summary>
        public bool ssl
        {
            get { return xmpp.UseSSL; }
            set
            {
                if (value != xmpp.UseSSL && xmpp.XmppConnectionState == XmppConnectionState.Disconnected)
                {
                    xmpp.UseSSL = value;
                    if (xmpp.UseSSL) { xmpp.UseStartTLS = false; }
                }
            }
        }

        /// <summary>
        /// S�curiser le flux avec la nouvelle m�thode
        /// </summary>
        public bool tls
        {
            get { return xmpp.UseStartTLS; }
            set
            {
                if (value != xmpp.UseStartTLS && xmpp.XmppConnectionState == XmppConnectionState.Disconnected)
                {
                    xmpp.UseStartTLS = value;
                    if (xmpp.UseStartTLS) { xmpp.UseSSL = false; }
                }
            }
        }

        /// <summary>
        /// Utiliser la compression de flux
        /// </summary>
        public bool compress
        {
            get { return xmpp.UseCompression; }
            set
            {
                if (value != xmpp.UseCompression && xmpp.XmppConnectionState == XmppConnectionState.Disconnected)
                {
                    xmpp.UseCompression = value;
                }
            }
        }

        /// <summary>
        /// Priorit� du client
        /// </summary>
        public int priority
        {
            get { return xmpp.Priority; }
            set
            {
                if (value != xmpp.Priority)
                {
                    xmpp.Priority = value;
                }
            }
        }

        /// <summary>
        /// Identit� du client
        /// </summary>
        public string resource
        {
            get { return xmpp.Resource; }
            set
            {
                if (value != xmpp.Resource)
                {
                    xmpp.Resource = value;
                }
            }
        }

        /// <summary>
        /// Rester connecter
        /// </summary>
        public bool keepAlive
        {
            get { return xmpp.KeepAlive; }
            set
            {
                if (value != xmpp.KeepAlive)
                {
                    xmpp.KeepAlive = value;
                }
            }
        }

        /// <summary>
        /// Interval entre chaque envoi de paquet null pour rester connecter
        /// </summary>
        public int keepAliveInterval
        {
            get { return xmpp.KeepAliveInterval; }
            set
            {
                if (value != xmpp.KeepAliveInterval)
                {
                    xmpp.KeepAliveInterval = value;
                }
            }
        }

        /// <summary>
        /// Enregistre le compte utilisateur lors de la connexion
        /// </summary>
        public bool register
        {
            get { return xmpp.RegisterAccount; }
            set
            {
                if (value != xmpp.RegisterAccount && xmpp.XmppConnectionState == XmppConnectionState.Disconnected)
                {
                    xmpp.RegisterAccount = value;
                }
            }
        }

        private bool _ignoreSslWarnings = false;
        /// <summary>
        /// Ignorer les erreurs SSL
        /// </summary>
        public bool ignoreSslWarnings
        {
            get { return _ignoreSslWarnings; }
            set
            {
                if (value != _ignoreSslWarnings)
                {
                    _ignoreSslWarnings = value;
                }
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructeur
        /// </summary>
        public Jabber()
        {
            xmpp.AutoAgents = false;
            xmpp.AutoPresence = false;
            xmpp.AutoRoster = false;
            xmpp.EnableCapabilities = false;
            xmpp.OnReadXml += new XmlHandler(xmppOnReadXml);
            xmpp.OnWriteXml += new XmlHandler(xmppOnWriteXml);
            xmpp.OnLogin += new ObjectHandler(xmppOnLogin);
            xmpp.OnClose += new ObjectHandler(xmppOnClose);
            xmpp.OnRosterStart += new ObjectHandler(xmppOnRosterStart);
            xmpp.OnRosterEnd += new ObjectHandler(xmppOnRosterEnd);
            xmpp.OnPasswordChanged += new ObjectHandler(xmppOnPasswordChanged);
            xmpp.OnRegistered += new ObjectHandler(xmppOnRegistered);
            xmpp.ClientSocket.OnValidateCertificate += new RemoteCertificateValidationCallback(xmppOnCertificate);
        }

        #endregion

        #region Destructor

        /// <summary>
        /// Destructeur
        /// </summary>
        public void Dispose()
        {
            disconnect();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Connexion
        /// </summary>
        public void connect()
        {
            disconnect();
            xmpp.Open();
        }

        /// <summary>
        /// D�connexion
        /// </summary>
        public void disconnect()
        {
            if (xmpp.XmppConnectionState != XmppConnectionState.Disconnected) { xmpp.Close(); }
        }

        /// <summary>
        /// Change le mot de passe de son compte
        /// </summary>
        /// <param name="newPassword">Nouveau mot de passe � attribuer</param>
        /// <returns>Vrai si la modification a �t� demand�e, sinon Faux</returns>
        public bool changePassword(string newPassword)
        {
            // si il n'y a pas de stream XMPP en cours ou si ce n'est pas notre fiche d'identit�, on s'arrete l�.
            if (!xmpp.Authenticated || xmpp.MyJID.ToString() != identity.jabberID.full)
            {
                return false;
            }
            xmpp.ChangePassword(newPassword);
            return true;
        }

        /// <summary>
        /// Rafraichi la liste des fonctionnalit�s du serveur
        /// </summary>
        public void refreshServices()
        {
            xmppDiscoServer();
        }

        #endregion

        #region Debug

        /// <summary>
        /// Renvoi sur la console les donn�es XML re�ues
        /// </summary>
        /// <param name="sender">Objet parent</param>
        /// <param name="datas">Donn�es</param>
        private void xmppOnReadXml(object sender, string datas)
        {
            if (_debug)
            {
                string d = datas.Replace("\r", "").Replace("\n", "");
                d = d.Replace("><", ">\r\n<");
                d = d.Replace("/>", "/>\r\n");
                d = d.Replace(">\r\n\r\n<", ">\r\n<");
                d = d.Replace("\r\n", "\r\n\t");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\tRECEPTION:\r\n\t" + d + "\r\n");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Renvoi sur la console les donn�es XML envoy�es
        /// </summary>
        /// <param name="sender">Objet parent</param>
        /// <param name="datas">Donn�es</param>
        private void xmppOnWriteXml(object sender, string datas)
        {
            if (_debug)
            {
                string d = datas.Replace("\r", "").Replace("\n", "");
                d = d.Replace("><", ">\r\n<");
                d = d.Replace("/>", "/>\r\n");
                d = d.Replace(">\r\n\r\n<", ">\r\n<");
                d = d.Replace("\r\n", "\r\n\t");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\tENVOI:\r\n\t" + d + "\r\n");
                Console.ResetColor();
            }
        }

        #endregion

        #region Discover informations on server

        private void xmppDiscoServer()
        {
            DiscoManager dm = new DiscoManager(xmpp);
            dm.AutoAnswerDiscoInfoRequests = false;
            dm.DiscoverInformation(new Jid(xmpp.Server), new IqCB(xmppDiscoServerInformation), new Jid(xmpp.Server));
        }

        private void xmppDiscoServerInformation(object sender, agsXMPP.protocol.client.IQ iq, object data)
        {
            if (iq.Type == agsXMPP.protocol.client.IqType.result)
            {
                if (iq.Query != null && iq.Query is DiscoInfo)
                {
                    DiscoInfo di = iq.Query as DiscoInfo;
                    List<string> features = new List<string>();
                    if (di.GetFeatures() != null)
                    {
                        DiscoFeature[] fs = di.GetFeatures();
                        foreach (DiscoFeature f in fs)
                        {
                            if (!features.Contains(f.Var))
                            {
                                features.Add(f.Var);
                            }
                        }
                    }
                    if (features.Contains("http://jabber.org/protocol/pubsub"))
                    {
                        if (features.Contains("http://jabber.org/protocol/pubsub#publish"))
                        {
                            _pepCapable = true;
                            Jabber._presence.setMood(Jabber._presence.mood.type, Jabber._presence.mood.text);
                            Jabber._presence.setActivity(Jabber._presence.activity.type, Jabber._presence.activity.text);
                            Jabber._presence.setLocation(Jabber._presence.location);
                            Jabber._presence.clearTune();
                        }
                    }
                }
            }
            if (Jabber.xmpp.IqGrabber != null && iq.Id != null) { Jabber.xmpp.IqGrabber.Remove(iq.Id); }
        }

        #endregion

        /// <summary>
        /// Se produit lorsque le flux XMPP est disponible
        /// </summary>
        /// <param name="sender">Objet parent</param>
        private void xmppOnLogin(object sender)
        {
            Jabber.xmpp.DiscoInfo = Queries.getDiscoInfo();
            xmppDiscoServer();
            _queries = new Queries();
            _privacy = new Privacy();
            _bookmarks = new Bookmarks();
            _identity = new Identity(xmpp.MyJID);
            _identity.retrieve();
            _roster = new Roster();
            _presence = new nJim.Presence();
            OnConnected();
            xmpp.RequestRoster();
        }

        /// <summary>
        /// Se produit lorsque un certification est pr�sent
        /// </summary>
        /// <param name="sender">Objet parent</param>
        /// <param name="certificate">Certificat en question</param>
        /// <param name="chain">Chaine</param>
        /// <param name="errors">Erreur SSL</param>
        /// <returns>Vrai si le certicat est accept� sinon Faux</returns>
        private bool xmppOnCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            if (errors != SslPolicyErrors.None && !ignoreSslWarnings)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Se produit lorsque le flux XMPP est ferm�
        /// </summary>
        /// <param name="sender">Objet parent</param>
        private void xmppOnClose(object sender)
        {
            if (_bookmarks != null)
            {
                _bookmarks.Dispose();
                _bookmarks = null;
            }
            if (_privacy != null)
            {
                _privacy.Dispose();
                _privacy = null;
            }
            if (_identity != null)
            {
                _identity.Dispose();
                _identity = null;
            }
            if (_roster != null)
            {
                _roster.Dispose();
                _roster = null;
            }
            if (_presence != null)
            {
                _presence.Dispose();
                _presence = null;
            }
            if (_queries != null)
            {
                _queries.Dispose();
                _queries = null;
            }
            OnDisconnected();
        }

        /// <summary>
        /// Se produit lorsque le Roster va �tre modifi�
        /// </summary>
        /// <param name="sender">Objet parent</param>
        private void xmppOnRosterStart(object sender)
        {
            OnRosterStartUpdate();
        }

        /// <summary>
        /// Se produit lorsque le Roster viend d'�tre modifi�
        /// </summary>
        /// <param name="sender">Objet parent</param>
        private void xmppOnRosterEnd(object sender)
        {
            OnRosterEndUpdate();
            presence.applyStatus();
        }

        /// <summary>
        /// Se produit lorsque le mot de passe a �t� chang�
        /// </summary>
        /// <param name="sender">Objet parent</param>
        private void xmppOnPasswordChanged(object sender)
        {
            OnPasswordChanged();
        }

        /// <summary>
        /// Se produit lorsque le compte a bien �t� enregistr�
        /// </summary>
        /// <param name="sender">Objet parent</param>
        private void xmppOnRegistered(object sender)
        {
            OnRegistred();
        }



    }

}
