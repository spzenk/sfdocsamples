using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.UI.Common;

namespace Health.Front.profesional
{
    public partial class frmProfesionales_Grid : Fwk.UI.Forms.FormMDIChildBase
    {
        public frmProfesionales_Grid()
        {
            InitializeComponent();
        }
        public override void Refresh()
        {
            using (WaitCursorHelper fr = new WaitCursorHelper(this))
            {
                uc_Profesionales_Grid1.Refresh();
            }
            base.Refresh();
        }

        private void uc_Profesionales_Grid1_uc_ProfesionalesGrid_DoubleClick(object sender, EventArgs e)
        {

        }

        private void frmProfesionales_Grid_KeyDown(object sender, KeyEventArgs e)
        {

            Refresh();

        }
    }
}
