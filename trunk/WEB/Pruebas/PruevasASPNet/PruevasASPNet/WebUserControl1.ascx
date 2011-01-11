<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="WebApplication1.WebUserControl1" %>
    <div>
        <textarea runat="server" id="Textarea1" name="Textarea1" 
            onchange="javascript:return GetText('WebUserControl11_Textarea1')" 
            style="border-style: dashed; height: 233px; width: 898px;"> </textarea>
    </div>
<asp:Button ID="Button1" runat="server" Height="38px" onclick="Button1_Click" 
    style="height: 26px" Text="Button" Width="144px" />
    <br />
    <div>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
</div>