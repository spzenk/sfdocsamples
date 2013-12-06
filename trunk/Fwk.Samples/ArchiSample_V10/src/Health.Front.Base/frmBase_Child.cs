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
    public partial class frmBase_Child : Fwk.UI.Forms.FormMDIChildBase
    {
        public Fwk.Bases.EntityUpdateEnum State = Fwk.Bases.EntityUpdateEnum.NEW;

        public frmBase_Child()
        {
            InitializeComponent();
        }
        internal void SetDialogsToDefault()
        {
            this.MessageViewer.MessageBoxButtons = MessageBoxButtons.OK;
            this.MessageViewer.MessageBoxIcon = Fwk.UI.Common.MessageBoxIcon.Information;
        }
    }
}
