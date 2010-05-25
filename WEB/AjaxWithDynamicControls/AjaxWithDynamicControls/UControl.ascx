<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UControl.ascx.cs" Inherits="AjaxWithDynamicControls.UControl" %>
<div>
    <asp:Label ID="lbltitle" runat="server" Text="Control :
    "></asp:Label>
</div>
<div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox2_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="CheckBox3" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox3_CheckedChanged" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
       
    </asp:UpdatePanel>
</div>
