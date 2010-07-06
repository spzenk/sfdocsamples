using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Allus.Cnn.Common.BE;

namespace Allus.Cnn.Common
{
    [DefaultEvent("MessageControlClose")]
    public partial class ClientMessageControl : XtraUserControl
    {
        #region fields
        [Category("Allus.Libraries")]
        public event EventHandler MessageControlClose;
        #endregion


        public ClientMessageControl()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageControlClose != null) MessageControlClose(this, e);
        }

        private void MessageControl_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            lblTitle.ForeColor = Color.Chocolate;
        }

        private void groupBox1_Leave(object sender, EventArgs e)
        {
            lblTitle.ForeColor = Color.SteelBlue;
        }

        private void ClientMessageControl_Leave(object sender, EventArgs e)
        {

            lblTitle.ForeColor = Color.SteelBlue;
        }

        private void ClientMessageControl_Enter(object sender, EventArgs e)
        {

            lblTitle.ForeColor = Color.Chocolate;

        }

        public void Populate(AlertMessage alertMsg)
        {
            if (alertMsg == null) return;
            if (alertMsg.MessageType == MessageType.RichText)
                txtMessage.RtfText = alertMsg.Text;
            else
                txtMessage.Text = alertMsg.Text;

            lblTitle.Text = alertMsg.Title;
            //f Fecha y hora: viernes, 28 de Septiembre de 2007 11:04 
            lblDate.Text = String.Format("{0:f}", alertMsg.Date);
            imgMessageChecked.Visible = alertMsg.Read;
            if(alertMsg.Picture !=null)
            {
                imgMessage.Image = Fwk.HelperFunctions.TypeFunctions.ConvertByteArrayToImage(alertMsg.Picture);
            }
            if (string.IsNullOrEmpty(alertMsg.Url))
                hyperLink.Visible = false;
            else
            {
                hyperLink.Visible = true;
                hyperLink.Text = alertMsg.Url;
            }
        
        }
        public void SetChecked()
        {
            imgMessageChecked.Visible = true;
        }
    }
}
