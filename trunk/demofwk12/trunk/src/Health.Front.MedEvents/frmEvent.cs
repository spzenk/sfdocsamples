using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.UI.Common;

namespace Health.Front.Events
{
    public partial class frmEvent : frmBase_Dialog
    {
        public int MedicalEventId { get; set; }
        public frmEvent()
        {
            InitializeComponent();
            aceptCancelButtonBar1.AceptButtonVisible = false;
        }

        public override void Refresh()
        {
            using (WaitCursorHelper w = new WaitCursorHelper(this))
            {
                this.uc_event_view1.MedicalEventId = this.MedicalEventId;
                this.uc_event_view1.Populate(null);
                base.Refresh();
            }
        }

        private void aceptCancelButtonBar1_ClickOkCancelEvent(object sender, DialogResult result)
        {
            this.Close();
        }
    }
}
