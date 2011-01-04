    <%@ Control Language="C#" AutoEventWireup="true" CodeBehind="News_Simple.ascx.cs" Inherits="Maria.Usercontrol.News_Simple" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="NewsTitle.ascx" tagname="NewsTitle" tagprefix="uc1" %>

<link href="../Styles/News.css" rel="stylesheet" type="text/css" />
<link href="../Styles/common.css" rel="stylesheet" type="text/css" />

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
       function cambiarEstilo() {

           document.getElementById('btnCreateNew').style.backgroundColor = '#FFAAFF';
          
       }
</script>

   

<style type="text/css">
    .style1
    {
         font: bold 11px Verdana;
        width: 74px;
    }
    .style2
    {
        width: 47px;
    }
</style>


<div id="Div2">

    <div id="Div3" class ="EnvelopeContNews">
        <div id="Div4" class="EnvelopeNews">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="pnlTitle" runat="server">
                        <div class="EnvelopeNewsHeader">
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlContent" runat="server" Height="100%">
                        <asp:Panel ID="Panel1" runat="server" CssClass="cpHeaderStatic">
                            <asp:Label ID="Label1" runat="server" Text="Nueva noticia" />
                      </asp:Panel>
                        <asp:Panel ID="pnlComments" runat="server" CssClass="EnvelopeNewsBody">
                            <table style="width: 100%; height : "100%"">
                                <tr>
                              
                                    <td class="style1">
                                        &nbsp;
                                        <asp:Label ID="Label2" runat="server" Text="Titulo " />
                                    </td>
                                    <td>
                                    
                                        <asp:TextBox ID="txtTitle" runat="server" BorderColor="#003366" Columns="250" 
                                            CssClass="guionbajo" ForeColor="Black" Height="21px" MaxLength="1000" Rows="4" 
                                            Width="44%" />
                                    </td>
                                </tr>
                                <tr>
                           
                                    <td class="style1">
                                        &nbsp;
                                        <asp:Label ID="lblComments" runat="server" Text="Texto " />
                                    </td>
                                    <td>
                                       
                                        <asp:TextBox ID="txtComments" runat="server" Columns="250" 
                                            CssClass="AreaNewsComments" Height="171px" MaxLength="1000" Rows="4" 
                                            TextMode="MultiLine" Width="100%" 
                                            ontextchanged="txtComments_TextChanged" />
                                    </td>
                                </tr>
                            
                            </table>
                            <br />
                           
                              
                            <br />
                                <br />
                            <asp:Button ID="btnCreateNew" runat="server" Text="Crear noticia" 
                                OnClick="btnCreateNew_Click" CssClass="btGrisNegrita" />
                        </asp:Panel>
                    </asp:Panel>
         
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div id="Div1" class ="EnvelopeContNews">
        <div id="d1" class="EnvelopeNews">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="pHeader" runat="server" CssClass="cpHeaderExpand">
                        <asp:Label ID="lblText" runat="server" Text="Avanzada" />
                    </asp:Panel>
                    <asp:Panel ID="pBody" runat="server" CssClass="cpBody">
                        Aagregue noticias
                    </asp:Panel>
                    <cc1:CollapsiblePanelExtender ID="CollapsiblePanelExtender2" runat="server" TargetControlID="pBody"
                        CollapseControlID="pHeader" ExpandControlID="pHeader" Collapsed="true" TextLabelID="lblText"
                        CollapsedText="+ Avanzada" ExpandedText="- Avanzada"
                        CollapsedSize="0">
                    </cc1:CollapsiblePanelExtender>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
     </div>
</div>
