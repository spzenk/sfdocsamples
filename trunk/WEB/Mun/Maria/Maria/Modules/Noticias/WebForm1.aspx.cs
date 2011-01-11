using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maria.BE;
using Maria.DAC;

namespace Maria.Modules.Noticias
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NewsList wNewsList = MariaDAC.SearchByParam(new NewsInfo());
            this.News_SimpleView1.Populate(wNewsList[0]);
        }
        
    }
}
