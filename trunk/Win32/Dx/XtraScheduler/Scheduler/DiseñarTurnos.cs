using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Scheduler
{
    public partial class DiseñarTurnos : Form
    {

        ResourceSchedulingBE currentShiftSheduling;
        List<ResourceSchedulingBE> list = new List<ResourceSchedulingBE>();
        public DiseñarTurnos()
        {
            InitializeComponent();
            


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
            using (frmShiftsControls frm = new frmShiftsControls())
            {
                frm.ShiftSchedulingList = list;
                frm.ShowDialog();
            }
          
        }

        GridHitInfo _HitInfo = null;
        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {

            //  if (e.Button != MouseButtons.Right) return;
            _HitInfo = gridView1.CalcHitInfo(new Point(e.X, e.Y));
            currentShiftSheduling = ((ResourceSchedulingBE)gridView1.GetRow(_HitInfo.RowHandle));
    
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            using (frmShiftsControls frm = new frmShiftsControls())
            {
                frm.ShiftSchedulingList = list;
                frm.ShowDialog();
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            

        }
    }

    

   
}
