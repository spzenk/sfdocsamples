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

namespace Health.Front.profesional
{

    public partial class uc_Profesionales_Grid : DevExpress.XtraEditors.XtraUserControl
    {
        public BE.Profesional_FullViewBE SelectedProfesionalBE { get; set; }
        public event EventHandler uc_ProfesionalesGrid_DoubleClick;
        public uc_Profesionales_Grid()
        {
            InitializeComponent();
        }
        public override void Refresh()
        {
            profesionalFullViewBEBindingSource.DataSource = Controller.RetriveProfesionales(null, null, Controller.CurrentHealthInstitution.HealthInstitutionId);
            gridView1.RefreshData();
            grdPersonas.RefreshDataSource();

            base.Refresh();
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedProfesionalBE == null) return;
            using (frmProfesionalCard frm = new frmProfesionalCard(Fwk.Bases.EntityUpdateEnum.UPDATED, SelectedProfesionalBE.IdProfesional))
            {
                frm.ShowDialog();
                Refresh();
            }
        }

        GridHitInfo _HitInfo = null;
        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {

            //  if (e.Button != MouseButtons.Right) return;
            _HitInfo = gridView1.CalcHitInfo(new Point(e.X, e.Y));
            SelectedProfesionalBE = ((Profesional_FullViewBE)gridView1.GetRow(_HitInfo.RowHandle));
            if (uc_ProfesionalesGrid_DoubleClick != null)
                uc_ProfesionalesGrid_DoubleClick(this, new EventArgs());
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column == colProfesional && e.IsGetData)
            {
                
                e.Value = String.Concat(((Health.BE.Profesional_FullViewBE)(e.Row)).Apellido.Trim(), ", ", ((Health.BE.Profesional_FullViewBE)(e.Row)).Nombre.Trim());
            }
        }


    }
}
