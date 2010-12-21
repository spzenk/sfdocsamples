<%@ Page Title="" Language="C#" MasterPageFile="~/Maria.Master" AutoEventWireup="true" CodeBehind="Localidad_NaceUnPueblo.aspx.cs" Inherits="Maria.Modules.Localidad_NaceUnPueblo" %>
<%@ Register src="../Menues/VMenu_Localidad.ascx" tagname="VMenu_Localidad" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContetnPH1" runat="server">
    <uc1:VMenu_Localidad ID="VMenu_Localidad1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContetnPH2" runat="server">
    <p>
    Localidad Nace un pueblo</p>
</asp:Content>
