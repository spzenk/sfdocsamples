<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AjaxWithDynamicControls._Default" %>

<%@ Register src="UControl.ascx" tagname="UControl" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="Stylesheet1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="bodyDiv">
        <div id = "leftContent">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:PlaceHolder ID="pnlContent" runat="server"></asp:PlaceHolder>
        </div>
        <div id ="rightContent">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                </ContentTemplate>
            </asp:UpdatePanel>
           
            <asp:TextBox ID="TextBox1" runat="server" Height="42px" Width="798px"></asp:TextBox>
        </div>
    </div>
    <div id ="footer">
     <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Style="margin-bottom: 0px"
                Text="View results" Width="96px" />
    <asp:GridView ID="GridView1" runat="server" Width="738px" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Check control" />
            <asp:CheckBoxField DataField="Chk1" HeaderText="Check1" />
            <asp:CheckBoxField DataField="Chk2" HeaderText="Check2" />
            <asp:CheckBoxField DataField="Chk3" HeaderText="Check3" />
        </Columns>
    </asp:GridView>
    </div>
    </form>
</body>
</html>
