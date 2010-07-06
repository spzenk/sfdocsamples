using System;
using System.Collections.Generic;
using System.Text;

namespace nJim
{

    /// <summary>
    /// Identifiant Jabber scind� en multiples parties
    /// </summary>
    public struct JabberID
    {

        /// <summary>
        /// Utilisateur
        /// </summary>
        public string user;

        /// <summary>
        /// Domaine
        /// </summary>
        public string domain;

        /// <summary>
        /// Ressource
        /// </summary>
        public string resource;

        /// <summary>
        /// Identifiant sans sa ressource
        /// </summary>
        public string bare;

        /// <summary>
        /// Identifiant au complet
        /// </summary>
        public string full;

    }

    /// <summary>
    /// Nomination scind�e en multiples parties
    /// </summary>
    public struct Name
    {

        /// <summary>
        /// Pr�nom
        /// </summary>
        public string firstname;

        /// <summary>
        /// Second pr�nom ou 2�me partie d'un pr�nom compos�
        /// </summary>
        public string middle;

        /// <summary>
        /// Nom de famille
        /// </summary>
        public string lastname;

    }

    /// <summary>
    /// Entreprise scind�e en multiples parties
    /// </summary>
    public struct Organization
    {

        /// <summary>
        /// Nom de l'entreprise
        /// </summary>
        public string name;

        /// <summary>
        /// Secteur d'activit�
        /// </summary>
        public string unit;

    }

    /// <summary>
    /// Structure d'un email
    /// </summary>
    public struct Email
    {

        /// <summary>
        /// Cat�gorie de l'adresse email
        /// </summary>
        public Enumerations.EmailType type;

        /// <summary>
        /// Adresse email
        /// </summary>
        public string address;

    }

    /// <summary>
    /// Structure d'un favoris
    /// </summary>
    public struct Favorite
    {

        /// <summary>
        /// Nommination
        /// </summary>
        public string name;

        /// <summary>
        /// Adresse
        /// </summary>
        public string address;

    }

    /// <summary>
    /// Structure d'un num�ro de t�l�phone
    /// </summary>
    public struct Telehone
    {

        /// <summary>
        /// Emplacement
        /// </summary>
        public Enumerations.LocationType location;

        /// <summary>
        /// Cat�gorie
        /// </summary>
        public Enumerations.PhoneType type;

        /// <summary>
        /// Num�ro associ�
        /// </summary>
        public string number;

    }

    /// <summary>
    /// Structure d'une adresse
    /// </summary>
    public struct Address
    {

        /// <summary>
        /// Emplacement
        /// </summary>
        public Enumerations.LocationType location;

        /// <summary>
        /// Num�ro et nom de la rue
        /// </summary>
        public string street;

        /// <summary>
        /// Compl�ment d'adresse
        /// </summary>
        public string extra;

        /// <summary>
        /// Code postal
        /// </summary>
        public string zipcode;

        /// <summary>
        /// Ville
        /// </summary>
        public string city;

        /// <summary>
        /// R�gion / D�partement
        /// </summary>
        public string region;

        /// <summary>
        /// Pays
        /// </summary>
        public string country;

    }

    /// <summary>
    /// Status d'une pr�sence
    /// </summary>
    public struct Status
    {

        /// <summary>
        /// Type du status
        /// </summary>
        public Enumerations.StatusType type;

        /// <summary>
        /// Message
        /// </summary>
        public string message;

    }

    /// <summary>
    /// Service
    /// </summary>
    public struct Service
    {

        /// <summary>
        /// Identifiant Jabber du server
        /// </summary>
        public JabberID jabberID;

        /// <summary>
        /// Nom public du service
        /// </summary>
        public string name;

        /// <summary>
        /// Cat�gorie du service
        /// </summary>
        public string category;

        /// <summary>
        /// Liste des fonctionnalit�s li�es au service
        /// </summary>
        public List<string> features;

    }

    /// <summary>
    /// Version d'un client logiciel
    /// </summary>
    public struct ClientVersion
    {

        /// <summary>
        /// Nom du logiciel client
        /// </summary>
        public string name;

        /// <summary>
        /// Version du syst�me d'exploitation
        /// </summary>
        public string os;

        /// <summary>
        /// Version du logiciel client
        /// </summary>
        public string version;

    }

    /// <summary>
    /// Structure utilis�e pour le passage par r�f�rnce de donn�es de blocage
    /// </summary>
    public struct PrivacyStructure
    {

        /// <summary>
        /// Identifiant de la requete
        /// </summary>
        public string id;

        /// <summary>
        /// Identifiant Jabber incrimin�
        /// </summary>
        public agsXMPP.Jid jid;

    }

    /// <summary>
    /// Structure d'un salon
    /// </summary>
    public struct Room
    {

        /// <summary>
        /// Rejoindre automatiquement le salon
        /// </summary>
        public bool autoJoin;

        /// <summary>
        /// Adresse du salon
        /// </summary>
        public JabberID jabberID;

        /// <summary>
        /// Nom du salon
        /// </summary>
        public string name;

        /// <summary>
        /// Nom d'utilisateur de connexion
        /// </summary>
        public string nickname;

        /// <summary>
        /// Mot de passe de connexion
        /// </summary>
        public string password;

    }

    /// <summary>
    /// Structure d'une humeur
    /// </summary>
    public struct Mood
    {

        /// <summary>
        /// Type de l'hummeur
        /// </summary>
        public Enumerations.MoodType type;

        /// <summary>
        /// Description
        /// </summary>
        public string text;

    }

    /// <summary>
    /// Structure d'une activit�
    /// </summary>
    public struct Activity
    {

        /// <summary>
        /// Type de l'activit�
        /// </summary>
        public Enumerations.ActivityType type;

        /// <summary>
        /// Description
        /// </summary>
        public string text;

    }

    /// <summary>
    /// Structure d'un emplacement g�ographique
    /// </summary>
    public struct Location
    {

        /// <summary>
        /// Altitude
        /// </summary>
        public double altitude;

        /// <summary>
        /// Emplacement compl�mentaire
        /// </summary>
        public string area;

        /// <summary>
        /// D�calage directionnel satellite
        /// </summary>
        public double bearing;

        /// <summary>
        /// Nom de l'immeuble
        /// </summary>
        public string building;

        /// <summary>
        /// Nom du pays
        /// </summary>
        public string country;

        /// <summary>
        /// GPS Datum
        /// </summary>
        public string datum;

        /// <summary>
        /// Description de l'emplacement
        /// </summary>
        public string description;

        /// <summary>
        /// Erreur GPS horizontale
        /// </summary>
        public double error;

        /// <summary>
        /// Nom ou num�ro du niveau d'un immeuble
        /// </summary>
        public string floor;

        /// <summary>
        /// Latitude
        /// </summary>
        public double latitude;

        /// <summary>
        /// Ville (nom complet sans abr�viations)
        /// </summary>
        public string locality;

        /// <summary>
        /// Longitude
        /// </summary>
        public double longitude;

        /// <summary>
        /// Code postal
        /// </summary>
        public string postalcode;

        /// <summary>
        /// R�gion ou d�partement
        /// </summary>
        public string region;

        /// <summary>
        /// Emplacement � l'interieur d'un immeuble
        /// </summary>
        public string room;

        /// <summary>
        /// Vitesse de d�placement
        /// </summary>
        public double speed;

        /// <summary>
        /// Num�ro et nom de la rue
        /// </summary>
        public string street;

        /// <summary>
        /// Compl�ment d'adresse
        /// </summary>
        public string text;

        /// <summary>
        /// Temps universel en provenance du GPS
        /// </summary>
        public DateTime timestamp;

        /// <summary>
        /// URL pointant vers d'autres informations
        /// </summary>
        public string uri;

    }

    /// <summary>
    /// Structure d'une lecture en cours
    /// </summary>
    public struct Tune
    {

        /// <summary>
        /// Nom de l'artiste
        /// </summary>
        public string artist;

        /// <summary>
        /// Dur�e de la lecture en cours en secondes
        /// </summary>
        public int length;

        /// <summary>
        /// De 1 � 10, avis sur la lecture
        /// </summary>
        public int rating;

        /// <summary>
        /// Nom de l'album, de la playslist
        /// </summary>
        public string source;

        /// <summary>
        /// Titre du morceau
        /// </summary>
        public string title;

        /// <summary>
        /// Num�ro de la piste
        /// </summary>
        public int track;

        /// <summary>
        /// Lien direct vers des informations sur la lecture
        /// </summary>
        public string uri;

    }

    /// <summary>
    /// Structure regroupant les Users trucs
    /// </summary>
    public struct UserPEP
    {

        /// <summary>
        /// Humeur
        /// </summary>
        public Mood mood;

        /// <summary>
        /// Activit�
        /// </summary>
        public Activity activity;

        /// <summary>
        /// Emplacement g�ographique
        /// </summary>
        public Location location;

        /// <summary>
        /// Lecture en cours
        /// </summary>
        public Tune tune;

    }











}
