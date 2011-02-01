using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Authenticate
{
    public partial class NotAuthorizedUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
  
                this.Login1.DestinationPageUrl =  Request.QueryString["id"];
            }
        }
    }
}
