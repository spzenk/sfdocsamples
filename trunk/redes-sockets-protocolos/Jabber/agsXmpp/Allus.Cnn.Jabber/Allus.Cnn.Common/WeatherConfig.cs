using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Allus.Cnn.Weather.ISVC.GetWeatherLocation;
using Allus.Cnn.Common;


namespace Allus.Cnn.Common
{
    public partial class WeatherConfig : frmBaseDialog
    {
        bool _Changed = false;
        public event EventHandler OnButtonClick;

        public WeatherConfig()
        {
            InitializeComponent();
        }



        private void WeatherConfig_Load(object sender, EventArgs e)
        {
            WeatherController wController = new WeatherController();
            getWeatherResponseBindingSource.DataSource = wController.GetWeatherLocation();



            if (SettingStorage.Storage.LocationBE != null)
            {
                cmbLocalidad.Text = SettingStorage.Storage.LocationBE.Name;
                spinEdit1.Value = Convert.ToDecimal(SettingStorage.Storage.WeatherRefreshTime);
            }

        }

        private void cmbLocalidad_EditValueChanged(object sender, EventArgs e)
        {
            if (SettingStorage.Storage.LocationBE != null)
            {
                if (cmbLocalidad.Text != SettingStorage.Storage.LocationBE.Name)
                    _Changed = true;
                else
                    _Changed = false;
            }
            else
                _Changed = true;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SettingStorage.Storage.WeatherRefreshTime = Convert.ToInt32(spinEdit1.Value);
            SettingStorage.Save();

            if (_Changed == true)
            {
                SettingStorage.Storage.LocationBE = new Allus.Cnn.Weather.BE.LocationBE();
                SettingStorage.Storage.LocationBE.Name = cmbLocalidad.Text;
                SettingStorage.Storage.LocationBE.Code = cmbLocalidad.EditValue.ToString();
                SettingStorage.Storage.WeatherRefreshTime = Convert.ToInt32(spinEdit1.Value);
                SettingStorage.Save();
                //WeatherControlSlim wWeatherControlSlim = new WeatherControlSlim();
                //wWeatherControlSlim.PopulateAsync();
                if (OnButtonClick != null)
                    OnButtonClick(sender, e);

            }           

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void spinEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }


    }

}