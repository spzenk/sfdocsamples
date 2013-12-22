using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Health.Back.BE;
using Health.Isvc.GetPatient;
using System.Runtime.Remoting.Messaging;

namespace Health.Front
{
    public partial class frmGridPatients : frmBase_Dialog
    {
        //TODO: Ver si se usa Mutuales
        internal BE.MutualPorPacienteList Mutuales { get; set; }
        internal BE.PatientBE SelectedPatientBE { get; set; }
        internal bool AllowEditPatient = false;

        public frmGridPatients()
        {
            InitializeComponent();
        }

        public override void Refresh()
        {
            uc_PatientsGrid1.PopulateAsync();


            base.Refresh();
        }





        private void aceptCancelButtonBar1_ClickOkCancelEvent(object sender, DialogResult result)
        {
            SelectedPatientBE = uc_PatientsGrid1.SelectedPatientBE;
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                if (SelectedPatientBE == null)
                {
                    MessageViewer.Show("Seleccione algun Patient o precione ESC");
                    return;
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            this.Close();
        }


        private void btnCreatePatient_Click(object sender, EventArgs e)
        {
            using (FrmABMPatient frm = new FrmABMPatient())
            {

                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Refresh();
                }
            }
        }

        private void uc_PatientsGrid1_OnDoubleClickEvent(object sender, EventArgs e)
        {
            if (uc_PatientsGrid1.SelectedPatientBE == null) return;

            SelectedPatientBE = uc_PatientsGrid1.SelectedPatientBE;

            if (State == Fwk.Bases.EntityUpdateEnum.UPDATED)
            {
                using (FrmABMPatient frm = new FrmABMPatient(Fwk.Bases.EntityUpdateEnum.UPDATED))
                {
                    frm.Patient = SelectedPatientBE;
                    frm.Refresh();
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {

                    }
                }
                return;
            }
            //if (State == Fwk.Bases.EntityUpdateEnum.UPDATED)
            //{
            //    this.Mutuales = Controller.GetPatient_Mutuals(SelectedPatientBE.IdPatient);

            //}

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();

        }


    }
}
