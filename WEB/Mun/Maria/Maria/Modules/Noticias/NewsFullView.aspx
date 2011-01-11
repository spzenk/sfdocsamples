<%@ Page Title="" Language="C#" MasterPageFile="~/Maria_News.master" AutoEventWireup="true" CodeBehind="NewsFullView.aspx.cs" Inherits="Maria.Modules.Noticias.NewsFullView" %>
<%@ Register src="../../Usercontrol/News_FullViews.ascx" tagname="News_FullViews" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:News_FullViews ID="News_FullViews1" runat="server" />
</asp:Content>
