<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="_Menu" MasterPageFile="~/Examples.master"
    StylesheetTheme="Basic" Title="Menu Control Adapter: ASP.NET 2.0 CSS Friendly Control Adapters 1.0" %>

<asp:Content runat="server" ContentPlaceHolderID="Prolog">
    <p>
        Binding a Menu control to a SiteMapDataSource is an elegant and simple way to create a menu for a web site. By default,
        ASP.NET uses &lt;table&gt; tags to render the Menu. A <a href="http://www.meyerweb.com/eric/css/edge/menus/demo.html" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;">pure CSS strategy</a> 
        using nested &lt;ul&gt; tags has been gaining popularity in <a href="http://www.alistapart.com/articles/horizdropdowns/" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;">recent years</a>.
    </p>
    <p>
        A control adapter can "teach" the Menu how to produce this kind of CSS friendly HTML without sacrificing the power and flexibility
        of the original Menu control. For example, the root nodes of the menu can be laid out vertically or horizontally.
    </p>
    <p>
        You can learn more about visualizing hierarchical data by studying the <a href="TreeView.aspx">TreeView</a> example, too.
    </p>
    <p>
        This kit's tutorial includes an additional <a runat="server" href="~/WalkThru/WalkThrough.aspx#SimpleMenu" title="Links to the section in the Tutorial that discusses this example page.">Menu example</a>.
    </p>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="LiveExample">
    <div id="SampleMenu">
        <asp:menu id="Menu1" runat="server" skinid="SampleMenuVertical" datasourceid="ExampleSiteMapDS" cssselectorclass="PrettyMenu" />
        <asp:menu id="Menu2" runat="server" skinid="SampleMenuHorizontal" datasourceid="ExampleSiteMapDS" cssselectorclass="PrettyMenu" orientation="Horizontal" />
        <div id="Sample-Content">
            <select>
                <option>The menu should cover this element</option>
                <option>second option</option>
                <option>third</option>
                <option>forth</option>
                <option>fifth</option>
                <option>sixth</option>
            </select>
            Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Donec vehicula aliquam tellus. Sed porta. Proin ac tortor vitae
            justo dapibus pharetra. Cras adipiscing. Nullam rhoncus aliquam mi. Proin sagittis dui sit amet neque blandit rhoncus. Donec
            cursus mattis libero. Nunc et nisl. Ut nibh. Mauris orci massa, dignissim ut, adipiscing a, nonummy non, mauris. Aliquam
            justo. Nullam eu neque. Nulla scelerisque, nisi at cursus commodo, odio est bibendum enim, nec hendrerit turpis tortor sed
            metus. Vestibulum non massa ut lorem ultrices fringilla. Nam placerat velit vitae sem. Cras luctus eros vitae quam.
            <select>
                <option>This one, too</option>
                <option>apples</option>
                <option>oranges</option>
                <option>bananas</option>
            </select>
        </div>
        <asp:sitemapdatasource runat="server" id="ExampleSiteMapDS" sitemapprovider="ExampleSiteMapProvider" showstartingnode="false" />
    </div>
</asp:Content>
