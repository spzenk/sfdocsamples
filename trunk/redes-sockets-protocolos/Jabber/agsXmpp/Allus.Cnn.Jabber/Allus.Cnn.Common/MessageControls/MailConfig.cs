using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Allus.Cnn.Common
{
    public partial class MailConfig : frmBaseDialog
    {
        public string UserName
        {
            get { return txtEmail.Text; }
            set { txtEmail.Text = value; }
        }

        public string Password
        {
            get { return txtPassword.Text; }
        }

        public MailConfig()
        {
            InitializeComponent();            
        }

        public MailConfig(bool mailInit)
        {
            InitializeComponent();

            if (mailInit== false)
            {
                labelControl3.Text = "La dirección de correo electrónico ingresada y/o contraseña no pertenecen a un usuario válido";
                txtEmail.Text = txtEmail.Text;
                this.imgMessage.Image = global::Allus.Cnn.Common.Properties.Resources.web_mail_close_32;                
            }            
        }
        

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                dxErrorProvider1.SetError(txtPassword, "Debe ingresar una clave");
                return;
            }
            dxErrorProvider1.SetError(txtPassword, String.Empty);
        }
           
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {

            if (!Fwk.HelperFunctions.EMailFunctions.MailAddressValidate(txtEmail.Text))

            {
                dxErrorProvider1.SetError(txtEmail, "Dirección de correo electrónico no válida");
                return;
              
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                dxErrorProvider1.SetError(txtEmail, "Debe ingresar una dirección de correo electrónico");
                return;
            }
            dxErrorProvider1.SetError(txtEmail, String.Empty);
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (dxErrorProvider1.HasErrors)
            { 
                this.MessageViewer.Show("Los datos del correo electrónico deben ser correctos");
                
                return;
            }
            this.DialogResult = DialogResult.OK;
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
        
    }
}
