<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register src="UserControls/UC1.ascx" tagname="UC1" tagprefix="uc1" %>
<%@ Register src="UserControls/DisplayModeMenu.ascx" tagname="DisplayModeMenu" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .style1
        {
            width: 316px;
            height: 523px;
        }
        .style2
        {
            width: 258px;
            height: 523px;
        }
        .style3
        {
            width: 227px;
            height: 523px;
        }
        #TextArea1
        {
            width: 203px;
        }
        .style4
        {
            width: 316px;
            height: 79px;
        }
        #Table2
        {
            width: 596px;
        }
        #Table1
        {
            height: 433px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;Prueba web parts Ejemplo 2<uc2:DisplayModeMenu ID="DisplayModeMenu1" 
            runat="server" />
        <br />
        <asp:WebPartManager ID="WebPartManager1" runat="server">
        </asp:WebPartManager>
        <asp:Button ID="brnReset" runat="server" Text="Reset" 
            Width="133px" />
        <asp:Button ID="brnDesign" runat="server" 
            Text="Design" Width="133px" />
        <asp:Button ID="brnEdit" runat="server"  Text="Edit" 
            Width="133px" />
    </div>
    <div>
        <table id="Table1">
            <tr>
                <td id="Td1" class="style1" 
                    style="border: thin groove #000000; background-color: #FFFFFF">
                    <asp:WebPartZone ID="WebPartZone1" runat="server" Height="492px" Width="297px">
                    </asp:WebPartZone>
                </td>
                <td id="Td2" class="style3">
                    <asp:WebPartZone ID="WebPartZone2" runat="server" Height="501px" Width="286px" 
                        onload="WebPartZone2_Load">
                        <ZoneTemplate>
                            <uc1:UC1 ID="UC11" runat="server" />
                        </ZoneTemplate>
                    </asp:WebPartZone>
                </td>
                <td id="Td3" class="style2">
                    &nbsp;</td>
            </tr>
        
        </table>
        
        <table id= "Table2">
           <tr>
              <td class="style4">
              
              </td>
            
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
