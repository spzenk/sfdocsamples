using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maria.BE;

namespace Maria
{
    public partial class NewsTitle : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void Populate(NewsInfo pNew)
        {
            this.lblDate.Text = pNew.CreationDate.ToString();
            this.lblTitle.Text = pNew.Title;
        }
    }
}