using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Authenticate
{
    public partial class PrivateForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.User.Identity.IsAuthenticated)
            {
               
                Response.Redirect(string.Concat( @"~\NotAuthorizedUser.aspx?id=", this.Page.AppRelativeVirtualPath));
            }
        }
    }
}
