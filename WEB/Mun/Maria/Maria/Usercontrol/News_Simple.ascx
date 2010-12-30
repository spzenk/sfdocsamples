<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="News_Simple.ascx.cs" Inherits="Maria.Usercontrol.News_Simple" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="NewsBase.ascx" tagname="NewsBase" tagprefix="uc1" %>
<link href="../Styles/News.css" rel="stylesheet" type="text/css" />
   <script type="text/javascript">

       function pageLoad(sender, args) {
           smoothAnimation();
       }


       function smoothAnimation() {
           var collPanel = $find("CollapsiblePanelExtender1");
           collPanel._animation._fps = 45;
           collPanel._animation._duration = 0.90;
       }
       function coll_ExpandedComplete(sender, arg) {
           for (num = 1; num < 3; num++) {
               var CollapsiblePanel = $find("CollapsiblePanelExtender" + num);
               if (sender._expandControlID != CollapsiblePanel._expandControlID)
                   CollapsiblePanel.collapsePanel(CollapsiblePanel._expandControlID);
           }
       }       
 
</script>


<div id="Div2">

    <div id="Div3" class ="EnvelopeCont">
        <div id="Div4" class="EnvelopeArtic">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="pnlTitle" runat="server">
                        <div class="EnvelopeNewsHeader">
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlContent" runat="server" Height="174px">
                        <asp:Panel ID="Panel1" runat="server" CssClass="cpHeader">
                            <asp:Label ID="Label1" runat="server" /></asp:Panel>
                        <asp:Panel ID="pnlComments" runat="server" CssClass="EnvelopeNewsBody">
                            <asp:Label ID="Label2" runat="server" Text="Titulo: " />
                            <br />
                            <asp:Label ID="lblComments" runat="server" Text="Texto: " />
                            <asp:TextBox ID="txtTitle" runat="server" CssClass="guionbajo" MaxLength="1000" Width="44%"
                                Columns="250" Rows="4" Height="21px" BorderColor="#003366" ForeColor="Black" />
                            <br />
                            <asp:TextBox ID="txtComments" runat="server" CssClass="AreaNewsComments" MaxLength="1000"
                                Width="100%" Columns="250" Rows="4" TextMode="MultiLine" />
                            <asp:Button ID="btnCreateNew" runat="server" Text="Crear noticia" OnClick="btnCreateNew_Click" />
                        </asp:Panel>
                    </asp:Panel>
                    <cc1:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" TargetControlID="pnlContent"
                        CollapseControlID="pnlTitle" ExpandControlID="pnlTitle" Collapsed="true" TextLabelID="lblText"
                        CollapsedText="+ Noticias" ExpandedText="- Noticias" CollapsedSize="0">
                    </cc1:CollapsiblePanelExtender>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div id="Div1" class ="EnvelopeCont">
        <div id="d1" class="EnvelopeArtic">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="pHeader" runat="server" CssClass="cpHeader">
                        <asp:Label ID="lblText" runat="server" />
                    </asp:Panel>
                    <asp:Panel ID="pBody" runat="server" CssClass="cpBody">
                        Aagregue noticias
                    </asp:Panel>
                    <cc1:CollapsiblePanelExtender ID="CollapsiblePanelExtender2" runat="server" TargetControlID="pBody"
                        CollapseControlID="pHeader" ExpandControlID="pHeader" Collapsed="true" TextLabelID="lblText"
                        CollapsedText="Click to Show Content.." ExpandedText="Click to Hide Content.."
                        CollapsedSize="0">
                    </cc1:CollapsiblePanelExtender>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
     </div>
</div>
</div>