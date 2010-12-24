<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Maquetado.WebForm1" %>
<%@ Register src="Menues/MainMenu.ascx" tagname="MainMenu" tagprefix="uc1" %>
<%@ Register src="Menues/VMenu_Localidad.ascx" tagname="VMenu_Localidad" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentLeft" runat="server">
    
    <uc1:MainMenu ID="MainMenu1" runat="server" />
    <uc2:VMenu_Localidad ID="VMenu_Localidad1" runat="server" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentCenter" runat="server">
            
</asp:Content>
