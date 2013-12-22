using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler.UI;
using DevExpress.XtraScheduler;
using Health.Back.BE;
using Health.Entities;
using Health.BE;
using Health.BE.Enums;

namespace Health.Front.Scheduler
{

    public partial class frmShiftAppointment : frmBase_Dialog
    {

        internal Profesional_FullViewBE Profesional;
        internal AppointmentBE currentApt;
        internal bool AceptCancelButtonBar_Visible
        {
            get { return aceptCancelButtonBar1.Visible; } 
            set{aceptCancelButtonBar1.Visible=value;}
        }


        public frmShiftAppointment()
        {
            InitializeComponent();
        }



        public override void Refresh()
        {

            UpdateControls();
            base.Refresh();
        }

        void UpdateControls()
        {


            if (State == Fwk.Bases.EntityUpdateEnum.NONE)
            {
                this.txSubject.Enabled = this.btnFindPatient.Enabled = false;
            }

            txtProfesional.Text = Profesional.ApellidoNombre;
            txSubject.Text = currentApt.Subject;

            lblStatusValue.Text = ((AppoimantsStatus_SP)currentApt.Status.Value).ToString();
            lblStatusValue.Appearance.Image = imageList1.Images[SchedulerHelper.GetImageStatusKey((AppoimantsStatus_SP)currentApt.Status.Value)];


            dtStart.DateTime = currentApt.Start.Value;
            dtEnd.DateTime = currentApt.End.Value;

            timeStart.Time = new DateTime(currentApt.Start.Value.Ticks);
            timeEnd.Time = new DateTime(currentApt.End.Value.Ticks);

            //edLabel.Storage = control.Storage;
            //TODO: Obtener el Patient por id


            ///Se anula a pedido de Dr Renaudo
            //int index = 0;
            if (State == Fwk.Bases.EntityUpdateEnum.NEW)
            {
                currentApt.ProfesionalAppointment = new ProfesionalAppointmentBE();
            }
            //else
            //{
            //    index = cmbMotivoConsulta.Properties.GetDataSourceRowIndex("IdParametro", currentApt.ProfesionalAppointment.IdMotivoConsulta);
            //}

            //cmbMotivoConsulta.ItemIndex = index;

            //if ((AppoimantsStatus_SP)currentApt.Status.Value != AppoimantsStatus_SP.Reservado)
            //    cmbMotivoConsulta.Enabled = false;

            txtPatient.Text = currentApt.ProfesionalAppointment.PatientName;
            if (!String.IsNullOrEmpty(currentApt.ProfesionalAppointment.PatientName))
                SelectedPatientBE = Controller.GetPatient(currentApt.ProfesionalAppointment.PatientId).BusinessData.Patient;
        }



        PatientBE SelectedPatientBE;
        private void btnFindPatient_Click(object sender, EventArgs e)
        {
            ///Busca Patient 
            using (frmGridPatients form = new frmGridPatients())
            {
                form.Refresh();
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    SelectedPatientBE = form.SelectedPatientBE;
                    txtPatient.Text = SelectedPatientBE.Persona.ApellidoNombre;
                    txSubject.Text = String.Concat("Reservado para ", SelectedPatientBE.Persona.ApellidoNombre);
                    currentApt.ProfesionalAppointment.PatientId = SelectedPatientBE.PatientId;
                    currentApt.ProfesionalAppointment.PatientName = SelectedPatientBE.Persona.ApellidoNombre;
                    cmbMutual.Properties.DataSource = form.Mutuales;

                    if (form.Mutuales == null || form.Mutuales.Count==0)
                    {
                        cmbMutual.Properties.NullText = "No existen mutuales para este paciente";
                        chkPresentaOrden.Enabled = txtNroAfiliado.Enabled = false;
                    }
                    else
                    {
                        cmbMutual.Properties.NullText = "Seleccione uan opción";
                        chkPresentaOrden.Enabled=txtNroAfiliado.Enabled = true;
                        
                    }
                    
                    cmbMutual.Refresh();

                }

            }
        }

        private void aceptCancelButtonBar1_ClickOkCancelEvent(object sender, DialogResult result)
        {
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                ValidateControls();
                if (dxErrorProvider1.HasErrors) return;
                currentApt.Subject = txSubject.Text;
                currentApt.Description = txtDEscription.Text;
            }
            this.DialogResult = result;
            this.Close();

        }

        void ValidateControls()
        {
            dxErrorProvider1.ClearErrors();
            if (SelectedPatientBE == null)
                dxErrorProvider1.SetError(txtPatient, "El paceinte es requerido");
        }

        private void txSubject_EditValueChanged(object sender, EventArgs e)
        {
            if (SelectedPatientBE != null)
                if (String.IsNullOrEmpty(txSubject.Text))
                    txSubject.Text = String.Concat("Reservado para ", SelectedPatientBE.Persona.ApellidoNombre);
        }

        private void frmShiftAppointment_Load(object sender, EventArgs e)
        {
            //Anulado por renaudo
            //cmbMotivoConsulta.Properties.DataSource = Controller.MotivoConsultaList;

            //cmbMotivoConsulta.Refresh();
        }


    }

}
