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
using Health.Front.Profecional;
using Health.Front.Scheduler;

namespace Health.Front
{
    public partial class frmMainRibon : RibbonForm
    {
        internal Dictionary<Type, Fwk.UI.Forms.FormMDIChildBase> FormsList = new Dictionary<Type,FormMDIChildBase> ();
        static FwkSimpleStorageBase<ClientUserSettings> storage = new FwkSimpleStorageBase<ClientUserSettings>();

        #region General functions
        public frmMainRibon()
        {
            InitializeComponent();
            Application.CurrentCulture = new CultureInfo("es-AR");

            //IServiceWrapper iwraper = WrapperFactory.GetWrapper("health_sec");
            //if (iwraper != null)
            //{
            //    System.Net.NetworkCredential cr = new System.Net.NetworkCredential(@"santana\moviedo", "3");
            //    //System.Net.WebProxy pr = new System.Net.WebProxy("127.0.1.2", 80);
            //    ((WebServiceWrapper)iwraper).Credentials = cr;
            //}
            

        }

       


        /// <summary>
        /// Cargamos el Formulario de Autenticación
        /// </summary>
        private void LoadAuthenticationForm()
        {
            
            FRM_AuthenticationForm_ASPNet wAuthForm = new FRM_AuthenticationForm_ASPNet("health_sec_ws");

            wAuthForm.Auth_Title_Image = null;
            wAuthForm.Auth_Title_Text = "Autenticación";
            wAuthForm.InitCredentials(storage.StorageObject.User, storage.StorageObject.Password);
        
            if (wAuthForm.ShowDialog() == DialogResult.OK)
            {
               storage.StorageObject.User = FormBase.Principal.Identity.Name;
                storage.StorageObject.Password = wAuthForm.Password;
                storage.Save();
            }
            else
                this.Close();

        }

        Fwk.UI.Forms.FormMDIChildBase childForm;
        void addChild<T>(bool refresh) where T : Fwk.UI.Forms.FormMDIChildBase
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
            this.ActiveMdiChild.Dock = DockStyle.Fill;
        }
      

        void childForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormsList.Remove(sender.GetType());
        
        }

        private void frmMainRibon_Load(object sender, EventArgs e)
        {
            storage.Load();
            if (storage.StorageObject == null)
            {
                storage.StorageObject = new ClientUserSettings();
                storage.Save();
            }
            LoadAuthenticationForm();
        }

       
        #endregion

       
        private void iNuevoMedico_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //using (FrmABMProfecional frm = new FrmABMProfecional())
            //{
            //    frm.Refresh();
            //    frm.ShowDialog();
            //}
            using (frmProfecionalCard frm = new frmProfecionalCard( EntityUpdateEnum.NEW))
            {
                frm.Refresh();
                frm.ShowDialog();
            }
        }

        private void iCrearPaciente_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FrmABMPaciente frm = new FrmABMPaciente())
            {
                //frm.Refresh();
                frm.ShowDialog();
            }
        }

        private void iVademecum_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //frmWebBrowser frm = new frmWebBrowser();
            //frm.Url = "http://www.prvademecum.com/default.asp";
            addChild<frmWebBrowser>(true);
        }

        private void iNuevaAtencion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (FormsList.ContainsKey(typeof(frmPacienteAtencion)))
            {
                addChild<frmPacienteAtencion>(true);
                return;
            }

            ///Busca paciente 
            using (frmGridPacientes form = new frmGridPacientes())
            {
                form.State = EntityUpdateEnum.NONE;
                form.Refresh();
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Controller.CurrentPaciente = form.SelectedPacienteBE;
                    addChild<frmPacienteAtencion>(true);
                }

            }
        }

        private void iBuscar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            ///Busca paciente 
            using (frmGridPacientes form = new frmGridPacientes())
            {
                form.State = EntityUpdateEnum.UPDATED;
                form.Refresh();form.ShowDialog();
                //if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                //{
                    //Controller.CurrentPaciente = form.SelectedPacienteBE;
                    //using (FrmABMPaciente frm = new FrmABMPaciente( EntityUpdateEnum.UPDATED ))
                    //{
                  
                    //    frm.ShowDialog();
                    //}
                //}

            }
        }

        private void iVademecumImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            using (frmVademecum frm = new frmVademecum())
            {
                //frm.Refresh();
                frm.ShowDialog();
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!FormsList.ContainsKey(typeof(frmProfecionales_Grid)))
            {
                addChild<frmProfecionales_Grid>(true);
                return;
            }
        }

        private void iAgenda_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!FormsList.ContainsKey(typeof(frmShiftsMannager)))
            {
                addChild<frmShiftsMannager>(true);
                return;
            }
        }

     

       
    }
}
