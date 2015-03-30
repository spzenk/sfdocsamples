using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Health.Entities;
using Fwk.HelperFunctions;
using Health.Back.BE;
using Health.Back;
using System.Drawing.Imaging;
using Health.BE;
using Fwk.UI.Forms;
using Health.BE.Enums;


namespace Health.Front.Patients
{
    public partial class uc_Persona : UserControl
    {
        DateTime? _AnteriorFechaNacimiento;
        public DateTime? AnteriorFechaNacimiento
        {
            get
            {
                if (!_AnteriorFechaNacimiento.HasValue)
                    return _AnteriorFechaNacimiento;
                if (_AnteriorFechaNacimiento.Equals(Persona.FechaAlta))
                    return null;

                return _AnteriorFechaNacimiento;
            }

        }

        Fwk.Bases.EntityUpdateEnum State = Fwk.Bases.EntityUpdateEnum.NEW;
        ParametroList EstadoCivilList = new ParametroList();
        public event EventHandler PersonaChanged;


        internal PersonaBE Persona;

        public uc_Persona()
        {
            InitializeComponent();
            txtApellido.RightToLeft = System.Windows.Forms.RightToLeft.No;
            txtDocumento.RightToLeft = System.Windows.Forms.RightToLeft.No;
            txtNombres.RightToLeft = System.Windows.Forms.RightToLeft.No;
        }

        internal void Init()
        {


            if (ServiceCalls.IsInDesignMode()) return;
            EstadoCivilList.AddRange(ServiceCalls.EstadoCivilList.Where<ParametroBE>(p => p.IdParametro != (int)CommonValuesEnum.TodosComboBoxValue));
            cmbEstadoCivil.Properties.DataSource = EstadoCivilList;

            cmbTipoDoc.Properties.DataSource = ServiceCalls.SearchParametroByParams((int)TipoParametroEnum.TipoDocumento, null);

            cmbEstadoCivil.Refresh();
            cmbTipoDoc.Refresh();



        }



        private void rndSexoM_CheckedChanged(object sender, EventArgs e)
        {
            if (this.pictureEdit1.EditValue != null) return;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Clip;
            if (rndSexoM.Checked)
                this.pictureEdit1.EditValue = global::Health.Front.Base.Properties.Resource.User_M;
            else
                this.pictureEdit1.EditValue = global::Health.Front.Base.Properties.Resource.User_F;
        }

        public bool HasErrors()
        {
            dxErrorProvider1.ClearErrors();
            if (String.IsNullOrEmpty(txtNombres.Text))
            {
                dxErrorProvider1.SetError(txtNombres, "Ingerse nombre");
                return dxErrorProvider1.HasErrors;
            }
            if (String.IsNullOrEmpty(txtApellido.Text))
            {
                dxErrorProvider1.SetError(txtApellido, "Ingerse apellido");
                return dxErrorProvider1.HasErrors;
            }
            if (String.IsNullOrEmpty(txtDocumento.Text))
            {
                dxErrorProvider1.SetError(txtDocumento, "Ingerse documento");
                return dxErrorProvider1.HasErrors;
            }


            if (cmbEstadoCivil.EditValue == null)
                dxErrorProvider1.SetError(cmbEstadoCivil, "Debe seleccionar estado civil");


            return dxErrorProvider1.HasErrors;

        }

        Image intermedialImage;
        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            string imgFileName = Fwk.HelperFunctions.FileFunctions.OpenFileDialog_Open(FileFunctions.OpenFilterEnums.OpenImageFilter);
            if (String.IsNullOrEmpty(imgFileName))
                return;
            intermedialImage = Image.FromFile(imgFileName);
            if (intermedialImage == null) return;
            pictureEdit1.Image = Common.ImageChangeSize(intermedialImage, 200, 250);

            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;

            //Byte[] img1 = Fwk.HelperFunctions.TypeFunctions.ConvertImageToByteArray( pictureEdit1.Image , ImageFormat.Jpeg); ;
            //Byte[] img2 = Fwk.HelperFunctions.TypeFunctions.ConvertImageToByteArray(intermedialImage, ImageFormat.Jpeg);

        }



        internal void Populate(PersonaBE persona, Fwk.Bases.EntityUpdateEnum state)
        {
            Persona = persona;
            State = state;

            _AnteriorFechaNacimiento = persona.FechaNacimiento;

            txtApellido.Text = Persona.Apellido;
            txtNombres.Text = Persona.Nombre;
            txtDocumento.Text = Persona.NroDocumento;
            cmbTipoDoc.EditValue = Persona.TipoDocumento;
            if (Persona.Foto != null)
            {
                this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
                pictureEdit1.Image = Fwk.HelperFunctions.TypeFunctions.ConvertByteArrayToImage(Persona.Foto);
            }

            if (Persona.Foto == null)
                this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Clip;
            if (Persona.Sexo.Equals((Int16)Sexo.Masculino))
            {
                rndSexoM.Checked = true;
                if (Persona.Foto == null)
                    pictureEdit1.Image = Health.Front.Base.Properties.Resource.User_M;
            }
            else
            {
                rndSexoF.Checked = true;
                if (Persona.Foto == null)
                    pictureEdit1.Image = Health.Front.Base.Properties.Resource.User_F;
            }


            int index = 0;
            if (State == Fwk.Bases.EntityUpdateEnum.NEW)
            {
                dtFechaNac.EditValue = DateTime.Now;
                index = cmbTipoDoc.Properties.GetDataSourceRowIndex("IdParametro", "610");
                cmbTipoDoc.ItemIndex = index;
            }
            else
            {
                dtFechaNac.EditValue = Persona.FechaNacimiento;
                index = cmbEstadoCivil.Properties.GetDataSourceRowIndex("IdParametro", Persona.IdEstadocivil);
                cmbEstadoCivil.ItemIndex = index;

                index = cmbTipoDoc.Properties.GetDataSourceRowIndex("IdParametro", Persona.TipoDocumento);
                cmbTipoDoc.ItemIndex = index;

                btnBuscar.Visible = false;
            }

            //bool admin_person_abm = FormBase.CheckRule("admin_person_edit_info");
            //cmbEstadoCivil.Enabled = admin_person_abm;
            //cmbTipoDoc.Enabled = admin_person_abm;
            //txtNombres.Enabled = admin_person_abm;
            //txtApellido.Enabled = admin_person_abm;
            //txtDocumento.Enabled = admin_person_abm;

            //rndSexoF.Enabled = admin_person_abm;
            //rndSexoM.Enabled = admin_person_abm;
            //pictureEdit1.Enabled = admin_person_abm;

            //btnBuscar.Enabled = admin_person_abm;
            //dtFechaNac.Enabled = admin_person_abm;
        }




        internal void SetPersona()
        {
            if (HasErrors()) return;
            if ((int)cmbEstadoCivil.EditValue != (int)CommonValuesEnum.SeleccioneUnaOpcion)
                Persona.IdEstadocivil = Convert.ToInt32(cmbEstadoCivil.EditValue);

            if (cmbTipoDoc.EditValue != null)
                Persona.TipoDocumento = cmbTipoDoc.EditValue.ToString();

            Persona.Apellido = txtApellido.Text;
            Persona.Nombre = txtNombres.Text;
            Persona.FechaNacimiento = dtFechaNac.DateTime;
            Persona.NroDocumento = txtDocumento.Text;
            if (intermedialImage != null)
                Persona.Foto = Fwk.HelperFunctions.TypeFunctions.ConvertImageToByteArray(intermedialImage, ImageFormat.Jpeg);
            if (rndSexoM.Checked)
                Persona.Sexo = Convert.ToInt16(Sexo.Masculino);
            else
                Persona.Sexo = Convert.ToInt16(Sexo.Femenino);


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (frmFindPerosnas f = new frmFindPerosnas())
            {
                f.Refresh();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    Persona = f.SelectedPersona;

                    Populate(Persona, Fwk.Bases.EntityUpdateEnum.UPDATED);

                    PersonaChanged(this, new EventArgs());
                }
            }
        }




    }
}

