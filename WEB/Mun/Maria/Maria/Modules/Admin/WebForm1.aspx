<%@ Page Title="" Language="C#" MasterPageFile="~/Maria_Admin.master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Maria.Modules.Admin.WebForm1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register src="../../Usercontrol/News_Simple.ascx" tagname="News_Simple" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="Div1" class ="EnvelopeCont">
        <div id="d1" class="EnvelopeArtic">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="pHeader" runat="server" CssClass="cpHeader">
                        <asp:Label ID="lblText" runat="server" />
                    </asp:Panel>
                    <asp:Panel ID="pBody" runat="server" CssClass="cpBody">
                        Aagregue noticias
                    </asp:Panel>
                    <cc1:CollapsiblePanelExtender ID="CollapsiblePanelExtender1"
                     runat="server" TargetControlID="pBody"
                        CollapseControlID="pHeader" ExpandControlID="pHeader" Collapsed="true" TextLabelID="lblText"
                        CollapsedText="Click to Show Content.." ExpandedText="Click to Hide Content.."
                        CollapsedSize="0">
                    </cc1:CollapsiblePanelExtender>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
     </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
