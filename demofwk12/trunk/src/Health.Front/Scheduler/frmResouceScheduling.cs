using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using Health.Back.BE;
using Health.Entities;
using Health.BE;

namespace Health.Front.Scheduler
{
    public partial class frmResouceScheduling : frmBase_Dialog
    {
        ResourceSchedulingBE _SchedulerShiftCopy;
        ResourceSchedulingBE _SchedulerShiftOriginal;
        /// <summary>
        /// Existente Resource Scheduling del profesional
        /// </summary>
        internal ResourceSchedulingList ResourceSchedulingList { get; set; }
        
            
        internal ResourceSchedulingBE SchedulerShift
        {
            get
            {
                return _SchedulerShiftOriginal;
            }
            set
            {
                _SchedulerShiftOriginal = value;
                _SchedulerShiftCopy = _SchedulerShiftOriginal.Clone<ResourceSchedulingBE>();
            }
        }
        int ResourceId;
        public frmResouceScheduling()
        {
            InitializeComponent();
        }
        public frmResouceScheduling(int resourceId)
        {
            InitializeComponent();
            ResourceId = resourceId;
            this.weekDaysCheckEdit1.WeekDays = 0;
        }


        void Set_SchedulerShift( ResourceSchedulingBE schedulerShift )
        {
            if (this.State == Fwk.Bases.EntityUpdateEnum.NEW && schedulerShift == null)
            {
                //schedulerShift = new ResourceSchedulingBE();
                schedulerShift.ResourceId = ResourceId;
            }

            schedulerShift.Description = txtNombre.Text;
            schedulerShift.Duration = durationEdit1.Duration.TotalMinutes;
            schedulerShift.WeekDays = (int)weekDaysCheckEdit1.WeekDays;
            schedulerShift.TimeStart = cmbTimeStart.Text;
            schedulerShift.TimeEnd = cmbTimeEnd.Text;
        }

        /// <summary>
        /// DEtecta si se realizo algun cambio
        /// </summary>
        /// <returns></returns>
        bool  HasChanges()
        {
            
            if (!_SchedulerShiftOriginal.Description.Equals(_SchedulerShiftCopy.Description)
                    || !_SchedulerShiftOriginal.Duration.Equals(_SchedulerShiftCopy.Duration)
                    || !_SchedulerShiftOriginal.WeekDays.Equals(_SchedulerShiftCopy.WeekDays)
                    || !_SchedulerShiftOriginal.TimeStart.Equals(_SchedulerShiftCopy.TimeStart)
                    || !_SchedulerShiftOriginal.TimeEnd.Equals(_SchedulerShiftCopy.TimeEnd))

            {
                _SchedulerShiftOriginal.EntityState= Fwk.Bases.EntityState.Changed;
                return true;
            }
            return false;
        }
        void Set_Controls(ResourceSchedulingBE schedulerShift)
        {
            txtNombre.Text = schedulerShift.Description;
            durationEdit1.Duration = TimeSpan.FromMinutes(schedulerShift.Duration.Value);
            weekDaysCheckEdit1.WeekDays = (WeekDays) schedulerShift.WeekDays;
            cmbTimeStart.Text = schedulerShift.TimeStart;
            cmbTimeEnd.Text = schedulerShift.TimeEnd;
        }

        private void aceptCancelButtonBar1_ClickOkCancelEvent(object sender, DialogResult result)
        {
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                if ( this.State == Fwk.Bases.EntityUpdateEnum.NEW)
                {
                    _SchedulerShiftOriginal = new ResourceSchedulingBE();
                    Set_SchedulerShift(_SchedulerShiftOriginal);
                    ValidateControls(_SchedulerShiftOriginal);
                    if (dxErrorProvider1.HasErrors) return;

                    if (!ValidateIntersection(_SchedulerShiftOriginal))
                    {
                        MessageBox.Show("Esta programación de turnos se superpone con turnos existentes", "Programación de turnos del profesional");
                        return;
                    }

                }

                if (this.State == Fwk.Bases.EntityUpdateEnum.UPDATED)
                {

                    Set_SchedulerShift(_SchedulerShiftCopy);
                    if (HasChanges())
                    {
                        ValidateControls(_SchedulerShiftCopy);
                        if (dxErrorProvider1.HasErrors) return;

                        if (!ValidateIntersection(_SchedulerShiftCopy))
                        {
                            MessageBox.Show("Esta programacion de turnos se superpone con turnos existentes", "Programación de turnos del profesional");
                            return;
                        }
                        Set_SchedulerShift(_SchedulerShiftOriginal);
                    }
                }
            }
            this.DialogResult = result;
            this.Close();
        }

        private void durationEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TimeSpan t = (TimeSpan)durationEdit1.EditValue;
                UpdateCombo(t.TotalMinutes, true);    
            }
            catch{}
            
        }

        private void frmResouceScheduling_Load(object sender, EventArgs e)
        {
            UpdateCombo(60,false);
            if(this.State == Fwk.Bases.EntityUpdateEnum.UPDATED)
                Set_Controls(_SchedulerShiftOriginal);
        }

        void UpdateCombo(double duration,bool maintainingPosition)
        {
            var x = ResourceSchedulingBE.Get_ArrayOfTimes(DateTime.Now, TimeSpan.Parse("00:00"), TimeSpan.Parse("24:0:0"), duration, "Turno tarde");
            timespamViewBindingSource.DataSource = x;
            bindingSource1.DataSource = x;
            cmbTimeStart.Refresh();

            cmbTimeEnd.Refresh();
            if (maintainingPosition) return;
            int index = cmbTimeStart.Properties.GetDataSourceRowIndex("TimeString", "09:00");
            cmbTimeStart.ItemIndex = index;
            index = cmbTimeEnd.Properties.GetDataSourceRowIndex("TimeString", "18:00");
            cmbTimeEnd.ItemIndex = index;
        }
        void ValidateControls(ResourceSchedulingBE pResourceSchedulingBE)
        {
            dxErrorProvider1.ClearErrors();
            if (String.IsNullOrEmpty(pResourceSchedulingBE.Description))
            {
                dxErrorProvider1.SetErrorType(txtNombre, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                   dxErrorProvider1.SetError(txtNombre, "Valor requerido");
            }
            if (pResourceSchedulingBE.TimeStart_timesp > pResourceSchedulingBE.TimeEnd_timesp)
            {
                dxErrorProvider1.SetErrorType(cmbTimeStart, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                dxErrorProvider1.SetError(cmbTimeStart, "La hora de inicio debe ser anterior a la hora de finalización del turno");
               
            }
            
        }

        /// <summary>
        /// Valida la overlaping de horarios
        /// Si todo esta bien returna True
        /// </summary>
        /// <param name="pResourceSchedulingBE"></param>
        /// <returns></returns>
        Boolean ValidateIntersection(ResourceSchedulingBE pResourceSchedulingBE)
        {

            

            TimeInterval interva1 = null;
            TimeInterval interva2 = null;

            interva2 = new TimeInterval(
                Fwk.HelperFunctions.DateFunctions.BeginningOfTimes.AddHours(pResourceSchedulingBE.TimeStart_timesp.TotalHours),
                Fwk.HelperFunctions.DateFunctions.BeginningOfTimes.AddHours(pResourceSchedulingBE.TimeEnd_timesp.TotalHours));

            foreach (ResourceSchedulingBE r in ResourceSchedulingList.Where(p=>!p.IdSheduler.Equals(pResourceSchedulingBE.IdSheduler)))
            {

                //Si no hay dias en comun no hay problema
                if (!r.HasDaysInCommon(pResourceSchedulingBE.WeekDays_BinArray))
                {
                    return true;
                }
                //Si tienen dias en comun hay que verificar que no se overlapen los horarios
                 interva1 = new TimeInterval(
                     Fwk.HelperFunctions.DateFunctions.BeginningOfTimes.AddHours(r.TimeStart_timesp.TotalHours),
                     Fwk.HelperFunctions.DateFunctions.BeginningOfTimes.AddHours(r.TimeEnd_timesp.TotalHours));


                if (interva1.IntersectsWithExcludingBounds(interva2))
                    return false;

                //bool val3 = interva1.IntersectsWith(interva2);
            }
            return true;

        }

       

        private void chboxEveryWeek_CheckedChanged(object sender, EventArgs e)
        {
            if (chboxEveryWeek.Checked)
                weekDaysCheckEdit1.WeekDays = WeekDays.EveryDay;

        }
    }


}
