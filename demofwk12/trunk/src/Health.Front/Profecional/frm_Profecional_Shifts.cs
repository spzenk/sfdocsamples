using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Health.Back.BE;
using Health.Isvc.GetPatient;
using Fwk.UI.Common;
using Health.BE;
using Health.BE.Enums;

namespace Health.Front.profesional
{
    public partial class frm_Profesional_Shifts : frmBase_Dialog
    {
        //Patient relacionado al turno
        ProfesionalBE profesional;
        internal PatientBE Patient;
        /// <summary>
        /// Turno que el profesional va a atender
        /// </summary>
        internal AppointmentBE Appointment;
        public frm_Profesional_Shifts()
        { }
        public frm_Profesional_Shifts(ProfesionalBE profesional)
        {
            InitializeComponent();
            this.profesional = profesional;

        
        
        }


        private void frm_Profesional_Shifts_Load(object sender, EventArgs e)
        {
            if (profesional == null) return;

            if (DesignMode) return;
            using (WaitCursorHelper w = new WaitCursorHelper (this))
            {
                uc_TimeLine1.SelectedProfesionalBE = new Profesional_FullViewBE();
                
                uc_TimeLine1.SelectedProfesionalBE.Nombre = profesional.Persona.Nombre;
                uc_TimeLine1.SelectedProfesionalBE.Apellido = profesional.Persona.Apellido;
                uc_TimeLine1.SelectedProfesionalBE.IdProfesional = profesional.IdProfesional;
                uc_TimeLine1.SelectedProfesionalBE.NombreEspecialidad = profesional.NombreEspecialidad;
                uc_TimeLine1.SelectedProfesionalBE.Matricula = profesional.Matricula;

                uc_TimeLine1.SelectedProfesionalBE.UserName = profesional.UserName;
                uc_TimeLine1.SelectedProfesionalBE.UserId = profesional.Persona.UserId;
                uc_TimeLine1.SelectedProfesionalBE.Foto = profesional.Persona.Foto;
                //this.uc_AllShiftGrid1.profesional = profesional;
                //this.uc_AllShiftGrid1.Refresh();
                uc_TimeLine1.Set_ProfesionalChanged();
            }
      
 

            
        }

        private void uc_AllShiftGrid1_ChangeStatusEvent(object sender, EventArgs e)
        {
            if (((AppoimantsStatus_SP)sender) == AppoimantsStatus_SP.EnAtencion)
            {
                this.Appointment = this.uc_TimeLine1.SelectedAppointment;
                GetPatientRes res = ServiceCalls.GetPatient(this.Appointment.ProfesionalAppointment.PatientId);
                this.Patient = res.BusinessData.Patient;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }

        }

        public override void Refresh()
        {
            this.uc_TimeLine1.Refresh();
            base.Refresh();
        }

    
        //Control currentControl;
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (DesignMode) return;
            //if (currentControl == uc_TimeLine1)
            //{
         

            uc_TimeLine1.SetDateChanged(e.Start);
            //}
            //if (currentControl == uc_AllShiftGrid1)
            //{
               // uc_AllShiftGrid1.SetDateChanged(e.Start);
            //}

        }

        private void uc_TimeLine1_OnChangeStatusEvent(object sender, EventArgs e)
        {
            if (((AppoimantsStatus_SP)sender) == AppoimantsStatus_SP.EnAtencion)
            {
                this.Appointment = this.uc_TimeLine1.SelectedAppointment;
                GetPatientRes res = ServiceCalls.GetPatient(this.uc_TimeLine1.SelectedAppointment.ProfesionalAppointment.PatientId);
                this.Patient = res.BusinessData.Patient;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
    }
}
