using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using System.Security.Principal;


namespace Allus.Cnn.Common
{
    [ToolboxItem(false)]
    public partial class UserControlBase : DevExpress.XtraEditors.XtraUserControl
    {
   
        public UserControlBase()
        {
            InitializeComponent();
            
        }
        protected void SetMessageViewInfoDefault()
        {
            MessageViewer.MessageBoxIcon = Allus.Libs.Common.MessageBoxIcon.Information;
            MessageViewer.MessageBoxButtons = MessageBoxButtons.OK;
        }
        
    }
}
