using System;
using System.Web.UI.WebControls;
using CSSFriendly;

public partial class _DetailsView : ExamplePage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        RelevantControlName = "DetailsView";
    }

    protected void Page_PreRenderComplete(object sender, EventArgs e)
    {
        GenerateSnippets(DetailsView1, new CSSFriendly.DetailsViewAdapter());
    }

    protected void FakeItemUpdate(object sender, DetailsViewUpdatedEventArgs e)
    {
        e.ExceptionHandled = true;
        e.KeepInEditMode = false;
    }
}
