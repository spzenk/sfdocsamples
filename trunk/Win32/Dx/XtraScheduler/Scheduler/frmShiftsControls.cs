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
    public partial class frmShiftsControls : Form
    {
        internal List<ResourceSchedulingBE> ShiftSchedulingList
        {
            get { return uc_ShiftsControls1.ShiftSchedulingList; }
            set { uc_ShiftsControls1.ShiftSchedulingList = value; }
        }
        public frmShiftsControls()
        {
            InitializeComponent();
        }
    }
}
