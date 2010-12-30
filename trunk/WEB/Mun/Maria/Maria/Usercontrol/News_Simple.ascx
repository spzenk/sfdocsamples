<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="News_Simple.ascx.cs" Inherits="Maria.Usercontrol.News_Simple" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="NewsBase.ascx" tagname="NewsBase" tagprefix="uc1" %>
<link href="/Styles/News.css" rel="stylesheet" type="text/css" />

<div id="<%=string.Concat("WC", News.NewsId) %>">
    <div id="EnvelopeNews">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <asp:Panel ID="pnlTitle" runat="server">
            <div class="EnvelopeNewsHeader">
                
            </div>  
        </asp:Panel>
        <ContentTemplate>
        
        <asp:Panel ID="pnlContent" runat="server">
            <div class="EnvelopeNewsBody">
                <asp:Panel ID="Panel1" runat="server" />
                <asp:Label ID="lblNote" runat="server" Text="" Font-Italic="true" />
            </div>
            <div class="EnvelopeNewsComments">
                <asp:Panel ID="pnlComments" runat="server">
                    <asp:Label ID="lblComments" runat="server" Text="Comentarios: " />
                    <br />
                    <asp:TextBox ID="txtComments" runat="server" CssClass="AreaNewsComments" MaxLength="1000" Width="100%" Columns="250" Rows="4" TextMode="MultiLine" />
                </asp:Panel>
            </div>
        </asp:Panel>
        <cc1:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server"
            TargetControlID="pnlContent"
            CollapseControlID="pnlTitle"
            ExpandControlID="pnlTitle">
        </cc1:CollapsiblePanelExtender>
          </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>