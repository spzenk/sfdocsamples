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
using Health.Front.Patients;
using Health.BE;

namespace Health.Front.Scheduler
{
    public partial class frmMain_ShiftsMannager : frmBase_Child
    {
        Control currentControl;
        public frmMain_ShiftsMannager()
        {
            InitializeComponent();
            currentControl = uc_shedule_profesional_timeline1;

        }
        public override void Refresh()
        {
            uc_shedule_profesional_timeline1.SetDateChanged(monthCalendar1.SelectionStart);
            profesionalFullViewBEBindingSource.DataSource = ServiceCalls.RetriveProfesionales(null, null, ServiceCalls.CurrentHealthInstitution.HealthInstitutionId);
            gridView2.RefreshData();
            gridControl2.RefreshDataSource();

            base.Refresh();
        }
        GridHitInfo _HitInfo = null;
        private void gridView2_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button != MouseButtons.Left) return;
            _HitInfo = gridView2.CalcHitInfo(new Point(e.X, e.Y));
            uc_shedule_profesional_timeline1.SelectedProfesionalBE = ((Profesional_FullViewBE)gridView2.GetRow(_HitInfo.RowHandle));

            uc_shedule_profesional_timeline1.Set_ProfesionalChanged();


        }

        private void gridView2_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column == colProfesional && e.IsGetData)
            {
                e.Value = ((Health.BE.Profesional_FullViewBE)(e.Row)).ApellidoNombre.Trim();
            }
        }

        private void frmShiftsMannager_Load(object sender, EventArgs e)
        {
            uc_shedule_profesional_timeline1.Refresh();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (currentControl == uc_shedule_profesional_timeline1)
            {
                if (gridView2.RowCount == 0)
                    return;
                if (uc_shedule_profesional_timeline1.SelectedProfesionalBE == null)
                    uc_shedule_profesional_timeline1.SelectedProfesionalBE = ((Profesional_FullViewBE)gridView2.GetRow(0));

                uc_shedule_profesional_timeline1.SetDateChanged(e.Start);
            }
            if (currentControl == uc_AllShiftGrid)
            {
                uc_AllShiftGrid.SetDateChanged(e.Start);
            }

        }

        void AddContronToPannel(Xtra_UC_Base ctrl, object obj,bool repopulate= false)
        {

            if (!this.splitContainerControl1.Panel2.Contains(ctrl))
            {

                ctrl.Populate(obj);
                this.splitContainerControl1.Panel2.Controls.Add(ctrl);
                ctrl.Location = new System.Drawing.Point(0, 0);
                ctrl.Dock = System.Windows.Forms.DockStyle.Fill;
            }
            else
            {
                if (repopulate)
                    ctrl.Populate(obj);
            }
            ctrl.BringToFront();
            ctrl.Refresh();
            currentControl = ctrl;
        }

        private void uc_shedule_profesional_timeline1_Load(object sender, EventArgs e)
        {

        }
        uc_AllShiftGrid uc_AllShiftGrid = null;
        private void iTurnosPorPatient_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (uc_AllShiftGrid == null) uc_AllShiftGrid = new uc_AllShiftGrid();
            AddContronToPannel(uc_AllShiftGrid, null);
        }

        private void navBarGroup1_ItemChanged(object sender, EventArgs e)
        {
            AddContronToPannel(uc_shedule_profesional_timeline1, null);
        }
        uc_PatientsGrid uc_PatientsGrid1 = null;
        private void iFindPatients_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (uc_PatientsGrid1 == null)
            {
                uc_PatientsGrid1 = new uc_PatientsGrid();
                this.uc_PatientsGrid1.OnDoubleClickEvent += new System.EventHandler(this.uc_PatientsGrid1_OnDoubleClickEvent);

            }
            AddContronToPannel(uc_PatientsGrid1, null);
        }



        uc_PatientAppoiments uc_PatientAppoiments1 = null;
        private void uc_PatientsGrid1_OnDoubleClickEvent(object sender, EventArgs e)
        {
            //Al seleccionar un Patient se deben mostrar todos sus turnos otorgados y se debe dar posibilidad de cargar nuevo turno 
            if (uc_PatientsGrid1.SelectedPatientBE == null) return;
            if (uc_PatientAppoiments1 == null)
            {
                uc_PatientAppoiments1 = new uc_PatientAppoiments();
            }
            AddContronToPannel(uc_PatientAppoiments1, uc_PatientsGrid1.SelectedPatientBE,true);
        }
    }
}
