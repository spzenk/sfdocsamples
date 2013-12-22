using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Fwk.UI.Forms;
using System.Globalization;
using Fwk.UI.Common;
using Fwk.Bases;
using Fwk.UI.Security.Controls;
using System.Security.Principal;
using Fwk.Caching;
using Fwk.Bases.Connector;
using DevExpress.XtraBars.Ribbon;
using Fwk.UI.Controls.Menu.Tree;
using Health.Front.profesional;
using Health.Front.Scheduler;
using Health.Isvc.GetProfesional;
using Fwk.UI.Controller;
using System.Reflection;
using Fwk.Security;
using DevExpress.XtraBars;
using Health.Front.Environment;
using Health.BE;
using Fwk.UI.Controls;


namespace Health.Front
{
    public partial class frmMainRibon : RibbonForm
    {
        internal Dictionary<Type, Fwk.UI.Forms.FormMDIChildBase> FormsList = new Dictionary<Type,FormMDIChildBase> ();
        static FwkSimpleStorageBase<ClientUserSettings> storage = new FwkSimpleStorageBase<ClientUserSettings>();
        ExceptionViewComponent exceptionViewer;
        #region General functions
        public frmMainRibon()
        {
            InitializeComponent();
            exceptionViewer = new ExceptionViewComponent();
            Application.CurrentCulture = new CultureInfo("es-AR");
            Controller.OnControlerException += new EventHandler(Controller_OnControlerException);
            Controller.PopulateAsync();
            this.Text = string.Concat(Health.Front.Properties.Resources.Health32Name, " version ", Assembly.GetExecutingAssembly().GetName().Version.ToString());


            //WrapperFactory.GetWrapper("").DefaultCulture = "xxxx";
            //IServiceWrapper w1 = WrapperFactory.GetWrapper("");
            //WrapperFactory.ChangeDefaultProvider("health_ws");
            //IServiceWrapper w2 =WrapperFactory.GetWrapper("");
            //IServiceWrapper iwraper = WrapperFactory.GetWrapper("health_sec");
            //if (iwraper != null)
            //{
            //    System.Net.NetworkCredential cr = new System.Net.NetworkCredential(@"santana\moviedo", "3");
            //    //System.Net.WebProxy pr = new System.Net.WebProxy("127.0.1.2", 80);
            //    ((WebServiceWrapper)iwraper).Credentials = cr;
            //}
            //internal static string currentCobfigProvider = "Prov_A";
            //Fwk.Configuration.ConfigurationManager.GetProperty(currentCobfigProvider, "1");
            //      Fwk.Configuration.ConfigurationManager.GetProperty("1");
            //Fwk.Configuration.ConfigurationManager.ConfigProvider.DefaultProviderName = "ppe";
         
        }

        void Controller_OnControlerException(object sender, EventArgs e)
        {
            Fwk.UI.Controls.ExceptionView.Show((Exception)sender, "Error de inicialización");
        }

       


       
        Fwk.UI.Forms.FormMDIChildBase childForm;
        void addChild<T>(bool refresh,object[] parameters) where T : Fwk.UI.Forms.FormMDIChildBase
        {
            //Si hiso click en un boton que hace llamada a un formulario activo no hacer nada
            if (childForm != null && !childForm.IsDisposed)
                if (childForm.GetType() == typeof(T))
                    return;
                else
                    childForm.SendToBack();//Oculta el anterior

            if (FormsList.ContainsKey(typeof(T)))
            {
                childForm = FormsList[typeof(T)];

                childForm.WindowState = FormWindowState.Maximized;
                this.ActivateMdiChild(childForm);
                this.BringToFront();
                return;
            }
            if (parameters!=null)
            
                childForm = Fwk.HelperFunctions.ReflectionFunctions.CreateInstance<T>(parameters);
            else
                childForm = Fwk.HelperFunctions.ReflectionFunctions.CreateInstance<T>();
            childForm.FormClosing += new FormClosingEventHandler(childForm_FormClosing);
           
            childForm.WindowState = FormWindowState.Maximized;
            childForm.MinimizeBox = false;
            childForm.MaximizeBox = false;
            childForm.ControlBox = true;
         
            childForm.MdiParent = this;

            this.FormsList.Add(typeof(T), childForm);
            if (refresh)
                childForm.Refresh();
            childForm.Show();
        }
        private void frmMainRibon_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild!=null)
                this.ActiveMdiChild.Dock = DockStyle.Fill;
        }
      

        void childForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FormsList.ContainsKey(typeof(frmPatientAtencion)))
            {
                frmPatientAtencion childForm = (frmPatientAtencion)FormsList[typeof(frmPatientAtencion)];
                DialogResult res = childForm.CheckCloseForm() ;
                if (res == System.Windows.Forms.DialogResult.No || res== System.Windows.Forms.DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
          
            }
            FormsList.Remove(sender.GetType());
        }

        private void frmMainRibon_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(10 * 1000);
            storage.Load();
            if (storage.StorageObject == null)
            {
                storage.StorageObject = new ClientUserSettings();
                storage.Save();
            }

            LoadAuthenticationForm();

            

            foreach (BarItem barItem in this.ribbonControl1.Items)
            {
                CheckRule(barItem);
            }
            
 
            
        }

        void CheckRule(BarItem i)
        {
            DevExpress.Utils.SuperToolTip superToolTip1 = null;
            DevExpress.Utils.ToolTipItem toolTipItem1 = null;
            if (i.Tag != null)
                try
                {
                    i.Enabled = FormBase.CheckRule(i.Tag.ToString());
                }
                catch
                {

                    superToolTip1 = new DevExpress.Utils.SuperToolTip();
                    toolTipItem1 = new DevExpress.Utils.ToolTipItem();
                    toolTipItem1.Text = string.Concat("Error regla de seguridad : ", i.Tag.ToString());
                    superToolTip1.Items.Add(toolTipItem1);
                    i.Enabled = false;
                    i.SuperTip = superToolTip1;
                    i.AppearanceDisabled.ForeColor = Color.Red;
                }
        }

        bool LoadRegisterForm()
        {
            using(frmRegisterHealth frm = new frmRegisterHealth(storage))
            {
                frm.ShowDialog();

               return frm.RegisterOk;

            }
        }
        #endregion

       
        private void iNuevoMedico_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //using (FrmABMProfesional frm = new FrmABMProfesional())
            //{
            //    frm.Refresh();
            //    frm.ShowDialog();
            //}
            using (frmProfesionalCard frm = new frmProfesionalCard(EntityUpdateEnum.NEW,-1))
            {
                frm.ShowDialog();
            }
        }

        private void iCrearPatient_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FrmABMPatient frm = new FrmABMPatient())
            {
                //frm.Refresh();
                frm.ShowDialog();
            }
        }

        private void iVademecum_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmWebBrowser frm = new frmWebBrowser();
            frm.Url = "http://www.prvademecum.com/default.asp";
            
            addChild<frmWebBrowser>(true,null);
        }

        private void iNuevaAtencion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (FormsList.ContainsKey(typeof(frmPatientAtencion)))
            {
                addChild<frmPatientAtencion>(true, null);
                return;
            }

            ///Busca Patient 
            using (frmGridPatients form = new frmGridPatients())
            {
                form.State = EntityUpdateEnum.NONE;
                form.Refresh();
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (NotAppoiment() == System.Windows.Forms.DialogResult.Yes)
                    {
                        //Controller.CurrentPatient = form.Patient;
                        Controller.CurrentPatient = form.SelectedPatientBE;
                        addChild<frmPatientAtencion>(true, null);
                    }
                }

            }
        }

        DialogResult NotAppoiment()
        {
            return MessageBox.Show("Está ingresando a la historia clinica de un pasiente sin turno asignado\r\nTodos las acciones que realice seran registradas \r\n Esta seguro de realizar esta operación?", "Atención de pacientes", MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question);
        }

        private void iBuscar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            ///Busca Patient 
            using (frmGridPatients form = new frmGridPatients())
            {
                form.State = EntityUpdateEnum.UPDATED;
                form.Refresh();form.ShowDialog();
                //if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                //{
                    //Controller.CurrentPatient = form.SelectedPatientBE;
                    //using (FrmABMPatient frm = new FrmABMPatient( EntityUpdateEnum.UPDATED ))
                    //{
                  
                    //    frm.ShowDialog();
                    //}
                //}
            }
        }

     

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!FormsList.ContainsKey(typeof(frmProfesionales_Grid)))
            {
                addChild<frmProfesionales_Grid>(true, null);
                return;
            }
        }

        private void iAgenda_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (FormsList.ContainsKey(typeof(frmPatientAtencion)))
            {
                if (NotAppoiment() == System.Windows.Forms.DialogResult.Yes)
                {
                    addChild<frmPatientAtencion>(true, null);
                    return;
                }
            }

           
            ///Busca turnos de un profesional 
            using (frm_Profesional_Shifts form = new frm_Profesional_Shifts(Controller.CurrentProfesional))
            {
                form.State = EntityUpdateEnum.NONE;
                form.Refresh();
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Controller.CurrentPatient = form.Patient;

                    addChild<frmPatientAtencion>(true, new Object[] { form.Appointment});
                }

            }
        }

        private void iAgendas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!FormsList.ContainsKey(typeof(frmMain_ShiftsMannager)))
            {
                addChild<frmMain_ShiftsMannager>(true,null);
                return;
            }
        }

        private void iCEI_10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (frm_cei10 form = new frm_cei10())
            {
                form.Refresh();
                form.ShowDialog();
            }
        }


        internal static Fwk.Security.IAuthorizationProvider RuleProvider=null;
        #region Authorization Factory
        /// <summary>
        /// Cargamos el Formulario de Autenticación
        /// </summary>
        private void LoadAuthenticationForm()
        {
            SecurityController.WrapperSecurityProvider = System.Configuration.ConfigurationManager.AppSettings["WrapperSecurityProvider"].ToString();
            Health.Front.Environment.FRM_AuthenticationForm_ASPNet wAuthForm = new Health.Front.Environment.FRM_AuthenticationForm_ASPNet();
            wAuthForm.Text = string.Concat("Iniciar sesión ",Health.Front.Properties.Resources.Health32Name);
            wAuthForm.Auth_Title_Image = Health.Front.Properties.Resources.Group_Security;
            wAuthForm.Auth_Title_Text = "Autenticación";
            wAuthForm.InitCredentials(storage);
            
            if (wAuthForm.ShowDialog() == DialogResult.OK)
            {
                storage.StorageObject.User = FormBase.Principal.Identity.Name;
                storage.StorageObject.Password = wAuthForm.Password;
                //GetProfesionalRes res = Controller.GetProfesional(null, false, false, (Guid)frmBase_TabForm.IndentityUserInfo.ProviderId);

                //Controller.CurrentProfesional = res.BusinessData.profesional;

                storage.StorageObject.HealthInstitutionId = Controller.CurrentHealthInstitution.HealthInstitutionId;
                storage.StorageObject.HealthInstitutionName = Controller.CurrentHealthInstitution.RazonSocial;
                this.iHealtInst_Info.Caption = string.Concat("Inicio sesion en: ", Controller.CurrentHealthInstitution.RazonSocial);
                this.statusBarItem_Usuario.Caption = String.Concat(this.statusBarItem_Usuario.Caption, " ", Controller.CurrentProfesional.Persona.ApellidoNombre);
                this.statusBarItem_Especialidad.Caption = String.Concat(this.statusBarItem_Especialidad.Caption, " ", Controller.CurrentProfesional.NombreEspecialidad);
                storage.Save();
            }
            else
                this.Close();
             
          

        }



        #endregion

        private void iSendMail_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void btnAboutHealth_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void btnHealtInst_Info_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (frmHealthInst_Info frm = new frmHealthInst_Info())
            {
                frm.ShowDialog();
            }
        }

        private void btnClearCache_ItemClick(object sender, ItemClickEventArgs e)
        {
            storage.Clear();
        }
    }

        
}
