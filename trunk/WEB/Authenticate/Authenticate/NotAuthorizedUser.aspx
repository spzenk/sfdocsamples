<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NotAuthorizedUser.aspx.cs" Inherits="Authenticate.NotAuthorizedUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <span style="color: #666666">&nbsp;No es un usuario autorizado para realizar
            esta acción.
            <br />
        </span>
        <br style="color: #666666" />
        <span style="color: #666666">Por favor inicie sesion.- </span>
    </div>

    <div style="width: 100%; height: 182px; float: left">
        <div id="divStatus">
            <asp:Login ID="Login1" runat="server" Width="100%" FailureText="Su intento de inicio de sesión no se realizó correctamente. Por favor, inténtelo de nuevo."
                LoginButtonText="Iniciar" PasswordRequiredErrorMessage="La password es requerida."
                RememberMeText="Recordar mis datos la próxima vez" UserNameLabelText="Nombre de usuario:"
                UserNameRequiredErrorMessage="El nombre ed usuario es requerido.">
            </asp:Login>
        </div>
    </div>
    </form>
</body>
</html>
