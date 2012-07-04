using System;
using CSSFriendly;

public partial class _DataList : ExamplePage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        RelevantControlName = "DataList";
    }

    protected void Page_PreRenderComplete(object sender, EventArgs e)
    {
        GenerateSnippets(MyDataList, new CSSFriendly.DataListAdapter());
    }
}
