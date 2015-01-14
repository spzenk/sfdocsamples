using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Fwk.Security.Common;

namespace WebChat.Common.Security
{
    public class SecurityPortalMembershipUser : MembershipUser
    {
        #region Properties
        public Guid UserGuid { get; set; }
        public UserSession LogedUserSession {get; set;}
        
        public string[] Roles { get; set; }
        #endregion

        public SecurityPortalMembershipUser(User user, String providernName)
            : base(providernName, user.UserName, user.UserId, user.Email, string.Empty, string.Empty, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now)
        {
            LogedUserSession.Firstname = user.FirstName;
            LogedUserSession.Lastname = user.LastName;
            UserSession.DNI = user.DNI;
            UserGuid = (Guid)user.ProviderId;

        }


        //public SecurityPortalMembershipUser(User user, String providernName)
        //    : base(providernName, user.UserName, user.UserId, user.Email, string.Empty, string.Empty, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now)
        //{
        //    LogedUserSession.Firstname = user.FirstName;
        //    LogedUserSession.Lastname = user.LastName;
        //    UserSession.DNI = user.DNI;
        //    UserGuid = (Guid)user.ProviderId;

        //}


     


    }
}