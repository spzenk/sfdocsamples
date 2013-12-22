using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Health.BE;
using Fwk.Caching;

namespace Health.Front.Environment
{
    public partial class frmRegisterHealth : frmBase_Dialog
    {
        public bool RegisterOk { get; set; }
        FwkSimpleStorageBase<ClientUserSettings> _Storage;

        public frmRegisterHealth()
        {
            RegisterOk = false;
            InitializeComponent();
        }
        public frmRegisterHealth(FwkSimpleStorageBase<ClientUserSettings> storage)
        {
            RegisterOk = false;
            _Storage = storage;
            InitializeComponent();
        }

        private void aceptCancelButtonBar1_ClickOkCancelEvent(object sender, DialogResult result)
        {
            this.Close();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                HealthInstitutionBE wHealthInstitutionBE = Controller.ValidateActivationCode(txtCode.Text.Trim());

                _Storage.StorageObject.HealthInstitutionId = wHealthInstitutionBE.HealthInstitutionId;
                _Storage.StorageObject.ActivationKey = txtCode.Text.Trim();
                _Storage.Save();

                txtRazonSocial.Text = wHealthInstitutionBE.RazonSocial;

                RegisterOk = true;
            }
            catch (Exception ex)
            {
                this.ExceptionViewer.Show(ex);
            }
        }


    }
}