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
    public partial class DiseñarTurnos : Form
    {
        ResourceSchedulingBE _ResourceScheduling =null;
        List<ResourceSchedulingBE> list = new List<ResourceSchedulingBE>();
        public DiseñarTurnos()
        {
            InitializeComponent();
            dateEdit1.DateTime = System.DateTime.Now;


        }

       
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            using (frmResouceScheduling frm = new frmResouceScheduling())
            {
                frm.ResourceSchedulingBEList = list;
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    list.Add(frm.SchedulerShift);
                    schedulerShiftBindingSource.DataSource = list;
                    gridControl1.RefreshDataSource();
                }
            }
           
            
            //bool x = _ResourceScheduling.Date_IsContained(dateEdit1.DateTime);
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {


        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            List<TimespamView> s = _ResourceScheduling.Get_ArrayOfTimes(System.DateTime.Now);
            timespamViewBindingSource.DataSource = s;
            gridControl2.RefreshDataSource();
        }
    }

    

   
}
