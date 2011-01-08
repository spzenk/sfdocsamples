using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maria.Modules.Noticias
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCreateNew_Click(object sender, EventArgs e)
        {
            lblResult1.Text = TextBox1.Value; // para textareas, el texto está en el VALUE
            lblResult2.Text = TextBox2.Text; // para textboxes, el texto está en el TXT
        }
    }
}
