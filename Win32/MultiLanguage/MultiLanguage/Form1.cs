using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Globalization;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;

namespace MultiLanguage
{
    public partial class Form1 : Form
    {
        private CultureInfo culture;
        public Form1()
        {
            InitializeComponent();
            culture = CultureInfo.CurrentCulture;
            //if (CultureInfo.CurrentCulture.Parent.TwoLetterISOLanguageName == "iv")
            if (CultureInfo.CurrentCulture.Parent.ToString() == "es")
            {
                rnd_Esp.Checked = true;
            }

            adjustCulture();
        }

        private void rnd_Esp_CheckedChanged(object sender, EventArgs e)
        {
            
            if (rnd_Esp.Checked)
            {
                culture = CultureInfo.CreateSpecificCulture("es"); //por defecto español (España)
            }
            else
            {
                culture = CultureInfo.CreateSpecificCulture("en");//por English (United States)
            }
            adjustCulture();

        }
        ResourceManager rm;
        private void adjustCulture()
        {
            lblCulture.Text = string.Concat(culture.DisplayName, " ", culture.ToString());
            this.Text = culture.ToString();
            rm = new ResourceManager("MultiLanguage.Recursito", typeof(Form1).Assembly);

            foreach (Control c in this.Controls)
            {

                if (c.GetType() == typeof(DevExpress.XtraEditors.SimpleButton))
                    SetControl((DevExpress.XtraEditors.SimpleButton)c);

                if (c.GetType() == typeof(DevExpress.XtraGrid.GridControl))
                    SetControl((DevExpress.XtraGrid.GridControl)c);

                if (c.GetType() == typeof(System.Windows.Forms.RadioButton) || c.GetType() == typeof(System.Windows.Forms.Label) || c.GetType() == typeof(System.Windows.Forms.Button))
                    SetControl(c);

            }

        }

        void SetControl(DevExpress.XtraEditors.SimpleButton c)
        {
            c.Text = rm.GetString(string.Concat(c.Name,".Text"), culture);
            c.ToolTip = rm.GetString(string.Concat(c.Name, ".ToolTip"), culture);
        }
        void SetControl(DevExpress.XtraGrid.GridControl c)
        {
            c.SuspendLayout();
            c.BeginInit();
            foreach (DevExpress.XtraGrid.Views.Grid.GridView gv in c.Views)
            {
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in gv.Columns)
                {
                    col.Caption = rm.GetString(string.Concat(col.Name, ".Caption"), culture);
                    col.ToolTip = rm.GetString(string.Concat(col.Name, ".ToolTip"), culture);
                }
            }
            c.EndInit();
            c.ResumeLayout();
        }
        /// <summary>
        /// label
        /// </summary>
        /// <param name="c"></param>
        void SetControl(Control c)
        {
            c.Text = rm.GetString(string.Concat(c.Name, ".Text"), culture);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> i = new List<int>();
            i.Add(1);
            i.Add(2);
            i.Add(3);
            i.Add(4);

            foreach (int x in i)
            {
                if (x == 1)
                    continue;
                if (x == 4)
                    break;
              
            }
        }
      
   
    }
    public class Persons
    {
        public string Nombre {get;set;}
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        
    }
}
