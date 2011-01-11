using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maria.DAC;

namespace Maria.Modules.Noticias
{
    public partial class NewsFullView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Guid id;
            global::Maria.BE.NewsInfo wNewsInfo = null;

            if (!Page.IsPostBack)
            {
                id = new Guid(Request.QueryString["id"]);
                wNewsInfo = new global::Maria.BE.NewsInfo(id);
                wNewsInfo =MariaDAC.GetById(id);
                News_FullViews1.Populate(wNewsInfo);

            }
        }
    }
}
