using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Health.Front.Environment
{
    public partial class frmHealthInst_Info : frmBase_Dialog
    {
        public frmHealthInst_Info()
        {
            InitializeComponent();
        }

       

        private void frmHealthInst_Info_Load(object sender, EventArgs e)
        {
            lblbRazonSocial.Text = ServiceCalls.CurrentHealthInstitution.RazonSocial;
            lblDesc.Text = ServiceCalls.CurrentHealthInstitution.Description;

            //TODO: Set CurrentHealthInstitution Type
            lblTipo.Text = "Centro de salud";
        }
    }
}