using System;
using CSSFriendly;

public partial class _FormView : ExamplePage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        RelevantControlName = "FormView";
    }

    protected void Page_PreRenderComplete(object sender, EventArgs e)
    {
        GenerateSnippets(FormView1, new CSSFriendly.FormViewAdapter());
    }
}
