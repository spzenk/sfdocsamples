<%@ Page Title="" Language="C#" MasterPageFile="~/Maria.Master" AutoEventWireup="true" CodeBehind="Municipalidad.aspx.cs" Inherits="Maria.Modules.WebForm1" %>
<%@ Register src="../Menues/VMenu_Home.ascx" tagname="VMenu_Home" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContetnPH1" runat="server">
    <uc1:VMenu_Home ID="VMenu_Home1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContetnPH2" runat="server" EnableViewState="True">
</asp:Content>
