using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Health.Back.BE;
using Health.Entities;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Health.BE;
using DevExpress.XtraEditors.Controls;
using Health.BE.Enums;

namespace Health.Front.Events
{
    
    [ToolboxItem(true)]
    public partial class uc_event_view : Xtra_UC_Base
    {
  
        PatientMedicament_ViewBE Selected_PatientMedicament = null;
        MedicalEventBE _Evento;
        public int MedicalEventId = -1;
        public uc_event_view()
        {
            InitializeComponent();
            uC_EventDetailsGrid_Diagnosis.DetailType = MedicalEventDetailType.CEI10_Diagnosis;
            uC_EventDetailsGrid_MetComplementario.DetailType = MedicalEventDetailType.Metodo_Complementarios;
            ParametroList items = new ParametroList();

            items.Add(new ParametroBE { Nombre = Enum.GetName(typeof(CommonValuesEnum), CommonValuesEnum.Ninguno), IdParametro = (int)CommonValuesEnum.Ninguno });
            items.Add(new ParametroBE(870, "Relevante actual"));
            items.Add(new ParametroBE(871, "Relevante Crónico"));
            items.Add(new ParametroBE(872, "Presuntivo"));

            parametroBEBindingSource.DataSource = items;

            
        }

        public override void Populate(object filter)
        {
            int index = -1;
            _Evento = ServiceCalls.GetMedicalEvent(MedicalEventId);
            txtEvolution.Text = _Evento.Evolucion;
            txtMotivo.Text = _Evento.Motivo;
          
            lblProfesional.Text = String.Concat(_Evento.NombreApellidoProfesional, "  (", _Evento.NombreEspesialidad, ")");


            patientMedicamentViewListBindingSource.DataSource = _Evento.PatientMedicaments;
            gridView_Medicaments.RefreshData();

            if (_Evento.IdTipoConsulta.HasValue)
            {
                 index = cmbTipoConsulta.Properties.GetDataSourceRowIndex("IdParametro", _Evento.IdTipoConsulta);
                cmbTipoConsulta.ItemIndex = index;
                cmbTipoConsulta.Refresh();
            }
            _Evento.DetailView_Diagnosis = _Evento.MedicalEventDetail_ViewList.Get_Diagnosis();
            _Evento.DetailView_MetodosComplementarios = _Evento.MedicalEventDetail_ViewList.Get_Metodo_Complementarios();
            uC_EventDetailsGrid_Diagnosis.Populate(_Evento);
            uC_EventDetailsGrid_MetComplementario.Populate(_Evento);
            base.Populate(filter);
        }

        public override void Refresh()
        {
            
            //this.cEI10ComboBindingSource.DataSource = Controller.CEI_10ComboList;
            //var cei10 = Controller.CEI_10ComboList.Where(p => p.Code.Equals(_Evento.CEI10_Code));
            
            

            cmbTipoConsulta.Properties.DataSource = ServiceCalls.TipoEventoMedicoList;
            

            base.Refresh();
        }


        private void gridView_Medicaments_DoubleClick(object sender, EventArgs e)
        {
            if (Selected_PatientMedicament == null) return;
            using (frmQueryUpdateMedicament frm = new frmQueryUpdateMedicament())
            {
                frm.State = this.State;
                frm.PatientMedicament_Original = Selected_PatientMedicament;
                frm.currentMedicalEventId = _Evento.MedicalEventId;
                frm.Refresh();
            }
        }
        GridHitInfo _HitInfo = null;
        private void gridView_Medicaments_MouseDown(object sender, MouseEventArgs e)
        {
            _HitInfo = gridView_Medicaments.CalcHitInfo(new Point(e.X, e.Y));
            Selected_PatientMedicament = ((PatientMedicament_ViewBE)gridView_Medicaments.GetRow(_HitInfo.RowHandle));
        }

        private void btnAddMedicamento_Click(object sender, EventArgs e)
        {

        }

        private void gridControl_Medicaments_Click(object sender, EventArgs e)
        {

        }
    }
}
