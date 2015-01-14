using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Security;
using Fwk.Security.Common;

using helper = WebChat.Common;


namespace WebChat.Common.Security
{
   
    /// <summary>
    /// Implementa ASP NET Membership Provider
    /// </summary>
    public class SecurityPortalMemberships : MembershipProvider
    {
        #region Class Variables
        private string _providerName;

        private string _SQLMembershipProvider;

        private int _cacheTimeoutInMinutes = 30;
        private string _connectionString;
        private string _applicationName;
        private bool _enablePasswordReset;
        private bool _enablePasswordRetrieval;
        private bool _requiresQuestionAndAnswer;
        private bool _requiresUniqueEmail;
        private int _minRequiredNonAlphanumericCharacters;
        private int _minRequiredPasswordLength;

        #endregion





        public override string ApplicationName
        {
            get
            {
                return _applicationName;
            }
            set { _applicationName = value; }

        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            return Fwk.Security.FwkMembership.ChangeUserPassword(username, oldPassword, newPassword, _SQLMembershipProvider);
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        //TODO FALSE DEFAULT
        public override bool EnablePasswordReset
        {
            get
            {
                return _enablePasswordReset;
            }
        }
        //TODO IDEM ANTERIOR
        public override bool EnablePasswordRetrieval
        {
            get
            {
                return _enablePasswordRetrieval;
            }
        }
        //RETURN FALSE
        public override bool RequiresQuestionAndAnswer
        {
            get
            {
                return _requiresQuestionAndAnswer;
            }
        }
        //True
        public override bool RequiresUniqueEmail
        {
            get
            {
                return _requiresUniqueEmail;
            }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            //var cacheKey = string.Format("UserData_{0}", username);
            //if (HttpRuntime.Cache[cacheKey] != null)
            //    return (SecurityPortalMembershipUser)HttpRuntime.Cache[cacheKey];


            try
            {
                Fwk.Security.Common.User user = Fwk.Security.FwkMembership.GetUser(username, _SQLMembershipProvider);
                Guid guid = (Guid)user.ProviderId;

                //var userHealth = SociosDAC.GetByGuid(guid);
                //if (userHealth != null)
                //{
                var membershipUser = new SecurityPortalMembershipUser(user, _SQLMembershipProvider);
                //Store in cache
                ///HttpRuntime.Cache.Insert(cacheKey, membershipUser, null, DateTime.Now.AddMinutes(_cacheTimeoutInMinutes), Cache.NoSlidingExpiration);
                //} 

                return membershipUser;

            }
            catch (ProviderException ex)
            {
                throw new ProviderException("Error: " + ex);
            }


        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            return Fwk.Security.FwkMembership.GetUserNameByEmail(email, _SQLMembershipProvider);
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }



        public override string ResetPassword(string username, string answer)
        {
            return Fwk.Security.FwkMembership.ResetUserPassword(username, _SQLMembershipProvider);
        }

        public override bool UnlockUser(string userName)
        {
            return Fwk.Security.FwkMembership.UnlockUser(userName, _SQLMembershipProvider);
        }

        public override void UpdateUser(MembershipUser user)
        {
            User userFwk = new User(user);
            Fwk.Security.FwkMembership.UpdateUser(userFwk, user.UserName, _SQLMembershipProvider);
        }

        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            base.Initialize(name, config);
            _cacheTimeoutInMinutes = 1;
            if (String.IsNullOrEmpty(name))
                _providerName = "sec_health";
            else
                _providerName = name;



            _SQLMembershipProvider = "sec_health_sql";// GetConfigValue(config["sqlMembershipProvider"], "sec_health");
            //SqlMembershipProvider sqlProvider  = (SqlMembershipProvider)System.Web.Security.Membership.Provider;
            _applicationName = "Health";// sqlProvider.ApplicationName;


            _enablePasswordReset = true;//sqlProvider.EnablePasswordReset;
            _enablePasswordRetrieval = false;//sqlProvider.EnablePasswordRetrieval;
            _requiresQuestionAndAnswer = false;//sqlProvider.RequiresQuestionAndAnswer;
            _requiresUniqueEmail = true;//sqlProvider.RequiresUniqueEmail;
            _minRequiredNonAlphanumericCharacters = 0;// sqlProvider.MinRequiredNonAlphanumericCharacters;
            _minRequiredPasswordLength = 1;// sqlProvider.MinRequiredPasswordLength;

            ConnectionStringSettings ConnectionStringSettings = ConfigurationManager.ConnectionStrings[config["connectionStringName"]];

            if ((ConnectionStringSettings == null) || (ConnectionStringSettings.ConnectionString.Trim() == String.Empty))
            {
                throw new ProviderException("Connection string cannot be blank.");
            }

            _connectionString = ConnectionStringSettings.ConnectionString;
        }

        private string GetConfigValue(string configValue, string defaultValue)
        {
            if (String.IsNullOrEmpty(configValue))
            {
                return defaultValue;
            }

            return configValue;
        }

        public override bool ValidateUser(string username, string password)
        {
            //TODO: Verificar si ValidateUser chequea IsLockedOut user
            User usrInfo = null;
            bool isValid = Fwk.Security.FwkMembership.ValidateUser(username, password, _SQLMembershipProvider);

            if (isValid)
            {
                usrInfo = Fwk.Security.FwkMembership.GetUser(username, _SQLMembershipProvider);
                if (usrInfo != null)
                {
                    if (usrInfo.IsLockedOut)
                    {
                        throw new Exception("Su cuenta de usuario se encuentra bloqueada debido a demaciados intentos fallidos. Por favor contacto su administrador de Health para desbloquear su cuenta.");
                    }
                    else if (!usrInfo.IsApproved)
                    {
                        throw new Exception("El usuario no esta activo. Por favor contacto su administrador de Health para solicitar la activación del usuario");
                    }
                }
                //ProfesionalBE s = ProfesionalesDAC.GetByUserGuid((Guid)usrInfo.ProviderId);
                //isValid = s.Persona.IsUserActive;
                //if (s.Persona.IsUserActive == false)
                //    throw new Exception("El usuario no esta activo. Por favor contacto su administrador de Health para solicitar la activación del usuario.");

            }

            return isValid;
        }

        /// <summary>
        /// Valida usuario chequeando username & pwd + Adiciona otras validaciones si es necesario
        /// </summary>
        /// <param name="wUserData"></param>
        /// <param name="OuthRuleName"></param>
        internal void ValidateUser(UserSession wUserData, string OuthRuleName)
        {
            ValidateUser(wUserData.Username, wUserData.Password);
        }

        public bool VerifyLoggingAuthorization(string username, string token)
        {
            User user = Fwk.Security.FwkMembership.GetUser(username, _SQLMembershipProvider);
            if (user == null)
                return false;

            return  helper.Common.verifyMd5Hash(string.Concat(user.UserName, user.Email), token);
        }
        public bool VerifyLoggingAuthorization(string username, string email, string token)
        {

            return helper.Common.verifyMd5Hash(string.Concat(username, email), token);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userame"></param>
        public void ApproveUser(string userame)
        {
            User user = Fwk.Security.FwkMembership.GetUser(userame, _SQLMembershipProvider);
            user.IsApproved = true;
            Fwk.Security.FwkMembership.UpdateUser(user, userame, _SQLMembershipProvider);

        }

        //public UserSession GetUser(string userName)
        //{
        //   // User user = Fwk.Security.FwkMembership.GetUser(userName, _SQLMembershipProvider);
        //    UserSession wUserSession = UsersDAC.Get(userName);
        //    return wUserSession;
        //}

       
    }
}