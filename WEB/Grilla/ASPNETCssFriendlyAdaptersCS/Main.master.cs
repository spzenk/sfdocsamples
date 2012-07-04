using System;

public partial class MainMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["PreferredTheme"] != null)
        {
            if (Request.Cookies["PreferredTheme"].Value.IndexOf("none", StringComparison.OrdinalIgnoreCase) == 0)
            {
                AdaptersInvariantImportCSS.Visible = false;
                IEMenu6CSS.Visible = false;
            }
        }
    }
}
     