using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Health.Back.BE;
using Health.BE;


namespace Health.Front.Personas
{
    public partial class uc_MedioContacto : UserControl
    {
        internal PersonaBE Persona = null;
        public uc_MedioContacto()
        {
            InitializeComponent();
            txtBarrio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            txtCalle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            txtPiso.RightToLeft = System.Windows.Forms.RightToLeft.No;
            txtNro.RightToLeft = System.Windows.Forms.RightToLeft.No;
            txtTel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            txtTel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
        }



        internal void Init()
        {
            txtBarrio.Text = Persona.Barrio;
            txtCalle.Text = Persona.Calle;
            txtEmail.Text = Persona.mail;
            txtPiso.Text = Persona.Piso;
            txtNro.EditValue = Persona.CalleNumero;
            txtTel1.Text = Persona.Telefono1;
            txtTel2.Text = Persona.Telefono2;

            int index = 0;
            cmbPaices.Properties.DataSource = Controller.SearchParametroByParams((int)Health.Entities.TipoParametroEnum.Paices, null);//Todos los paices

            if (!Persona.IdPais.HasValue && !Persona.IdProvincia.HasValue && !Persona.IdLocalidad.HasValue)
            {
                cmbPaices.Properties.DataSource = Controller.SearchParametroByParams((int)Health.Entities.TipoParametroEnum.Paices, null);//Todos los paices
                cmbPaices.ItemIndex = 0;
                cmbProvincia.Properties.DataSource = Controller.SearchParametroByParams((int)Health.Entities.TipoParametroEnum.Provincia, 1051);//Provincias de Arg 
                cmbProvincia.ItemIndex = 0;
                cmbLocalidad.Properties.DataSource = Controller.SearchParametroByParams((int)Health.Entities.TipoParametroEnum.Localidad, 1106);//Localidades de Cordoba
                cmbLocalidad.ItemIndex = 0;

            }

            else
            {
                if (Persona.IdPais.HasValue)
                {
                    index = cmbPaices.Properties.GetDataSourceRowIndex("IdParametro", Persona.IdPais);
                    cmbPaices.ItemIndex = index;
                }
                else
                {
                    cmbPaices.ItemIndex = 0;
                }

                if (Persona.IdProvincia.HasValue)
                {
                    cmbProvincia.Properties.DataSource = Controller.SearchParametroByParams((int)Health.Entities.TipoParametroEnum.Provincia, Persona.IdPais);//Provincias de usuario
                    index = cmbProvincia.Properties.GetDataSourceRowIndex("IdParametro", Persona.IdProvincia);
                    cmbProvincia.ItemIndex = index;
                }
                else
                { cmbProvincia.ItemIndex = 0; }

                if (Persona.IdLocalidad.HasValue)
                {
                    cmbLocalidad.Properties.DataSource = Controller.SearchParametroByParams((int)Health.Entities.TipoParametroEnum.Localidad, Persona.IdLocalidad);//Localidad del usuario
                    index = cmbLocalidad.Properties.GetDataSourceRowIndex("IdParametro", Persona.IdLocalidad);
                    cmbLocalidad.ItemIndex = index;
                }
                else
                { cmbLocalidad.ItemIndex = 0; }
            }

            cmbPaices.Refresh();
            cmbLocalidad.Refresh();
            cmbLocalidad.Refresh();
        }



        private void cmbPaices_EditValueChanged(object sender, EventArgs e)
        {

            cmbProvincia.Properties.DataSource = Controller.SearchParametroByParams((int)Health.Entities.TipoParametroEnum.Provincia, Convert.ToInt32(cmbPaices.EditValue));//Provincias de Arg 
            cmbProvincia.ItemIndex = 0;
            cmbProvincia.Refresh();
            cmbLocalidad.Properties.DataSource = Controller.SearchParametroByParams((int)Health.Entities.TipoParametroEnum.Localidad, Convert.ToInt32(cmbProvincia.EditValue));//Localidades de Cordoba
            cmbLocalidad.ItemIndex = 0;
            cmbLocalidad.Refresh();
        }

        private void cmbProvincia_EditValueChanged(object sender, EventArgs e)
        {
            cmbLocalidad.Properties.DataSource = Controller.SearchParametroByParams((int)Health.Entities.TipoParametroEnum.Localidad, Convert.ToInt32(cmbProvincia.EditValue));//Localidades de Cordoba
            cmbLocalidad.ItemIndex = 0;
            cmbLocalidad.Refresh();

        }


        internal void SetPersona()
        {
            Persona.Calle = txtCalle.Text.Trim();
            Persona.Barrio = txtBarrio.Text.Trim();
            Persona.mail = txtEmail.Text.Trim();
            Persona.Piso = txtPiso.Text.Trim();
            if (txtNro.EditValue != null)
                Persona.CalleNumero = Convert.ToInt16(txtNro.EditValue);
            Persona.Telefono1 = txtTel1.Text;
            Persona.Telefono2 = txtTel2.Text;
            //if ((int)cmbLocalidad.EditValue != (int)CommonValuesEnum.SeleccioneUnaOpcion)
            if (cmbPaices.EditValue != null)
                Persona.IdPais = Convert.ToInt32(cmbPaices.EditValue);
            if (cmbProvincia.EditValue != null)
                Persona.IdProvincia = Convert.ToInt32(cmbProvincia.EditValue);
            if (cmbLocalidad.EditValue != null)
                Persona.IdLocalidad = Convert.ToInt32(cmbLocalidad.EditValue);
             
        }
    }
}
