using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epiron.Back.Bases.BE
{
    public class EPUser : UsersBE
    {

        #region [Private Members]

        private string password;
        private string hostName;
        private string ipAdress;
        private string applicationInstanceGUID;
        private static Guid userGUID;

        #endregion

        #region [Properties]

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string HostName
        {
            get { return hostName; }
            set { hostName = value; }
        }

        public string IpAdress
        {
            get { return ipAdress; }
            set { ipAdress = value; }
        }

        //TODO: Ver esto :applicationInstanceGUID = Common.ApplicationInstanceGUIDKey
        public string ApplicationInstanceGUID
        {
            get { return applicationInstanceGUID; }
            set { applicationInstanceGUID = value; }
        }

        public static Guid UserGUID
        {
            get { return userGUID; }
        }


        #endregion


        public void AssignGuid(Guid pUGuid)
        {
            try
            {
                userGUID = pUGuid;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
