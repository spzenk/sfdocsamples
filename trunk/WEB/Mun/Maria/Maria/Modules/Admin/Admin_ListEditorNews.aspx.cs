using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maria.BE;
using Maria.DAC;
using Maria.Usercontrol;

namespace Maria.Modules.Admin
{
    public partial class Admin_ListEditorNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       
        protected void btnSeach_Click(object sender, ImageClickEventArgs e)
        {
            NewsInfo wNews = new NewsInfo();

            wNews.Title = string.Concat ("%",this.txtSearch.Text,"%");

            NewsList wNewsList = MariaDAC.SearchByParam(wNews);

            foreach (NewsInfo n in wNewsList)
            {
                this.pnlNewscontainer.Controls.Add(LoadSimpleNews(n));
            }
        }



        private System.Web.UI.UserControl LoadSimpleNews(NewsInfo pNewsInfo)
        {
            System.Web.UI.UserControl wWebNews = (System.Web.UI.UserControl)Page.LoadControl(WebUserControlsConstants.News_ItemList);

            ((News_ItemList)wWebNews).Populate(pNewsInfo);
            wWebNews.EnableViewState = true;



            return wWebNews;
        }

    }
}
