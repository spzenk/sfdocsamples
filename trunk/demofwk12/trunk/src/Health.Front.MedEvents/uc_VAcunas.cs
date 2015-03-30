using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Health.Back.BE;
using Health.BE;

namespace Health.Front.Patients
{
    public partial class uc_Vacunas : Xtra_UC_Base
    {
        PlanVacunacion_FullViewList _PlanVacunacion_FullViewList = null;
        public uc_Vacunas()
        {
            InitializeComponent();
            repositoryItemDateEdit1.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(repositoryItemDateEdit1_EditValueChanging);
            this.ShowClose = true;
            this.ShowSave = false;
        }
        public override void Refresh()
        {
             _PlanVacunacion_FullViewList = ServiceCalls.Patient_GetPlanVacunacion(ServiceCalls.CurrentPatient.PatientId);
            this.planVacunacionFullViewListBindingSource.DataSource = _PlanVacunacion_FullViewList;

            //foreach(string 
            gridControl1.RefreshDataSource();
            base.Refresh();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
           
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            PlanVacunacion_FullViewList list_to_update = null;
            PlanVacunacion_FullViewBE plan = null;
            //Esta columnba puede altearar otras vacunas del plan y ismo grupo
            //gridView1.GetRow(gridView1.FocusedRowHandle);
            if (e.Column == colFechaColocacion)
                list_to_update = new PlanVacunacion_FullViewList();
            {
                plan = ((PlanVacunacion_FullViewBE)gridView1.GetRow(gridView1.FocusedRowHandle));
                var x = _PlanVacunacion_FullViewList.Where<PlanVacunacion_FullViewBE>(p => p.Grupo.Equals(plan.Grupo));
                list_to_update = new PlanVacunacion_FullViewList();
                list_to_update.AddRange(x.ToList<PlanVacunacion_FullViewBE>());
            }
            if (e.Column == colNombreProfesionalQueColoco || (e.Column == colLote))
            {
                list_to_update = new PlanVacunacion_FullViewList();
                plan = ((PlanVacunacion_FullViewBE)gridView1.GetRow(gridView1.FocusedRowHandle));
                list_to_update.Add(plan);
            }
            if (list_to_update != null)
                ServiceCalls.Patient_UpdatePlanVacunacion(list_to_update);
        }

        void repositoryItemDateEdit1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
     
            DateTime date = (DateTime)e.NewValue;
            
            //Obtener vacuna enfocada
            PlanVacunacion_FullViewBE focused_plan = ((PlanVacunacion_FullViewBE)gridView1.GetRow(gridView1.FocusedRowHandle));
            
            focused_plan.FechaColocacion = Fwk.HelperFunctions.DateFunctions.GetStartDateTime(date);

            if (focused_plan.FechaPlaneada.Equals(focused_plan.FechaColocacion))
                  return;

            //Trae todas las del grupo que le siguen
            var grupovacunaslist = _PlanVacunacion_FullViewList.Where<PlanVacunacion_FullViewBE>(
                p => !p.Codigo.Equals(focused_plan.Codigo) 
                    &&
                    p.Grupo.Equals(focused_plan.Grupo)
                    && 
                    p.Cantidad > focused_plan.Cantidad).OrderBy(s => s.Cantidad);

            foreach (PlanVacunacion_FullViewBE pv in grupovacunaslist)
            {
                pv.FechaPlaneada = focused_plan.FechaColocacion.Value.AddDays(pv.Cantidad.Value);
                pv.FechaPlaneada_Alterada = true;
            }
           
            gridView1.RefreshData();

        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
           //PlanVacunacion_FullViewBE plan = (PlanVacunacion_FullViewBE)e.Row;
           //var x = _PlanVacunacion_FullViewList.Where<PlanVacunacion_FullViewBE>(p => p.Grupo.Equals(plan.Grupo));
           //PlanVacunacion_FullViewList list_to_update = new PlanVacunacion_FullViewList();
           //list_to_update.AddRange(x.ToList<PlanVacunacion_FullViewBE>());
           //Controller.Patient_UpdatePlanVacunacion(list_to_update);

        }

    }
}
