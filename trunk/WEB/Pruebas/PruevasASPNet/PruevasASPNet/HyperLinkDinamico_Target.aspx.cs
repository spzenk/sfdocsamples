using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class HyperLinkDinamico_Target : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string A = this.Page.ClientQueryString;
            string B = Request.QueryString["newGuid"];


            Label1.Text ="newGuid = " + B;
        }
    }
}
