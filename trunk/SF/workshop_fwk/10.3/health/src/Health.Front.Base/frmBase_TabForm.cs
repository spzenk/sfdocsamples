using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Fwk.UI.Forms;



namespace Health.Front
{
    public partial class frmBase_TabForm : Fwk.UI.Forms.FormBase
    {
        public Fwk.Bases.EntityUpdateEnum State = Fwk.Bases.EntityUpdateEnum.NEW;
        Xtra_UC_Base _CurrentControl = null;

        public Xtra_UC_Base CurrentControl
        {
            get { return _CurrentControl; }
            set { _CurrentControl = value; }
        }
        

        public frmBase_TabForm()
        {
            InitializeComponent();

        }
        private TabControl tabCtrl;
        private TabPage tabPag;
        public TabPage TabPag
        {
            get
            {
                return tabPag;
            }
            set
            {
                tabPag = value;
            }
        }

        public TabControl TabCtrl
        {
            set
            {
                tabCtrl = value;
            }
        }

        private void frmBasegastos_Activated(object sender, EventArgs e)
        {
            tabCtrl.SelectedTab = tabPag;

            //if (!tabCtrl.Visible)
            //{
            //    tabCtrl.Visible = true;
            //}

        }

        private void frmBasegastos_FormClosing(object sender, FormClosingEventArgs e)
        {

            //if (typeof(frmMainRibon) != this.GetType())
            //{
            //    ((frmMainRibon)this.ParentForm).FormsList.Remove(this.GetType());
            //    this.tabPag.Dispose();
            //}

            
        }

        internal void SetDialogsToDefault()
        {
            // 
            // MessageViewer
            // 
            this.MessageViewer.MessageBoxButtons = MessageBoxButtons.OK ;
            this.MessageViewer.MessageBoxIcon = Fwk.UI.Common.MessageBoxIcon.Information;
        }
    }
}