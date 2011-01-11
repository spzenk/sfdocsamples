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
            RangeValidator1.MinimumValue = DateTime.Now.ToString("dd/MM/yyyy");
            //RangeValidator1.MaximumValue = new DateTime(2400, 01, 01).ToString("dd/MM/yyyy");
        }

        protected void btnCreateNew_Click(object sender, EventArgs e)
        {
          
            NewsInfo wNews = new NewsInfo();
            wNews.Title = this.txtTitle.Value;
            wNews.Text = txtBody.Value;
            wNews.TextIntro = txtIntro.Value;
            if (!string.IsNullOrEmpty(txtStartDate.Text))
                wNews.ExpitationDate = System.Convert.ToDateTime(txtStartDate.Text);
         

           
            MariaDAC.Create(wNews);
        }

        

    }
}
