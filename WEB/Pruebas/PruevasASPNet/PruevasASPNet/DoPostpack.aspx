<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DoPostpack.aspx.cs" Inherits="WebApplication1.DoPostpack" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >


    
<head runat="server">
    <title></title>
    
     <script type="text/javascript">
         function ejecutar__doPostBack() {
             __doPostBack('<%= txt_desde.UniqueID %>', 'actualizar_label');
         }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
        <asp:Label ID="lbl_hasta" runat="server"></asp:Label>
        <asp:TextBox ID="txt_desde" runat="server"></asp:TextBox>
        <div style="margin:2em">
        <a href="#" onclick="ejecutar__doPostBack()">Ejecutar __doPostBack</a>
        </div>
        
    </div>
    </form>
</body>
</html>
