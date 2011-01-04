using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maria.BE;

namespace Maria.Usercontrol
{
    public partial class NewsFooter : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void Populate(NewsInfo pNew)
        {
            this.lblDate.Text = string.Concat( pNew.CreationDate.ToLongDateString() , " a las ",pNew.CreationDate.ToShortTimeString());
          
        }

    }
}