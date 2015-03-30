using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Health.BE;
using Health.BE.Enums;

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

           PatientBE patient = (PatientBE)filter;

            if (ServiceCalls.IsInDesignMode()) return;

            cmbTipoDoc.Properties.DataSource = ServiceCalls.SearchParametroByParams((int)TipoParametroEnum.TipoDocumento, null);

            cmbTipoDoc.Refresh();

            txtNombres.Text = patient.Persona.ApellidoNombre;
            txtDocumento.Text = patient.Persona.NroDocumento;
            cmbTipoDoc.EditValue = patient.Persona.TipoDocumento;
            if (patient.Persona.Foto != null)
            {
                this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
                pictureEdit1.Image = Fwk.HelperFunctions.TypeFunctions.ConvertByteArrayToImage(patient.Persona.Foto);
            }

            if (patient.Persona.Foto == null)
                this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Clip;
            if (patient.Persona.Sexo.Equals((Int16)Sexo.Masculino))
            {
                rndSexoM.Checked = true;
                if (patient.Persona.Foto == null)
                    pictureEdit1.Image = Health.Front.Base.Properties.Resource.User_M;
            }
            else
            {
                rndSexoF.Checked = true;
                if (patient.Persona.Foto == null)
                    pictureEdit1.Image = Health.Front.Base.Properties.Resource.User_F;
            }


            int index = 0;

            //txtDocumento.Enabled = false;
            //cmbTipoDoc.Enabled = false;
            dtFechaNac.EditValue = patient.Persona.FechaNacimiento;


            index = cmbTipoDoc.Properties.GetDataSourceRowIndex("IdParametro", patient.Persona.TipoDocumento);
            cmbTipoDoc.ItemIndex = index;

        }

    }
}
