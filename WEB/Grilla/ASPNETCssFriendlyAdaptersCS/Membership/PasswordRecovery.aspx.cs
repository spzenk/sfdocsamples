using System;
using System.Web.UI.WebControls;
using CSSFriendly;
using Wilco.Web.SyntaxHighlighting;

public partial class _PasswordRecovery : ExamplePage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        RelevantControlName = "PasswordRecovery";
    }

    protected void Page_PreRenderComplete(object sender, EventArgs e)
    {
        GenerateSnippets(passwordrecovery1, new CSSFriendly.PasswordRecoveryAdapter());
    }

    protected void DoSendMailError(object sender, SendMailErrorEventArgs e)
    {
        e.Handled = true;
    }
}
