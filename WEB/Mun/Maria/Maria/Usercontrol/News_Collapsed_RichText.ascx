<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="News_Collapsed_RichText.ascx.cs" Inherits="Maria.Usercontrol.News_Collapsed_RichText" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<link href="/Styles/Common.css" rel="stylesheet" type="text/css" />
<link href="/Styles/News.css" rel="stylesheet" type="text/css" />

<div id="d1" style="width: 100%; height: 100%"  >
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pHeader" runat="server" CssClass="cpHeaderExpand">
                <asp:Label ID="lbltitle" runat="server" Text="Parrafo introductorio" />
            </asp:Panel>
            <asp:Panel ID="pBody" runat="server" CssClass="cpBody" Width="100%">
                <textarea runat="server" id="txtText" name="txtIntro" cols="10" style="width: 100%;
                    height: 500px"> </textarea>
            </asp:Panel>
            <cc1:CollapsiblePanelExtender ID="CollapsiblePanelExtender2" runat="server" TargetControlID="pBody"
                CollapseControlID="pHeader" ExpandControlID="pHeader" Collapsed="true" TextLabelID="lblText"
                CollapsedText="+ Avanzada" ExpandedText="- Avanzada" CollapsedSize="0">
            </cc1:CollapsiblePanelExtender>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
