using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Fwk.UI.Forms;
using Fwk.UI.Security.ServiceCalls;
using Fwk.Security.Common;

namespace Fwk.UI.Security.Controls
{
    public partial class FRM_UserChangePassword : FormDialogBase
    {
        public string UserName {get;set;}
        public FRM_UserChangePassword()
        {
            InitializeComponent();
        }
      

        public void Populate(string pUserName)
        {
            //Seteamos la property UserName del UserControl
            UserName = pUserName;
        }
 

        private void aceptCancelButtonBar1_ClickOkCancelEvent(object sender, DialogResult result)
        {
            if (result == System.Windows.Forms.DialogResult.Cancel)
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            if (ChangePassword())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }

        }

        public bool ChangePassword()
        {
            //Validamos que no haya errores en el UserControl
            if (!dxErrorProvider1.HasErrors && ValidateUC())
            {
                using (WaitCursorHelper waitn = new WaitCursorHelper(this))
                {
                    //Cambiamos el Password
                    try
                    {
                        SecurityServiceCalls.UserChangePassword(UserName, txtOldPassword.Text, txtNewPassword.Text);
                        MessageViewer.Show("Su contraseña fue cambiada exitosamente");
                    }
                    catch (Exception ex)
                    {
                        this.ExceptionViewer.Show(ex);
                        return false;
                    }
                }
                return true;
            }
            else
                return false;
        }


        public bool ValidateUC()
        {
            return (txtOldPassword.ValidateValue() & txtNewPassword.ValidateValue() & txtPasswordConfirm.ValidateValue());
        }

        private void txtPasswordConfirm_Validating(object sender, CancelEventArgs e)
        {
            if (!String.Equals(txtNewPassword.Text, txtPasswordConfirm.Text))
                dxErrorProvider1.SetError(txtPasswordConfirm, "La nueva contraseña y su confirmación no coinciden");
            else
                dxErrorProvider1.SetError(txtPasswordConfirm, "");
        }

    }
}
