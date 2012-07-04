using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using CSSFriendly;

public partial class _GridView : ExamplePage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        RelevantControlName = "GridView";
    }

    protected void Page_PreRenderComplete(object sender, EventArgs e)
    {
        GenerateSnippets(GridView1, new CSSFriendly.GridViewAdapter());
    }

    protected void DoRowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            int i = -1;
            for (i = 0; i < GridView1.Columns.Count; i++)
            {
                DataControlField field = GridView1.Columns[i];
                if (field.SortExpression == GridView1.SortExpression)
                {
                    break;
                }
            }
            
            if ((i > -1) && (i < GridView1.Columns.Count) && (e.Row.Cells.Count > i))
            {
                TableCell tc = e.Row.Cells[i];
                if (tc.HasControls())
                {
                    Image img = new Image();
                    if (GridView1.SortDirection == SortDirection.Ascending)
                    {
                        img.ImageUrl = "~/images/asc.gif";
                    }
                    else
                    {
                        img.ImageUrl = "~/images/desc.gif";
                    }
                    tc.Controls.Add(new LiteralControl("<br />"));
                    tc.Controls.Add(img);
                }
            }
        }
    }
}
