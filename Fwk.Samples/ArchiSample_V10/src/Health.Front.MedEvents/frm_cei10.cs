using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Health.Front
{
    public partial class frm_cei10 : frmBase_Dialog
    {
        public frm_cei10()
        {
            InitializeComponent();
        }

        private void frm_cei10_Load(object sender, EventArgs e)
        {
            this.uc_CEI10_Tree1.Refresh();
        }
    }
}
