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
using Health.BE.Enums;


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
            txtBarrio.Text = Persona.Neighborhood;
            txtCalle.Text = Persona.Street;
            txtEmail.Text = Persona.mail;
            txtPiso.Text = Persona.Floor;
            txtNro.EditValue = Persona.StreetNumber;
            txtTel1.Text = Persona.Telefono1;
            txtTel2.Text = Persona.Telefono2;

            int index = 0;
            cmbPaices.Properties.DataSource = ServiceCalls.SearchParametroByParams((int)TipoParametroEnum.Paices, null);//Todos los paices

            if (!Persona.CountryId.HasValue && !Persona.ProvinceId.HasValue && !Persona.CityId.HasValue)
            {
                cmbPaices.Properties.DataSource = ServiceCalls.SearchParametroByParams((int)TipoParametroEnum.Paices, null);//Todos los paices
                cmbPaices.ItemIndex = 0;
                cmbProvincia.Properties.DataSource = ServiceCalls.SearchParametroByParams((int)TipoParametroEnum.Provincia, 1051);//Provincias de Arg 
                cmbProvincia.ItemIndex = 0;
                cmbLocalidad.Properties.DataSource = ServiceCalls.SearchParametroByParams((int)TipoParametroEnum.Localidad, 1106);//Localidades de Cordoba
                cmbLocalidad.ItemIndex = 0;

            }

            else
            {
                if (Persona.CountryId.HasValue)
                {
                    index = cmbPaices.Properties.GetDataSourceRowIndex("IdParametro", Persona.CountryId);
                    cmbPaices.ItemIndex = index;
                }
                else
                {
                    cmbPaices.ItemIndex = 0;
                }

                if (Persona.ProvinceId.HasValue)
                {
                    cmbProvincia.Properties.DataSource = ServiceCalls.SearchParametroByParams((int)TipoParametroEnum.Provincia, Persona.CountryId);//Provincias de usuario
                    index = cmbProvincia.Properties.GetDataSourceRowIndex("IdParametro", Persona.ProvinceId);
                    cmbProvincia.ItemIndex = index;
                }
                else
                { cmbProvincia.ItemIndex = 0; }

                if (Persona.CityId.HasValue)
                {
                    cmbLocalidad.Properties.DataSource = ServiceCalls.SearchParametroByParams((int)TipoParametroEnum.Localidad, Persona.CountryId);//Localidad del usuario
                    index = cmbLocalidad.Properties.GetDataSourceRowIndex("IdParametro", Persona.CityId);
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

            cmbProvincia.Properties.DataSource = ServiceCalls.SearchParametroByParams((int)TipoParametroEnum.Provincia, Convert.ToInt32(cmbPaices.EditValue));//Provincias de Arg 
            cmbProvincia.ItemIndex = 0;
            cmbProvincia.Refresh();
            cmbLocalidad.Properties.DataSource = ServiceCalls.SearchParametroByParams((int)TipoParametroEnum.Localidad, Convert.ToInt32(cmbProvincia.EditValue));//Localidades de Cordoba
            cmbLocalidad.ItemIndex = 0;
            cmbLocalidad.Refresh();
        }

        private void cmbProvincia_EditValueChanged(object sender, EventArgs e)
        {
            cmbLocalidad.Properties.DataSource = ServiceCalls.SearchParametroByParams((int)TipoParametroEnum.Localidad, Convert.ToInt32(cmbProvincia.EditValue));//Localidades de Cordoba
            cmbLocalidad.ItemIndex = 0;
            cmbLocalidad.Refresh();

        }


        internal void SetPersona()
        {
            Persona.Street = txtCalle.Text.Trim();
            Persona.Neighborhood = txtBarrio.Text.Trim();
            Persona.mail = txtEmail.Text.Trim();
            Persona.Floor = txtPiso.Text.Trim();
            if (txtNro.EditValue != null)
                Persona.StreetNumber = Convert.ToInt16(txtNro.EditValue);
            Persona.Telefono1 = txtTel1.Text;
            Persona.Telefono2 = txtTel2.Text;
            //if ((int)cmbLocalidad.EditValue != (int)CommonValuesEnum.SeleccioneUnaOpcion)
            if (cmbPaices.EditValue != null)
                Persona.CountryId = Convert.ToInt32(cmbPaices.EditValue);
            if (cmbProvincia.EditValue != null)
                Persona.ProvinceId = Convert.ToInt32(cmbProvincia.EditValue);
            if (cmbLocalidad.EditValue != null)
                Persona.CityId = Convert.ToInt32(cmbLocalidad.EditValue);
             
        }
    }
}
