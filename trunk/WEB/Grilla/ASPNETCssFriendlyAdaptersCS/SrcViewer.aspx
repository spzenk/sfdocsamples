<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="SrcViewer.aspx.cs" Inherits="SrcViewer" Title="Source Viewer: ASP.NET 2.0 CSS Friendly Control Adapters 1.0" StyleSheetTheme="Basic" %>
<%@ Register TagPrefix="wilco" Namespace="Wilco.Web.SyntaxHighlighting" Assembly="Wilco.SyntaxHighlighter" %>

<asp:Content ContentPlaceHolderID="HeadContent" runat="Server">
<!--[if IE 6]>
<style>
#SCVPanel
{
    left: 0 !important;
}
</style>
<![endif]--> 
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="Server">
    <asp:Panel runat="server" id="SCVTree" CssClass="SCVTree">
        <div class="dashboardLink">
            <asp:Button runat="server" ID="ReturnBtn" CssClass="button" Text="back to example" OnClick="ReturnBtnClicked" />
        </div>
        <asp:TreeView ID="SrcCodeViewerTree" runat="server" DataSourceID="SourceTreeDS" SkinID="SrcCodeViewerTree">
            <DataBindings>
                <asp:TreeNodeBinding DataMember="logicalUnit" TextField="id" SelectAction="Expand" />
                <asp:TreeNodeBinding DataMember="folder" TextField="name" SelectAction="Expand" />
                <asp:TreeNodeBinding DataMember="file" TextField="name" />
            </DataBindings>
        </asp:TreeView>
        <asp:XmlDataSource runat="server" ID="SourceTreeDS" DataFile="~/App_Data/sourceFiles.xml" />
    </asp:Panel>
    <div id="SCVPanel">
        <h1 runat="server" id="FileBanner">
        </h1>
        <wilco:SyntaxHighlighter ID="SrcCodeViewerPanel" runat="server" Language="ASPX" Mode="Source" />
    </div>
</asp:Content>
