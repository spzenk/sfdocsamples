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
            SchedulerShift.Duration = (int)Convert.ToInt32(durationEdit1.Duration.TotalMinutes);
            SchedulerShift.WeekDays = (int)weeklyRecurrenceControl1.RecurrenceInfo.WeekDays;
            DateTime d = Convert.ToDateTime(timeEdit_From.EditValue);
            //_SchedulerShift.Star =  System.TimeSpan.Parse(String.Format"{0}:{0}:{0}")
            SchedulerShift.TimeStart = d.TimeOfDay;
            d = Convert.ToDateTime(timeEdit_To.EditValue);
            SchedulerShift.TimeEnd = d.TimeOfDay;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Set_SchedulerShift();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

    }


}
