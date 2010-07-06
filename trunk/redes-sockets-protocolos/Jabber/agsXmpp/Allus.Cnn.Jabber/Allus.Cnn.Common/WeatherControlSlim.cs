using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Allus.Cnn.Weather.BE;
using Allus.Cnn.Common;
using System.Runtime.Remoting.Messaging;

namespace Allus.Cnn.Common
{
    public partial class WeatherControlSlim : UserControl
    {
        #region Fields
        public event EventHandler<ExceptionEventArgs> ExceptionEvent;
        WeatherBE _Clima;
        private String _LocationCode;
        private String _LanguageWeather;
        private Int32 _RefreshTime = 45;

        [Browsable(true), Category("Weather"), DefaultValue(45)]
        public Int32 RefreshTime
        {
            get
            {
                return _RefreshTime;
            }
            set
            {
                _RefreshTime = value;
            }
        }

        [Browsable(true), Category("Weather"), DefaultValue("es")]
        public String LocationName
        {
            get { return lblRegion.Text; }
            set { lblRegion.Text = value; }
        }

        //[Browsable(true), Category("Weather"), DefaultValue("es")]
        //public String LastRecord
        //{
        //    get { return lblLastRecord.Text; }
        //    set { lblLastRecord.Text = value; }
        //}

        [Browsable(true), Category("Weather"), DefaultValue("es")]
        public String LanguageWeather
        {
            get
            {
                return _LanguageWeather;
            }
            set
            {
                _LanguageWeather = value;
            }
        }

        [Browsable(true), Category("Weather")]
        public String LocationCode
        {
            get
            {
                return _LocationCode;
            }
            set
            {
                _LocationCode = value;
            }

        }


        #endregion

        public WeatherControlSlim()
        {
            InitializeComponent();

            //TODO: ver como mostrar.
        }

        public void PopulateAsync()
        {
            Exception ex = null;
            DelegateWithOutAndRefParameters s = new DelegateWithOutAndRefParameters(Populate);
            s.BeginInvoke(out ex, new AsyncCallback(EndPopulate), null);
        }

        void EndPopulate(IAsyncResult res)
        {
            Exception ex;
            if (this.InvokeRequired)
            {
                AsyncCallback d = new AsyncCallback(EndPopulate);
                this.Invoke(d, new object[] { res });
            }
            else
            {
                AsyncResult result = (AsyncResult)res;
                DelegateWithOutAndRefParameters del = (DelegateWithOutAndRefParameters)result.AsyncDelegate;
                del.EndInvoke(out ex, res);
                FillWeather();
                if (ex != null)
                {
                    if (ExceptionEvent != null)
                        ExceptionEvent(this, new ExceptionEventArgs(ex));
                    return;
                }
            }
        }

        void Populate(out Exception ex)
        {
            ex = null;

            try
            {
                Populate();
            }
            catch (Exception err)
            {
                err.Source = "Origen de datos";
                ex = err;
            }
        }

        void FillWeather()
        {
            if (_Clima == null) return;
            if (_Clima.Conditions != null)
            {
                // Seleccion de la imagen correspondiente por la clave
                String wDia = _Clima.Astronomy.ByDay ? "d" : "n";
                String wCodeCurrent = String.Concat(_Clima.Conditions.Code.ToString(), "s", ".png");
                String wCodeToday = String.Concat(_Clima.Items[0].Code.ToString(), "s", ".png");
                String wCodeTomorrow = String.Concat(_Clima.Items[1].Code.ToString(), "s", ".png");
                String[] wClima;

                if (_Clima.Astronomy.ByDay)
                    panel2.BackgroundImage = Allus.Cnn.Common.Properties.Resources.wdgt_day;
                else
                    panel2.BackgroundImage = Allus.Cnn.Common.Properties.Resources.wdgt_night;

                // Imagenes
                picToday.Image = ImageCollectionClima.Images[wCodeToday];
                PicTomorrow.Image = ImageCollectionClima.Images[wCodeTomorrow];
                picCurrent.Image = ImageCollectionClima.Images[wCodeCurrent];

                // Current Temperature
                lblTemperature.Text = String.Format("{0}°", Convert.ToString(_Clima.Conditions.Temperature));

                // Today
                lblTMax.Text = String.Format("{0}°", _Clima.Items[0].High.ToString());
                lblTMin.Text = String.Format("{0}°", _Clima.Items[0].Low.ToString());

                // Tomorrow                    
                //lblTomorrow.Text = mClima.Items[1].Date;
                lblTRMax.Text = String.Format("{0}°", _Clima.Items[1].High.ToString());
                lblTRMin.Text = String.Format("{0}°", _Clima.Items[1].Low.ToString());

                // Fechas
                lblFechaToday.Text = DateTime.Parse(_Clima.Items[0].Date).ToString("dd/MM");
                lblFechaTomorrow.Text = DateTime.Parse(_Clima.Items[1].Date).ToString("dd/MM");

                //ToolTip
                picCurrent.ToolTip = _Clima.Conditions.Text;
                picToday.ToolTip = _Clima.Items[0].Text;
                PicTomorrow.ToolTip = _Clima.Items[1].Text;

                //Last Record
                wClima = _Clima.BuildDate.Split(',');
                if (!string.IsNullOrEmpty(wClima[1]))
                    lblLastRecord.Text = "Último registro: " + wClima[1].Substring(1);

            }
        }

        public void Populate()
        {
            if (!this.DesignMode)
            {
                if (SettingStorage.Storage.LocationBE == null) return;
                _LocationCode = SettingStorage.Storage.LocationBE.Code;
                _RefreshTime = SettingStorage.Storage.WeatherRefreshTime;

                WeatherController wController = new WeatherController();
                _Clima = wController.GetWeather(_LocationCode, _LanguageWeather);
                if (SettingStorage.Storage.WeatherRefreshTime == 0)
                    timerClima.Interval = (_RefreshTime * 60000);
                else
                    timerClima.Interval = (SettingStorage.Storage.WeatherRefreshTime * 60000);
                timerClima.Start();
            }
        }

        private void WeatherControlSlim_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                _LanguageWeather = "es";
                //Preguntamos por el objeto cacheado.
                if (SettingStorage.Storage.LocationBE != null)
                {
                    _LocationCode = SettingStorage.Storage.LocationBE.Code;
                    _RefreshTime = SettingStorage.Storage.WeatherRefreshTime;
                    lblRegion.Text = SettingStorage.Storage.LocationBE.Name;
                }
            }
        }

        // Actualizacion por time elapsed
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!this.DesignMode)
                PopulateAsync();
        }

        public void TimerStop()
        {
            timerClima.Stop();
        }

        // Actualizacion por submenu
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!this.DesignMode)
                PopulateAsync();
        }
    }
}