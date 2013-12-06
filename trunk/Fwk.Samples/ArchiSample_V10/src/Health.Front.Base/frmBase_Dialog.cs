using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Fwk.UI.Forms;
using Fwk.UI.Common;



namespace Health.Front
{
    public partial class frmBase_Dialog : Fwk.UI.Forms.FormDialogBase
    {
       
        public Fwk.Bases.EntityUpdateEnum State = Fwk.Bases.EntityUpdateEnum.NEW;
        public frmBase_Dialog()
        {
            InitializeComponent();

        }
        

      

        private void frmBase_FormClosing(object sender, FormClosingEventArgs e)
        {

            //if (typeof(frmMainRibon) != this.GetType())
            if (this.GetType().Name.Equals("frmMainRibon"))
                this.Dispose();

            
        }

        internal void SetDialogsToDefault()
        {
            // 
            // MessageViewer
            // 
            this.MessageViewer.MessageBoxButtons = MessageBoxButtons.OK ;
            this.MessageViewer.MessageBoxIcon = Fwk.UI.Common.MessageBoxIcon.Information;
        }

        private void frmBase_Dialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                using (WaitCursorHelper frm = new WaitCursorHelper(this))
                {
                    this.Refresh();
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}