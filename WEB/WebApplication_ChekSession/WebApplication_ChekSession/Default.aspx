<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebApplication_ChekSession._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Ingrese su nombre de usuario y precione iniciar session
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
    </h2>
    <p>
        
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Iniciar session (Id Contacto)" 
            onclick="Button1_Click" />
      <asp:Label
            ID="Label1" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
    </p>
</asp:Content>
