using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maria.DAC;
using Maria.BE;

namespace Maria.Usercontrol
{
    public partial class News_Simple_Creator : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnCreateNew.Attributes.Add("onfocus", "javascript:cambiarEstilo();"); 
        }

        protected void btnCreateNew_Click(object sender, EventArgs e)
        {
            NewsInfo wNews = new NewsInfo();
          
            wNews.Title = this.txtTitle.Text;
            wNews.Text = this.txtText.Text;

            MariaDAC.Create(wNews);
        }

        protected void txtComments_TextChanged(object sender, EventArgs e)
        {

        }
    }
}