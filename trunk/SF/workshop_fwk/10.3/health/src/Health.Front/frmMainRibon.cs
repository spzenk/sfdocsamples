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
using System.Reflection;
using Microsoft.Practices.EnterpriseLibrary.Security;
using Fwk.Security;
using DevExpress.XtraBars;

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
    
            this.Text = string.Concat(Assembly.GetExecutingAssembly().GetName().ProcessorArchitecture, " version ", Assembly.GetExecutingAssembly().GetName().Version.ToString());


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

                
            


            //LoadAuthenticationForm();
  
        }

     
        #endregion

       
      

        private void iCrearPatient_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FrmABMPatient frm = new FrmABMPatient())
            {
                //frm.Refresh();
                frm.ShowDialog();
            }
        }

    

    

        private void iBuscar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            
        }

     

      

       


     

     
    }

        
}
