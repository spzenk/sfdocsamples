using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Health.Front.Events
{
    public partial class uc_pmo_grid_view : Xtra_UC_Base
    {
        public uc_pmo_grid_view()
        {
            InitializeComponent();
        }

        public override void Refresh()
        {
            if (this.Tag.Equals("CEI10"))
                medicalEventPMODiagListBindingSource.DataSource = ServiceCalls.RetriveMedicalEvent_PMO_Diad(ServiceCalls.CurrentPatient.PatientId,false,true,false);
            if (this.Tag.Equals("PMOMetodoComplementario"))
                medicalEventPMODiagListBindingSource.DataSource = ServiceCalls.RetriveMedicalEvent_PMO_Diad(ServiceCalls.CurrentPatient.PatientId, false, false    , true);
            if (this.Tag.Equals("PMOQuir"))
            {
                medicalEventPMODiagListBindingSource.DataSource = ServiceCalls.RetriveMedicalEvent_PMO_Diad(ServiceCalls.CurrentPatient.PatientId, true, false, false);
                this.lblTitle.Text = "Lista de practicas quirurgicas";
            }
            gridControl1.RefreshDataSource();
        }
    }
}
