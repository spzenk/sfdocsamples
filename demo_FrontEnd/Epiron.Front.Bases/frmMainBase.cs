using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Epiron.Front.Bases;
using Fwk.Security.Common;
using System.IO;
using Fwk.Exceptions;

namespace Epiron.Gestion
{
    public  partial class frmMainBase : frmBase, Epiron.Front.Bases.IfrmMainBase
    {
        private Xtra_UC_Base _CurrentControl = null;

        public Xtra_UC_Base CurrentControl
        {
            get { return userContrlManager1.CurrentControl; }
            set { userContrlManager1.CurrentControl = value; }
        }
        public frmMainBase()
        {
            InitializeComponent();
          
        }
    

        #region Mannage controls
        
        

        protected void AddContronToPannel(PanelEnum panelEnum, Xtra_UC_Base userControl, object obj)
        {
            userContrlManager1.AddContronToPannel(panelEnum,userControl,obj);
        }

        protected void AddContronToPannel(PanelEnum panelEnum, String assemblyInfo, object obj)
        {
            Fwk.UI.Controls.Menu.Tree.MenuItem item = new Fwk.UI.Controls.Menu.Tree.MenuItem();
            item.AssemblyInfo = assemblyInfo;
            PanelControl wPanelControl = Get_Panel(panelEnum);
            userContrlManager1.AddContronToPannel(wPanelControl, item, obj);
        }

        protected void AddContronToPannel(PanelEnum panelEnum, Fwk.UI.Controls.Menu.Tree.MenuItem item, object obj)
        {
            PanelControl wPanelControl = Get_Panel(panelEnum);
            userContrlManager1.AddContronToPannel(wPanelControl, item, obj);
        }

        protected void AddContronToPannel(DevExpress.XtraEditors.PanelControl panel, Fwk.UI.Controls.Menu.Tree.MenuItem item, object obj)
        {
            userContrlManager1.AddContronToPannel(panel,item,obj);
        }

        public virtual DevExpress.XtraEditors.PanelControl Get_Panel(PanelEnum panelEnum) { throw new  NotImplementedException(); }




        protected void RemoveControlFromPannel(Xtra_UC_Base ctrl)
        {
            userContrlManager1.RemoveControlFromPannel(ctrl);

        }

        //protected Xtra_UC_Base GetControlFromPanel(String controlKey, PanelControl panel)
        //{
        //    Xtra_UC_Base userControl = null;
        //    foreach (System.Windows.Forms.Control c in panel.Controls)
        //    {
        //        if (c.GetType().IsSubclassOf(typeof(Xtra_UC_Base)))
        //        {
        //            if (((Xtra_UC_Base)c).Key.Equals(controlKey))
        //            {
        //                userControl = (Xtra_UC_Base)c;
        //                break;
        //            }
        //        }
        //    }

        //    return userControl;
        //}
        void ctrl_OnExitControlEvent(Xtra_UC_Base sender, PanelControl panel)
        {
            if (panel.Contains(sender))
            {
                userContrlManager1.RemoveControlFromPannel((Xtra_UC_Base)sender);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="luncherControl"></param>
        /// <param name="panelEnum"></param>
        /// <param name="menuItem"></param>
        /// <param name="populateObject"></param>
        protected void ctrl_OnLunchUserControlEvent(Xtra_UC_Base luncherControl, PanelEnum panelEnum, Fwk.UI.Controls.Menu.Tree.MenuItem menuItem, Object populateObject)
        {
           userContrlManager1.AddContronToPannel(panelEnum, menuItem, populateObject);
        }
        #endregion 

      
       
        protected frmDialogBase GetDialog(String assemblyInfo)
        {

            return userContrlManager1.GetDialog(assemblyInfo);
        }

       

       
    }
}