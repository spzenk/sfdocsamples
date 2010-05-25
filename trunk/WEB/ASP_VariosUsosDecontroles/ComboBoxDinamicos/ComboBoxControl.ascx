<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ComboBoxControl.ascx.cs" Inherits="WebApplication1.ComboBoxDinamicos.ComboBoxControl" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<div>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Label ID="lblItemQuestionId" runat="server" Text="Numero"></asp:Label>
        <dxe:ASPxComboBox ID="cmbTest" runat="server" 
        EnableCallbackMode="True"
        OnSelectedIndexChanged="cmbTest_SelectedIndexChanged" Height="18px" 
            Width="187px" ValueType="System.String" CallbackPageSize="15" 
            EnableAnimation="False" oncallback="cmbTest_Callback">

            <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cmbTest.PerformCallback(s.GetValue());
}" />

        </dxe:ASPxComboBox>
    </ContentTemplate>


</asp:UpdatePanel>
</div>


