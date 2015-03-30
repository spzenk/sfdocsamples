using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Health.Back.BE;
using Health.BE;

namespace Health.Front.Events
{
    internal enum UpdateMedicalEventEnum
    {
            Other_MedicalEvent,
            Same_MedicalEvent,
            
    }
    public partial class frmQueryUpdateMedicament : frmBase_Dialog
    {
        internal PatientMedicament_ViewList PatientMedicamentList;
        internal PatientMedicament_ViewBE PatientMedicament_Original;
        internal PatientMedicament_ViewBE UpdatedPatientMedicament;
        internal int currentMedicalEventId = -1;
        internal UpdateMedicalEventEnum UpdateMedicamentEnum;
        public frmQueryUpdateMedicament()
        {
            InitializeComponent();
        }


        public override void Refresh()
        {
            SetControls(PatientMedicament_Original);
            
 

            UpdatedPatientMedicament = PatientMedicament_Original.Clone<PatientMedicament_ViewBE>();

            //Medicamento de otro evento
            if (currentMedicalEventId != PatientMedicament_Original.MedicalEventId && 
                PatientMedicament_Original.PatientMedicamentId > 0) //es por que se puede intentar modificar la info mas de una ves 
            {
                UpdatedPatientMedicament.MedicalEventId = currentMedicalEventId;
                //Historial
                UpdatedPatientMedicament.PatientMedicamentId_Parent = PatientMedicament_Original.PatientMedicamentId;

                int count = PatientMedicamentList.Count(p => p.PatientMedicamentId < 0);
                // Sin Id x q se creara luego
                UpdatedPatientMedicament.PatientMedicamentId = -(count + 1);

                //Marcar como nuevo
                UpdatedPatientMedicament.EntityState = Fwk.Bases.EntityState.Added;
                UpdateMedicamentEnum = UpdateMedicalEventEnum.Other_MedicalEvent;
                
            }

            ///Fue agregado en este evento
            if (currentMedicalEventId == PatientMedicament_Original.MedicalEventId)
            {
                UpdateMedicamentEnum = UpdateMedicalEventEnum.Same_MedicalEvent;
            }

      
           


            if (this.State == Fwk.Bases.EntityUpdateEnum.NONE)
            {
                this.txtDaysCount.Enabled =
                    this.txtMedicamentName.Enabled =
                    this.txtDosis.Enabled =
                    this.txtFecha.Enabled =
                    this.txtMedicamentName.Enabled =
                    this.txtPeriodicity_hours.Enabled =
                    this.txtPresentation.Enabled = false;
                aceptCancelButtonBar1.AceptButtonVisible = false;
                aceptCancelButtonBar1.CancelButtonText = "Salir";
            }

            base.Refresh();

        }
        void SetControls(PatientMedicament_ViewBE pPatientMedicament_ViewBE)
        {
            if (pPatientMedicament_ViewBE.EntityState == Fwk.Bases.EntityState.Added)
                chkSuspend.Visible = false;

            this.txtMedicamentName.Text = pPatientMedicament_ViewBE.MedicamentName;
            this.txtPresentation.Text = pPatientMedicament_ViewBE.MedicamentPresentation;
            this.txtFecha.Text = pPatientMedicament_ViewBE.CreatedDate.ToString();
            this.lblProfesional.Text = pPatientMedicament_ViewBE.ApellidoNombre;

            this.txtDaysCount.EditValue = pPatientMedicament_ViewBE.DaysCount;
            this.txtPeriodicity_hours.EditValue = pPatientMedicament_ViewBE.Periodicity_hours;

            this.txtDosis.EditValue = pPatientMedicament_ViewBE.Dosis;
            if (pPatientMedicament_ViewBE.Status == (int)Health.BE.Enums.MedicamentStatus.Permanente)
                this.chkPermanent.Checked = true;
            else
                this.chkPermanent.Checked = false;

            if (pPatientMedicament_ViewBE.Status == (int)Health.BE.Enums.MedicamentStatus.Suspendido)
                this.chkSuspend.Checked = true;
            else
                this.chkSuspend.Checked = false;

            string[] arrDosis = pPatientMedicament_ViewBE.Dosis.Split(';');

            this.txtDosis.EditValue = arrDosis[0];
            if (arrDosis.Count() > 1)
                this.cmdbMeasures.Text = arrDosis[1];
        }

        bool HasChanges()
        {
            return (!UpdatedPatientMedicament.DaysCount.Equals(PatientMedicament_Original.DaysCount) ||
                          !UpdatedPatientMedicament.Periodicity_hours.Equals(PatientMedicament_Original.Periodicity_hours) ||
                          !UpdatedPatientMedicament.Status.Equals(PatientMedicament_Original.Status) ||
                          !UpdatedPatientMedicament.Dosis.Equals(PatientMedicament_Original.Dosis) ||
                          UpdatedPatientMedicament.MedicamentName.CompareTo(PatientMedicament_Original.MedicamentName) != 0 ||
                          UpdatedPatientMedicament.MedicamentPresentation.CompareTo(PatientMedicament_Original.MedicamentPresentation) != 0
            );
        }
        void SetMedicamet()
        {
            UpdatedPatientMedicament.DaysCount = Convert.ToInt16(this.txtDaysCount.EditValue);
            UpdatedPatientMedicament.Periodicity_hours = Convert.ToInt16(this.txtPeriodicity_hours.EditValue);


            if (this.chkPermanent.Checked)
                UpdatedPatientMedicament.Status = (int)Health.BE.Enums.MedicamentStatus.Permanente;
            else
                UpdatedPatientMedicament.Status = (int)Health.BE.Enums.MedicamentStatus.Temporal;

            ///Este estado tiene prioridad
            if (this.chkSuspend.Checked)
                UpdatedPatientMedicament.Status = (int)Health.BE.Enums.MedicamentStatus.Suspendido;


            UpdatedPatientMedicament.Dosis = string.Concat(this.txtDosis.EditValue.ToString(), ";", cmdbMeasures.Text);
            UpdatedPatientMedicament.MedicamentName = txtMedicamentName.Text.Trim();
            UpdatedPatientMedicament.MedicamentPresentation = txtPresentation.Text.Trim();

        }

        void Validation()
        {
            dxErrorProvider1.ClearErrors();

            if (String.IsNullOrEmpty(txtMedicamentName.Text))
                dxErrorProvider1.SetError(txtMedicamentName, "No puede estar vasio");

            if (String.IsNullOrEmpty(txtPresentation.Text))
                dxErrorProvider1.SetError(txtPresentation, "No puede estar vasio");
            if (txtPeriodicity_hours.Value == 0)
                dxErrorProvider1.SetError(txtPeriodicity_hours, "Debe ser mayor a 0");

            if (String.IsNullOrEmpty(txtDosis.Text))
                dxErrorProvider1.SetError(txtPresentation, "No puede estar vasio");


            if (chkPermanent.Checked == false)
            {
                if (Convert.ToInt32(txtDaysCount.EditValue) <= 0)
                    dxErrorProvider1.SetError(txtDaysCount, "Debe ser mayor a 0");
                
            }


        }
        private void aceptCancelButtonBar1_ClickOkCancelEvent(object sender, DialogResult result)
        {
            this.DialogResult = result;
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Validation();
                if (dxErrorProvider1.HasErrors)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.None;
                    return;
                }
                SetMedicamet();
                if (!HasChanges())
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
            this.Close();
        }

        private void chkPermanent_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPermanent.Checked)
            {
                txtDaysCount.Text = string.Empty;
                txtDaysCount.Enabled = false;
            }
            else
                txtDaysCount.Enabled = true;
        }
    }
}
