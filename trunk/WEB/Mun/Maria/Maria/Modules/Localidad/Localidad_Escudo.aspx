<%@ Page Title="" Language="C#" MasterPageFile="~/Maria_Localidad.master" AutoEventWireup="true" CodeBehind="Localidad_Escudo.aspx.cs" Inherits="Maria.Modules.Localidad.Localidad_Escudo" %>
<%@ Register src="Localidad_BarrioNorte.ascx" tagname="Localidad_BarrioNorte" tagprefix="uc1" %>
<%@ Register src="Uc_ExplicacionEscudo.ascx" tagname="Uc_ExplicacionEscudo" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <uc2:Uc_ExplicacionEscudo ID="Uc_ExplicacionEscudo1" runat="server" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
