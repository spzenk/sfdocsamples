<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="News_Rich_Creator.ascx.cs" Inherits="Maria.Usercontrol.News_Rich_Creator" %>


<link href="../Styles/News.css" rel="stylesheet" type="text/css" />
<link href="../Styles/common.css" rel="stylesheet" type="text/css" />

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


<div id="Div3" class ="EnvelopeContNews">
        <div id="Div4" class="EnvelopeNews">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
             
                        <asp:Panel ID="pnlContent" runat="server" Height="100%">
                            <asp:Panel ID="pnHeader" runat="server" CssClass="cpHeaderStatic">
                                <asp:Label ID="Label1" runat="server" Text="Nueva noticia" />
                          </asp:Panel>
                        <asp:Panel ID="pnlBody" runat="server" CssClass="EnvelopeNewsBody">
                            <table style="width: 100%; height : "100%"">
                                <tr>
                              
                                    <td class="style1">
                                        &nbsp;
                                        <asp:Label ID="Label2" runat="server" Text="Titulo " />
                                    </td>
                                    <td>
                                    
                                        <asp:TextBox ID="txtTitle" runat="server" BorderColor="#003366" Columns="250" 
                                            CssClass="guionbajo" ForeColor="Black" Height="21px" MaxLength="1000" Rows="4" 
                                            Width="90%" />
                                    </td>
                                </tr>
                                <tr>
                           
                                    <td class="style1">
                                        &nbsp;
                                        <asp:Label ID="lblComments" runat="server" Text="Texto " />
                                    </td>
                                    <td>
                                       
                                     <textarea runat="server" id="txtText" name="txtBody" rows="8" cols="50" 
                                        onkeyup="javascript:ValidateKeys(this, 4000);" onkeypress="javascript:return LimitSize(this, 4000);" 
                                        onchange="javascript:ValidateSize(this, 4000);"></textarea>
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