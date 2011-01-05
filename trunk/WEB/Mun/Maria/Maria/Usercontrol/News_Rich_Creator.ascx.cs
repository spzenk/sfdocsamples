using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maria.BE;
using Maria.DAC;
using System.Web.UI.HtmlControls;

namespace Maria.Usercontrol
{
    public partial class News_Rich_Creator : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCreateNew_Click(object sender, EventArgs e)
        {
            NewsInfo wNews = new NewsInfo();

            wNews.Title = this.txtTitle.Text;
            wNews.Text = this.txtText.Value;
            HtmlTextArea wHtmlTextArea = (HtmlTextArea)this.Page.FindControl("txtBody");
            MariaDAC.Create(wNews);
        }
    }
}