<%@ Page Title="" Language="C#" MasterPageFile="~/Maria_Admin.master" AutoEventWireup="true" CodeBehind="Admin_CreateNews.aspx.cs" Inherits="Maria.Modules.Admin.Admin_CreateNews" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register src="../../Usercontrol/News_Simple_Creator.ascx" tagname="News_Simple" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <uc1:News_Simple ID="News_Simple1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
