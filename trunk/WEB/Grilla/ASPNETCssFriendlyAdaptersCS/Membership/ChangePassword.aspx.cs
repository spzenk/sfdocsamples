using System;
using System.Web.UI.WebControls;
using CSSFriendly;
using Wilco.Web.SyntaxHighlighting;


public partial class _ChangePassword : ExamplePage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        RelevantControlName = "ChangePassword";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        changepassword1.UserName = "fred";        
    }

    protected void Page_PreRenderComplete(object sender, EventArgs e)
    {
        GenerateSnippets(changepassword1, new CSSFriendly.ChangePasswordAdapter());
    }
}
