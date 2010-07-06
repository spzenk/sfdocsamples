using System;
using System.Collections.Generic;
using System.Text;

namespace nJim
{

    /// <summary>
    /// Gestion des contacts
    /// </summary>
    public class Roster : IDisposable
    {

        /// <summary>
        /// Liste des contacts du Roster
        /// </summary>
        /// <remarks>
        /// La clef est le Bare du JabberID
        /// La valeur est une liste de Contacts par ressource
        /// </remarks>
        private Dictionary<string, Dictionary<string, Contact>> contacts = new Dictionary<string, Dictionary<string, Contact>>();

        /// <summary>
        /// Stocke les UserPEP des qu'il sont re�us
        /// </summary>
        private Dictionary<string, UserPEP> initialUserPEP = new Dictionary<string, UserPEP>();

        /// <summary>
        /// Liste des contact bloqu�s
        /// </summary>
        private List<string> blockedJid = new List<string>();

        #region Events

        /// <summary>
        /// Un contact a �t� enlev� du Roster
        /// </summary>
        public event ContactHandler ContactRemoved;
        private void OnContactRemoved(string bare)
        {
            try
            {
                ContactRemoved(bare);
            }
            catch { }
        }

        /// <summary>
        /// Un contact a �t� ajout� au Roster
        /// </summary>
        public event ContactHandler ContactAdded;
        private void OnContactAdded(string bare)
        {
            try
            {
                ContactAdded(bare);
            }
            catch { }
        }

        /// <summary>
        /// Une ressource a �t� ajout�e � un Contact
        /// </summary>
        public event ResourceHandler ResourceAdded;
        private void OnResourceAdded(Contact contact)
        {
            try
            {
                ResourceAdded(contact);
            }
            catch { }
        }

        /// <summary>
        /// Une ressource a �t� supprim�e d'un Contact
        /// </summary>
        public event ResourceHandler ResourceRemoved;
        private void OnResourceRemoved(Contact contact)
        {
            try
            {
                ResourceRemoved(contact);
            }
            catch { }
        }

        /// <summary>
        /// La Presence d'une ressource a �t� modifi�e.
        /// </summary>
        public event ResourceHandler PresenceUpdated;
        private void OnPresenceUpdated(Contact contact)
        {
            try
            {
                PresenceUpdated(contact);
            }
            catch { }
        }

        /// <summary>
        /// Un contact demande un abonnement
        /// </summary>
        public event ContactHandler AskForSubscribtion;
        private void OnAskForSubscribtion(string bare)
        {
            try
            {
                AskForSubscribtion(bare);
            }
            catch { }
        }

        /// <summary>
        /// Informe du d�sabonnement d'un contact
        /// </summary>
        public event ContactHandler InformUnsubscribtion;
        private void OnInformUnsubscribtion(string bare)
        {
            try
            {
                InformUnsubscribtion(bare);
            }
            catch { }
        }

        /// <summary>
        /// Ce contact est bloqu�
        /// </summary>
        public event ResourceHandler Blocked;
        private void OnBlocked(Contact contact)
        {
            try
            {
                Blocked(contact);
            }
            catch { }
        }

        /// <summary>
        /// Ce contact est d�bloqu�
        /// </summary>
        public event ResourceHandler Unblocked;
        private void OnUnblocked(Contact contact)
        {
            try
            {
                Unblocked(contact);
            }
            catch { }
        }

        /// <summary>
        /// Se produit lorsque une hummeur a changer
        /// </summary>
        public event ResourceMoodHandler MoodUpdated;
        private void OnMoodUpdated(Contact contact, Mood mood)
        {
            try
            {
                MoodUpdated(contact, mood);
            }
            catch { }
        }

        /// <summary>
        /// Se produit lorsque une activit� a changer
        /// </summary>
        public event ResourceActivityHandler ActivityUpdated;
        private void OnActivityUpdated(Contact contact, Activity activity)
        {
            try
            {
                ActivityUpdated(contact, activity);
            }
            catch { }
        }

        /// <summary>
        /// Se produit lorsque un emplacement g�ographique a changer
        /// </summary>
        public event ResourceLocationHandler LocationUpdated;
        private void OnLocationUpdated(Contact contact, Location location)
        {
            try
            {
                LocationUpdated(contact, location);
            }
            catch { }
        }

        /// <summary>
        /// Se produit lorsque une lecture � changer
        /// </summary>
        public event ResourceTuneHandler TuneUpdated;
        private void OnTuneUpdated(Contact contact, Tune tune)
        {
            try
            {
                TuneUpdated(contact, tune);
            }
            catch { }
        }

        #endregion

        #region Properties

        private bool _autoAcceptSubscribtion = false;
        /// <summary>
        /// Autorise automatiquement chaque demande d'abonnement
        /// </summary>
        public bool autoAcceptSubscribtion
        {
            get { return _autoAcceptSubscribtion; }
            set
            {
                if (value != _autoAcceptSubscribtion)
                {
                    _autoAcceptSubscribtion = value;
                }
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructeur
        /// </summary>
        public Roster()
        {
            Jabber.xmpp.OnRosterItem += new agsXMPP.XmppClientConnection.RosterHandler(xmppOnRosterItem);
            Jabber.xmpp.OnPresence += new agsXMPP.protocol.client.PresenceHandler(xmppOnPresence);
            Jabber._privacy.PrivacyListUpdated += new NeutralHandler(privacyListUpdated);
            Jabber.xmpp.OnMessage += new agsXMPP.protocol.client.MessageHandler(xmppOnMessage);
        }

        #endregion

        #region Destructor

        /// <summary>
        /// Destructeur
        /// </summary>
        public void Dispose()
        {
            if (Jabber._privacy != null)
            {
                Jabber._privacy.PrivacyListUpdated -= new NeutralHandler(privacyListUpdated);
            }
            Jabber.xmpp.OnRosterItem -= new agsXMPP.XmppClientConnection.RosterHandler(xmppOnRosterItem);
            Jabber.xmpp.OnPresence -= new agsXMPP.protocol.client.PresenceHandler(xmppOnPresence);
            Jabber.xmpp.OnMessage -= new agsXMPP.protocol.client.MessageHandler(xmppOnMessage);
            foreach (KeyValuePair<string, Dictionary<string, Contact>> c in contacts)
            {
                foreach (KeyValuePair<string, Contact> r in c.Value)
                {
                    r.Value.Dispose();
                }
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Supprimer une ressource ou un contact avec toutes ses ressources
        /// </summary>
        /// <param name="jbid">Identifiant Jabber</param>
        public void remove(string jbid)
        {
            agsXMPP.Jid jid = new agsXMPP.Jid(jbid);
            if (jid != null)
            {
                if (contacts.ContainsKey(jid.Bare))
                {
                    if (jid.Resource != null && contacts[jid.Bare].ContainsKey(jid.Resource.Trim()))
                    {
                        Jabber.xmpp.PresenceManager.Unsubscribe(jid);
                        Jabber.xmpp.RosterManager.RemoveRosterItem(jid);
                    }
                    else
                    {
                        foreach (KeyValuePair<string, Contact> r in contacts[jid.Bare])
                        {
                            remove(r.Value.identity.jabberID.full);
                        }
                        Jabber.xmpp.PresenceManager.Unsubscribe(jid);
                        Jabber.xmpp.RosterManager.RemoveRosterItem(jid);
                    }
                }
            }
        }

        /// <summary>
        /// Ajouter un contact
        /// </summary>
        /// <param name="jbid">Identifiant Jabber</param>
        public void add(string jbid)
        {
            agsXMPP.Jid jid = new agsXMPP.Jid(jbid);
            if (jid != null)
            {
                if (!contacts.ContainsKey(jid.Bare))
                {
                    Jabber.xmpp.RosterManager.AddRosterItem(new agsXMPP.Jid(jid.Bare));
                    Jabber.xmpp.PresenceManager.Subscribe(new agsXMPP.Jid(jid.Bare));
                }
            }
        }

        /// <summary>
        /// Accepte une demande d'abonnement
        /// </summary>
        /// <param name="bare">Identifiant Jabber</param>
        public void acceptSubscribtion(string bare)
        {
            if (Jabber.xmpp.Authenticated && (new agsXMPP.Jid(bare)) != null)
            {
                Jabber.xmpp.PresenceManager.ApproveSubscriptionRequest(new agsXMPP.Jid(new agsXMPP.Jid(bare).Bare));
            }
        }

        /// <summary>
        /// Refuse une demande d'abonnement
        /// </summary>
        /// <param name="bare">Identifiant Jabber</param>
        public void refuseSubscribtion(string bare)
        {
            if (Jabber.xmpp.Authenticated && (new agsXMPP.Jid(bare)) != null)
            {
                Jabber.xmpp.PresenceManager.RefuseSubscriptionRequest(new agsXMPP.Jid(new agsXMPP.Jid(bare).Bare));
            }
        }

        /// <summary>
        /// Demande un abonnement
        /// </summary>
        /// <param name="jbid">Identifiant Jabber</param>
        public void subscribe(string jbid)
        {
            if (Jabber.xmpp.Authenticated && (new agsXMPP.Jid(jbid)) != null)
            {
                Jabber.xmpp.PresenceManager.Subscribe(new agsXMPP.Jid(jbid));
            }
        }

        /// <summary>
        /// D�sabonnement
        /// </summary>
        /// <param name="jbid">Identifiant Jabber</param>
        public void unsubscribe(string jbid)
        {
            if (Jabber.xmpp.Authenticated && (new agsXMPP.Jid(jbid)) != null)
            {
                Jabber.xmpp.PresenceManager.Unsubscribe(new agsXMPP.Jid(jbid));
            }
        }

        #endregion

        /// <summary>
        /// Se produit lorsque un �l�ment du Roster est re�u
        /// </summary>
        /// <param name="sender">Objet parent</param>
        /// <param name="item">Element du ROster re�u</param>
        private void xmppOnRosterItem(object sender, agsXMPP.protocol.iq.roster.RosterItem item)
        {
            if (item.Jid != null)
            {
                string bare = item.Jid.Bare.Trim();
                string resource = (item.Jid.Resource != null) ? item.Jid.Resource.Trim() : string.Empty;
                if (item.Subscription == agsXMPP.protocol.iq.roster.SubscriptionType.remove)
                {
                    // si le contact existe
                    if (contacts.ContainsKey(bare))
                    {
                        foreach (KeyValuePair<string, Contact> r in contacts[bare])
                        {
                            r.Value.Dispose();
                            OnResourceRemoved(r.Value);
                        }
                        contacts.Remove(bare);
                        OnContactRemoved(bare);
                    }
                }
                else
                {
                    // si le contact n'existe pas encore
                    if (!contacts.ContainsKey(bare))
                    {
                        contacts.Add(bare, new Dictionary<string, Contact>());
                        OnContactAdded(bare);
                    }
                    // si on a une resource disponible sur ce contact
                    if (resource != string.Empty)
                    {
                        // si elle n'existe pas encore
                        if (!contacts[bare].ContainsKey(resource))
                        {
                            contacts[bare].Add(resource, new Contact(item.Jid, ((item.Name != null) ? item.Name : string.Empty), item.GetGroups()));
                            contacts[bare][resource].subscription = Enumerations.SubscribtionTypeConverter(item.Subscription);
                            OnResourceAdded(contacts[bare][resource]);
                        }
                    }
                    if (item.Subscription == agsXMPP.protocol.iq.roster.SubscriptionType.from)
                    {
                        subscribe(bare);
                    }
                    privacyListUpdated(Jabber._privacy);
                }
            }
        }

        /// <summary>
        /// Se produit lorsque un� presence est arriv�e
        /// </summary>
        /// <param name="sender">Objet parant</param>
        /// <param name="presence">Contenu de la pr�sence</param>
        private void xmppOnPresence(object sender, agsXMPP.protocol.client.Presence presence)
        {
            if (presence.From != null && presence.To.Bare == Jabber.xmpp.MyJID.Bare)
            {
                string bare = presence.From.Bare;
                string resource = (presence.From.Resource != null) ? presence.From.Resource.Trim() : string.Empty;
                if (presence.Error == null)
                {
                    switch (presence.Type)
                    {
                        case agsXMPP.protocol.client.PresenceType.subscribe:
                            if (autoAcceptSubscribtion)
                            {
                                Jabber.xmpp.PresenceManager.ApproveSubscriptionRequest(presence.From);
                            }
                            else
                            {
                                OnAskForSubscribtion(bare);
                            }
                            break;
                        case agsXMPP.protocol.client.PresenceType.subscribed:
                            //Jabber.xmpp.PresenceManager.Subcribe(presence.From);
                            SetPresence(presence);
                            break;
                        case agsXMPP.protocol.client.PresenceType.unsubscribe:
                            OnInformUnsubscribtion(bare);
                            break;
                        case agsXMPP.protocol.client.PresenceType.unsubscribed:
                            //Jabber.xmpp.PresenceManager.Unsubcribe(presence.From);
                            SetPresence(presence);
                            break;
                        case agsXMPP.protocol.client.PresenceType.error:
                            break;
                        default:
                            SetPresence(presence);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Change la Presence d'une resource
        /// </summary>
        /// <param name="presence">Contenu de la pr�sence</param>
        private void SetPresence(agsXMPP.protocol.client.Presence presence)
        {
            if (presence.From != null && presence.To.Bare == Jabber.xmpp.MyJID.Bare)
            {
                string bare = presence.From.Bare;
                string resource = (presence.From.Resource != null) ? presence.From.Resource.Trim() : string.Empty;
                if (contacts.ContainsKey(bare))
                {
                    if (resource != string.Empty)
                    {
                        if (!contacts[bare].ContainsKey(resource))
                        {
                            contacts[bare].Add(resource, new Contact(presence.From, string.Empty, null));
                            OnResourceAdded(contacts[bare][resource]);
                        }
                        contacts[bare][resource].priority = presence.Priority;
                        Status st = new Status();
                        st.message = (presence.Status != null) ? presence.Status.Trim() : string.Empty;
                        st.type = Enumerations.PresenceTypeConverter(presence.Type);
                        if (st.type == Enumerations.StatusType.Normal)
                        {
                            if (contacts[bare][resource].status.type != Enumerations.StatusType.Normal)
                            {
                                if (initialUserPEP.ContainsKey(bare))
                                {
                                    if (initialUserPEP[bare].activity.text != null)
                                    {
                                        contacts[bare][resource].activity = initialUserPEP[bare].activity;
                                        OnActivityUpdated(contacts[bare][resource], contacts[bare][resource].activity);
                                    }
                                    if (initialUserPEP[bare].mood.text != null)
                                    {
                                        contacts[bare][resource].mood = initialUserPEP[bare].mood;
                                        OnMoodUpdated(contacts[bare][resource], contacts[bare][resource].mood);
                                    }
                                    if (initialUserPEP[bare].location.text != null)
                                    {
                                        contacts[bare][resource].location = initialUserPEP[bare].location;
                                        OnLocationUpdated(contacts[bare][resource], contacts[bare][resource].location);
                                    }
                                    if (initialUserPEP[bare].tune.title != null)
                                    {
                                        contacts[bare][resource].tune = initialUserPEP[bare].tune;
                                        OnTuneUpdated(contacts[bare][resource], contacts[bare][resource].tune);
                                    }
                                    initialUserPEP.Remove(bare);
                                }
                            }
                            st.type = Enumerations.StatusTypeConverter(presence.Show);
                        }
                        if (st.type == Enumerations.StatusType.Unvailable)
                        {
                            if (contacts[bare][resource].status.type != Enumerations.StatusType.Unvailable)
                            {

                                if (initialUserPEP.ContainsKey(bare))
                                {
                                    initialUserPEP.Remove(bare);
                                }
                                UserPEP up = new UserPEP();
                                up.tune = contacts[bare][resource].tune;
                                up.activity = contacts[bare][resource].activity;
                                up.mood = contacts[bare][resource].mood;
                                up.location = contacts[bare][resource].location;
                                initialUserPEP.Add(bare, up);
                            }
                        }
                        contacts[bare][resource].status = st;
                        if (presence.XDelay != null)
                        {
                            contacts[bare][resource].timeInterval = (DateTime.Now - presence.XDelay.Stamp);
                        }
                        if (presence.Nickname != null)
                        {
                            contacts[bare][resource].identity.nickname = presence.Nickname.ToString().Trim();
                        }
                        contacts[bare][resource].lastUpdated = DateTime.Now;
                        OnPresenceUpdated(contacts[bare][resource]);
                    }
                    privacyListUpdated(Jabber._privacy);
                }
            }
        }

        /// <summary>
        /// Lorsque la liste priv�e a �t� modifi�e
        /// </summary>
        /// <param name="sender">Objet parent</param>
        private void privacyListUpdated(object sender)
        {
            Privacy privacy = sender as Privacy;
            foreach (KeyValuePair<string, Dictionary<string, Contact>> c in contacts)
            {
                if (privacy.blockedJid.Contains(c.Key))
                {
                    foreach (KeyValuePair<string, Contact> r1 in c.Value)
                    {
                        if (!r1.Value.blocked)
                        {
                            r1.Value.blocked = true;
                            OnBlocked(r1.Value);
                        }
                    }
                }
                else
                {
                    foreach (KeyValuePair<string, Contact> r1 in c.Value)
                    {
                        if (!r1.Value.blocked && privacy.blockedJid.Contains(r1.Value.identity.jabberID.full))
                        {
                            r1.Value.blocked = true;
                            OnBlocked(r1.Value);
                        }
                        else if (r1.Value.blocked && !privacy.blockedJid.Contains(r1.Value.identity.jabberID.full))
                        {
                            r1.Value.blocked = false;
                            OnUnblocked(r1.Value);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Se produit lorsqu'un message est disponible
        /// </summary>
        /// <param name="sender">Objet parent</param>
        /// <param name="message">Message en question</param>
        private void xmppOnMessage(object sender, agsXMPP.protocol.client.Message message)
        {
            if (message.From != null)
            {
                string bare = message.From.Bare;
                if (message.From.Resource != null && message.Nickname != null)
                {
                    if (contacts.ContainsKey(bare) && contacts[bare].ContainsKey(message.From.Resource) && message.Nickname.ToString().Trim() != string.Empty)
                    {
                        contacts[bare][message.From.Resource].identity.nickname = message.Nickname.ToString().Trim();
                    }
                }
                if (message.HasTag("event"))
                {
                    agsXMPP.Xml.Dom.Element evt = message.SelectSingleElement("event");
                    if (evt.Namespace == "http://jabber.org/protocol/pubsub#event" && evt.HasChildElements)
                    {
                        #region PubSub Events
                        // HACK: Bug serveur. Suivant la XEP c'est Items, ejabberd2.0 retourne parfois Item sans S
                        if (evt.HasTag("items") || evt.HasTag("item"))
                        {
                            agsXMPP.Xml.Dom.Element items = evt.SelectSingleElement("items");
                            if (items == null)
                            {
                                items = evt.SelectSingleElement("item");
                            }
                            if (items.HasTag("item"))
                            {
                                agsXMPP.Xml.Dom.Element item = items.SelectSingleElement("item");
                                // TODO: g�rer le User mood dans les messages chat
                                #region User mood
                                if (items.HasAttribute("node") && (items.Attributes["node"] as string) == "http://jabber.org/protocol/mood" && (item.HasTag("mood") || item.HasTag("retract")))
                                {
                                    agsXMPP.Xml.Dom.Element mood = item.SelectSingleElement("mood");
                                    if (mood != null)
                                    {
                                        // HACK: mood.Namespace == "http://jabber.org/protocol/mood"
                                        if (mood.HasChildElements)
                                        {
                                            Enumerations.MoodType moodType = Enumerations.MoodType.none;
                                            foreach (Enumerations.MoodType mt in Enum.GetValues(typeof(Enumerations.MoodType)))
                                            {
                                                string mtn = Enum.GetName(typeof(Enumerations.MoodType), mt);
                                                if (mood.HasTag(mtn))
                                                {
                                                    moodType = mt;
                                                    break;
                                                }
                                            }
                                            string moodString = string.Empty;
                                            if (mood.HasTag("text") && mood.SelectSingleElement("text").Value != null)
                                            {
                                                moodString = mood.SelectSingleElement("text").Value.Trim();
                                            }
                                            if (contacts.ContainsKey(bare) && contacts[bare].Values.Count > 0)
                                            {
                                                foreach (KeyValuePair<string, Contact> r in contacts[bare])
                                                {
                                                    Mood md = new Mood();
                                                    md.type = moodType;
                                                    md.text = moodString;
                                                    r.Value.mood = md;
                                                    OnMoodUpdated(r.Value, r.Value.mood);
                                                }
                                            }
                                            else
                                            {
                                                Mood md = new Mood();
                                                md.type = moodType;
                                                md.text = moodString;
                                                UserPEP up = new UserPEP();
                                                up.mood = md;
                                                if (!initialUserPEP.ContainsKey(bare))
                                                {
                                                    initialUserPEP.Add(bare, up);
                                                }
                                                else
                                                {
                                                    up.tune = initialUserPEP[bare].tune;
                                                    up.activity = initialUserPEP[bare].activity;
                                                    up.location = initialUserPEP[bare].location;
                                                    initialUserPEP[bare] = up;
                                                }
                                            }
                                        }
                                    }
                                    else if (item.SelectSingleElement("retract") != null)
                                    {
                                        if (contacts.ContainsKey(bare) && contacts[bare].Values.Count > 0)
                                        {
                                            foreach (KeyValuePair<string, Contact> r in contacts[bare])
                                            {
                                                Mood md = new Mood();
                                                md.type = Enumerations.MoodType.none;
                                                md.text = string.Empty;
                                                r.Value.mood = md;
                                                OnMoodUpdated(r.Value, r.Value.mood);
                                            }
                                        }
                                        else
                                        {
                                            Mood md = new Mood();
                                            md.type = Enumerations.MoodType.none;
                                            md.text = string.Empty;
                                            UserPEP up = new UserPEP();
                                            up.mood = md;
                                            if (!initialUserPEP.ContainsKey(bare))
                                            {
                                                initialUserPEP.Add(bare, up);
                                            }
                                            else
                                            {
                                                up.tune = initialUserPEP[bare].tune;
                                                up.activity = initialUserPEP[bare].activity;
                                                up.location = initialUserPEP[bare].location;
                                                initialUserPEP[bare] = up;
                                            }
                                        }
                                    }
                                }
                                #endregion
                                #region User activity
                                if (items.HasAttribute("node") && (items.Attributes["node"] as string) == "http://jabber.org/protocol/activity" && (item.HasTag("activity") || item.HasTag("retract")))
                                {
                                    agsXMPP.Xml.Dom.Element activity = item.SelectSingleElement("activity");
                                    if (activity != null)
                                    {
                                        // HACK: activity.Namespace == "http://jabber.org/protocol/activity"
                                        if (activity.HasChildElements)
                                        {
                                            Enumerations.ActivityType activityType = Enumerations.ActivityType.none;
                                            List<string> activityTypes = recurseActivityTags(activity, new List<string>());
                                            activityTypes.Remove("activity");
                                            if (activityTypes.Count > 0)
                                            {
                                                object o = Enum.Parse(typeof(Enumerations.ActivityType), activityTypes[0], true);
                                                if (o != null)
                                                {
                                                    activityType = (Enumerations.ActivityType)o;
                                                }
                                            }
                                            string activityString = string.Empty;
                                            if (activity.HasTag("text") && activity.SelectSingleElement("text").Value != null)
                                            {
                                                activityString = activity.SelectSingleElement("text").Value.Trim();
                                            }
                                            if (contacts.ContainsKey(bare) && contacts[bare].Values.Count > 0)
                                            {
                                                foreach (KeyValuePair<string, Contact> r in contacts[bare])
                                                {
                                                    Activity a = new Activity();
                                                    a.type = activityType;
                                                    a.text = activityString;
                                                    r.Value.activity = a;
                                                    OnActivityUpdated(r.Value, r.Value.activity);
                                                }
                                            }
                                            else
                                            {
                                                Activity a = new Activity();
                                                a.type = activityType;
                                                a.text = activityString;
                                                UserPEP up = new UserPEP();
                                                up.activity = a;
                                                if (!initialUserPEP.ContainsKey(bare))
                                                {
                                                    initialUserPEP.Add(bare, up);
                                                }
                                                else
                                                {
                                                    up.tune = initialUserPEP[bare].tune;
                                                    up.mood = initialUserPEP[bare].mood;
                                                    up.location = initialUserPEP[bare].location;
                                                    initialUserPEP[bare] = up;
                                                }
                                            }
                                        }
                                    }
                                    else if (item.SelectSingleElement("retract") != null)
                                    {
                                        if (contacts.ContainsKey(bare) && contacts[bare].Values.Count > 0)
                                        {
                                            foreach (KeyValuePair<string, Contact> r in contacts[bare])
                                            {
                                                Activity a = new Activity();
                                                a.type = Enumerations.ActivityType.none;
                                                a.text = string.Empty;
                                                r.Value.activity = a;
                                                OnActivityUpdated(r.Value, r.Value.activity);
                                            }
                                        }
                                        else
                                        {
                                            Activity a = new Activity();
                                            a.type = Enumerations.ActivityType.none;
                                            a.text = string.Empty;
                                            UserPEP up = new UserPEP();
                                            up.activity = a;
                                            if (!initialUserPEP.ContainsKey(bare))
                                            {
                                                initialUserPEP.Add(bare, up);
                                            }
                                            else
                                            {
                                                up.tune = initialUserPEP[bare].tune;
                                                up.mood = initialUserPEP[bare].mood;
                                                up.location = initialUserPEP[bare].location;
                                                initialUserPEP[bare] = up;
                                            }
                                        }
                                    }
                                }
                                #endregion
                                #region User location
                                if (items.HasAttribute("node") && (items.Attributes["node"] as string) == "http://jabber.org/protocol/geoloc" && (item.HasTag("geoloc") || item.HasTag("retract")))
                                {
                                    agsXMPP.Xml.Dom.Element geoloc = item.SelectSingleElement("geoloc");
                                    if (geoloc != null)
                                    {
                                        // HACK: geoloc.Namespace == "http://jabber.org/protocol/geoloc"
                                        if (geoloc.HasChildElements)
                                        {
                                            Location l = new Location();
                                            l.altitude = (geoloc.HasTag("alt") && geoloc.SelectSingleElement("alt").Value != null) ? Convert.ToDouble(geoloc.SelectSingleElement("alt").Value, System.Globalization.CultureInfo.InvariantCulture) : 0.0d;
                                            l.latitude = (geoloc.HasTag("lat") && geoloc.SelectSingleElement("lat").Value != null) ? Convert.ToDouble(geoloc.SelectSingleElement("lat").Value, System.Globalization.CultureInfo.InvariantCulture) : 0.0d;
                                            l.longitude = (geoloc.HasTag("lon") && geoloc.SelectSingleElement("lon").Value != null) ? Convert.ToDouble(geoloc.SelectSingleElement("lon").Value, System.Globalization.CultureInfo.InvariantCulture) : 0.0d;
                                            l.bearing = (geoloc.HasTag("bearing") && geoloc.SelectSingleElement("bearing").Value != null) ? Convert.ToDouble(geoloc.SelectSingleElement("bearing").Value, System.Globalization.CultureInfo.InvariantCulture) : 0.0d;
                                            l.error = (geoloc.HasTag("error") && geoloc.SelectSingleElement("error").Value != null) ? Convert.ToDouble(geoloc.SelectSingleElement("error").Value, System.Globalization.CultureInfo.InvariantCulture) : 0.0d;
                                            l.speed = (geoloc.HasTag("speed") && geoloc.SelectSingleElement("speed").Value != null) ? Convert.ToDouble(geoloc.SelectSingleElement("speed").Value, System.Globalization.CultureInfo.InvariantCulture) : 0.0d;
                                            l.area = (geoloc.HasTag("area") && geoloc.SelectSingleElement("area").Value != null) ? geoloc.SelectSingleElement("area").Value.Trim() : string.Empty;
                                            l.building = (geoloc.HasTag("building") && geoloc.SelectSingleElement("building").Value != null) ? geoloc.SelectSingleElement("building").Value.Trim() : string.Empty;
                                            l.country = (geoloc.HasTag("country") && geoloc.SelectSingleElement("country").Value != null) ? geoloc.SelectSingleElement("country").Value.Trim() : string.Empty;
                                            l.datum = (geoloc.HasTag("datum") && geoloc.SelectSingleElement("datum").Value != null) ? geoloc.SelectSingleElement("datum").Value.Trim() : string.Empty;
                                            l.description = (geoloc.HasTag("description") && geoloc.SelectSingleElement("description").Value != null) ? geoloc.SelectSingleElement("description").Value.Trim() : string.Empty;
                                            l.floor = (geoloc.HasTag("floor") && geoloc.SelectSingleElement("floor").Value != null) ? geoloc.SelectSingleElement("floor").Value.Trim() : string.Empty;
                                            l.locality = (geoloc.HasTag("locality") && geoloc.SelectSingleElement("locality").Value != null) ? geoloc.SelectSingleElement("locality").Value.Trim() : string.Empty;
                                            l.postalcode = (geoloc.HasTag("postalcode") && geoloc.SelectSingleElement("postalcode").Value != null) ? geoloc.SelectSingleElement("postalcode").Value.Trim() : string.Empty;
                                            l.region = (geoloc.HasTag("region") && geoloc.SelectSingleElement("region").Value != null) ? geoloc.SelectSingleElement("region").Value.Trim() : string.Empty;
                                            l.room = (geoloc.HasTag("room") && geoloc.SelectSingleElement("room").Value != null) ? geoloc.SelectSingleElement("room").Value.Trim() : string.Empty;
                                            l.street = (geoloc.HasTag("street") && geoloc.SelectSingleElement("street").Value != null) ? geoloc.SelectSingleElement("street").Value.Trim() : string.Empty; l.area = (geoloc.HasTag("area") && geoloc.SelectSingleElement("area").Value != null) ? geoloc.SelectSingleElement("area").Value.Trim() : string.Empty;
                                            l.text = (geoloc.HasTag("text") && geoloc.SelectSingleElement("text").Value != null) ? geoloc.SelectSingleElement("text").Value.Trim() : string.Empty;
                                            l.timestamp = (geoloc.HasTag("timestamp") && geoloc.SelectSingleElement("timestamp").Value != null) ? DateTime.Parse(geoloc.SelectSingleElement("timestamp").Value) : new DateTime();
                                            l.uri = (geoloc.HasTag("uri") && geoloc.SelectSingleElement("uri").Value != null) ? geoloc.SelectSingleElement("uri").Value.Trim() : string.Empty;
                                            if (contacts.ContainsKey(bare) && contacts[bare].Values.Count > 0)
                                            {
                                                foreach (KeyValuePair<string, Contact> r in contacts[bare])
                                                {
                                                    r.Value.location = l;
                                                    OnLocationUpdated(r.Value, r.Value.location);
                                                }
                                            }
                                            else
                                            {
                                                UserPEP up = new UserPEP();
                                                up.location = l;
                                                if (!initialUserPEP.ContainsKey(bare))
                                                {
                                                    initialUserPEP.Add(bare, up);
                                                }
                                                else
                                                {
                                                    up.tune = initialUserPEP[bare].tune;
                                                    up.mood = initialUserPEP[bare].mood;
                                                    up.activity = initialUserPEP[bare].activity;
                                                    initialUserPEP[bare] = up;
                                                }
                                            }
                                        }
                                    }
                                    else if (item.SelectSingleElement("retract") != null)
                                    {
                                        Location l = new Location();
                                        l.altitude = 0;
                                        l.latitude = 0;
                                        l.longitude = 0;
                                        l.bearing = 0;
                                        l.error = 0;
                                        l.speed = 0;
                                        l.area = string.Empty;
                                        l.building = string.Empty;
                                        l.country = string.Empty;
                                        l.datum = string.Empty;
                                        l.description = string.Empty;
                                        l.floor = string.Empty;
                                        l.locality = string.Empty;
                                        l.postalcode = string.Empty;
                                        l.region = string.Empty;
                                        l.room = string.Empty;
                                        l.street = string.Empty;
                                        l.text = string.Empty;
                                        l.timestamp = new DateTime();
                                        l.uri = string.Empty;
                                        if (contacts.ContainsKey(bare) && contacts[bare].Values.Count > 0)
                                        {
                                            foreach (KeyValuePair<string, Contact> r in contacts[bare])
                                            {
                                                r.Value.location = l;
                                                OnLocationUpdated(r.Value, r.Value.location);
                                            }
                                        }
                                        else
                                        {
                                            UserPEP up = new UserPEP();
                                            up.location = l;
                                            if (!initialUserPEP.ContainsKey(bare))
                                            {
                                                initialUserPEP.Add(bare, up);
                                            }
                                            else
                                            {
                                                up.tune = initialUserPEP[bare].tune;
                                                up.mood = initialUserPEP[bare].mood;
                                                up.activity = initialUserPEP[bare].activity;
                                                initialUserPEP[bare] = up;
                                            }
                                        }
                                    }
                                }
                                #endregion
                                #region User tune
                                if (items.HasAttribute("node") && (items.Attributes["node"] as string) == "http://jabber.org/protocol/tune" && (item.HasTag("tune") || item.HasTag("retract")))
                                {
                                    agsXMPP.Xml.Dom.Element tune = item.SelectSingleElement("tune");
                                    if (tune != null)
                                    {
                                        // HACK: tune.Namespace == "http://jabber.org/protocol/tune"
                                        if (tune.HasChildElements)
                                        {
                                            Tune t = new Tune();
                                            t.length = (tune.HasTag("length") && tune.SelectSingleElement("length").Value != null) ? Convert.ToInt32(tune.SelectSingleElement("length").Value, System.Globalization.CultureInfo.InvariantCulture) : 0;
                                            t.rating = (tune.HasTag("rating") && tune.SelectSingleElement("rating").Value != null) ? Convert.ToInt32(tune.SelectSingleElement("rating").Value, System.Globalization.CultureInfo.InvariantCulture) : 0;
                                            t.track = (tune.HasTag("track") && tune.SelectSingleElement("track").Value != null) ? Convert.ToInt32(tune.SelectSingleElement("track").Value, System.Globalization.CultureInfo.InvariantCulture) : 0;
                                            t.artist = (tune.HasTag("artist") && tune.SelectSingleElement("artist").Value != null) ? tune.SelectSingleElement("artist").Value.Trim() : string.Empty;
                                            t.source = (tune.HasTag("source") && tune.SelectSingleElement("source").Value != null) ? tune.SelectSingleElement("source").Value.Trim() : string.Empty;
                                            t.title = (tune.HasTag("title") && tune.SelectSingleElement("title").Value != null) ? tune.SelectSingleElement("title").Value.Trim() : string.Empty;
                                            t.uri = (tune.HasTag("uri") && tune.SelectSingleElement("uri").Value != null) ? tune.SelectSingleElement("uri").Value.Trim() : string.Empty;
                                            if (contacts.ContainsKey(bare) && contacts[bare].Values.Count > 0)
                                            {
                                                foreach (KeyValuePair<string, Contact> r in contacts[bare])
                                                {
                                                    r.Value.tune = t;
                                                    OnTuneUpdated(r.Value, r.Value.tune);
                                                }
                                            }
                                            else
                                            {
                                                UserPEP up = new UserPEP();
                                                up.tune = t;
                                                if (!initialUserPEP.ContainsKey(bare))
                                                {
                                                    initialUserPEP.Add(bare, up);
                                                }
                                                else
                                                {
                                                    up.mood = initialUserPEP[bare].mood;
                                                    up.activity = initialUserPEP[bare].activity;
                                                    up.location = initialUserPEP[bare].location;
                                                    initialUserPEP[bare] = up;
                                                }
                                            }
                                        }
                                    }
                                    else if (item.SelectSingleElement("retract") != null)
                                    {
                                        Tune t = new Tune();
                                        t.artist = string.Empty;
                                        t.length = 0;
                                        t.rating = 1;
                                        t.source = string.Empty;
                                        t.title = string.Empty;
                                        t.track = 0;
                                        t.uri = string.Empty;
                                        if (contacts.ContainsKey(bare) && contacts[bare].Values.Count > 0)
                                        {
                                            foreach (KeyValuePair<string, Contact> r in contacts[bare])
                                            {
                                                r.Value.tune = t;
                                                OnTuneUpdated(r.Value, r.Value.tune);
                                            }
                                        }
                                        else
                                        {
                                            UserPEP up = new UserPEP();
                                            up.tune = t;
                                            if (!initialUserPEP.ContainsKey(bare))
                                            {
                                                initialUserPEP.Add(bare, up);
                                            }
                                            else
                                            {
                                                up.mood = initialUserPEP[bare].mood;
                                                up.activity = initialUserPEP[bare].activity;
                                                up.location = initialUserPEP[bare].location;
                                                initialUserPEP[bare] = up;
                                            }
                                        }
                                    }
                                }
                                #endregion
                                #region User nickname
                                if (items.HasAttribute("node") && (items.Attributes["node"] as string) == "http://jabber.org/protocol/nick" && item.HasTag("nick"))
                                {
                                    agsXMPP.Xml.Dom.Element nick = item.SelectSingleElement("nick");
                                    if (nick != null)
                                    {
                                        // HACK: nick.Namespace == "http://jabber.org/protocol/nick"
                                        if (nick.HasChildElements)
                                        {
                                            string nm = (nick.Value != null) ? nick.Value.Trim() : string.Empty;
                                            if (nm != string.Empty)
                                            {
                                                if (contacts.ContainsKey(bare) && contacts[bare].Values.Count > 0)
                                                {
                                                    foreach (KeyValuePair<string, Contact> r in contacts[bare])
                                                    {
                                                        r.Value.identity.nickname = nm;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                #endregion
                            }
                        }
                        #endregion
                    }
                }
            }
        }

        /// <summary>
        /// Traverse la hierarchie des activit�s et sous activit�s
        /// </summary>
        /// <param name="start">Noeud de d�part</param>
        /// <param name="mem">Liste m�moire</param>
        /// <returns>Liste des activit�s</returns>
        private List<string> recurseActivityTags(agsXMPP.Xml.Dom.Element start, List<string> mem)
        {
            if (start != null)
            {
                List<string> memo = mem;
                memo.Add(start.TagName);
                if (start.HasChildElements)
                {
                    foreach (agsXMPP.Xml.Dom.Node n in start.ChildNodes)
                    {
                        if (n.NodeType == agsXMPP.Xml.Dom.NodeType.Element)
                        {
                            recurseActivityTags((n as agsXMPP.Xml.Dom.Element), mem);
                        }
                    }
                }
                return memo;
            }
            return mem;
        }

    }

}
