using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maria.BE;
using Maria.DAC;
using Maria.Usercontrol;
namespace Maria.Modules.Noticias
{
    public partial class News : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           NewsList wNewsList = MariaDAC.SearchByParam(new NewsInfo());

           foreach (NewsInfo n in wNewsList)
           {
               this.pnlNewscontainer.Controls.Add(LoadSimpleNews(n));
           }
        }



        private System.Web.UI.UserControl LoadSimpleNews(NewsInfo pNewsInfo)
        {
            System.Web.UI.UserControl wWebNews = (System.Web.UI.UserControl)Page.LoadControl(WebUserControlsConstants.News_SimpleView);
         
            ((News_SimpleView)wWebNews).Populate(pNewsInfo);
            wWebNews.EnableViewState = true;

           

            return wWebNews;
        }

      
    }
}
