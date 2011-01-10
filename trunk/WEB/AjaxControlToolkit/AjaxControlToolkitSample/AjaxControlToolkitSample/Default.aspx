<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AjaxControlToolkitSample._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server"> 
  <title>Untitled Page</title> 
</head> 
<body> 
  <form id="form1" runat="server"> 
    <asp:ScriptManager ID="ScriptManager1" runat="server"> 
    </asp:ScriptManager> 
    <cc1:AnimationExtender ID="AnimationExtender1"
runat="server" TargetControlID="Panel1">
 <Animations> 
    <OnMouseOver> 
      <Color Duration=".5" StartValue="#66FFFF" 
        EndValue="#66CCFF" Property="style" 
        PropertyKey="color" /> 
    </OnMouseOver> 
    <OnMouseOut> 
      <Color Duration=".5" EndValue="#6600FF" 
        StartValue="#3366CC" Property="style" 
        PropertyKey="color" /> 
    </OnMouseOut> 
  </Animations>     </cc1:AnimationExtender>
 <asp:Panel ID="Panel1" runat="server" 
      Height="50px" Width="125px" 
      BackColor="AliceBlue" BorderStyle="Groove"> 
      "My first animation with ACT" 
    </asp:Panel> 
  </form> 
</body> 
</html>
