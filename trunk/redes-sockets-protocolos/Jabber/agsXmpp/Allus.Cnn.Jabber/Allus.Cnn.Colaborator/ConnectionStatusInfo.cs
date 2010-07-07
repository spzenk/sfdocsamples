using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Allus.Cnn.Colaborator
{
    [ToolboxItem(true)]
    public partial class ConnectionStatusInfo : Allus.Cnn.Common.UserControlBase
    {
        StringBuilder strMessageLogs = new StringBuilder();
        public ConnectionStatusInfo()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            strMessageLogs = null;
            strMessageLogs = new StringBuilder();
            txtMessageLogger.Text = string.Empty;
            lblConnectionStatus.Text = string.Empty;

        }
        public void AddMessage(string status, string msg)
        {
          
            if (!string.IsNullOrEmpty(msg))
            {
                strMessageLogs.AppendLine(msg);
                txtMessageLogger.Text = strMessageLogs.ToString();
            }
            lblConnectionStatus.Text = status;
            lblConnectionStatus.Text = status;
       
        }
    }
}
