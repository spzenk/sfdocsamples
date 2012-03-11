using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;

namespace Scheduler
{
    public partial class frmResouceScheduling : Form
    {
        internal List<ResourceSchedulingBE> ResourceSchedulingBEList { get; set; }
        internal ResourceSchedulingBE SchedulerShift { get; set; }

        public frmResouceScheduling()
        {
            InitializeComponent();
            SchedulerShift = new ResourceSchedulingBE();
            
         
        }


        void Set_SchedulerShift()
        {
            SchedulerShift = new ResourceSchedulingBE();
            SchedulerShift.Nombre = txtNombre.Text;
            SchedulerShift.Duration = Convert.ToDecimal(durationEdit1.Duration.TotalMinutes);
            SchedulerShift.WeekDays = (int)weekDaysCheckEdit1.WeekDays;
            SchedulerShift.TimeStart = (TimeSpan)cmbTimeStart.EditValue;
            SchedulerShift.TimeEnd = (TimeSpan)cmbTimeEnd.EditValue;

            //SchedulerShift.TimeStart = d.TimeOfDay;
            //d = Convert.ToDateTime(timeEdit_To.EditValue);
            //SchedulerShift.TimeEnd = d.TimeOfDay;
            //DateTime d = Convert.ToDateTime(timeEdit_From.EditValue);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Set_SchedulerShift();
            ValidateControls(SchedulerShift);
            if (dxErrorProvider1.HasErrors) return;

            if (!ValidateIntersection(SchedulerShift))
            {
                MessageBox.Show("Problemas");
                return;
            }
            
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void durationEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
           UpdateCombo(((TimeSpan)durationEdit1.EditValue).TotalMinutes);
        }

        private void frmResouceScheduling_Load(object sender, EventArgs e)
        {
            UpdateCombo(60);
        }

        void UpdateCombo(double duration)
        {

            var x = ResourceSchedulingBE.Get_ArrayOfTimes(DateTime.Now, TimeSpan.Parse("00:00"), TimeSpan.Parse("24:0:0"), (double)duration, "Turno tarde");
            timespamViewBindingSource.DataSource = x;
            bindingSource1.DataSource = x;
            cmbTimeStart.Refresh();

            cmbTimeEnd.Refresh();

            int index = cmbTimeStart.Properties.GetDataSourceRowIndex("TimeString", "09:00");
            cmbTimeStart.ItemIndex = index;
            index = cmbTimeEnd.Properties.GetDataSourceRowIndex("TimeString", "18:00");
            cmbTimeEnd.ItemIndex = index;
        }
        void ValidateControls(ResourceSchedulingBE pResourceSchedulingBE)
        {
            if (pResourceSchedulingBE.TimeStart > pResourceSchedulingBE.TimeEnd)
            {
                dxErrorProvider1.SetErrorType(cmbTimeStart, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                dxErrorProvider1.SetError(cmbTimeStart, "La hora de inicio debe ser anterior a la hora de finalización del turno");
               
            }
            
        }
        Boolean ValidateIntersection(ResourceSchedulingBE pResourceSchedulingBE)
        {


            TimeInterval interva1 = null;
            TimeInterval interva2 = null;

            interva2 = new TimeInterval(
                Fwk.HelperFunctions.DateFunctions.BeginningOfTimes.AddHours(pResourceSchedulingBE.TimeStart.TotalHours),
                Fwk.HelperFunctions.DateFunctions.BeginningOfTimes.AddHours(pResourceSchedulingBE.TimeEnd.TotalHours));
            foreach (ResourceSchedulingBE r in ResourceSchedulingBEList)
            {
               
                 interva1 = new TimeInterval(
                     Fwk.HelperFunctions.DateFunctions.BeginningOfTimes.AddHours(r.TimeStart.TotalHours),
                     Fwk.HelperFunctions.DateFunctions.BeginningOfTimes.AddHours(r.TimeEnd.TotalHours));


                if (interva1.IntersectsWithExcludingBounds(interva2))
                    return false;

                //bool val3 = interva1.IntersectsWith(interva2);
            }
            return true;

        }
    }


}
