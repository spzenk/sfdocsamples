using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Web.Configuration;
using System.Configuration.Provider;
using System.Configuration;
using Fwk.Security.Common;
using Health.DAC;
using Fwk.Exceptions;
using Health.Back;
using Health.BE;
using Health.Entities;

namespace Health.Security
{

    /// <summary>
    /// Customizacion . Nececita si o si SQLMembershipProvider configurado
    /// </summary>
    public class HealthMembershipProvider : System.Web.Security.MembershipProvider 
    {
        #region Class Variables
        private string _providerName;

        private string _SQLMembershipProvider;

      
        private string _connectionString;
        private string _applicationName;
        private bool _enablePasswordReset;
        private bool _enablePasswordRetrieval;
        private bool _requiresQuestionAndAnswer;
        private bool _requiresUniqueEmail;
        private int _minRequiredNonAlphanumericCharacters;
        private int _minRequiredPasswordLength;

        #endregion
        #region Properties

        public string ProviderName
        {
            get { return _providerName; }
            //set { _providerName = value; }
        }

        public override string ApplicationName
        {
            get
            {
                return _applicationName;
            }
            set { _applicationName = value; }

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
        //VERDADERO
        public override bool RequiresUniqueEmail
        {
            get
            {
                return _requiresUniqueEmail;
            }
        }
        //NO
        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }
        //NO
        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }
        //NO
        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }
        //NO
        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }
        //VER VALOR POR DEFECTO
        public override int MinRequiredNonAlphanumericCharacters
        {
            get
            {
                return _minRequiredNonAlphanumericCharacters;
            }
        }
        //IDEM ANTERIOR
        public override int MinRequiredPasswordLength
        {
            get
            {
                return _minRequiredPasswordLength;
            }
        }

 
        public string SQLMembershipProvider
        {
            get { return _SQLMembershipProvider; }
            //set { _SQLMembershipProvider = value; }
        }

        #endregion


        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            base.Initialize(name, config);

            if (String.IsNullOrEmpty(name))
                _providerName = "HealthMembershipProvider";
            else
                _providerName = name;

            
            
            _SQLMembershipProvider = GetConfigValue(config["sqlMembershipProvider"],"sec");
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

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
          return  Fwk.Security.FwkMembership.ChangeUserPassword(username, oldPassword, newPassword, _SQLMembershipProvider);
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo que solo genera una solicitud de registro .- Esta solicitud debe ser aprovada despues .-
        /// </summary>
        /// <param name="username"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nroDocumento"></param>
        /// <param name="matricula"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="passwordQuestion"></param>
        /// <param name="passwordAnswer"></param>
        public void RegistrationRequest(RegistrationRequest registrationRequest)
        {
            var Profesional_FullView = ProfesionalesDAC.Get_ByParams(registrationRequest.NroDocumento, registrationRequest.Matricula);
            if (Profesional_FullView != null)
                throw new Fwk.Exceptions.TechnicalException(
               string.Format("Ya existe registrado un profecional con Nro Documento: {0} .-",
               registrationRequest.NroDocumento));

            string registrationCode = Common.getMd5Hash(string.Concat(registrationRequest.UserName, registrationRequest.mail)                );

            //RegistrationRequest registrationRequest = new RegistrationRequest();
            //registrationRequest.Nombre = txtNombre.Text.Trim();
            //registrationRequest.Apellido = txtApellido.Text.Trim();
            //registrationRequest.UserName = txtUserName.Text;
            //registrationRequest.NroDocumento = txtNrodocumento.Text.Trim();
            //registrationRequest.Matricula = txtMatricula.Text.Trim();
            //registrationRequest.mail = txtEmail.Text.Trim();
            registrationRequest.RegistrationCode = registrationCode;

            WebRegistrationDAC.CreateRegistrationRequest(registrationRequest);
        }

        /// <summary>
        /// Crea el usuario directamente. Este metodo sera llamado por una interfaz con autorizacion de desarrollador-super-admin del sistema
        /// dado que: Marca como aprovada la solicitud de registro y crea el usuario en el sistema
        /// Luego el usuario debera cambiar su clave
        /// 
        /// No se crea aqui el profecional
        /// </summary>
        /// <param name="registrationRequestId"></param>
        /// <param name="passwordQuestion"></param>
        /// <param name="passwordAnswer"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public MembershipUser CreateUser(int registrationRequestId, string passwordQuestion, string passwordAnswer, out MembershipCreateStatus status)
        {

            RegistrationRequest registrationRequest = WebRegistrationDAC.Get_RegistrationRequest_Id(registrationRequestId);
           
            if (registrationRequest == null)
                throw new Fwk.Exceptions.TechnicalException("Solicitud de registro no válida .-");


            WebRegistrationDAC.Approve(registrationRequest.Id);
            // Crea el usuario
            User usr = Fwk.Security.FwkMembership.CreateUser(registrationRequest.UserName, registrationRequest.RegistrationCode, registrationRequest.mail, passwordQuestion, passwordAnswer, true, out status, _SQLMembershipProvider);

            MembershipUser membershipUser = null;

            if (status == MembershipCreateStatus.Success || status == MembershipCreateStatus.DuplicateUserName)
            {
                membershipUser = GetUser(registrationRequest.UserName, true);

                //profesionalBE.Persona.UserId = (Guid)membershipUser.ProviderUserKey;

                
                //Generar el profesional 
                //ProfesionalesDAC.Create(profesionalBE);
            }

            return membershipUser;

        }
    
        /// <summary>
        /// Crea el usuario
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="passwordQuestion"></param>
        /// <param name="passwordAnswer"></param>
        /// <param name="isApproved"></param>
        /// <param name="providerUserKey"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public override MembershipUser CreateUser(string username, 
            string password, string email, string passwordQuestion, 
            string passwordAnswer, 
            bool isApproved, 
            object providerUserKey, out MembershipCreateStatus status)
        {
            //var userHealth = SociosDAC.Get(1,null);

            //if (userHealth == null)
            //    throw new Fwk.Exceptions.TechnicalException("No se puede encontrar el Nro de socio ingresado en nuestras bases de datos");
            //if (userHealth.UserId.HasValue )
            //    throw new Fwk.Exceptions.TechnicalException(string.Format("Ya existe un usuario con el numero de socio {0} registrado.-", username));
           // Crea el usuario
            User usr = Fwk.Security.FwkMembership.CreateUser(username, password, email, passwordQuestion, passwordAnswer, isApproved, out status, _SQLMembershipProvider);
            
            MembershipUser  membershipUser = null ;
            //if (status == MembershipCreateStatus.Success)
            //{
                membershipUser = GetUser(username, true);

            //    userHealth.UserId = (Guid)membershipUser.ProviderUserKey;

            //    SociosDAC.Registrar(userHealth.NroSocio, userHealth.NroAbonado, userHealth.UserId.Value, isApproved);
            //}


            return membershipUser;


        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
             Fwk.Security.FwkMembership.DeleteUser(username, _SQLMembershipProvider);

             return true;
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
        public   bool ExistUser(string username)
        {
            try
            {
                Fwk.Security.Common.User user = Fwk.Security.FwkMembership.GetUser(username, _SQLMembershipProvider);

                return true;

            }
            catch (TechnicalException ex)
            {
                if (ex.ErrorId == "4005")
                {
                    return false;
                }
                throw ex;
            }
        }
        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            MembershipUser membershipUser = null;
            try
            {
                Fwk.Security.Common.User user =  Fwk.Security.FwkMembership.GetUser(username, _SQLMembershipProvider);
                Guid guid= (Guid)user.ProviderId;

                //var userHealth = SociosDAC.GetByGuid(guid);
                //if (userHealth != null)
                //{
                    membershipUser = new MembershipUser(this.ProviderName, user.UserName, user.ProviderId, user.Email, string.Empty, string.Empty,user.IsApproved
                        , false, user.CreationDate.Value, DateTime.Today, DateTime.Today, DateTime.Today, DateTime.Today);
                //}

                
                
            }
            catch (ProviderException ex)
            {
                throw new ProviderException("Error: " + ex);
            }

            return membershipUser;
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            return Fwk.Security.FwkMembership.GetUserNameByEmail(email, _SQLMembershipProvider);
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

        /// <summary>
        /// 1- Valida pwd y username
        /// 2- Valida IsUserActive
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public override bool ValidateUser(string username, string password)
        {
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

        public bool VerifyLoggingAuthorization(string username, string token)
        {
            User user = Fwk.Security.FwkMembership.GetUser(username, _SQLMembershipProvider);
            if (user == null)
                return false;

            return Common.verifyMd5Hash(string.Concat(user.UserName,user.Email), token);
        }
        public bool VerifyLoggingAuthorization(string username,string email,string token)
        {
            return Common.verifyMd5Hash(string.Concat(username, email), token);
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


        public static string GetErrorMessage(MembershipCreateStatus status)
        {
            switch (status)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "Username already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A username for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
    }
}
