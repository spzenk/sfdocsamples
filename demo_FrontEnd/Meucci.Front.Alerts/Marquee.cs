using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGauges.Core.Model;

namespace Meucci.Front.Alerts.Control
{
    [ToolboxItem(true)]
    public partial class Marquee :  DevExpress.XtraEditors.XtraUserControl
    {
        private String mText;
        private Int32 mSpeed;
        private Direction mDirection;
        private Int32 mTimeToShow;
        private Int32 mTicks;
        private Position mPosition;
        private String mLink;
        private String mLinkText;


        int lockTimerCounter;
        int offsetCounter = 0;


        #region [Browseables Properties]

        [Browsable(true), Category("Epiron.Gestion.Libs"), DefaultValue(typeof(Int32), "30")]
        public Int32 DigitCount
        {
            get
            {
                return digitalGauge1.DigitCount;
            }
            set
            {
                digitalGauge1.DigitCount = value;
            }
        }

        [Browsable(true), Category("Epiron.Gestion.Libs"), DefaultValue(typeof(Int32), "10000")]
        public Int32 TimeToShow
        {
            get
            {
                return mTimeToShow;
            }
            set
            {
                mTimeToShow = value;
            }
        }

        [Browsable(true), Category("Epiron.Gestion.Libs"), DefaultValue(typeof(DigitalBackgroundShapeSetType), "Style7")]
        public DigitalBackgroundShapeSetType Shape
        {
            get
            {
                return digitalBackgroundLayerComponent1.ShapeType;
            }
            set
            {
                digitalBackgroundLayerComponent1.ShapeType = value;
            }
        }

        [Browsable(true), Category("Epiron.Gestion.Libs"), DefaultValue(typeof(Direction), "Left")]
        public Direction TextDirection
        {
            get
            {
                return mDirection;
            }
            set
            {
                mDirection = value;
            }
        }

        [Browsable(true), Category("Epiron.Gestion.Libs"), DefaultValue(typeof(Position), "Top")]
        public Position Position
        {
            get
            {
                return mPosition;
            }
            set
            {
                mPosition = value;
            }
        }

        [Browsable(true), Category("Epiron.Gestion.Libs"), DefaultValue(typeof(Int32), "1")]
        public Int32 Speed
        {
            get
            {
                return mSpeed;
            }
            set
            {
                mSpeed = value;
            }
        }

        [Browsable(true), Category("Epiron.Gestion.Libs"), DefaultValue(typeof(String), "Inserte su texto Aqui")]
        public String TextToShow
        {
            get
            {
                return mText;
            }
            set
            {
                mText = value;
            }
        }

        [Browsable(true), Category("Epiron.Gestion.Libs"), DefaultValue(typeof(Color), "Yellow")]
        public Color TextColor
        {
            set
            {
                this.digitalGauge1.AppearanceOn.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject(value);
            }
        }

        [Browsable(true), Category("Epiron.Gestion.Libs"), DefaultValue(typeof(Color), "White")]
        public Color LinkColor
        {
            set
            {
                lnkInfo.ForeColor =value;
            }
        }

        [Browsable(true), Category("Epiron.Gestion.Libs"), DefaultValue(typeof(String), "+Info")]
        public String LinkText
        {
            get
            {
                return mLinkText;
            }
            set            
            {
                lnkInfo.Text = value;
                
                if (String.IsNullOrEmpty(value)) lnkInfo.Enabled = false;
                else lnkInfo.Enabled = true;

                mLinkText = value;
            }
        }

        [Browsable(true), Category("Epiron.Gestion.Libs"), DefaultValue(typeof(String), "http://interallusweb/interallus/")]
        public String Link
        {
            get
            {
                return mLink;
            }
            set
            {               
                mLink = value;
            }
        }

        #endregion


        #region [Eventos]
        [Category("Allus.Libraries")]
        public delegate void StopEventHandler(object sender, EventArgs e);
        [Category("Allus.Libraries")]
        public event StopEventHandler StopEvent;

        #endregion

        public Marquee()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Se suma el intervalo, para saber cuando se detiene
            mTicks = mTicks + timer1.Interval;

            if (mTicks >= mTimeToShow)
                Stop();


            if (lockTimerCounter == 0)
            {
                digitalGauge1.BeginUpdate();
                lockTimerCounter++;
                UpdateText();
                lockTimerCounter--;
                digitalGauge1.EndUpdate();
            }

        }

        private void UpdateText()
        {

            string fullTextToShow = TextToShow;
            char[] textToShow = new char[digitalGauge1.DigitCount];

            if (fullTextToShow != null)
            {
                for (int i = 0; i < digitalGauge1.DigitCount; i++)
                {
                    if (i + offsetCounter >= 0 && i + offsetCounter < fullTextToShow.Length)
                    {
                        textToShow[i] = fullTextToShow[i + offsetCounter];
                    }
                    else textToShow[i] = ' ';
                }

                if (TextDirection == Direction.Left)
                    offsetCounter++;
                else offsetCounter--;

                if (TextDirection == Direction.Left && offsetCounter > digitalGauge1.DigitCount + fullTextToShow.Length)
                    offsetCounter = -digitalGauge1.DigitCount;

                if (TextDirection == Direction.Right && offsetCounter < -digitalGauge1.DigitCount)
                    offsetCounter = digitalGauge1.DigitCount + fullTextToShow.Length;

                digitalGauge1.Text = new string(textToShow);
            }
        }

        public void Start()
        {
            //if (timer1 != null)
            //{
            //    timer1.Stop();
            //    offsetCounter = -digitalGauge1.DigitCount;
            //    timer1.Interval = 500 / (Speed + 1);
            //    timer1.Start();
            //}
            //else
            //{
            //    Restart();
            //    timer1 = new Timer();
            //    timer1.Tick += new EventHandler(timer1_Tick);
            //    offsetCounter = -digitalGauge1.DigitCount;
            //    timer1.Interval = 500 / (Speed + 1);
            //    timer1.Start();
            //}
        }

        public void Stop()
        {
            lockTimerCounter++;
            if (timer1 != null)
            {
                timer1.Stop();
                timer1.Dispose();
                timer1 = null;

                // Lanzamos evento por el stop
                if (StopEvent != null)
                    StopEvent(this, new EventArgs());

            }
        }

        internal void Restart()
        {
            lockTimerCounter = 0;
            offsetCounter = 0;
            mTicks = 0;
        }

        private void lnkInfo_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("IExplore", Convert.ToString(mLink));
        }
    }

    public enum Direction
    {
        Right = 0,
        Left = 1
    }

    public enum Position
    {
        Top = 0,
        Bottom = 1
    }


}
