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
    public partial class frmAddMedicament : frmBase_Dialog
    {
        internal PatientMedicament_ViewBE _PatientMedicament;

        internal int currentMedicalEventId = -1;
        public override void Refresh()
        {
            this.txtMedicamet.Text = _PatientMedicament.MedicamentName;
            this.txtPresentation.Text = _PatientMedicament.MedicamentPresentation;
            this.lblPatient.Text = Controller.CurrentPatient.Persona.ApellidoNombre;
            string[] arrDosis = _PatientMedicament.Dosis.Split(';');

            this.txtDosis.EditValue = arrDosis[0];
            if (arrDosis.Count() > 1)
                this.cmdbMeasures.Text = arrDosis[1];

            this.txtDaysCount.EditValue = _PatientMedicament.DaysCount;
            this.txtPeriodicity_hours.EditValue = _PatientMedicament.Periodicity_hours;
            if (_PatientMedicament.Status == (int)Health.BE.Enums.MedicamentStatus.Permanente)
                this.chkPermanent.Checked = true;
            else
                this.chkPermanent.Checked = false;
            
            if (this.State == Fwk.Bases.EntityUpdateEnum.NONE)
            {
                this.txtMedicamet.Enabled = false;
                this.txtPresentation.Enabled = false;
                this.lblPatient.Enabled = false;
                this.txtDosis.Enabled = false;
                this.txtDaysCount.Enabled = false;
                this.txtPeriodicity_hours.Enabled = false;
                this.chkPermanent.Enabled = false;
                this.aceptCancelButtonBar1.AceptButtonVisible = false;
                this.aceptCancelButtonBar1.CancelButtonText = "Salir";
            }
            
            base.Refresh();
        }
        void SetMedicamet()
        {
            _PatientMedicament.PatientMedicamentId = -1;//DADO Q ES NUEVO
            _PatientMedicament.MedicalEventId = currentMedicalEventId;
            _PatientMedicament.MedicamentName = this.txtMedicamet.Text;
            _PatientMedicament.MedicamentPresentation = this.txtPresentation.Text;
            
            _PatientMedicament.Dosis = string.Concat(this.txtDosis.EditValue.ToString() ,";" , cmdbMeasures.Text);

            _PatientMedicament.DaysCount = Convert.ToInt16(this.txtDaysCount.EditValue);
            _PatientMedicament.Periodicity_hours = Convert.ToInt16(this.txtPeriodicity_hours.EditValue);

            if (this.chkPermanent.Checked)
                _PatientMedicament.Status = (int)Health.BE.Enums.MedicamentStatus.Permanente;
            else
                _PatientMedicament.Status = (int)Health.BE.Enums.MedicamentStatus.Temporal;

            _PatientMedicament.EntityState = Fwk.Bases.EntityState.Added;
            _PatientMedicament.Enabled = true;
            _PatientMedicament.CreatedDate = System.DateTime.Now;
        }
        void Validations()
        {
            dxErrorProvider1.ClearErrors();

            if (String.IsNullOrEmpty(txtMedicamet.Text))
                dxErrorProvider1.SetError(txtMedicamet, "No puede estar vasio");

            if (String.IsNullOrEmpty(txtPresentation.Text))
                dxErrorProvider1.SetError(txtPresentation, "No puede estar vasio");

            if (txtPeriodicity_hours.Value <= 0)
                dxErrorProvider1.SetError(txtPeriodicity_hours, "Debe ser mayor a 0");

            if (Convert.ToInt32(txtDosis.EditValue) <= 0)
                dxErrorProvider1.SetError(txtDosis, "Debe ser mayor a 0");

            if (chkPermanent.Checked == false)
            {
                if (Convert.ToInt32(txtDaysCount.EditValue) <= 0)
                    dxErrorProvider1.SetError(txtDaysCount, "Debe ser mayor a 0");

            }

        }
        public frmAddMedicament()
        {
            InitializeComponent();

        }

        private void aceptCancelButtonBar1_ClickOkCancelEvent(object sender, DialogResult result)
        {

            this.DialogResult = result;

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Validations();
                if (dxErrorProvider1.HasErrors)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.None;
                    return;
                }
                SetMedicamet();
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
                txtDaysCount.Enabled = true  ;
        }

        private void frmAddMedicament_Load(object sender, EventArgs e)
        {
            this.cmdbMeasures.SelectedIndex = 0;
        }


    }
}
