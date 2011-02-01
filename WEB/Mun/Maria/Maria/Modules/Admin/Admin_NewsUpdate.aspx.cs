using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maria.DAC;
using Maria.BE;

namespace Maria.Modules.Admin
{
    public partial class Admin_NewsUpdate : System.Web.UI.Page

    {
        Guid id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.User.Identity.IsAuthenticated)
            {
                Response.Redirect(string.Format(WebUserControlsConstants.NotAuthorizedUser_Redirect, this.Page.AppRelativeVirtualPath));
            }


            global::Maria.BE.NewsInfo wNewsInfo = null;
            RangeValidator1.MinimumValue = DateTime.Now.ToString("dd/MM/yyyy");
          
            if (!Page.IsPostBack)
            {
                this.RangeValidator1.Enabled = false;
                id = new Guid(Request.QueryString["id"]);
                wNewsInfo = new global::Maria.BE.NewsInfo(id);
                wNewsInfo = MariaDAC.GetById(id);

                this.txtTitle.Value = wNewsInfo.Title;
                this.News_Collapsed_RichText_Txt.populate(wNewsInfo.TextIntro, "Contenido de la nota completa");
                this.News_Collapsed_RichText_TxtIntro.populate(wNewsInfo.Text, "Nota rápida");
         
                 if (wNewsInfo.ExpitationDate != null)
                     txtStartDate.Text = wNewsInfo.ExpitationDate.ToString();


                 this.RangeValidator1.Enabled = true;
            }
            
        }

        protected void btnCreateNew_Click(object sender, EventArgs e)
        {
            NewsInfo wNews = new NewsInfo(new Guid(Request.QueryString["id"]));
            wNews.Title = this.txtTitle.Value;
            wNews.Text = News_Collapsed_RichText_Txt.HtmlText;
            wNews.TextIntro = News_Collapsed_RichText_TxtIntro.HtmlText;
            if (!string.IsNullOrEmpty(txtStartDate.Text))
                wNews.ExpitationDate = System.Convert.ToDateTime(txtStartDate.Text);

            if (wNews == null)
                throw new Exception("El identificador de l noticia fue modificado o la noticia fue eliminado de la base de datos");
            MariaDAC.Update(wNews);
        }
    }
}
