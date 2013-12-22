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
    public partial class frm_ManageMedicament : frmBase_Dialog
    {
        MedicalEventBE currentEvent;
        PatientMedicament_ViewBE selected_PatientMedicament = null;
       
        GridHitInfo _HitInfo = null;
        public frm_ManageMedicament(MedicalEventBE pCurrentEvent)
        {
            InitializeComponent();

            currentEvent = pCurrentEvent;

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
                frm.currentMedicalEventId = currentEvent.MedicalEventId;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //para nuevos medicamentos se le asignan numero negativos incrementales de -1,-2 a -x
                    int count = currentEvent.PatientMedicaments.Count(p => p.PatientMedicamentId < 0);
                    frm._PatientMedicament.PatientMedicamentId = -(count + 1);
                    currentEvent.PatientMedicaments.Add(frm._PatientMedicament);
                    gridView_Medicaments.RefreshData();
                }

            }
        }



      
        private void btnQuitarMedicamento_Click(object sender, EventArgs e)
        {
            QuitMedicamentFromGridView();
        }
        private void gridView_Medicaments_MouseDown(object sender, MouseEventArgs e)
        {
            _HitInfo = gridView_Medicaments.CalcHitInfo(new Point(e.X, e.Y));
            selected_PatientMedicament = ((PatientMedicament_ViewBE)gridView_Medicaments.GetRow(_HitInfo.RowHandle));
            if (selected_PatientMedicament == null) return;

            if (selected_PatientMedicament.MedicalEventId.Equals(currentEvent.MedicalEventId) && selected_PatientMedicament.PatientMedicamentId_Parent.HasValue == false)
            {
                btnQuitarMedicamento.Enabled = true;
                m_quitar.Enabled = true;

                return;
            }
            btnQuitarMedicamento.Enabled = false;
            m_quitar.Enabled = false;
        }
        private void gridView_Medicaments_DoubleClick(object sender, EventArgs e)
        {
            if (selected_PatientMedicament == null) return;
            using (frmQueryUpdateMedicament frm = new frmQueryUpdateMedicament())
            {
                #region seteos de formulario
                frm.currentMedicalEventId = currentEvent.MedicalEventId;
                if (selected_PatientMedicament.Enabled)
                    frm.State = this.State;
                else
                    frm.State = Fwk.Bases.EntityUpdateEnum.NONE;
                #endregion

                frm.PatientMedicament_Original = selected_PatientMedicament;
                frm.PatientMedicamentList = currentEvent.PatientMedicaments;
                frm.Refresh();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //Se debe obtener nuevamente dado q el PatientMedicaments que nos da la grilla pierde referencia con la coleccion _Evento.PatientMedicaments


                    ///Agrega uno nuevo en base una anterior
                    if (frm.UpdateMedicamentEnum == UpdateMedicalEventEnum.Other_MedicalEvent)
                    {
                        currentEvent.PatientMedicaments.Add(frm.UpdatedPatientMedicament);

                        selected_PatientMedicament.EntityState = Fwk.Bases.EntityState.Changed;
                        selected_PatientMedicament.Enabled = false;
                    }

                    //Actualiza la creada en este Evento Medico
                    if (frm.UpdateMedicamentEnum == UpdateMedicalEventEnum.Same_MedicalEvent)
                    {

                        //if (Selected_PatientMedicament.PatientMedicamentId >= 0)
                            //selected_PatientMedicament = _Evento.PatientMedicaments.Where(p => p.PatientMedicamentId.Equals(Selected_PatientMedicament.PatientMedicamentId)).FirstOrDefault();
                        //Mapeo
                        Fwk.HelperFunctions.ReflectionFunctions.MapProperties<PatientMedicament_ViewBE>(frm.UpdatedPatientMedicament, ref selected_PatientMedicament);
                        
                        if (selected_PatientMedicament.PatientMedicamentId >= 0)
                        {
                            //selected_PatientMedicament = currentEvent.PatientMedicaments.Where(p => p.PatientMedicamentId.Equals(selected_PatientMedicament.PatientMedicamentId)).FirstOrDefault();
                            //Fwk.HelperFunctions.ReflectionFunctions.MapProperties<PatientMedicament_ViewBE>(frm.UpdatedPatientMedicament, ref Selected_PatientMedicament);
                            selected_PatientMedicament.EntityState = Fwk.Bases.EntityState.Changed;
                        }
                        //else
                        //{
                            
                        //}
                    }
                    gridView_Medicaments.RefreshData();
                }
            }
        }
        void ChekMedicamentStatus()
        {
            var medicaments = currentEvent.PatientMedicaments.Where(p => p.PatientMedicamentId_Parent.HasValue);

            foreach (PatientMedicament_ViewBE updatedMedicament in medicaments)
            {
                var parent = currentEvent.PatientMedicaments.Where(p => p.PatientMedicamentId.Equals(updatedMedicament.PatientMedicamentId)).FirstOrDefault();
                parent.Enabled = false;
            }
        }
        void QuitMedicamentFromGridView()
        {
            //
            if (selected_PatientMedicament.PatientMedicamentId > 0)
            {
                currentEvent.PatientMedicaments.Remove(selected_PatientMedicament);
            }
            else
                selected_PatientMedicament.EntityState = Fwk.Bases.EntityState.Deleted;


            if (selected_PatientMedicament.PatientMedicamentId_Parent.HasValue)
            {
                var x = currentEvent.PatientMedicaments.Where(p => p.MedicalEventId.Equals(selected_PatientMedicament.PatientMedicamentId_Parent)).FirstOrDefault();
                if (x != null)
                    x.EntityState = Fwk.Bases.EntityState.Unchanged;
            }


            gridView_Medicaments.RefreshData();
        }

        private void aceptCancelButtonBar1_ClickOkCancelEvent(object sender, DialogResult result)
        {
            this.DialogResult = result;

            this.Close();

        }

        private void frm_ManageMedicament_Load(object sender, EventArgs e)
        {
           patientMedicamentViewListBindingSource.DataSource= currentEvent.PatientMedicaments;
        }

       

    }
}