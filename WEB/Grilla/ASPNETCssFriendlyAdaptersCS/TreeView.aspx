<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TreeView.aspx.cs" Inherits="_TreeView" MasterPageFile="~/Examples.master" StyleSheetTheme="Basic" Title="TreeView Control Adapter: ASP.NET 2.0 CSS Friendly Control Adapters 1.0" %>

<asp:Content runat="server" ContentPlaceHolderID="Prolog">
    <p>
        Both a TreeView and a <a href="Menu.aspx">Menu</a> visualize hierarchical information.
        Without adapters both use HTML &lt;table&gt; tags.  Control adapters can be used so that nested
        &lt;ul&gt; tags are rendered instead. A combination of CSS and JavaScript can then be
        used to show and hide portions of the hierarchy of the tree or menu.
    </p>
    <p>
        When the CSS and JavaScript are removed the adapted HTML degrades into simple nested unordered lists
        that are easily interpreted by screen readers, etc. You can see this for yourself by setting 
        the theme to <em>None</em> in the <em>Theme Chooser</em> on the left.
    </p>
    <p>
        <strong>Quick demo:</strong> Expand several nodes in the tree. Select a node (this causes the 
        page to post back). You'll notice that:
    </p>
    <ul>
        <li>The TreeView maintains its expansion state.</li>
        <li>The TreeView's selected node is visually identified.</li>
        <li>The page's sample content has changed to include several instances of the selected node's value.</li>
    </ul>
    <p>
        Additional TreeView examples:
    </p>
    <ul>
        <li><a runat="server" href="~/WalkThru/WalkThrough.aspx#CheckboxesTreeView" title="Links to the section in the Tutorial that discusses this example page">Checkboxes.</a></li>
        <li><a runat="server" href="~/WalkThru/WalkThrough.aspx#CascadingCheckboxTreeView" title="Links to the section in the Tutorial that discusses this example page">Cascading checkboxes.</a></li>
        <li><a runat="server" href="~/WalkThru/WalkThrough.aspx#PopulateOnDemandTreeView" title="Links to the section in the Tutorial that discusses this example page">Populate-on-demand</a></li>
        <li><a runat="server" href="~/WalkThru/WalkThrough.aspx#SimpleTreeView" title="Links to the section in the Tutorial that discusses this example page">Postback (including emulation of the SelectedNodeChanged, TreeNodeCheckChanged and TreeNodePopulate events)</a></li>
    </ul>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="LiveExample">
    <div id="SampleTreeView"> 
        <div id="Sample-Control">
            <asp:TreeView ID="TreeView1" runat="server" DataSourceID="ExampleSiteMapDS" SkinID="SampleTreeView"
                          CssSelectorClass="PrettyTree" OnSelectedNodeChanged="OnTreeSelection" OnAdaptedSelectedNodeChanged="OnTreeSelection">
                <DataBindings>
                  <asp:TreeNodeBinding DataMember="siteMapNode" TextField="title"/>
                </DataBindings>
            </asp:TreeView>
        </div>
        <div id="Sample-Content">
            <h1><asp:Label runat="server" ID="CurrentTopic" Text="Welcome" /></h1>
            <p>
                Lorem ipsum
                <strong><asp:Label runat="server" ID="FakeContextWord1" /></strong>
                dolor sit amet, consectetuer adipiscing elit. Donec vehicula aliquam tellus. Sed porta. Proin ac tortor vitae
                <strong><asp:Label runat="server" ID="FakeContextWord2" /></strong>
                justo dapibus pharetra. Cras adipiscing. Nullam rhoncus aliquam mi. Proin sagittis dui sit amet neque blandit 
                rhoncus. Donec cursus mattis libero. Nunc et nisl. Ut nibh. Mauris orci massa, dignissim ut, adipiscing a,
                nonummy non, mauris. Aliquam justo. Nullam eu neque. Nulla scelerisque, nisi at cursus commodo, odio est 
                <strong><asp:Label runat="server" ID="FakeContextWord3" /></strong>
                bibendum enim, nec hendrerit turpis tortor sed metus. Vestibulum non massa ut lorem ultrices fringilla. Nam 
                placerat velit vitae sem. Cras luctus eros vitae quam.
            </p>
        </div>
        <div class="clearing">&nbsp;</div>
        <asp:XmlDataSource runat="server" ID="ExampleSiteMapDS" DataFile="~/example.sitemap" TransformFile="~/RemoveNamespace.xsl" XPath="/siteMap/siteMapNode/siteMapNode" />
    </div>
</asp:Content>
