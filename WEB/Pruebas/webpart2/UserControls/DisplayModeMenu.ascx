<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DisplayModeMenu.ascx.cs" Inherits="UserControls_DisplayModeMenu" %>
<div>
  <asp:Panel ID="Panel1" runat="server" 
    Borderwidth="1" 
    Width="230" 
    BackColor="lightgray"
    Font-Names="Verdana, Arial, Sans Serif" >
    <asp:Label ID="Label1" runat="server" 
      Text="&nbsp;Display Mode" 
      Font-Bold="true"
      Font-Size="8"
      Width="120" />
    <div>
    <asp:DropDownList ID="DisplayModeDropdown" runat="server"  
      AutoPostBack="true" 
      Width="120"
      OnSelectedIndexChanged="DisplayModeDropdown_SelectedIndexChanged" />
    <asp:LinkButton ID="LinkButton1" runat="server"
      Text="Reset User State" 
      ToolTip="Reset the current user's personalization data for 
      the page."
      Font-Size="8" 
      OnClick="LinkButton1_Click" />
    </div>
    <asp:Panel ID="Panel2" runat="server" 
      GroupingText="Personalization Scope"
      Font-Bold="true"
      Font-Size="8" 
      Visible="false" >
      <asp:RadioButton ID="RadioButton1" runat="server" 
        Text="User" 
        AutoPostBack="true"
        GroupName="Scope" 
        OnCheckedChanged="RadioButton1_CheckedChanged" />
      <asp:RadioButton ID="RadioButton2" runat="server" 
        Text="Shared" 
        AutoPostBack="true"
        GroupName="Scope" 
        OnCheckedChanged="RadioButton2_CheckedChanged" />
    </asp:Panel>
  </asp:Panel>
</div>
