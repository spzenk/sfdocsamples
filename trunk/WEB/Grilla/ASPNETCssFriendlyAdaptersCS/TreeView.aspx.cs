using System;
using CSSFriendly;
using Wilco.Web.SyntaxHighlighting;

//  The pages in this kit derive from CSSFriendly.ExamplePage.  More typically you would build
//  pages that derive from System.Web.UI.Page. Ultimately, ExamplePage is a kind of System.Web.UI.Page.
//  Meanwhile, ExamplePage and its base class, DynamicAdaptersPage, provide these sample pages with
//  kit-specific functionality like the theme chooser or the adapter enabler/disabler radio buttons.
//  Your pages won't have those features so they will typically derive directly from System.Web.UI.Page.
public partial class _TreeView : ExamplePage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        RelevantControlName = "TreeView";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //  The following block of code prepares for the call to GenerateSnippets.
        //  Though this is important for this sample page, it is unlikely to be useful in
        //  you own web sites.
        if (!IsPostBack)
        {
            TreeView1.ExpandDepth = -1;
            TreeView1.ExpandAll();
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TreeView1.ExpandDepth = 0;
            TreeView1.CollapseAll();
            TreeViewAdapter.ExpandToDepth(TreeView1.Nodes, TreeView1.ExpandDepth);
        }
    }

    protected void Page_PreRenderComplete(object sender, EventArgs e)
    {
        //  Snippet generation.
        if (!IsPostBack)
        {
            TreeView1.ExpandDepth = -1;
            TreeView1.ExpandAll();
            GenerateSnippets(TreeView1, new CSSFriendly.TreeViewAdapter());
            TreeView1.ExpandDepth = 0;
            TreeView1.CollapseAll();
            TreeViewAdapter.ExpandToDepth(TreeView1.Nodes, TreeView1.ExpandDepth);
        }
    }

    //  IMPORTANT: This must be public, not protected.  The adapters OnAdapted... event attributes only work if you
    //  equate them to the names of public event delegate methods.
    public void OnTreeSelection(object sender, EventArgs e)
    {
        CurrentTopic.Text = TreeView1.SelectedNode.Text;
        FakeContextWord1.Text = TreeView1.SelectedNode.Text;
        FakeContextWord2.Text = TreeView1.SelectedNode.Text;
        FakeContextWord3.Text = TreeView1.SelectedNode.Text;
    }
}
