using System;
using CSSFriendly;
using Wilco.Web.SyntaxHighlighting;

public partial class _Login : ExamplePage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        RelevantControlName = "Login";
    }

    protected void Page_PreRenderComplete(object sender, EventArgs e)
    {
        GenerateSnippets(loginview1.FindControl("login1"), new CSSFriendly.LoginAdapter());
    }
}
