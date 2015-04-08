using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using  Epiron.Front.Bases.Controls;

using System.IO;
using Microsoft.Win32;
using System.Net;
using System.Linq;
using System.Xml;
using Epiron.Back.Bases.BE;
using Fwk.Security.Common;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Epiron.Front.Bases
{
    public partial class FRM_AuthenticationForm : frmBase
    {

        // Creacion de Usuario
        EPUser wUser = new EPUser();
          
        //Servicio
        
        //Instancia de Guid de Aplicacion
        Guid appInstanceGuid = Guid.NewGuid();
        //Instancia de Guid de Tipo de Autenticación
        Guid authenticationTypeGUID = Guid.NewGuid();
        //Instancia de Guid de Dominio
        Guid domainGuid = Guid.NewGuid();
        //Guid Intercambio
        Guid interGuid = Guid.NewGuid();
        //Guid Intercambio User
        Guid interTypeAutGuid = Guid.NewGuid();
        //Guid Intercambio User
        Guid interUserGuid = Guid.NewGuid();
        DataTable tblDomains = null;
        DataTable tblTiposAutenticacion = null;
        public string UserNameLogin { 
            get {return  txtUserNameLogin.Text;} 
        }

        public string Password { get {return  txtPassLogin.Text;} }
        public FRM_AuthenticationForm()
        {
            InitializeComponent();

        }
        bool formwasloaded = false;
        private void FRM_AuthenticationForm_Load(object sender, EventArgs e)
        {
          
             InitInitialize(); 
          
           
        }
        private void FRM_AuthenticationForm_Activated(object sender, EventArgs e)
        {
            if (formwasloaded == false)
                this.ShowWaitForm();
        }
        

      
        /// <summary>
        /// Este metodo se ejecuta en segundo plano y llena los combos
        /// </summary>
        public async void InitInitialize()
        {
           
            txtUserNameLogin.Enabled = txtPassLogin.Enabled = btnAcept.Enabled = false;
          
            //txtUserNameLogin.Focus();
            var task = task_SetLogging();
            task.Start();

            Exception valor_tarea = await task;

            if (task.IsCompleted)
            {
                if (valor_tarea != null)
                {
                    cmbDomains.Enabled=txtUserNameLogin.Enabled = txtPassLogin.Enabled = btnAcept.Enabled = false;
                    
                    this.ExceptionViewer.Show(valor_tarea);
                    
                }
                else {

                    comboAuthenticationType1.Populate(tblTiposAutenticacion);
                    cmbDomains.Populate(tblDomains);

                    String wGuidDomain = cmbDomains.GetDomainGUID();

                    if (!String.IsNullOrEmpty(wGuidDomain))
                    {
                        domainGuid = Guid.Parse(wGuidDomain);
                    }
                    cmbDomains.Enabled = txtUserNameLogin.Enabled = txtPassLogin.Enabled = btnAcept.Enabled = true;


                    this.CloseWaitForm();
                    formwasloaded = true;
                }

            }
 
        }

   

        Task<Exception> task_SetLogging()
        {
            return new Task<Exception>(() =>
            {
                return  SetLogging();
            });
            
        }

        private Exception SetLogging()
        {
            DataTable oTableValidarAplicacion = null;

            // Nombre de usuario local
            String wEnvironmentUserName = System.Environment.UserName;
            GetHostNameAndIpAdress();

            try
            {
                //Guid oGuidApp = Guid.Parse("ded93c29-109b-e311-9dd1-0022640637c2");
                if (!String.IsNullOrEmpty(Epiron.Back.Bases.Common.ApplicationInstanceGUIDKey))
                {
                    appInstanceGuid = Guid.Parse(Epiron.Back.Bases.Common.ApplicationInstanceGUIDKey);
                    oTableValidarAplicacion = Epiron.Bases.ServiceProxy.AccesoConnector.ValidarAplicacion("VALIDAR-APP", appInstanceGuid, wUser.HostName, wUser.IpAdress);

                    if (!oTableValidarAplicacion.Columns.Contains("EventResponseId"))
                    {
                        interGuid = (Guid)(oTableValidarAplicacion.Rows[0]["GUID"]);
                        tblTiposAutenticacion = Epiron.Bases.ServiceProxy.AccesoConnector.TiposAutenticacion("TIPOS-AUT", appInstanceGuid, wUser.HostName, wUser.IpAdress, interGuid);
                        interTypeAutGuid = (Guid)(tblTiposAutenticacion.Rows[0]["GUID"]);

                        if (!tblTiposAutenticacion.Columns.Contains("EventResponseId"))
                        {
                            String wAuthenticationType = tblTiposAutenticacion.Rows[0]["AuthenticationTypeTag"].ToString();
                            tblDomains = Epiron.Bases.ServiceProxy.AccesoConnector.DominioInstancia(appInstanceGuid, wAuthenticationType);
                            String wAuthenticationTypeGUID = tblTiposAutenticacion.Rows[0]["AuthenticationTypeGUID"].ToString();
                            if (!String.IsNullOrEmpty(wAuthenticationTypeGUID))
                            {
                                authenticationTypeGUID = Guid.Parse(wAuthenticationTypeGUID);
                            }

                        }
                    }
                }
                else
                {
                    return new Exception(Epiron.Front.Bases.EpironMessages.MsgCheckGuidOfConfigurationFileString);
                }

                return null;
            }

            catch (TypeInitializationException ti)
            {
                return ti.InnerException;
            }
            catch (Exception ex)
            { return ex; }
        }

        /// <summary>
        /// Obtiene el nombre de host y ip v 4
        /// </summary>
        private void GetHostNameAndIpAdress()
        {
            IPHostEntry wHostEntry = Dns.GetHostEntry(Dns.GetHostName());
            var ips = wHostEntry.AddressList.Where(p => p.AddressFamily.Equals(AddressFamily.InterNetwork));
            //wUser.IpAdress = wHostEntry.AddressList[wHostEntry.AddressList.Length - 1].ToString();
            wUser.IpAdress = ips.ToArray()[ips.Count() - 1].ToString();
            wUser.HostName = Dns.GetHostName();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void OnComboEditValueChanged_ComboEditValueChanged(object sender, EventArgs e)
        {
            String wAuthenticationType = String.Empty;
            try
            {
                if (sender != null)
                    wAuthenticationType = sender.ToString();

                DataTable wDtDominio = Epiron.Bases.ServiceProxy.AccesoConnector.DominioInstancia(appInstanceGuid, wAuthenticationType);
                cmbDomains.Populate(wDtDominio);
                cmbDomains.Enabled = cmbDomains.ContainDomains;

                // Modifico el AuthenticationTypeGUID  según lo elegido
                String sAuthenticationTypeGUID = comboAuthenticationType1.GetAuthenticationTypeGUID();

                if (!String.IsNullOrEmpty(sAuthenticationTypeGUID))
                {
                    authenticationTypeGUID = Guid.Parse(sAuthenticationTypeGUID);
                }

                if (wAuthenticationType == "OWN")
                {
                    domainGuid = Guid.Empty;
                }


            }
            catch (Exception ex)
            {
                this.MessageViewer.Show(ex);
            }
        }

        private void btnAcept_Click(object sender, EventArgs e)
        {
            //Validamos el valor que devuelve AcceptForm para ver si debemos cerrar o no el Formulario de Login
            if (AcceptForm(false))
                this.DialogResult = System.Windows.Forms.DialogResult.OK;


        }

      

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Boolean ValidateValues()
        {
            dxErrorProvider1.ClearErrors(); 
            Boolean isValid= true;
            //Si el password está habilitado lo validamos, de lo contrario sólo validamos el nombre de usuario
            if (txtUserNameLogin.Enabled == true)
            {
                if (String.IsNullOrEmpty(txtUserNameLogin.Text))
                {
                    dxErrorProvider1.SetError(txtUserNameLogin, "Nombre de usuario es requerido");
                    isValid = false;
                }

                if (String.IsNullOrEmpty(txtPassLogin.Text))
                {
                    dxErrorProvider1.SetError(txtUserNameLogin, "Contraseña de usuario es requerido");
                    isValid = false;                    
                }


            }
            return isValid;
        }


        private void ResetGuids()
        {
             appInstanceGuid = Guid.NewGuid();
            //Instancia de Guid de Tipo de Autenticación
             authenticationTypeGUID = Guid.NewGuid();
            //Instancia de Guid de Dominio
             domainGuid = Guid.NewGuid();
            //Guid Intercambio
             interGuid = Guid.NewGuid();
            //Guid Intercambio User
             interTypeAutGuid = Guid.NewGuid();
            //Guid Intercambio User
             interUserGuid = Guid.NewGuid();

           
        }


        public string GetUserNameLogin()
        {
            return wUser.UserNameLogin;
        }

        private void txtUserNameLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                txtPassLogin.Focus();
            }
        }

        private void txtPassLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Al presionar Enter en el Password, realizamos la misma validación que en el click del botón "Aceptar" o "Cambiar Clave"
            if (e.KeyChar == (int)Keys.Enter)
            {
                //Validamos el valor que devuelve AcceptForm para ver si debemos cerrar o no el Formulario de Login
                if (this.AcceptForm(false))
                    this.Close();
            }
        }

        private bool AcceptForm(bool p)
        {
            Boolean isValid = false;
            String eventResponse = String.Empty;
            DataSet dsMenuesUsr = new DataSet();
            DataTable oTableUserMenuPermisos = null;
            try
            {

                ///Validamos si los ErrorProviders tienen error
                if (ValidateValues())
                {

                    wUser.UserNameLogin = txtUserNameLogin.Text;
                    wUser.Password = txtPassLogin.Text;

                    //Muestra mensaje de Espera
                    this.ShowWaitForm();


                    DataTable oTableUserAutenticacion = new System.Data.DataTable();
                    oTableUserAutenticacion = Epiron.Bases.ServiceProxy.AccesoConnector.UserAutenticacion("USER-AUTENTIC", appInstanceGuid, wUser.HostName, wUser.IpAdress, authenticationTypeGUID, wUser.UserNameLogin, wUser.Password, domainGuid, interTypeAutGuid);


                    if (!oTableUserAutenticacion.Columns.Contains("EventResponseId"))
                    {
                        interUserGuid = (Guid)(oTableUserAutenticacion.Rows[0]["GUID"]);

                        //Asigna guid a usuario logueado
                        Guid wUG = new Guid();
                        wUG = Guid.Parse(oTableUserAutenticacion.Rows[0]["UserGuid"].ToString());
                        wUser.AssignGuid(wUG);

                        Guid wGuidMenuPermiso = Guid.NewGuid();

                         oTableUserMenuPermisos = Epiron.Bases.ServiceProxy.AccesoConnector.MenuPermisos("MENU-PERMISOS", appInstanceGuid, domainGuid, wGuidMenuPermiso, interUserGuid);

                        if (oTableUserMenuPermisos.Rows.Count > 0)
                        {
                            String sMenu = String.Empty;
                            if (!oTableUserMenuPermisos.Columns.Contains("EventResponseId"))
                            {
                                sMenu = oTableUserMenuPermisos.Rows[0]["XMLMENU"].ToString();
                                TextReader txtReaderMenu = new StringReader(sMenu);
                                XmlReader readerXmlMenu = new XmlTextReader(txtReaderMenu);
                                dsMenuesUsr.ReadXml(readerXmlMenu);
                                readerXmlMenu.Close();
                                isValid = true;
                            }
                            else
                            {
                                eventResponse = ExtracError(oTableUserMenuPermisos.Rows[0]);
                            }

                        }

                        isValid = true;
                    }
                    else
                    {
                        eventResponse = ExtracError(oTableUserAutenticacion.Rows[0]);

                    }


                }

            }
            catch (Exception ex)
            {
                eventResponse = ex.Message;
            }
            finally
            {    //SetLogging();
                this.CloseWaitForm();
                if (!String.IsNullOrEmpty(eventResponse))
                    this.MessageViewer.Show(eventResponse);
                
            }

            return isValid;
        
        }

        String ExtracError(DataRow dr)
        {

            Int32 sEventResponseId = Convert.ToInt32(dr["EventResponseId"]);
            String sEventResponseText = dr["EventResponseText"].ToString();
            Int32 sEventResponseInternalCode = Convert.ToInt32(dr["EventResponseInternalCode"].ToString());
            //Guid sGuid = Guid.Parse(dr.Table.Rows[i]["Guid"].ToString());
            return String.Concat("Error: \r\nEventResponseId = ", sEventResponseId, "\r\nEventResponseText =", sEventResponseText + "\r\nEventResponseInternalCode = ", sEventResponseInternalCode);
        }

   

        public System.Drawing.Font Auth_Title_Font { get; set; }

        public void InitCredentials(string user, string password)
        {
            txtPassLogin.Text = password;
            txtUserNameLogin.Text = user;
        }

       

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {    //Muestra mensaje de Espera
            this.ShowWaitForm();

        }



      
    }
}