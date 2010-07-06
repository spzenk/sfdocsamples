using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Allus.Cnn.Common
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MessageBase : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// 
        /// </summary>
        private string _Message = String.Empty;

        public virtual string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public MessageBase()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void FrmMsgBase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        
    }
}