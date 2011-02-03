using System;
using Fwk.Exceptions;
using System.Web;
using System.Web.Security;
using BigBang.FrontEnd.Survey.Web;
using BigBang.Common;
using System.Collections.Specialized;
using System.Collections.Generic;
using DevExpress.Web.ASPxEditors;
using System.Web.UI.WebControls;
using System.Linq;
using Fwk.Security.ActiveDirectory;

namespace BigBang.FrontEnd.Survey.Web
{
    public partial class Login : System.Web.UI.Page
    {

        #region Members
        private SecurityController _SecurityController;
        private SessionProxy SessionProxy;
        private Boolean _RedirToChangePasswordPage;        
        private Boolean _IsEnvironmentUser
        {
            get
            {
                bool? wEnvUsr = (bool?)ViewState["IsEnvironmentUser"];
                if (wEnvUsr != null)
                    return (bool)wEnvUsr;
                else
                    return false;
            }
            set
            {
                ViewState["IsEnvironmentUser"] = value;
            }
        }
        private String _DefaultUserName = String.Empty;
        private String _DefaultUserDomainName = String.Empty;
        private List<AuthenticationModeBE> _AuthMode;
        private List<DomainUrlInfo> _Domains;
        #endregion

        #region Properties
        public SecurityController SecurityController
        {
            get
            {
                if (_SecurityController == null)
                {
                    _SecurityController = new SecurityController();
                }
                return _SecurityController;
            }
        }
        public ASPxTextBox PasswordControl
        {
            get
            {
                return (ASPxTextBox)this.Login1.FindControl("Password");
            }
        }
        public ASPxTextBox UserNameControl
        {
            get
            {
                return (ASPxTextBox)this.Login1.FindControl("UserName");
            }
        }
        public ASPxButton ChangePasswordButton
        {
            get
            {
                return (ASPxButton)this.Login1.FindControl("ChangePasswordButton");
            }
        }

        #endregion

        #region Events Methods
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionProxy = new SessionProxy(Session);

            // Si el usuario se encuentra autenticado, continua sin pasar por login
            if (Context.User.Identity.IsAuthenticated)
            {
                Response.Redirect(BigBang.FrontEnd.Web.Properties.Resources.URL_SelectRecordSet);
            }

            _AuthMode = SecurityController.GetEnabledAuthenticationModes();
            _Domains = SecurityController.GetDomains();
            if (_AuthMode.Count(p => p.Value == Convert.ToInt32(AuthenticationModeEnum.WindowsIntegrated)) > 0)
            {
                // Está ativa la configuración de windows 
                if (Request.Params["LOGON_USER"] != String.Empty)
                {
                    // Se encontraron las credenciales enviadas por el navegador
                    _DefaultUserDomainName = Request.Params["LOGON_USER"].Split('\\')[0];
                    _DefaultUserName = Request.Params["LOGON_USER"].Split('\\')[1];
                }
                else
                {
                    // El navegador no envió credenciales y está activa la autenticación integrada
                    Helper.ProcessWebException(new TechnicalException("Error en Login.aspx: Deshabilite la autenticación integrada de Windows o configure el sitio para que no permita autenticación anónima. Ver solapa 'Seguridad de directorio'."));
                }
            }

        }


        protected void Page_PreRender(object sender, EventArgs e)
        {
            EnabledDisabledPassword();
        }

        /// <summary>
        /// Evento que lanza el control Login1 cuando se requiere autenticar al usuario. 
        /// Se llama al servicio de la securitycontroller para autenticar el usuario y se captura los AuthenticationException 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            try
            {
                //String wMustChangeUrlPage = BigBang.FrontEnd.Web.Properties.Resources.URL_ChangePassword;

                //// llama al servicio para autenticarse
                //AuthenticationModeEnum wAuthMode = HelperFunctions.Enumerations.IntToEnum<AuthenticationModeEnum>(Convert.ToInt32(AuthenticationMode.Value));

                //String wDomain = String.Empty;
                //object siteName = null;
                //if (Domains.SelectedItem != null)
                //{
                //    if (String.IsNullOrEmpty(Domains.Text))
                //    {
                //        Helper.ProcessWebException(new TechnicalException("El nombre del dominio no puede estar vacío."));
                //    }

                //    wDomain = Domains.Text;
                //    siteName = Domains.SelectedItem.Value;
                //}
                
                //if (siteName == null) { siteName = Environment.GetEnvironmentVariable("USERDNSDOMAIN"); }
                
                //SessionProxy.CurrentUserInfo = SecurityController.AuthenticateUser(Login1.UserName, Login1.Password, wAuthMode, wDomain, _IsEnvironmentUser, siteName.ToString());
                ////SessionProxy.CurrentUserInfo = SecurityController.AuthenticateUser(Login1.UserName, Login1.Password, wAuthMode, wDomain, _IsEnvironmentUser);
                //if (SessionProxy.CurrentUserInfo.MustChangePassword)
                //{
                //    // El usuario se autenticó por BigBang y está oblicado a cambiar la clave
                //    _RedirToChangePasswordPage = true;
                //    // le agrego el MustChange=true a la url de la página para cambiar
                //    wMustChangeUrlPage = String.Format("{0}?MustChange=true", BigBang.FrontEnd.Web.Properties.Resources.URL_ChangePassword);
                //}
                //if (_RedirToChangePasswordPage)
                //{
                //    // El usuario solicitó cambiar la clave o está obligado a hacerlo
                //    Login1.DestinationPageUrl = wMustChangeUrlPage;
                //}
                //else
                //{
                //    // Reenvía a la página por defecto
                //    Login1.DestinationPageUrl = BigBang.FrontEnd.Web.Properties.Resources.URL_SelectRecordSet;
                //}
                e.Authenticated = true;

            }
            catch (AuthenticationException ex)
            {
                // Falló la autenticación. Se carga el mensaje desde la exception.
                Login1.FailureText = ex.Message;
                e.Authenticated = false;
            }
        }

        protected void Domains_Load(object sender, EventArgs e)
        {
            ////if (_AuthMode.Count(p => p.Value == Convert.ToInt32(AuthenticationModeEnum.LDAP)) > 0)
            ////{
            ////    if (!IsPostBack)
            ////    {
            ////        if (_Domains.Count == 0)
            ////        {
            ////            Helper.ProcessWebException(new TechnicalException("Error en Login.aspx al intentar cargar la lista de dominios: No se encontró ningún dominio configurado en la base de datos."));
            ////        }
            ////        Domains.TextField = "DomainName";
            ////        Domains.ValueField = "SiteName";// _Domains[0].DomainDN.SiteName
            ////        Domains.DataSource = _Domains;
            ////        //Domains.Value = _Domains[0];
            ////    }
            ////    Domains.DataBind();
            ////}
            ////if (!IsPostBack)
            ////{
            ////    if (_DefaultUserDomainName != String.Empty)
            ////    {
            ////        //Domains.Value = _DefaultUserDomainName;
            ////        Domains.Text = _DefaultUserDomainName;
            ////    }
            ////}
        }

        protected void AuthenticationMode_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_AuthMode.Count == 0)
                {
                    Helper.ProcessWebException(new TechnicalException("Error en Login.aspx: No se encuentran modos de autenticación configurados con Value = true en el archivo de configuración. Por favor verifique."));
                }
                AuthenticationMode.DataSource = _AuthMode;
                AuthenticationMode.ValueField = "Value";
                AuthenticationMode.TextField = "Name";
                AuthenticationMode.Value = _AuthMode[0].Value;
            }
            AuthenticationMode.DataBind();
        }

        protected void UserName_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Login1.UserName = _DefaultUserName;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// (Des)Habilita los controles en función del modo de autenticación seleccionado y otras condiciones
        /// </summary>
        private void EnabledDisabledPassword()
        {
            switch (HelperFunctions.Enumerations.IntToEnum<AuthenticationModeEnum>(Convert.ToInt32(AuthenticationMode.Value)))
            {
                case AuthenticationModeEnum.Mixed:
                    DoEnabledDisabledPassword(false, true, true, false, true);
                    break;
                case AuthenticationModeEnum.LDAP:
                    DoEnabledDisabledPassword(true, true, true, false, false);
                    break;
                case AuthenticationModeEnum.WindowsIntegrated:
                    UserNameControl.Value = _DefaultUserName;
                    Domains.Value = _DefaultUserDomainName;
                    PasswordControl.Value = String.Empty;
                    DoEnabledDisabledPassword(false, false, false, true, false);
                    break;
                default:
                    Helper.ProcessWebException(new NotImplementedException(String.Format("Error en Login.aspx: El modo de autenticación {0} no se encuentra implementado.", AuthenticationMode.Text.ToString())));
                    break;
            }
        }

        /// <summary>
        /// Encapsula la (des)habilitacion de 4 controles. Esto obliga a que cuando se (des)habilita alguno, se inspecciones si se debe (des)habilitar los otros
        /// </summary>
        /// <param name="pIsEnvironmentUser"></param>
        /// <param name="pEnablePassword"></param>
        /// <param name="pEnableDomain"></param>
        /// <param name="pEnableChangePassword"></param>
        private void DoEnabledDisabledPassword(bool pEnableDomain, bool pEnableUserName, bool pEnablePassword, bool pIsEnvironmentUser, bool pEnableChangePasswordButton)
        {
            this._IsEnvironmentUser = pIsEnvironmentUser;
            this.PasswordControl.Enabled = pEnablePassword;
            this.Domains.Enabled = pEnableDomain;
            this.ChangePasswordButton.Enabled = pEnableChangePasswordButton;
            this.UserNameControl.Enabled = pEnableUserName;
        }


        /// <summary>
        /// Evento clic del botón de cambio de password. Es igual que el boton login pero setea la bandera this.RedirToChangePasswordPage en true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ChangePasswordButton_Command(object sender, CommandEventArgs e)
        {
            _RedirToChangePasswordPage = true;
        }
        #endregion
    }
}
