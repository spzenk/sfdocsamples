using System;
using CSSFriendly;

public partial class _Menu : ExamplePage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        RelevantControlName = "Menu";
    }

    protected void Page_PreRenderComplete(object sender, EventArgs e)
    {
        GenerateSnippets(Menu1, new CSSFriendly.MenuAdapter());
    }
}
