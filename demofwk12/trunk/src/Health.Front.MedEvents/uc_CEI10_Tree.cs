using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Health.Front
{
    [ToolboxItem(true)]
    public partial class uc_CEI10_Tree : UserControl
    {
        public uc_CEI10_Tree()
        {
            InitializeComponent();
        }
        public override void Refresh()
        {
            this.cEI10GridListBindingSource.DataSource = ServiceCalls.CEI_10List;
            gridControl1.RefreshDataSource();
            base.Refresh();
        }
    }
}
