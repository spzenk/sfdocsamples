<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="GenericPage.aspx.cs" Inherits="GenericPage" Title="Generic landing page: ASP.NET 2.0 CSS Friendly Control Adapters 1.0" StyleSheetTheme="Basic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<p>
    This page is generic.  It represents <em>any</em> page within your site.
</p>

<p runat="server" id="whereFrom">
    You navigated here from <asp:HyperLink runat="server" ID="returnLink" />.
</p>
</asp:Content>

