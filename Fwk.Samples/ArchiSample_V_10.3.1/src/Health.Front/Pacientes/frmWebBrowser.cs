using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Health.Front
{
    public partial class frmWebBrowser : frmBase_Child
    {
        string url;
        public string Url
        {
            set
            {
              

                url = value;
                webBrowser1.Navigate(url);
            }
            get { return webBrowser1.Url.ToString(); }
        }
        public frmWebBrowser()
        {
            InitializeComponent();
        }
        public override void Refresh()
        {
            
            base.Refresh();
        }

        private void frmWebBrowser_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://www.prvademecum.com/default.asp");
           
        }
    }
}
