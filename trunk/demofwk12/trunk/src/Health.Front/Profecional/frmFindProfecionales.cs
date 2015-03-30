using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Health.Back.BE;
using Health.BE;

namespace Health.Front
{
    public partial class frmFindProfesionales : frmBase_Dialog
    {
        public Profesional_FullViewBE SelectedProfesionalBE { get; set; }
        public frmFindProfesionales()
        {
            InitializeComponent();
        }
        public override void Refresh()
        {

            uc_Profesionales_Grid1.Refresh();
            base.Refresh();
        }

        private void uc_Profesionales_Grid1_uc_ProfesionalesGrid_DoubleClick(object sender, EventArgs e)
        {
            SelectedProfesionalBE = uc_Profesionales_Grid1.SelectedProfesionalBE;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void aceptCancelButtonBar1_ClickOkCancelEvent(object sender, DialogResult result)
        {
          SelectedProfesionalBE=  uc_Profesionales_Grid1.SelectedProfesionalBE;
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                if (uc_Profesionales_Grid1.SelectedProfesionalBE == null)
                {
                    MessageViewer.Show("Seleccione algun profesional o precione ESC");
                    return;
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            this.Close();
        }

      
       
        
    }
}