<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UControl.ascx.cs" Inherits="DynamicControls_NoAutopostBack.UControl" %>
<div>
    <asp:Label ID="lbltitle" runat="server" Text="Control :
    "></asp:Label>
</div>
<div>
<table>
    <tr>
        <td>
            <asp:CheckBox ID="CheckBox1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:CheckBox ID="CheckBox2" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:CheckBox ID="CheckBox3" runat="server" />
        </td>
    </tr>
</table>
</div>