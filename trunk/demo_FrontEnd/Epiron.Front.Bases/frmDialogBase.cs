using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Fwk.UI.Common;

namespace Epiron.Front.Bases
{
    public partial class frmDialogBase : Epiron.Front.Bases.frmBase
    {
        public frmDialogBase()
        {
            InitializeComponent();
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.F5)
            {
                using (WaitCursorHelper frm = new WaitCursorHelper(this))
                {
                    this.Refresh();
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                this.Close();
            }

        }
    }
}