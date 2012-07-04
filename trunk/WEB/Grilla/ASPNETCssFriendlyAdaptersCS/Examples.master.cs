using System;
using System.Web;
using System.Web.UI.WebControls;
using CSSFriendly;

public partial class Examples : System.Web.UI.MasterPage
{
    protected void Page_PreRender(object sender, EventArgs e)
    {
        DynamicAdaptersPage dynamicAdaptersPage = Page as DynamicAdaptersPage;
        if ((dynamicAdaptersPage != null) && dynamicAdaptersPage.Compatible)
        {
            SnippetWithAdapterContainer.CssClass = CSSFriendly.Context.Enabled ? "snippet" : "snippet snippet-dim";
            SnippetWithoutAdapterContainer.CssClass = CSSFriendly.Context.Enabled ? "snippet snippet-dim" : "snippet";
            EnabledAdaptersWarning.Visible = CSSFriendly.Context.Enabled;
            DisabledAdaptersWarning.Visible = !CSSFriendly.Context.Enabled;
            BrowserIncompatibility.Visible = false;
            AdaptersEnabled.SelectedIndex = CSSFriendly.Context.Enabled ? 0 : 1;
        }
        else
        {
            SnippetWithAdapterContainer.CssClass = "snippet snippet-dim";
            SnippetWithoutAdapterContainer.CssClass = "snippet snippet-dim";
            EnabledAdaptersWarning.Visible = false;
            DisabledAdaptersWarning.Visible = false;
            BrowserIncompatibility.Visible = true;
            AdaptersEnabled.SelectedIndex = 1;
            AdaptersEnabled.Enabled = false;
        }

        ListItem basicTheme = ThemeChooser.Items.FindByText("Basic");
        if (basicTheme != null)
        {
            ThemeChooser.SelectedIndex = ThemeChooser.Items.IndexOf(basicTheme);
        }

        if (Request.Cookies["PreferredTheme"] != null)
        {
            ListItem preferredTheme = ThemeChooser.Items.FindByText(Request.Cookies["PreferredTheme"].Value);
            if (preferredTheme != null)
            {
                ThemeChooser.SelectedIndex = ThemeChooser.Items.IndexOf(preferredTheme);
            }
        }

        ViewSourceBtn.Attributes["xml:lang"] = "en";
        ViewSourceBtn.Attributes["onmouseover"] = "this.className='button-hover'";
        ViewSourceBtn.Attributes["onmouseout"] = "this.className='button'";

        ExamplePage ePage = Page as ExamplePage;
        if (ePage != null)
        {
            ControlName.InnerText = ePage.RelevantControlName;
        }
    }

    protected void ViewSourceBtnClicked(object sender, EventArgs e)
    {
        string url = ResolveUrl("~/srcviewer.aspx") + "?inspect=" + Server.UrlEncode(Page.Request.Url.AbsolutePath);
        Response.Redirect(url);
    }

    protected void AdapterUsageChanged(object sender, EventArgs e)
    {
        //  Make sure we are not using faulty view-state info by making sure we are not in a
        //  PostBack state when we are done indicating that we want the adapters enabled/disabled.
        Response.Redirect(Request.Url.ToString());
    }

    protected void ThemeChanged(object sender, EventArgs e)
    {
        HttpCookie cookie = new HttpCookie("PreferredTheme");
        cookie.Value = ThemeChooser.SelectedItem.Text;
        if (Response.Cookies["PreferredTheme"] == null)
        {
            Response.Cookies.Add(cookie);
        }
        else
        {
            Response.Cookies.Set(cookie);
        }
        Response.Redirect(Request.Url.ToString());
    }
}
