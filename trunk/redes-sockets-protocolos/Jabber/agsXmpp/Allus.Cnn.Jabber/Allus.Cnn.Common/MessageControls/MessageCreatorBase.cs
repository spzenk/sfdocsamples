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
    public  partial class MessageCreatorBase : UserControlBase
    {
        public MessageCreatorBase()
        {
            InitializeComponent();
        }
        

        private void MessageCreatorBase_Load(object sender, EventArgs e)
        {
  
        }
       /// <summary>
       /// Rellena el mensaje con los datos del user control teniendo en cuenta el tipo referido.-
       /// </summary>
       /// <param name="pMessage"></param>
        internal virtual void FillMessage(AlertMessage pMessage) { }

        /// <summary>
        /// Retorna true si ningun control contiene datos.- 
        /// Sirve par adeterminar si el user control se encuentra en estado No Modificado o
        /// sin intencion del usuario de haber ingresado datos.-
        /// </summary>
        /// <returns></returns>
        internal virtual bool IsEmpty() { return true; }

        /// <summary>
        /// Lmpia los controles preparando el control de mensajes para un nuevo mensaje
        /// </summary>
        internal virtual void ClearControls() {  }
    }
}
