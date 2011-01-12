using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maria.BE;

namespace Maria.Usercontrol
{
    public partial class News_ItemList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        internal void Populate(NewsInfo pNew)
        {

            this.lblTitle.Text = pNew.Title;
            this.lblTitle.NavigateUrl = string.Format(WebUserControlsConstants.NavigateUrl_Admin_NewsUpdate, pNew.Id.ToString());

        }

       
    }
}