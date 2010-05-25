<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="UsoTreeList.Nivel1.WebForm2" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v8.2, Version=8.2.4.0, Culture=neutral, PublicKeyToken=49d90c14d24271b5"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dxe:ASPxImage ID="ASPxImage1" runat="server" Height="107px" 
        ImageUrl="~/Fotos/freeway.jpg" Width="345px">
    </dxe:ASPxImage>
    <dxe:ASPxLabel ID="ASPxLabel1" runat="server" Font-Bold="True" 
        Text="Formulario 2 nivel 1">
    </dxe:ASPxLabel>
</asp:Content>
