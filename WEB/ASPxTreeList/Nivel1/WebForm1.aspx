<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="UsoTreeList.WebForm1" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v8.2, Version=8.2.4.0, Culture=neutral, PublicKeyToken=49d90c14d24271b5" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dxe:ASPxLabel ID="ASPxLabel1" runat="server" Font-Bold="True" 
        Text="Formulario 1 nivel 1">
    </dxe:ASPxLabel>
    <dxe:ASPxCalendar ID="ASPxCalendar1" runat="server" 
        CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" 
        CssPostfix="Office2003_Blue" ImageFolder="~/App_Themes/Office2003 Blue/{0}/">
    </dxe:ASPxCalendar>
    
</asp:Content>
