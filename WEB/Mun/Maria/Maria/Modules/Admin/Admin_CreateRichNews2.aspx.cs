using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maria.BE;
using Maria.DAC;

namespace Maria.Modules.Admin
{
    public partial class Admin_CreateRichNews2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.User.Identity.IsAuthenticated)
            {
                Response.Redirect(@"~\modules\Admin\Admin_NotAuthorizedUser.aspx");
            }
            if (!IsPostBack)
            {
                RangeValidator1.MinimumValue = DateTime.Now.ToString("dd/MM/yyyy");
                News_Collapsed_RichText_Txt.populate(string.Empty, "Contenido de la nota completa");
                News_Collapsed_RichText_TxtIntro.populate(string.Empty, "Nota rápida");
            }
        }

        protected void btnCreateNew_Click(object sender, EventArgs e)
        {
            NewsInfo wNews = new NewsInfo();
            wNews.Title = this.txtTitle.Value;
            wNews.Text = News_Collapsed_RichText_Txt.HtmlText;
            wNews.TextIntro = News_Collapsed_RichText_TxtIntro.HtmlText;
            if (!string.IsNullOrEmpty(txtStartDate.Text))
                wNews.ExpitationDate = System.Convert.ToDateTime(txtStartDate.Text);



            MariaDAC.Create(wNews);

        }
    }
}
