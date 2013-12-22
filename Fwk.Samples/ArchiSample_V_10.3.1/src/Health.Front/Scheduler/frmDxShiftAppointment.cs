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
using Health.BE;

namespace Health.Front.Scheduler
{

    public partial class frmDxShiftAppointment : frmBase_Dialog
    {
        SchedulerControl control;
        public Profesional_FullViewBE profesional;
        DevExpress.XtraScheduler.Appointment apt;
        bool openRecurrenceForm = false;
        int suspendUpdateCount;
        // The MyAppointmentFormController class is inherited from
        // the AppointmentFormController to add custom properties.
        // See its declaration below.
        MyAppointmentFormController controller;
        public frmDxShiftAppointment()
        {
            InitializeComponent();
        }
     
        public frmDxShiftAppointment(SchedulerControl control, DevExpress.XtraScheduler.Appointment apt, bool openRecurrenceForm)
        {
            this.openRecurrenceForm = openRecurrenceForm;
            this.controller = new MyAppointmentFormController(control, apt);
            this.apt = apt;
            this.control = control;
            SuspendUpdate();
            InitializeComponent();
            ResumeUpdate();
            UpdateForm();

        }



        protected AppointmentStorage Appointments { get { return control.Storage.Appointments; } }
        protected internal bool IsNewAppointment { get { return controller != null ? controller.IsNewAppointment : true; } }
        protected bool IsUpdateSuspended { get { return suspendUpdateCount > 0; } }

        void ShowRecurrenceForm()
        {

            if (!control.SupportsRecurrence)
                return;

            // Prepare to edit the appointment's recurrence.
            DevExpress.XtraScheduler.Appointment editedAptCopy = controller.EditedAppointmentCopy;
            DevExpress.XtraScheduler.Appointment editedPattern = controller.EditedPattern;
            DevExpress.XtraScheduler.Appointment patternCopy = controller.PrepareToRecurrenceEdit();

            AppointmentRecurrenceForm dlg = new AppointmentRecurrenceForm(patternCopy,
                control.OptionsView.FirstDayOfWeek, controller);

            // Required for skin support.
            dlg.LookAndFeel.ParentLookAndFeel = this.LookAndFeel.ParentLookAndFeel;

            DialogResult result = dlg.ShowDialog(this);
            dlg.Dispose();

            if (result == DialogResult.Abort)
                controller.RemoveRecurrence();
            else
                if (result == DialogResult.OK)
                {
                    controller.ApplyRecurrence(patternCopy);
                    if (controller.EditedAppointmentCopy != editedAptCopy)
                        UpdateForm();
                }
            UpdateIntervalControls();
        }
        protected void SuspendUpdate()
        {
            suspendUpdateCount++;
        }
        protected void ResumeUpdate()
        {
            if (suspendUpdateCount > 0)
                suspendUpdateCount--;
        }

        void UpdateForm()
        {
            SuspendUpdate();
            try
            {
                txtProfesional.Text = profesional.ApellidoNombre;
                txSubject.Text = controller.Subject;
          
                //edStatus.Status = Appointments.Statuses[controller.StatusId];
                //edLabel.Label = Appointments.Labels[controller.LabelId];

                dtStart.DateTime = controller.DisplayStart.Date;
                dtEnd.DateTime = controller.DisplayEnd.Date;

                timeStart.Time = new DateTime(controller.DisplayStart.TimeOfDay.Ticks);
                timeEnd.Time = new DateTime(controller.DisplayEnd.TimeOfDay.Ticks);
                //checkAllDay.Checked = controller.AllDay;

                //edStatus.Storage = control.Storage;
                //edLabel.Storage = control.Storage;
                //TODO: Obtener el Patient por id
                //txtPatient.Text = controller.CustomIdPatient;


            }
            finally
            {
                ResumeUpdate();
            }
            UpdateIntervalControls();
        }
        protected virtual void UpdateIntervalControls()
        {
            if (IsUpdateSuspended)
                return;

            SuspendUpdate();
            try
            {


                //dtStart.EditValue = controller.DisplayStart.Date;
                //dtEnd.EditValue = controller.DisplayEnd.Date;
                timeStart.EditValue = new DateTime(controller.DisplayStart.TimeOfDay.Ticks);
                timeEnd.EditValue = new DateTime(controller.DisplayEnd.TimeOfDay.Ticks);

                txtDEscription.Text = controller.Description;

                //timeStart.Visible = !controller.AllDay;
                //timeEnd.Visible = !controller.AllDay;
                //timeStart.Enabled = !controller.AllDay;
                //timeEnd.Enabled = !controller.AllDay;

            }
            finally
            {
                ResumeUpdate();
            }
        }

        void UpdateAppointmentStatus()
        {
            //AppointmentStatus currentStatus = edStatus.Status;
            //AppointmentStatus newStatus = controller.UpdateAppointmentStatus(currentStatus);
            //if (newStatus != currentStatus)
            //    edStatus.Status = newStatus;
        }

        private void bt_Ok_Click(object sender, EventArgs e)
        {

        }

        private void MyAppointmentForm_Activated(object sender, EventArgs e)
        {
            // Required to show the recurrence form.
            //if (openRecurrenceForm)
            //{
            //    openRecurrenceForm = false;
            //    OnRecurrenceButton();
            //}
        }

        private void timeStart_EditValueChanged(object sender, EventArgs e)
        {
            if (!IsUpdateSuspended)
                controller.DisplayStart = dtStart.DateTime.Date + timeStart.Time.TimeOfDay;
            UpdateIntervalControls();
        }
        private void timeEnd_EditValueChanged_1(object sender, System.EventArgs e)
        {
            if (IsUpdateSuspended) return;
            if (IsIntervalValid())
                controller.DisplayEnd = dtEnd.DateTime.Date + timeEnd.Time.TimeOfDay;
            else
                timeEnd.EditValue = new DateTime(controller.DisplayEnd.TimeOfDay.Ticks);

        }
        bool IsIntervalValid()
        {
            DateTime start = dtStart.DateTime + timeStart.Time.TimeOfDay;
            DateTime end = dtEnd.DateTime + timeEnd.Time.TimeOfDay;
            return end >= start;
        }

        private void dtStart_EditValueChanged(object sender, EventArgs e)
        {
            if (!IsUpdateSuspended)
                controller.DisplayStart = dtStart.DateTime.Date + timeStart.Time.TimeOfDay;
            UpdateIntervalControls();
        }

        private void dtEnd_EditValueChanged(object sender, EventArgs e)
        {
            if (IsUpdateSuspended) return;
            if (IsIntervalValid())
                controller.DisplayEnd = dtEnd.DateTime.Date + timeEnd.Time.TimeOfDay;
            else
                dtEnd.EditValue = controller.DisplayEnd.Date;
        }

        private void lblLabel_Click(object sender, EventArgs e)
        {

        }
        PatientBE SelectedPatientBE;
        private void btnFindPatient_Click(object sender, EventArgs e)
        {
            ///Busca paciente 
            using (frmGridPatients form = new frmGridPatients())
            {
                form.Refresh();
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    SelectedPatientBE = form.SelectedPatientBE;
                    txtPatient.Text = SelectedPatientBE.Persona.ApellidoNombre;
                    txSubject.Text = String.Concat("Reservado para ", SelectedPatientBE.Persona.ApellidoNombre);
                }

            }
        }

        private void aceptCancelButtonBar1_ClickOkCancelEvent(object sender, DialogResult result)
        {
            // Required to check the appointment for conflicts.
            if (!controller.IsConflictResolved())
                return;

            controller.Subject = txSubject.Text;
            controller.SetStatus(edStatus.Status);
            controller.SetLabel(edLabel.Label);
            //controller.AllDay = this.checkAllDay.Checked;
            controller.DisplayStart = this.dtStart.DateTime.Date + this.timeStart.Time.TimeOfDay;
            controller.DisplayEnd = this.dtEnd.DateTime.Date + this.timeEnd.Time.TimeOfDay;



            controller.ResourceId = txtProfesional.Text;
            controller.CustomIdPatient = SelectedPatientBE.PatientId;
            // Save all changes of the editing appointment.
            controller.ApplyChanges();
        }

        private void btCanel_Click(object sender, EventArgs e)
        {

        }


    }
    public class MyAppointmentFormController : AppointmentFormController
    {

        public int CustomIdPatient
        {
            get
            {
                return (int)EditedAppointmentCopy.CustomFields["IdPatient"];
            }
            set
            {
                EditedAppointmentCopy.CustomFields["IdPatient"] = value;
            }
        }
        public int CustomStatus
        {
            get
            {
                return (int)EditedAppointmentCopy.CustomFields["CustomStatus"];
            }
            set
            {
                EditedAppointmentCopy.CustomFields["CustomStatus"] = value;
            }
        }

        int SourceIdPatient
        {
            get
            {
                return (int)SourceAppointment.CustomFields["IdPatient"];
            }
            set
            {
                SourceAppointment.CustomFields["IdPatient"] = value;
            }
        }

        int SourceCustomStatus
        {
            get
            {
                return (int)SourceAppointment.CustomFields["CustomStatus"];
            }
            set
            {
                SourceAppointment.CustomFields["CustomStatus"] = value;
            }
        }

        public MyAppointmentFormController(SchedulerControl control, DevExpress.XtraScheduler.Appointment apt) :
            base(control, apt)
        {
        }

        public override bool IsAppointmentChanged()
        {
            if (base.IsAppointmentChanged())
                return true;
            return SourceIdPatient != CustomIdPatient;//||  SourceCustomStatus != CustomStatus;
        }

        protected override void ApplyCustomFieldsValues()
        {
            SourceIdPatient = CustomIdPatient;
            //SourceCustomStatus = CustomStatus;
        }
    }
}
