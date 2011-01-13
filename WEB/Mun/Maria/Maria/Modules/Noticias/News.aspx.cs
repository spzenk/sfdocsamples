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
            global::Maria.BE.NewsList wNewsList = null;
            global::Maria.BE.NewsInfo wInfoParam = null;
           if (!Page.IsPostBack)
           {

               wInfoParam = new global::Maria.BE.NewsInfo();
               if(!string.IsNullOrEmpty(Request.QueryString["t"]))
               {
                   
                   wInfoParam.Title =string.Concat("%",Request.QueryString["t"],"%" );
                  
               }
               wNewsList = MariaDAC.SearchByParam(wInfoParam);


               foreach (NewsInfo n in wNewsList)
               {
                   this.pnlNewscontainer.Controls.Add(LoadSimpleNews(n));
               }

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
