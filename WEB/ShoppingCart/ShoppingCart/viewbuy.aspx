<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="viewbuy.aspx.cs" Inherits="ShoppingCart.viewbuy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <script type="text/javascript" language="javascript">

     $(document).ready(function () {

         var msg = $('#MainContent_msg');
         var comprarDiv = $('#comprarDiv');

         var CART_DIV = $('#cart-div-container');
         var todal_div = $('#todal_div');

         if (msg.is(":visible")) {
             CART_DIV.hide();
             todal_div.hide();
             comprarDiv.hide();
         }
         else {
             CART_DIV.show();
             todal_div.show();
         }
     });

     void buy()
     {
         var path = Getrootpath('');
         document.location.href = path + "/buycart.aspx"; 
     }
   
    </script>
    <div class="clear"></div>
    <div id="centerContent_div" class="grid_12">
        <div class="frm_title_2" style="margin-top: 9px">
            Listado de su compra</div>
        <asp:Label ID="msg" Width="641px" CssClass="frm-message" runat="server" Text="No productos en su carrito de compras"
            Font-Bold="True" Visible="false" Style="margin-left: 100px;"> </asp:Label>
        <div id="cart-div-container" class="cart-div" style="margin-left: 100px; width: 650px">
            <%--PRODUCT PANEL GRID VIEW--%>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div id="divGridView" class="cart-div" style="border-style: none; display: table;">
                        <asp:GridView ID="GridView_Prod" runat="server" AutoGenerateColumns="False" CSSSelectorClass="YodaGrilla"
                            ToolTip="Lista de productos" BorderColor="White" CaptionAlign="Left" Width="600"
                            ShowHeader="False" OnRowCommand="GridView_Prod_RowCommand" OnRowDataBound="GridView_Prod_RowDataBound">
                            <PagerSettings Position="TopAndBottom" FirstPageText="Ir al inicio" LastPageText="Ultima pagina"
                                Mode="NextPreviousFirstLast"></PagerSettings>
                            <Columns>
                                <asp:TemplateField HeaderText="" ItemStyle-CssClass="cart-catalog-col">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton2" CommandArgument='<%# Eval("Id") %>' CommandName="remove"
                                            runat="server" CssClass="icon_remov"> 
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Count" HeaderText="Count" ReadOnly="True" SortExpression="Count"
                                    ItemStyle-CssClass="cart-catalog-col" />
                                <asp:BoundField DataField="Description" HeaderText="Description" ReadOnly="True"
                                    SortExpression="Description" ItemStyle-CssClass="cart-catalog-col-desc" />
                                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" Visible="false" SortExpression="Id" />
                                <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="True" SortExpression="Price"
                                    ItemStyle-CssClass="cart-catalog-col-price" DataFormatString="{0:c}"/>
                            </Columns>
                              <AlternatingRowStyle  BorderStyle="Solid" BorderWidth="1" BorderColor="#A8A7A6" />
                            <RowStyle BorderStyle="Solid" BorderWidth="1"  BorderColor="#A8A7A6" />
                        </asp:GridView>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div id="todal_div" style="float: right; margin: 3px">
            <div class="frm_label_2">
                <span class="frm_ast">*</span> Total
            </div>
            <div class="frm_fieldvalue" style="margin-top: 4px">
                <input id="txtTotal" runat="server" type="text" class="frm_fieldvalue" style="width: 190px;"
                    readonly="readonly" />
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
    <div id="comprarDiv" style="float: right; margin: 2px">
        <div class="shoppingCartDiv_buy" style="width: 100px;">
            <span>
                <input type="image" name="buy" alt="Comprar" class="frm_btn_send" src="img/confirm_16.png"
                    style="display:inline;height: 16px; height: 16px;" onmousedown="Buy();" />
               
            </span> <a class="href" style="display:inline;margin-left: 1px; text-align: center" href="/buycart.aspx">Comprar</a>
        </div>
    </div>
</asp:Content>
