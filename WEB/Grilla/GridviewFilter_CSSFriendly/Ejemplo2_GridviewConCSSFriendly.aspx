<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Ejemplo2_GridviewConCSSFriendly.aspx.cs" Inherits="Ejemplo2_GridviewConCSSFriendly" %>

<%@ Register src="modulos/Ejemplo2_GridviewConCSSFriendly.ascx" tagname="Ejemplo2_GridviewConCSSFriendly" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Ejemplo2_GridviewConCSSFriendly ID="Ejemplo2_GridviewConCSSFriendly1" 
        runat="server" />
</asp:Content>

