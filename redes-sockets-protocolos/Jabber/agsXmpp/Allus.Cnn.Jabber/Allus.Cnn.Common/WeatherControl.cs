using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Net;
using Allus.Cnn.Weather.BE;
using System.Runtime.Remoting.Messaging;

namespace Allus.Cnn.Common
{
    public partial class WeatherControl : UserControl
    {
        WeatherBE mClima;
        private String mLocationCode;
        private String mLanguageWeather;
        public event EventHandler<ExceptionEventArgs> ExceptionEvent;
        [Browsable(true), Category("Weather"), DefaultValue("es")]
        public String LanguageWeather
        {
            get
            {
                return mLanguageWeather;
            }
            set
            {
                mLanguageWeather = value;
            }
        }

        [Browsable(true), Category("Weather"), DefaultValue("ARCA0023")]
        public String LocationCode
        {
            get
            {
                return mLocationCode;
            }
            set
            {
                mLocationCode = value;
            }
        }



        public WeatherControl()
        {
            InitializeComponent();           
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

        public void Populate()
        {

            if (!this.DesignMode)
            {

                if (LocationCode != String.Empty)
                {
                    WeatherController wController = new WeatherController();
                    mClima = wController.GetWeather(LocationCode, LanguageWeather);
                    

                    // Seleccion de la imagen correspondiente por la clave
                    String wDia = mClima.Astronomy.ByDay ? "d" : "n";
                    String wCodeCurrent = String.Concat(mClima.Conditions.Code.ToString(), wDia, ".png");
                    String wCodeToday = String.Concat(mClima.Conditions.Code.ToString(), wDia, ".png");
                    String wCodeTomorrow = String.Concat(mClima.Conditions.Code.ToString(), wDia, ".png");
                    

                    if (mClima.Astronomy.ByDay)
                        picBackGround.Image = Allus.Cnn.Common.Properties.Resources.wdgt_day;                        
                    else
                        picBackGround.Image = Allus.Cnn.Common.Properties.Resources.wdgt_night;

                    // Imagenes
                    picToday.Image = ImgCollectionClima.Images[wCodeToday];
                    picTomorrow.Image = ImgCollectionClima.Images[wCodeCurrent];
                    picClima.Image = ImgCollectionClima.Images[wCodeTomorrow];

                    // Current
                    lblWind.Text = String.Format("{0} {1}({2})", Convert.ToString(mClima.Wind.Speed), mClima.Units.Speed, mClima.Wind.CardinalPoint);
                    lblTemperature.Text = String.Format("{0}°", Convert.ToString(mClima.Conditions.Temperature));

                    lblCMax.Text = String.Format("{0}°", mClima.Items[0].High.ToString());
                    lblCMin.Text = String.Format("{0}°", mClima.Items[0].Low.ToString());
                    lblCurrent.Text = mClima.Conditions.Text;

                    // Tomorrow
                    lblTRMax.Text = mClima.Items[1].High.ToString();
                    lblTRMin.Text = mClima.Items[1].Low.ToString();

                    // Today
                    lblTMax.Text = mClima.Items[0].High.ToString();
                    lblTMin.Text = mClima.Items[0].Low.ToString();

                    // Fechas
                    lblToday.Text = DateTime.Parse(mClima.Items[0].Date).ToString("dd/MM");
                    lblTomorrow.Text = DateTime.Parse(mClima.Items[1].Date).ToString("dd/MM");

                    //ToolTip                    
                    picToday.ToolTip = mClima.Items[0].Text;
                    picTomorrow.ToolTip = mClima.Items[1].Text;

                }
                else
                {
                    lblCurrent.Text = "No se especifico la localidad";
                }
            }
        }


        private void WeatherControl_Paint(object sender, PaintEventArgs e)
        {
           // layoutControl1.Root.BackgroundImage = Allus.Cnn.Common.Properties.Resources.wdgt_day;
        }


    }
}
