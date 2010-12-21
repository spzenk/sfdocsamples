<%@ Page Title="" Language="C#" MasterPageFile="~/Maria.Master" AutoEventWireup="true" CodeBehind="Localidad_UbicacionAcceso.aspx.cs" Inherits="Maria.Menues.Localidad" %>
<%@ Register src="../Menues/VMenu_Home.ascx" tagname="VMenu_Home" tagprefix="uc1" %>
<%@ Register src="../Menues/VMenu_Localidad.ascx" tagname="VMenu_Localidad" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContetnPH1" runat="server">
    <p>
        <a href="Localidad_UbicacionAcceso.aspx"></a></p>
    <uc2:VMenu_Localidad ID="VMenu_Localidad1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContetnPH2" runat="server">
    Localidad_UbicacionAcceso
</asp:Content>
