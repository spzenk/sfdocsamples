using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynamicControls_NoAutopostBack
{
    public partial class UControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void Populate(CheckObjet pCheckObjet)
        {
            this.lbltitle.Text += pCheckObjet.Title;
            this.CheckBox1.Checked = pCheckObjet.Chk1;
            this.CheckBox2.Checked = pCheckObjet.Chk2;
            this.CheckBox3.Checked = pCheckObjet.Chk3;

        }
    }
}