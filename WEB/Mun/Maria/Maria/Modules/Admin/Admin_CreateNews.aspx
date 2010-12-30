<%@ Page Title="" Language="C#" MasterPageFile="~/Maria_Admin.master" AutoEventWireup="true" CodeBehind="Admin_CreateNews.aspx.cs" Inherits="Maria.Modules.Admin.Admin_CreateNews" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="pHeader" runat="server" CssClass="cpHeader">
                        <asp:Label ID="lblText" runat="server" />
                    </asp:Panel>
                    <asp:Panel ID="pBody" runat="server" CssClass="cpBody">
                        Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                        incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                        exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure
                        dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur
                    </asp:Panel>
                    <cc1:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" TargetControlID="pBody"
                        CollapseControlID="pHeader" ExpandControlID="pHeader" Collapsed="true" TextLabelID="lblText"
                        CollapsedText="Click to Show Content.." ExpandedText="Click to Hide Content.."
                        CollapsedSize="0">
                    </cc1:CollapsiblePanelExtender>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
