<%@ Page Title="" Language="C#" MasterPageFile="~/Maria_Admin.master" AutoEventWireup="true" CodeBehind="Admin_Login.aspx.cs" Inherits="Maria.Modules.Admin.Admin_Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <div id="divStatus">
      <asp:Login ID="Login1" runat="server" Width= "100%" 
          FailureText="Su intento de inicio de sesión no se realizó correctamente. Por favor, inténtelo de nuevo." 
          LoginButtonText="Iniciar" 
          PasswordRequiredErrorMessage="La password es requerida." 
          RememberMeText="Recordar mis datos la próxima vez" 
          UserNameLabelText="Nombre de usuario:" 
          UserNameRequiredErrorMessage="El nombre ed usuario es requerido.">
          
      </asp:Login>
  </div>
 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
