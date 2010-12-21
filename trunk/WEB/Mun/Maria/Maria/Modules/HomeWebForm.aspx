<%@ Page Title="" Language="C#" MasterPageFile="~/Maria.Master" AutoEventWireup="true" CodeBehind="HomeWebForm.aspx.cs" Inherits="Maria.Modules.HomeWebForm" %>

<%@ Register src="../Menues/VMenu_Home.ascx" tagname="VMenu_Home" tagprefix="uc1" %>



<asp:Content ID="Content3" ContentPlaceHolderID="ContetnPH1" runat="server">
    <uc1:VMenu_Home ID="VMenu_Home3" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContetnPH2" runat="server" EnableViewState="True">

    <p>
    HOME</p>
</asp:Content>
