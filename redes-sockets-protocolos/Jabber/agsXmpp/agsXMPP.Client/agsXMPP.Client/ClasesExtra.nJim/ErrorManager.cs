using System;
using System.Collections.Generic;
using System.Text;

namespace nJim
{

    /// <summary>
    /// Gestion des direffenteserreurs
    /// </summary>
    public class ErrorManager : IDisposable
    {

        #region Events

        /// <summary>
        /// Se produit lorsqu'une erreur se produit
        /// </summary>
        public event ErrorHandler ErrorRaised;
        private void OnErrorRaised(Enumerations.ErrorType type, string message)
        {
            try
            {
                ErrorRaised(type, message);
            }
            catch { }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructeur
        /// </summary>
        public ErrorManager()
        {
            Jabber.xmpp.OnError += new agsXMPP.ErrorHandler(Error);
            Jabber.xmpp.OnAuthError += new agsXMPP.XmppElementHandler(ElementError);
            Jabber.xmpp.OnRegisterError += new agsXMPP.XmppElementHandler(ElementError);
            Jabber.xmpp.OnSocketError += new agsXMPP.ErrorHandler(Error);
            //Jabber.xmpp.OnXmppError += new agsXMPP.XmppElementHandler(ElementError);
        }

        #endregion

        #region Destructor

        /// <summary>
        /// Destructeur
        /// </summary>
        public void Dispose()
        {
            Jabber.xmpp.OnError -= new agsXMPP.ErrorHandler(Error);
            Jabber.xmpp.OnAuthError -= new agsXMPP.XmppElementHandler(ElementError);
            Jabber.xmpp.OnRegisterError -= new agsXMPP.XmppElementHandler(ElementError);
            Jabber.xmpp.OnSocketError -= new agsXMPP.ErrorHandler(Error);
            //Jabber.xmpp.OnXmppError -= new agsXMPP.XmppElementHandler(ElementError);
        }

        #endregion

        #region Public method

        /// <summary>
        /// Provoque un �v�nement d'erreur personnalis�
        /// </summary>
        /// <param name="type">Type de l'erreur</param>
        /// <param name="message">Description de l'erreur</param>
        public void custom(Enumerations.ErrorType type, string message)
        {
            OnErrorRaised(type, message);
        }

        #endregion

        /// <summary>
        /// Exceptions
        /// </summary>
        /// <param name="sender">Objet parent</param>
        /// <param name="ex">Exception</param>
        private void Error(object sender, Exception ex)
        {
            OnErrorRaised(Enumerations.ErrorType.Client, ex.Message.Trim() + ex.StackTrace.Trim());
        }

        /// <summary>
        /// XMPP
        /// </summary>
        /// <param name="sender">Objet parent</param>
        /// <param name="el">Element</param>
        private void ElementError(object sender, agsXMPP.Xml.Dom.Element el)
        {
            if (el.HasTag("error", true))
            {
                agsXMPP.Xml.Dom.Element e = el.SelectSingleElement("error", true);
                int code = 0;
                if (e.HasAttribute("code")) { code = Convert.ToInt32(e.Attribute("code")); }
                switch (code)
                {
                    case 302:
                        OnErrorRaised(Enumerations.ErrorType.Query, "Demande redirig�.");
                        break;
                    case 400:
                        OnErrorRaised(Enumerations.ErrorType.Query, "Demande incorrecte.");
                        break;
                    case 401:
                        OnErrorRaised(Enumerations.ErrorType.Authentification, "Compte non autauris�.");
                        break;
                    case 402:
                        OnErrorRaised(Enumerations.ErrorType.Authentification, "Compte incorrect.");
                        break;
                    case 403:
                        OnErrorRaised(Enumerations.ErrorType.Authentification, "Compte refus�.");
                        break;
                    case 404:
                        OnErrorRaised(Enumerations.ErrorType.Warning, "Demande inconnue.");
                        break;
                    case 405:
                        OnErrorRaised(Enumerations.ErrorType.Warning, "Demande interdite.");
                        break;
                    case 406:
                        OnErrorRaised(Enumerations.ErrorType.Query, "Demande non autoris�e.");
                        break;
                    case 407:
                        OnErrorRaised(Enumerations.ErrorType.Authentification, "Compte non enregistr�.");
                        break;
                    case 408:
                        OnErrorRaised(Enumerations.ErrorType.Server, "Temps limite atteint.");
                        break;
                    case 409:
                        OnErrorRaised(Enumerations.ErrorType.Warning, "Demande en conflit.");
                        break;
                    case 500:
                        OnErrorRaised(Enumerations.ErrorType.Server, "Erreur interne.");
                        break;
                    case 501:
                        OnErrorRaised(Enumerations.ErrorType.Warning, "Demande non impl�ment�e.");
                        break;
                    case 502:
                        OnErrorRaised(Enumerations.ErrorType.Server, "Erreur distante.");
                        break;
                    case 503:
                        OnErrorRaised(Enumerations.ErrorType.Warning, "Service temporairement innaccessible.");
                        break;
                    case 504:
                        OnErrorRaised(Enumerations.ErrorType.Server, "Temps limite distant atteint.");
                        break;
                    case 510:
                        OnErrorRaised(Enumerations.ErrorType.Warning, "D�connect�.");
                        break;
                    default:
                        OnErrorRaised(Enumerations.ErrorType.Client, "Erreur g�n�rale.");
                        break;
                }
            }
            else
            {
                if (el.HasTag("bad-request", true)) { OnErrorRaised(Enumerations.ErrorType.Query, "Demande incorrecte."); }
                else if (el.HasTag("conflict", true)) { OnErrorRaised(Enumerations.ErrorType.Warning, "Demande en conflit."); }
                else if (el.HasTag("feature-not-implemented", true)) { OnErrorRaised(Enumerations.ErrorType.Warning, "Demande non impl�ment�e."); }
                else if (el.HasTag("forbidden", true)) { OnErrorRaised(Enumerations.ErrorType.Authentification, "Compte non autoris�."); }
                else if (el.HasTag("gone", true)) { OnErrorRaised(Enumerations.ErrorType.Query, "Demande redirig�e"); }
                else if (el.HasTag("internal-server-error", true)) { OnErrorRaised(Enumerations.ErrorType.Server, "Erreur interne."); }
                else if (el.HasTag("item-not-found", true)) { OnErrorRaised(Enumerations.ErrorType.Warning, "El�ment inconnu."); }
                else if (el.HasTag("jid-malformed", true)) { OnErrorRaised(Enumerations.ErrorType.Query, "Jabber ID incorrect."); }
                else if (el.HasTag("not-acceptable", true)) { OnErrorRaised(Enumerations.ErrorType.Query, "Demande non accept�e."); }
                else if (el.HasTag("not-allowed", true)) { OnErrorRaised(Enumerations.ErrorType.Server, "Op�ration non autoris�e."); }
                else if (el.HasTag("not-authorized", true)) { OnErrorRaised(Enumerations.ErrorType.Query, "Demande non autoris�e."); }
                else if (el.HasTag("payment-required", true)) { OnErrorRaised(Enumerations.ErrorType.Query, "Finalisation requise."); }
                else if (el.HasTag("recipient-unavailable", true)) { OnErrorRaised(Enumerations.ErrorType.Query, "Destinataire non disponible."); }
                else if (el.HasTag("redirect", true)) { OnErrorRaised(Enumerations.ErrorType.Query, "Demande redirig�."); }
                else if (el.HasTag("registration-required", true)) { OnErrorRaised(Enumerations.ErrorType.Authentification, "Compte non enregistr�."); }
                else if (el.HasTag("remote-server-not-found", true)) { OnErrorRaised(Enumerations.ErrorType.Server, "Erreur distante."); }
                else if (el.HasTag("remote-server-timeout", true)) { OnErrorRaised(Enumerations.ErrorType.Server, "Temps limite distant atteint."); }
                else if (el.HasTag("resource-constraint", true)) { OnErrorRaised(Enumerations.ErrorType.Authentification, "Ressource valide requise."); }
                else if (el.HasTag("service-unavailable", true)) { OnErrorRaised(Enumerations.ErrorType.Warning, "Service temporairement innaccessible."); }
                else if (el.HasTag("subscription-required", true)) { OnErrorRaised(Enumerations.ErrorType.Client, "Abonnement requis."); }
                else if (el.HasTag("undefined-condition", true)) { OnErrorRaised(Enumerations.ErrorType.Client, "Condition inconnue."); }
                else if (el.HasTag("unexpected-request", true)) { OnErrorRaised(Enumerations.ErrorType.Query, "Demande incorrecte."); }
            }
        }

    }


    /// <summary>
    /// Gestion des marques ta page!
    /// </summary>
    public class Bookmarks : IDisposable
    {

        #region events

        /// <summary>
        /// Une nouvelle liste de favoris est disponible
        /// </summary>
        public event NeutralHandler FavoritesAvailables;
        private void OnFavoritesAvailables()
        {
            try
            {
                FavoritesAvailables(this);
            }
            catch { }
        }

        /// <summary>
        /// Une nouvelle liste de salons est disponible
        /// </summary>
        public event NeutralHandler RoomsAvailables;
        private void OnRoomsAvailables()
        {
            try
            {
                RoomsAvailables(this);
            }
            catch { }
        }

        #endregion

        #region Properties

        private List<Favorite> _favorites = new List<Favorite>();
        /// <summary>
        /// Liste des favoris
        /// </summary>
        public List<Favorite> favorites
        {
            get { return _favorites; }
        }

        private List<Room> _rooms = new List<Room>();
        /// <summary>
        /// Liste des salons de discussions
        /// </summary>
        public List<Room> rooms
        {
            get { return _rooms; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructeur
        /// </summary>
        public Bookmarks()
        {
            retrieve();
        }

        #endregion

        #region Destructor

        /// <summary>
        /// Destructeur
        /// </summary>
        public void Dispose()
        {
            publishFavorites();
            publishRooms();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Charge les bookamrks enregistr�s sur le serveur
        /// </summary>
        public void retrieve()
        {
            if (Jabber.xmpp.Authenticated)
            {
                agsXMPP.protocol.extensions.bookmarks.BookmarkManager bm = new agsXMPP.protocol.extensions.bookmarks.BookmarkManager(Jabber.xmpp);
                bm.RequestBookmarks(new agsXMPP.IqCB(retrieveResult));
            }
        }

        /// <summary>
        /// Sauvegarde les favoris
        /// </summary>
        public void publishFavorites()
        {
            if (Jabber.xmpp.Authenticated && _favorites.Count > 0)
            {
                agsXMPP.protocol.extensions.bookmarks.BookmarkManager bm = new agsXMPP.protocol.extensions.bookmarks.BookmarkManager(Jabber.xmpp);
                agsXMPP.protocol.extensions.bookmarks.Url[] urls = new agsXMPP.protocol.extensions.bookmarks.Url[_favorites.Count];
                int counter = 0;
                foreach (Favorite f in _favorites)
                {
                    urls[counter] = new agsXMPP.protocol.extensions.bookmarks.Url(f.address, f.name);
                    counter++;
                }
                bm.StoreBookmarks(urls);
            }
        }

        /// <summary>
        /// Sauvegarde les salons
        /// </summary>
        public void publishRooms()
        {
            if (Jabber.xmpp.Authenticated && _rooms.Count > 0)
            {
                agsXMPP.protocol.extensions.bookmarks.BookmarkManager bm = new agsXMPP.protocol.extensions.bookmarks.BookmarkManager(Jabber.xmpp);
                agsXMPP.protocol.extensions.bookmarks.Conference[] conferences = new agsXMPP.protocol.extensions.bookmarks.Conference[_rooms.Count];
                int counter = 0;
                foreach (Room r in _rooms)
                {
                    conferences[counter] = new agsXMPP.protocol.extensions.bookmarks.Conference(new agsXMPP.Jid(r.jabberID.full), r.name, r.nickname, r.password, r.autoJoin);
                    counter++;
                }
                bm.StoreBookmarks(conferences);
            }
        }

        #endregion

        /// <summary>
        /// Resultat de la requette RequestBookmarks
        /// </summary>
        /// <param name="sender">Objet parent</param>
        /// <param name="iq">Requette</param>
        /// <param name="data">Donn�es suppl�mentaires</param>
        private void retrieveResult(object sender, agsXMPP.protocol.client.IQ iq, object data)
        {
            if (iq.Type == agsXMPP.protocol.client.IqType.result)
            {
                if (iq.Query != null && iq.Query.HasTag(typeof(agsXMPP.protocol.extensions.bookmarks.Storage)))
                {
                    if (iq.Query.SelectSingleElement(typeof(agsXMPP.protocol.extensions.bookmarks.Storage)) != null)
                    {
                        agsXMPP.protocol.extensions.bookmarks.Storage st = iq.Query.SelectSingleElement(typeof(agsXMPP.protocol.extensions.bookmarks.Storage)) as agsXMPP.protocol.extensions.bookmarks.Storage;
                        agsXMPP.protocol.extensions.bookmarks.Url[] urls = st.GetUrls();
                        if (urls != null)
                        {
                            _favorites.Clear();
                            foreach (agsXMPP.protocol.extensions.bookmarks.Url url in urls)
                            {
                                if (url.Address != null && url.Name != null)
                                {
                                    Favorite f = new Favorite();
                                    f.address = url.Address;
                                    f.name = url.Name;
                                    if (!_favorites.Contains(f))
                                    {
                                        _favorites.Add(f);
                                    }
                                }
                            }
                            OnFavoritesAvailables();
                        }
                        agsXMPP.protocol.extensions.bookmarks.Conference[] conferences = st.GetConferences();
                        if (conferences != null)
                        {
                            _rooms.Clear();
                            foreach (agsXMPP.protocol.extensions.bookmarks.Conference conference in conferences)
                            {
                                if (conference.Name != null && conference.Jid != null && conference.Nickname != null)
                                {
                                    Room r = new Room();
                                    r.autoJoin = conference.AutoJoin;
                                    r.jabberID = new JabberID();
                                    r.jabberID.user = conference.Jid.User;
                                    r.jabberID.resource = conference.Jid.Resource;
                                    r.jabberID.domain = conference.Jid.Server;
                                    r.jabberID.bare = conference.Jid.Bare;
                                    r.jabberID.full = conference.Jid.ToString();
                                    r.name = conference.Name;
                                    r.nickname = conference.Nickname;
                                    r.password = (conference.Password != null) ? conference.Password : string.Empty;
                                    if (!_rooms.Contains(r))
                                    {
                                        _rooms.Add(r);
                                    }

                                }
                            }
                            OnRoomsAvailables();
                        }
                    }
                }
            }
        }

    }


}
