using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fwk.Bases;

namespace Epiron.Back.Bases
{
    [Serializable]
    public class UsersBE : Entity
    {
        #region [Private Members]

        private System.String _UserNameLogin;
        private System.String _UserName;
        private System.String _FirstName;
        private System.String _LastName;
        private System.String _Password;

       
        #endregion

        #region [Properties]
        public System.String Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        public System.String UserNameLogin
        {
            get { return _UserNameLogin; }
            set { _UserNameLogin = value; }
        }

        public System.String UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        public System.String FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        public System.String LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        #endregion



    }
}
