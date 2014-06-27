using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Health.Back.BE;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

using Fwk.UI.Forms;
using Health.BE;

namespace Health.Front
{
    public partial class FrmABMPatient : frmBase_Dialog
    {

        GridHitInfo _HitInfo = null;

        internal PatientBE Patient { get; set; }
        public FrmABMPatient()
        {
            InitializeComponent();

        }
        public FrmABMPatient(Fwk.Bases.EntityUpdateEnum state)
        {
            InitializeComponent();
            this.State = state;
        }

        public override void Refresh()
        {
            
          

   
        }
    
        private void FrmABMPatient_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            this.uc_Persona1.Init();
            this.Refresh();


        }

        private void btnAcept_Click(object sender, EventArgs e)
        {

        }

        

       

   


     


    }
}
