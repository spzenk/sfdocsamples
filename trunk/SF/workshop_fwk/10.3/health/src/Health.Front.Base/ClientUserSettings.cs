using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Health.Front
{
    [Serializable]
    public class ClientUserSettings
    {
        string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        string user;

        public string User
        {
            get { return user; }
            set { user = value; }
        }
        string domain;

        public string Domain
        {
            get { return domain; }
            set { domain = value; }
        }
        string userDomain;

        public string UserDomain
        {
            get { return userDomain; }
            set { userDomain = value; }
        }
        string _Server;

        public string Server
        {
            get { return _Server; }
            set { _Server = value; }
        }

        string _Resource = String.Empty;

        public string Resource
        {
            get { return _Resource; }
            set { _Resource = value; }
        }

        //TODO: hacer los servicio q traen sus valores
        public string ActivationKey { get; set; }
        public Guid HealthInstitutionId { get; set; }

    }
}
