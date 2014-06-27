using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Health.BE;

namespace Health.Front.Personas
{
    [ToolboxItem(true)]
    public partial class uc_PatientCard : Xtra_UC_Base
    {
        public uc_PatientCard()
        {
            InitializeComponent();

            txtDocumento.RightToLeft = System.Windows.Forms.RightToLeft.No;
            txtNombres.RightToLeft = System.Windows.Forms.RightToLeft.No;
        }

        public override void Populate(object filter)
        {

           

        }

    }
}
