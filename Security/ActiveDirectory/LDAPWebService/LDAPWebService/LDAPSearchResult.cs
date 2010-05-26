using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace LDAPWebService
{
    public class LDAPSearchResult : IComparable
    {
        private string _displayName = string.Empty;
        private string _telephoneNumber = string.Empty;
        private string _samAccountName = string.Empty;
        private LDAPSearchResult _manager;
        private string _distinguishedName = string.Empty;
        private string _title = string.Empty;
        private string _department = string.Empty;
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;

        public string displayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }

        public string telephoneNumber
        {
            get { return _telephoneNumber; }
            set { _telephoneNumber = value; }
        }

        public string samAccountName
        {
            get { return _samAccountName; }
            set { _samAccountName = value; }
        }

        public LDAPSearchResult manager
        {
            get { return _manager; }
            set
            {
                _manager = new LDAPSearchResult();
                _manager = value;
            }
        }

        public string distinguishedName
        {
            get { return _distinguishedName; }
            set { _distinguishedName = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string department
        {
            get { return _department; }
            set { _department = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        #region IComparable Members

        public int CompareTo(object obj)
        {
            if (obj is LDAPSearchResult)
            {
                LDAPSearchResult u2 = (LDAPSearchResult)obj;
                return _displayName.CompareTo(u2.displayName);
            }
            else
                throw new ArgumentException("Object is not a User.");
        }

        #endregion
    }
}
