using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Health.Back.BE;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Health.Front.Events;
using Health.BE;

namespace Health.Front.Patients
{
    public partial class uc_PatientMedicaments_Grid : Xtra_UC_Base
    {
        bool includeHistory = false;
        PatientMedicament_ViewBE _PatientMedicament_ViewBE;
        public uc_PatientMedicaments_Grid()
        {
            InitializeComponent();
        }
        public override void Refresh()
        {
            includeHistory = Convert.ToBoolean(this.Tag);
            patientMedicamentViewListBindingSource.DataSource = ServiceCalls.RetrivePatientMedicaments(ServiceCalls.CurrentPatient.PatientId, null, includeHistory);

            if (includeHistory)
            {
                gridView_Medicaments.OptionsCustomization.AllowGroup = true; 
                gridView_Medicaments.OptionsFind.AllowFindPanel = true;
                gridView_Medicaments.OptionsFind.AlwaysVisible = true;
                gridView_Medicaments.OptionsView.ShowGroupedColumns = false;
                gridView_Medicaments.OptionsView.ShowGroupPanel = true;
            }
            gridControl_Medicaments.RefreshDataSource();


        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (_PatientMedicament_ViewBE == null) return;
            using (frmAddMedicament frm = new frmAddMedicament())
            {
                frm.State = Fwk.Bases.EntityUpdateEnum.NONE;
                frm._PatientMedicament = _PatientMedicament_ViewBE;
                frm.Refresh();
                frm.ShowDialog();
            }
        }

        GridHitInfo _HitInfo = null;
        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {

            _HitInfo = gridView_Medicaments.CalcHitInfo(new Point(e.X, e.Y));
            _PatientMedicament_ViewBE = ((PatientMedicament_ViewBE)gridView_Medicaments.GetRow(_HitInfo.RowHandle));

        }

        private void gridView_Medicaments_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            Health.BE.PatientMedicament_ViewBE be = null;
          

            if (e.Column == colYear && e.IsGetData)
            {
                be = (Health.BE.PatientMedicament_ViewBE)e.Row;
                e.Value = be.CreatedDate.Year;
            }

        }


    }
}
