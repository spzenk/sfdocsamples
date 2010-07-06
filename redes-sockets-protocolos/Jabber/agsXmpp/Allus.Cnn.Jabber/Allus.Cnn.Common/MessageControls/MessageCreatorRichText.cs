using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Allus.Cnn.Common
{
    public partial class MessageCreatorRichText : MessageCreatorBase
    {
        public MessageCreatorRichText()
        {
            InitializeComponent();
        }
        internal override void FillMessage(Allus.Cnn.Common.BE.AlertMessage pMessage)
        {
            pMessage.Text = this.richEditSimpleControl1.RtfText;
            pMessage.TextNoRtf = richEditSimpleControl1.Text;
            pMessage.Title = this.txtTitle.Text;
            pMessage.Url = this.txtUrl.Text;
            pMessage.MessageType = MessageType.RichText;
            pMessage.RequireConfirm = chkRequireConfirm.Checked;

        }

        /// <summary>
        /// Retorna true si ningun control contiene datos.- 
        /// Sirve par adeterminar si el user control se encuentra en estado No Modificado o
        /// sin intencion del usuario de haber ingresado datos.-
        /// </summary>
        /// <returns></returns>
        internal override bool IsEmpty()
        {
            return (string.IsNullOrEmpty(richEditSimpleControl1.Text) &&
                string.IsNullOrEmpty(txtUrl.Text));


        }
        internal override void ClearControls()
        {
            this.richEditSimpleControl1.Text = String.Empty;
            richEditSimpleControl1.Refresh();
            txtTitle.Text = String.Empty;
            txtUrl.Text = String.Empty;
            this.chkRequireConfirm.Checked = false;

        }

        private void richEditSimpleControl1_Load(object sender, EventArgs e)
        {
      

        }
    }
}
