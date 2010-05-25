using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.SessionState;

namespace AjaxWithDynamicControls
{
    internal class SessionProxy
    {
        static HttpSessionState _CurrentSession;

        public static CheckObjetLis List
        {
            get { return (CheckObjetLis)_CurrentSession["List"]; }
            set { _CurrentSession["List"] = value; }
        }

       



        public static HttpSessionState CurrentSession
        {
            get { return _CurrentSession; }
            set { _CurrentSession = value; }
        }

       

    
    }
}
