using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maria.Usercontrol
{
    public partial class News_Simple : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateNew_Click(object sender, EventArgs e)
        {
            News wNews = new News();
            wNews.Text = this.txtComments.Text;
            wNews.Title = this.txtTitle.Text;
            wNews.CreateDate = System.DateTime.Now;
        }
    }
}