//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Security;
//using Fwk.Exceptions;


//namespace WebChat.Common.Security
//{
//    /// <summary>
//    /// Simple adaptador 
//    /// </summary>
//    public class SecurityAdapter : ISecurityAdapter
//    {
//        SecurityPortalMemberships _SQLMembershipProvider = null;
//        public SecurityAdapter()
//        {
//            _SQLMembershipProvider  = (SecurityPortalMemberships)Membership.Provider;
            
//        }
//        public UserSession GetUser(string userName)
//        {
//            UserSession wUserSession = UsersDAC.Get(userName);

//            return wUserSession;
//        }

//        public UserSession GetUser(Guid userId)
//        {
//            UserSession wUserSession = UsersDAC.Get(userId);

//            return wUserSession;
//        }

//        public UserSession CreateUser(string userName, string password, string email)
//        {
//            throw new NotImplementedException();
//        }

//        public bool ValidateUser(string userName, string password)
//        {
//            return UsersDAC.ValidateUser( userName,  password);

//            //SecurityPortalMemberships wHealthMembershipProvider = (SecurityPortalMemberships)Membership.Provider;
//            //return wHealthMembershipProvider.ValidateUser(userName, password);
            
            
//        }
//        public void ValidateUser(UserSession userData, string outhRuleName)
//        {
//            if (!UsersDAC.ValidateUser(userData.Username, userData.Password))
//            {
//                throw new FunctionalException("Usuario o contraseña incorrecta");
//            }

//            //SecurityPortalMemberships wHealthMembershipProvider = (SecurityPortalMemberships)Membership.Provider;
//            //return wHealthMembershipProvider.ValidateUser(userName, password);


//        }
//        public string[] GetRolesForUser(string userName)
//        {
//            throw new NotImplementedException();
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="username"></param>
//        /// <param name="oldPassword"></param>
//        /// <param name="newPassword"></param>
//        /// <returns></returns>
//        public bool ChangePassword(string username, string oldPassword, string newPassword)
//        {
//            return _SQLMembershipProvider.ChangePassword (username, oldPassword, newPassword);
//        }



//    }

//    public interface ISecurityAdapter
//    {
//        UserSession GetUser(string username);
//        UserSession GetUser(Guid userId);
//        UserSession CreateUser(string username, string password, string email);
//        bool ValidateUser(string username, string password);
//        string[] GetRolesForUser(string username);
//        bool ChangePassword(string username, string oldPassword, string newPassword);
//        void ValidateUser(UserSession userData, string outhRuleName);
//    }
//}