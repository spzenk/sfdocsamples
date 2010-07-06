using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace Allus.Cnn.Common
{
    public partial class MarqueeForm : Form
    {
       
        [Browsable(true), Category("Allus.Libs")]
        public Marquee Marquee
        {
            get
            {
                return this.marquee1;
            }
        }

        public MarqueeForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// posiciona el formulario en la parte superior de la pantalla
        /// </summary>
        private void CenterScreenHigh()
        {
            int x = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;

            this.Left = x;
            if (x < 0) { x = 0; }
            this.Top = 0;
            this.TopMost = true;
        }

        // posiciona el formulario en la parte inferior de la pantalla
        private void CenterScreenLow()
        {
            int x = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;

            this.Left = x;
            if (x < 0) { x = 0; }
            this.Top = Screen.PrimaryScreen.Bounds.Height - this.Height;
            this.TopMost = true;

        }

        
        void marquee1_StopEvent(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MarqueeForm_Load(object sender, EventArgs e)
        {
            marquee1.StopEvent += new Marquee.StopEventHandler(marquee1_StopEvent);

            // se deifne la posicion
            if (marquee1.Position == Position.Top)
                CenterScreenHigh();
            else
                CenterScreenLow();

        }


        
    }
}
