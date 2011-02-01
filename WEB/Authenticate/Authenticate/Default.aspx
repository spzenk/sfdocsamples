<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Authenticate._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:LoginName ID="LoginName1" runat="server" FormatString="Usuario registrado es {0}" />
        <asp:LoginStatus ID="LoginStatus1" runat="server" LoginText="Iniciar" LogoutText="Salir" />
    </div>
    
    <div id="menuh" >
        <ul>
        
               
                <li><a href="PrivateForm.aspx">Acceso Restringido</a> </li>

                <li><a href="PublicForm.aspx">Acceso publico</a></li>
                                   
               

        </ul>

</div>
    </form>
</body>
</html>
