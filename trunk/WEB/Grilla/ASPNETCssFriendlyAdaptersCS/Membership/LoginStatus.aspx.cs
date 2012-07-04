using System;
using CSSFriendly;

public partial class _LoginStatus : ExamplePage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        RelevantControlName = "LoginStatus";
    }

    protected void Page_PreRenderComplete(object sender, EventArgs e)
    {
        GenerateSnippets(loginstatus1, new CSSFriendly.LoginStatusAdapter());
    }
}
