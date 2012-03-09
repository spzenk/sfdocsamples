using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class frmResouceScheduling : Form
    {
        
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
            

            SchedulerShift.WeekDays = (int)weeklyRecurrenceControl1.RecurrenceInfo.WeekDays;
            //DateTime d = Convert.ToDateTime(timeEdit_From.EditValue);

            SchedulerShift.TimeStart = (TimeSpan)cmbTimeStart.EditValue;
            //SchedulerShift.TimeStart = d.TimeOfDay;
            //d = Convert.ToDateTime(timeEdit_To.EditValue);
            //SchedulerShift.TimeEnd = d.TimeOfDay;
            SchedulerShift.TimeEnd = (TimeSpan)cmbTimeEnd.EditValue;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Set_SchedulerShift();
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
          
            var x = ResourceSchedulingBE.Get_ArrayOfTimes(DateTime.Now, TimeSpan.Parse("00:00"), TimeSpan.Parse("24:0:0"), (double)duration);
            timespamViewBindingSource.DataSource = x;
            bindingSource1.DataSource = x;
            cmbTimeStart.Refresh();

            cmbTimeEnd.Refresh();

            int index = cmbTimeStart.Properties.GetDataSourceRowIndex("TimeString", "09:00");
            cmbTimeStart.ItemIndex = index;
            index = cmbTimeEnd.Properties.GetDataSourceRowIndex("TimeString", "18:00");
            cmbTimeEnd.ItemIndex = index;
        }


    }


}
