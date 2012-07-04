using System;
using CSSFriendly;

public partial class _CreateUserWizard : ExamplePage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        RelevantControlName = "CreateUserWizard";
    }

    protected void Page_PreRenderComplete(object sender, EventArgs e)
    {
        GenerateSnippets(createuserwizard1, new CSSFriendly.CreateUserWizardAdapter());
    }
}
