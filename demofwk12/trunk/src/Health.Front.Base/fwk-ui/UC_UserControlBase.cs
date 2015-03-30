using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using System.Security.Principal;
using System.Web.Security;
using Fwk.UI.Forms;

namespace Fwk.UI.Controls
{

    /// <summary>
    /// User control base. Este componente base se utiliza como herencia de componentes de negocio (bussiness views) en los casos de uso
    /// </summary>
    [ToolboxItem(false)]
    public partial class UC_UserControlBase : DevExpress.XtraEditors.XtraUserControl
    {
        #region Properties
        private Button _acceptButton;
        private Button _cancelButton;

        public event EventHandler<EventArgs> AcceptEvent;
        public event EventHandler<EventArgs> CancelEvent;

        [Browsable(true)]
        public Button AcceptButton
        {
            get { return _acceptButton; }
            set { _acceptButton = value; }
        }

        [Browsable(true)]
        public Button CancelButton
        {
            get { return _cancelButton; }
            set { _cancelButton = value; }
        }
        #endregion

        public UC_UserControlBase()
        {
            InitializeComponent();
        }


        protected virtual void OnAcceptEvent(EventArgs args)
        {
            if (AcceptEvent != null)
                AcceptEvent(this, args);
        }

        protected virtual void OnCancelEvent(EventArgs args)
        {
            if (CancelEvent != null)
                CancelEvent(this, args);
        }

        /// <summary>
        ///  Establece el MessageViewer a sus valores por defecto (inforamcion y boton OK)
        /// </summary>
        protected void SetMessageViewInfoDefault()
        {
            MessageViewer.MessageBoxIcon = Fwk.UI.Common.MessageBoxIcon.Information;
            MessageViewer.MessageBoxButtons = MessageBoxButtons.OK;
        }

        #region Authorization Factory

       

        /// <summary>
        /// intenta autorizar el usuario registrado para la regla pasada por parametrio
        /// </summary>
        /// <param name="pRuleName">Nombre de la regla</param>
        /// <returns></returns>
        public static bool CheckRule(string pRuleName)
        {
            return FormBase.CheckRule(pRuleName);
        }
        #endregion
    }
}