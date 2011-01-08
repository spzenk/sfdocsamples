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
    public partial class Admin_CreateRichNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateNew_Click(object sender, EventArgs e)
        {
          
            NewsInfo wNews = new NewsInfo();
            wNews.Title = this.txtTitle.Text;
            wNews.Text = txtBody.Value;


            MariaDAC.Create(wNews);
        }

        
    }
}
