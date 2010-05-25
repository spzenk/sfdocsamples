<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MicrosoftCombocontrol.ascx.cs" Inherits="WebApplication1.ComboBoxDinamicos.MicrosoftCombocontrol" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<div>
<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Label ID="lblItemQuestionId" runat="server" Text="Numero"></asp:Label>
        <div>
        <asp:DropDownList ID="cmbTest" runat="server" AutoPostBack ="true"  Height="16px" Width="232px">
        </asp:DropDownList>
        </div>
    </ContentTemplate>


</asp:UpdatePanel>
</div>