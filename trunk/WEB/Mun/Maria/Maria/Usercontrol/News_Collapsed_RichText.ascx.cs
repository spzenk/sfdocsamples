using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maria.Usercontrol
{
    public partial class News_Collapsed_RichText : System.Web.UI.UserControl
    {


        public string HtmlText
        {
            get { return txtText.Value; }
           
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        internal void populate(string htmlTextIntro,string labelTitulo)
        {
            txtText.Value = htmlTextIntro;
          lbltitle.Text = labelTitulo;
        }
    }
}