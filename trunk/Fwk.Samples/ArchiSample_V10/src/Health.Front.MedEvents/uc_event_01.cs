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
using Health.BE.Enums;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;

namespace Health.Front.Events
{
    //Controller.CEI_10ComboList.Where(p => p.Code.Equals(_Evento.CEI10_Code));
    public partial class uc_event_01 : Xtra_UC_Base
    {
        MedicalEventBE _Evento;
        GridHitInfo _HitInfo = null;

        PatientMedicament_ViewBE Selected_PatientMedicament = null;
        //MedicalEventDetail_ViewList _MedicalEventDetails_From_OtherEvents = null;
       public uc_event_01()
        {

            InitializeComponent();
            uC_EventDetailsGrid_Diagnosis.DetailType = MedicalEventDetailType.CEI10_Diagnosis;
            uC_EventDetailsGrid_MetComplementario.DetailType = MedicalEventDetailType.Metodo_Complementarios;
            this.ShowClose = true;
            this.ShowSave = true;
            colEnabled.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value;
            colEnabled.FilterInfo = new ColumnFilterInfo("[Enabled] = true");

            ParametroList items = new ParametroList();

            items.Add(new ParametroBE { Nombre = Enum.GetName(typeof(CommonValuesEnum), CommonValuesEnum.Ninguno), IdParametro = (int)CommonValuesEnum.Ninguno });
            items.Add(new ParametroBE(870, "Enfermedad relevante"));
            items.Add(new ParametroBE(871, "Enfermedad crónica"));
            items.Add(new ParametroBE(872, "Dx quirurjicos "));

            parametroBEBindingSource.DataSource = items;
            
        }

        public override void Populate(object filter)
        {
            _Evento = frmPatientAtencion.GetInstance(this).MedicalEvent;

            cmbTipoConsulta.Properties.DataSource = Controller.TipoEventoMedicoList;
            cmbTipoConsulta.Refresh();

            //this.cEI10ComboBindingSource.DataSource = Controller.CEI_10ComboList;

            //this.pMOFileListBindingSource.DataSource = Controller.PMOFileList.Where(p => 
            //    (p.Type.Equals((int)PMOEnum.Diagnostico_Imagenes) ||
            //    p.Type.Equals((int)PMOEnum.Odontológicas) ||
            //    p.Type.Equals((int)PMOEnum.Diagnostico_Analisis_Clinico)) && 
            //    p.HasChild.Equals(false)).OrderBy(p => p.Id);

            //var pmo = Controller.PMOFileList.Where(p =>
            //      (p.Type.Equals((int)PMOEnum.Diagnostico_Imagenes) ||
            //      p.Type.Equals((int)PMOEnum.Odontológicas) ||
            //      p.Type.Equals((int)PMOEnum.Diagnostico_Analisis_Clinico)) &&
            //      p.HasChild.Equals(false)).OrderBy(p => p.Id);

            //Int32 c = pmo.Count();
            //this.pMOFileListBindingSource.DataSource = pmo;


            this.pMOFileListBindingSource_Quirurgico.DataSource = Controller.PMOFileList.Where(p =>
                p.Type.Equals((int)PMOEnum.Quirurgicas) && p.HasChild.Equals(false)).OrderBy(p => p.Id);


            _Evento.PatientMedicaments = Controller.RetrivePatientMedicaments(Controller.CurrentPatient.PatientId, null);

            //Nunca traera del evento _Event dado que es recientemente creado y no posee aun Detalles
           // _Evento.MedicalEventDetail_ViewList = Controller.RetriveMedicalEventDetails(Controller.CurrentPatient.PatientId, null);
            if (_Evento.DetailView_Diagnosis == null)
                _Evento.DetailView_Diagnosis = new MedicalEventDetail_ViewList();

            if (_Evento.DetailView_MetodosComplementarios == null)
                _Evento.DetailView_MetodosComplementarios = new MedicalEventDetail_ViewList();

            //Medicamentos
            patientMedicamentViewListBindingSource.DataSource = _Evento.PatientMedicaments;
            gridView_Medicaments.RefreshData();

            //Diagnosis
            uC_EventDetailsGrid_Diagnosis.Populate(_Evento);
            //MetComplementario
            uC_EventDetailsGrid_MetComplementario.Populate(_Evento);

            base.Populate(filter);
        }
        
       

        /// <summary>
        /// 
        /// </summary>
        public override void AceptChanges(bool this_will_close)
        {
            //_Evento.IsDefinitive = chkDefinitivo.Checked;
            _Evento.Motivo = txtMotivo.Text;
            _Evento.Evolucion = txtEvolution.Text;
            _Evento.Motivo = txtMotivo.Text;

            //_Evento.CEI10_Code = txtCEI10.EditValue.ToString();
            //_Evento.Diagnosis = txtCEI10.Text;
            //_Evento.MetodoComplementario = cmbPMO_Espesialidad.EditValue.ToString();
            //_Evento.PMOQuirurgico = cmbPMO_Quirurgico.EditValue.ToString();

            if (cmbTipoConsulta.EditValue != null)
                if ((int)cmbTipoConsulta.EditValue != (int)CommonValuesEnum.SeleccioneUnaOpcion)
                    _Evento.IdTipoConsulta = Convert.ToInt32(cmbTipoConsulta.EditValue);

            //No enviar los medicamentos que no sufrieron modificaciones
            var medList = _Evento.PatientMedicaments.Where(p => p.EntityState != Fwk.Bases.EntityState.Unchanged).ToList();
            _Evento.PatientMedicaments.Clear();
            _Evento.PatientMedicaments.AddRange(medList);

            #region   Mapeo de details view a DetailView_Diagnosis
            var medDetails = _Evento.DetailView_Diagnosis.Where(p => p.EntityState != Fwk.Bases.EntityState.Unchanged).ToList();

            foreach (MedicalEventDetail_ViewBE det_view in medDetails)
            {
                MedicalEventDetailBE det = new MedicalEventDetailBE(det_view);
                det.ActiveRelevance = true;
                _Evento.MedicalEventDetailList.Add(det);
            }
            #endregion

            #region   Mapeo de details view a DetailView_Diagnosis
            medDetails = _Evento.DetailView_MetodosComplementarios.Where(p => p.EntityState != Fwk.Bases.EntityState.Unchanged).ToList();

            foreach (MedicalEventDetail_ViewBE det_view in medDetails)
            {
                MedicalEventDetailBE det = new MedicalEventDetailBE(det_view);
                det.ActiveRelevance = true;
                _Evento.MedicalEventDetailList.Add(det);
            }
            #endregion

            try
            {
             

                Controller.UpdateMedicalEvent(_Evento);
      
                if (this_will_close == false)
                {
                    MessageBox.Show("Datos actualizados con éxito", "Atención de pacientes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _Evento.MedicalEventDetailList.Clear();
                    _Evento.PatientMedicaments.Clear();
                    
                    Selected_PatientMedicament = null;
                    
                    _Evento.PatientMedicaments = Controller.RetrivePatientMedicaments(Controller.CurrentPatient.PatientId, _Evento.MedicalEventId);


                   MedicalEventDetail_ViewList details =  Controller.RetriveMedicalEventDetails(Controller.CurrentPatient.PatientId, _Evento.MedicalEventId);

                   _Evento.DetailView_Diagnosis = details.Get_Diagnosis();
                   _Evento.DetailView_MetodosComplementarios = details.Get_Metodo_Complementarios();

                    patientMedicamentViewListBindingSource.DataSource = _Evento.PatientMedicaments;
                    gridControl_Medicaments.RefreshDataSource();
                    gridView_Medicaments.RefreshData();
                    uC_EventDetailsGrid_Diagnosis.Populate(_Evento);
                    uC_EventDetailsGrid_MetComplementario.Populate(_Evento);
                    this.State = Fwk.Bases.EntityUpdateEnum.UPDATED;
                    frmPatientAtencion.PopulateAsync(this);
                }
            }
            catch (Exception ex2)
            {
                ExceptionViewer.Show(ex2);
            }

        }

        /// <summary>
        /// Medicaments grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_Medicaments_DoubleClick(object sender, EventArgs e)
        {
            if (Selected_PatientMedicament == null) return;
            using (frmQueryUpdateMedicament frm = new frmQueryUpdateMedicament())
            {
                #region seteos de formulario
                frm.currentMedicalEventId = _Evento.MedicalEventId;
                if (Selected_PatientMedicament.Enabled)
                    frm.State = this.State;
                else
                    frm.State = Fwk.Bases.EntityUpdateEnum.NONE;
                #endregion

                frm.PatientMedicament_Original = Selected_PatientMedicament;
                frm.PatientMedicamentList = _Evento.PatientMedicaments;
                frm.Refresh();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //Se debe obtener nuevamente dado q el PatientMedicaments que nos da la grilla pierde referencia con la coleccion _Evento.PatientMedicaments


                    ///Agrega uno nuevo en base una anterior
                    if (frm.UpdateMedicamentEnum == UpdateMedicalEventEnum.Other_MedicalEvent)
                    {
                        _Evento.PatientMedicaments.Add(frm.UpdatedPatientMedicament);

                        Selected_PatientMedicament.EntityState = Fwk.Bases.EntityState.Changed;
                        Selected_PatientMedicament.Enabled = false;
                    }

                    //Actualiza la creada en este Evento Medico
                    if (frm.UpdateMedicamentEnum == UpdateMedicalEventEnum.Same_MedicalEvent)
                    {

                        //if (Selected_PatientMedicament.PatientMedicamentId >= 0)
                        //    Selected_PatientMedicament = _Evento.PatientMedicaments.Where(p => p.PatientMedicamentId.Equals(Selected_PatientMedicament.PatientMedicamentId)).FirstOrDefault();
                        //Mapeo


                        if (Selected_PatientMedicament.PatientMedicamentId >= 0)
                        {
                            Selected_PatientMedicament = _Evento.PatientMedicaments.Where(p => p.PatientMedicamentId.Equals(Selected_PatientMedicament.PatientMedicamentId)).FirstOrDefault();
                            Fwk.HelperFunctions.ReflectionFunctions.MapProperties<PatientMedicament_ViewBE>(frm.UpdatedPatientMedicament, ref Selected_PatientMedicament);
                            Selected_PatientMedicament.EntityState = Fwk.Bases.EntityState.Changed;
                        }
                        else
                        {
                            Fwk.HelperFunctions.ReflectionFunctions.MapProperties<PatientMedicament_ViewBE>(frm.UpdatedPatientMedicament, ref Selected_PatientMedicament);
                        }
                    }
                    patientMedicamentViewListBindingSource.DataSource = _Evento.PatientMedicaments;
                    gridControl_Medicaments.RefreshDataSource();
                    gridView_Medicaments.RefreshData();
                }
            }
        }

        /// <summary>
        /// Medicaments grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_Medicaments_MouseDown(object sender, MouseEventArgs e)
        {
            _HitInfo = gridView_Medicaments.CalcHitInfo(new Point(e.X, e.Y));
            Selected_PatientMedicament = ((PatientMedicament_ViewBE)gridView_Medicaments.GetRow(_HitInfo.RowHandle));
            if (Selected_PatientMedicament == null) return;

            if (Selected_PatientMedicament.MedicalEventId.Equals(_Evento.MedicalEventId) && Selected_PatientMedicament.PatientMedicamentId_Parent.HasValue == false)
            {
                btnQuitarMedicamento.Enabled = true;
                m_quitar.Enabled = true;

                return;
            }
            btnQuitarMedicamento.Enabled = false;
            m_quitar.Enabled = false;


        }


        //private void simpleButton1_Click(object sender, EventArgs e)
        //{
        //    colEnabled.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value;
        //    colEnabled.FilterInfo = new ColumnFilterInfo("[Enabled] = true");
        //}

        void ChekMedicamentStatus()
        {
            var medicaments = _Evento.PatientMedicaments.Where(p => p.PatientMedicamentId_Parent.HasValue);

            foreach (PatientMedicament_ViewBE updatedMedicament in medicaments)
            {
                var parent = _Evento.PatientMedicaments.Where(p => p.PatientMedicamentId.Equals(updatedMedicament.PatientMedicamentId)).FirstOrDefault();
                parent.Enabled = false;
            }
        }
        

        private void btnAddMedicamento_Click(object sender, EventArgs e)
        {
            using (frmAddMedicament frm = new frmAddMedicament())
            {
                frm.State = Fwk.Bases.EntityUpdateEnum.NEW;
                frm._PatientMedicament = new PatientMedicament_ViewBE();
                frm._PatientMedicament.ApellidoProfesional = Controller.CurrentProfesional.Persona.Apellido;
                frm._PatientMedicament.NombreProfesional = Controller.CurrentProfesional.Persona.Nombre;
                frm._PatientMedicament.PatientId = Controller.CurrentPatient.PatientId;
                frm.currentMedicalEventId = _Evento.MedicalEventId;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //para nuevos medicamentos se le asignan numero negativos incrementales de -1,-2 a -x
                    int count = _Evento.PatientMedicaments.Count(p=>p.PatientMedicamentId <0);
                    frm._PatientMedicament.PatientMedicamentId = -(count + 1);
                    _Evento.PatientMedicaments.Add(frm._PatientMedicament);
                    patientMedicamentViewListBindingSource.DataSource = _Evento.PatientMedicaments;
                    gridControl_Medicaments.RefreshDataSource();
                    gridView_Medicaments.RefreshData();
                }

            }
        }


        void QuitMedicamentFromGridView()
        {
            if (Selected_PatientMedicament == null) return;

            Selected_PatientMedicament = _Evento.PatientMedicaments.Where(p => p.PatientMedicamentId.Equals(Selected_PatientMedicament.PatientMedicamentId)).FirstOrDefault();
            //Si ahun no se envio a la BD se elimina de la coleccion
            if (Selected_PatientMedicament.PatientMedicamentId < 0)

                _Evento.PatientMedicaments.Remove(Selected_PatientMedicament);
            else
            {
                Selected_PatientMedicament.EntityState = Fwk.Bases.EntityState.Deleted;
                Selected_PatientMedicament.Enabled = false;

            }

            //if (Selected_PatientMedicament.PatientMedicamentId_Parent.HasValue)
            //{
            //    var x = _Evento.PatientMedicaments.Where(p => p.PatientMedicamentId.Equals(Selected_PatientMedicament.PatientMedicamentId_Parent)).FirstOrDefault();
            //    if(x!=null)
            //        x.EntityState = Fwk.Bases.EntityState.Unchanged;
            //}

            patientMedicamentViewListBindingSource.DataSource = _Evento.PatientMedicaments;
            gridView_Medicaments.RefreshData();
            gridControl_Medicaments.RefreshDataSource();
        }

        private void btnQuitarMedicamento_Click(object sender, EventArgs e)
        {
            QuitMedicamentFromGridView();
        }
        private void m_quitar_Click(object sender, EventArgs e)
        {
            QuitMedicamentFromGridView();
        }

        //private void simpleButton1_Click_1(object sender, EventArgs e)
        //{
        //    using (frm_ManageMedicament frm = new frm_ManageMedicament(_Evento))
        //    {
        //        if (frm.ShowDialog() == DialogResult.OK)
        //        {
        //            patientMedicamentViewListBindingSource.DataSource = _Evento.PatientMedicaments;
        //            gridControl_Medicaments.RefreshDataSource();
        //            gridView_Medicaments.RefreshData();
        //        }
        //    }
        //}

        private void btnDiagnosis_Click(object sender, EventArgs e)
        {
            
            using (frm_EventDetails_Diagnosis frm = new frm_EventDetails_Diagnosis(_Evento))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //medicalEventDetailViewListBindingSource.DataSource = _Evento.MedicalEventDetail_ViewList;
                    //gridControl_Details.RefreshDataSource();
                    //gridView_Details.RefreshData();
                    uC_EventDetailsGrid_Diagnosis.RefreshDataSourse();
                    //uC_EventDetailsGrid_Diagnosis.Populate(_Evento);
                    tab_Control.SelectedTabPage = tabPage_Diagnostico;
                }
            }
        }

        private void btnMetComplementario_Click(object sender, EventArgs e)
        {
            using (frm_EventDetails_MetodoComplementario frm = new frm_EventDetails_MetodoComplementario(_Evento))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    uC_EventDetailsGrid_MetComplementario.RefreshDataSourse();
                    tab_Control.SelectedTabPage = tabPage_MetComplementario;
                }
            }
        }

       

      
    }
}
