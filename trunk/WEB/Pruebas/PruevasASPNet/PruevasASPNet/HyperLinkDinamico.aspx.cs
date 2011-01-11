using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class HyperLinkDinamico : System.Web.UI.Page
    {
        string url = "~/HyperLinkDinamico_Target.aspx?newGuid={0}";
        public string Guid = "Hola";
        protected void Page_Load(object sender, EventArgs e)
        {


            this.HyperLink1.NavigateUrl = string.Format(url,24326054);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            string inputText = Request.Form["txtBody"];
            s.Append("txtBody = " + inputText);

            inputText = Request.Form["TextArea1"];
            s.AppendLine();
            s.AppendLine();
            s.AppendLine("TextArea1 = " + inputText);

      


          
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {

            // Register a startup script in order to fill the html
            // hidden field with a message value

            if (!ClientScript.IsClientScriptBlockRegistered("HtmlHiddenFieldScript") && !IsPostBack)
            {

                ClientScript.RegisterStartupScript(typeof(Page), "SCRIPT_KEY", "PutHtmlHiddenFieldValue('Html hidden hello world');", true);

            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {

        }
    }
}
