using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Prueba.DinControls
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Fill();

        }

        void Fill()
        {
            System.Web.UI.UserControl wWebNews = null;

            for (int i = 0; i <= 2; i++)
            {
                wWebNews = (System.Web.UI.UserControl)Page.LoadControl("control1.ascx");
                wWebNews.ID = "News_" + i;
                ((control1)wWebNews).controlId = i.ToString() ;
                this.Panel1.Controls.Add(wWebNews);
            }
        }
    }

    
}
