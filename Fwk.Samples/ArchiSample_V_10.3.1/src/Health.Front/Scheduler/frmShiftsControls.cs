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

namespace Health.Front.Scheduler
{
    public partial class frmShiftsControls : frmBase_Dialog
    {
        internal ResourceSchedulingList ShiftSchedulingList
        {
            get { return uc_ShiftsControls1.ShiftSchedulingList; }
            set { uc_ShiftsControls1.ShiftSchedulingList = value; }
        }
        public frmShiftsControls()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            List<TimespamView> d = uc_ShiftsControls1.GetSelectedShifts();
        }

        private void dateNavigator1_EditDateModified(object sender, EventArgs e)
        {
            this.Cursor =  Cursors.WaitCursor;
            uc_ShiftsControls1.Date = dateNavigator1.DateTime;
            uc_ShiftsControls1.Refresh();
            this.Cursor = Cursors.Default;
        }
    }
}
