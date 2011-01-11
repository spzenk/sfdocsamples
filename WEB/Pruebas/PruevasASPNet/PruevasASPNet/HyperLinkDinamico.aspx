<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HyperLinkDinamico.aspx.cs" Inherits="WebApplication1.HyperLinkDinamico" %>

<%@ Register src="WebUserControl1.ascx" tagname="WebUserControl1" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<script type="text/javascript" >

        function GetText(txtName) {
            //alert(txtName);
            txtArea = document.getElementById(txtName);
            alert(txtArea.value);
            document.getElementById('HTMLHiddenField').value = txtName;
            h = document.getElementById('HTMLHiddenField');
            return txtArea.value ;
        }
        function RedirectNews() {

           

            var hidden = document.getElementById('HTMLHiddenField');
            Response.Redirect('HyperLinkDinamico_Target.aspx');
            if (hidde != null) {
                hidden.value = h;
                alert(hidden.value);
            }
            else {
                alert('NO');
            }
        }   
        
 </script >
 
<head runat="server">


    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
  
        <asp:HyperLink ID="HyperLink1" NavigateUrl ="~/HyperLinkDinamico_Target.aspx?newGuid=12345"  runat="server" Target  ="_blank">HyperLink</asp:HyperLink>
    </div>
    
   
      
   
    </form>
</body>
</html>
