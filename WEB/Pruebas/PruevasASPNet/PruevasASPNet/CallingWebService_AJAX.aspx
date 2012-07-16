<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CallingWebService_AJAX.aspx.cs" Inherits="WebApplication1.CallingWebService_AJAX" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript"> 
    function OnLookup()
    {           
      var stb = document.getElementById("_symbolTextBox");
      Health.Ws.SingleService.Test(OnLookupComplete, OnError);


    }
    
    function OnLookupComplete(result)
    {
      var res = document.getElementById("_resultLabel");
      res.innerHTML = "<b>" + result + "</b>";
      alert('llegaron los datos');
  }
  function OnError(result) {
      alert("Error: " + result.get_message());
  }
  </script>  
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="_scriptManager" runat="server">
            <Services>
                <asp:ServiceReference Path="http://localhost:38091/SingleService.asmx" />
            </Services>
        </asp:ScriptManager>
        <div>
            <h1>
                ASP.NET AJAX Web Services: Web Service Sample Page</h1>
            Enter symbol:
            <asp:TextBox runat="server" ID="_symbolTextBox" />
            <br />
            <input onclick="OnLookup();" id="_lookupButton" type="button" value="Lookup" />
            <br />
            <asp:Label runat="server" ID="_resultLabel" />
        </div>
    </div>
    </form>
</body>
</html>
