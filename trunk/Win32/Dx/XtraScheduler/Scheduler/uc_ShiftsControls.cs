using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class uc_ShiftsControls : UserControl
    {


        internal List<ResourceSchedulingBE> ShiftSchedulingList { get; set; }
        public uc_ShiftsControls()
        {
            InitializeComponent();
            dateEdit1.DateTime = System.DateTime.Now;
        }


        public override void Refresh()
        {
            if (this.DesignMode) return;
            gridControl2.RefreshDataSource();
            base.Refresh();
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            if (ShiftSchedulingList == null) return;

            timespamViewBindingSource.DataSource = Get_ArrayOfTimes();
        }

        List<TimespamView> Get_ArrayOfTimes()
        {
            List<TimespamView> array = new List<TimespamView>();
            List<TimespamView> partialList = null;
            foreach (ResourceSchedulingBE ShiftScheduling in ShiftSchedulingList)
            {
                partialList = ShiftScheduling.Get_ArrayOfTimes(dateEdit1.DateTime, true);
                if (partialList != null)
                    array.AddRange(partialList);

            }
            return array;
        }

        private void gridView2_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {

        }

        public List<ResourceSchedulingBE> GetSelectedShifts()
        {
            foreach(int in  gridView2.GetSelectedRows())
            {

            }
        }
    }
}
