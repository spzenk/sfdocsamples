using System;
using System.Web.SessionState;


using System.Security.Principal;
using Microsoft.Practices.EnterpriseLibrary.Security;


namespace Maria
{
    public class SessionProxy
    {
        private HttpSessionState _CurrentSession;

        /// <summary>
        /// Limpia el ProxySession
        /// </summary>
        public void Clear()
        {
            ClearFilters();

            Error = null;


  
            _CurrentSession["FirstTime"] = null;
            _CurrentSession["WasClosed"] = null;




      
       
            
            //CurrentUserInfo = null;
            RuleProvider = null;
            Principal = null;
            
            _CurrentSession = null;
        }

        public void ClearFilters()
        {
            //Limpio los filtros
            _CurrentSession["CounterFilters"] = null;
            _CurrentSession["CounterAttributes"] = null;
            _CurrentSession["FilterTextBoxList"] = null;
            _CurrentSession["FilterDropDownList"] = null;
            _CurrentSession["FilterButtonList"] = null;
            _CurrentSession["FilterRecordSetAttributeList"] = null;
            
     

            //limpio filtros para JS
            _CurrentSession["FilterAndValues"] = string.Empty;
            _CurrentSession["FiltersDeleted"] = string.Empty;
        }

        public SessionProxy(HttpSessionState PageSession)
        {
            _CurrentSession = PageSession;
        }

       
      
        public  Exception Error
        {
            get { return (Exception)_CurrentSession["Error"]; }
            set { _CurrentSession["Error"] = value; }
        }

       

        public HttpSessionState CurrentSession
        {
            get { return _CurrentSession; }
        }

     
        //public  UserInfo CurrentUserInfo
        //{
        //    get { return (UserInfo)_CurrentSession["CurrentUserInfo"]; }
        //    set { _CurrentSession["CurrentUserInfo"] = value; }
        //}

        public  Boolean FirstTime
        {
            get { return (Boolean)_CurrentSession["FirstTime"]; }
            set { _CurrentSession["FirstTime"] = value; }
        }

        public  Boolean WasClosed
        {
            get { return (Boolean)_CurrentSession["WasClosed"]; }
            set { _CurrentSession["WasClosed"] = value; }
        }

        public IAuthorizationProvider RuleProvider
        {
            get { return (IAuthorizationProvider)_CurrentSession["RuleProvider"]; }
            set { _CurrentSession["RuleProvider"] = value; }
        }

        public IPrincipal Principal
        {
            get { return (IPrincipal)_CurrentSession["Principal"]; }
            set { _CurrentSession["Principal"] = value; }
        }
    }
}
