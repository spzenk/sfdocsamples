using System;
using CSSFriendly;

public partial class GenericPage : DynamicAdaptersPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Request != null) && (Request.UrlReferrer != null))
        {
            returnLink.NavigateUrl = Request.UrlReferrer.AbsolutePath;
            returnLink.Text = Request.UrlReferrer.AbsolutePath;
        }
        else
        {
            whereFrom.Visible = false;
        }
    }
}
