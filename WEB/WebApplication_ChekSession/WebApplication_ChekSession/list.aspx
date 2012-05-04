<%@ Page Title="USuarios logueados Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="list.aspx.cs" Inherits="WebApplication_ChekSession.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Usuarios Activos <%= ((Dictionary<string, DateTime>)Application["ActiveUsers"]).Count%>
    </h2>
    <p>
        <%= LIST %>
    </p>
</asp:Content>
