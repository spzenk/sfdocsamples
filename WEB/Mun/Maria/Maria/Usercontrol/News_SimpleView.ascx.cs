using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maria.BE;

namespace Maria.Usercontrol
{
    public partial class News_SimpleView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void Populate(NewsInfo pNew)
        {

            this.NewsTitle1.Populate(pNew);
            this.NewsFooter1.Populate(pNew);
            this.lblTextContent.Text = pNew.Text;
            //this.txtTextContent.InnerText = pNew.Text;
        }
    }
}