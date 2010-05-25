<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComboBoxPage.aspx.cs" Inherits="WebApplication1.ComboBoxDinamicos.ComboBoxPage" EnableSessionState="False" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1
        {
            height: 410px;
            width: 838px;
            margin-bottom: 15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Button ID="btnLoad" runat="server" onclick="Button1_Click" Text="Load" />
    <asp:ScriptManager ID="ScriptManager1" runat="server" 
        onprerender="ScriptManager1_PreRender">
    </asp:ScriptManager>
    <div style="border-style: dotted; border-width: thin; text-align: left; position: absolute;
        top: 27px; left: 102px; width: 727px; height: 70%; ">
        <div style="background-color: #FFFF99; height: 100%; bottom:100px;">
            <br />
            <br />
            <asp:Panel ID="ContentPanel" runat="server" Height="121%" 
                Style="margin-bottom: 4px" ScrollBars="Vertical">
            </asp:Panel>
        </div>
    </div>
    </form>
</body>
</html>
