using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Allus.Cnn.Common.BE;

namespace Allus.Cnn.Common
{
    [ToolboxItem(false)]
    public partial class MessageCreatorSimple : MessageCreatorBase
    {
        public MessageCreatorSimple()
        {
            InitializeComponent();
        }

        internal override void FillMessage(AlertMessage pMessage)
        {
            pMessage.Text = txtMessageText.Text;

            pMessage.Title = txtTitle.Text;
            pMessage.Url = txtUrl.Text;
            pMessage.RequireConfirm = this.chkRequireConfirm.Checked;
            pMessage.MessageType = MessageType.SimpleText;
        }

        /// <summary>
        /// Retorna true si ningun control contiene datos.- 
        /// Sirve par adeterminar si el user control se encuentra en estado No Modificado o
        /// sin intencion del usuario de haber ingresado datos.-
        /// </summary>
        /// <returns></returns>
        internal override bool IsEmpty()
        {
            return (string.IsNullOrEmpty(txtMessageText.Text) &&
                string.IsNullOrEmpty(txtUrl.Text));
              
            
        }
        internal override void ClearControls()
        {
           txtMessageText.Text= String.Empty;

           txtTitle.Text = String.Empty;
           txtUrl.Text = String.Empty;
           this.chkRequireConfirm.Checked = false;
         
        }
    }
}
