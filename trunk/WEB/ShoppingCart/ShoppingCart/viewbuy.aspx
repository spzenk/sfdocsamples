<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="viewbuy.aspx.cs" Inherits="ShoppingCart.viewbuy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <script type="text/javascript" language="javascript">

     $(document).ready(function () {

         var msg = $('#MainContent_msg');
         var CART_DIV = $('#cart-div-container');
         var todal_div = $('#todal_div');

         if (msg.is(":visible")) {
             CART_DIV.hide();
             todal_div.hide();
         }
         else {
             CART_DIV.show();
             todal_div.show();
         }


     });

   
    </script>
    <div class="clear"></div>
   <div id="centerContent_div" class="grid_12">

            <div class="frm_title_2" style="margin-top:9px">Listado de su compra</div> 
      
             <asp:Label ID="msg" Width="641px" CssClass="frm-message" runat="server" 
                Text="No productos en su carrito de compras" Font-Bold="True" Visible="false"></asp:Label>
             
        <div id="cart-div-container" class="cart-div" style = "margin-left:30px ;width:650px"> 

            <%--PRODUCT PANEL GRID VIEW--%>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                
                    <div id="divGridView" class="cart-div" style="border-style:none;display:table;">
                        <asp:GridView ID="GridView_Prod" runat="server" AutoGenerateColumns="False" CSSSelectorClass="YodaGrilla"
                            ToolTip="Lista de productos" BorderColor="White" CaptionAlign="Left" Width="600" 
                            ShowHeader="False" OnRowCommand="GridView_Prod_RowCommand" OnRowDataBound="GridView_Prod_RowDataBound">
                            <PagerSettings Position="TopAndBottom" FirstPageText="Ir al inicio" LastPageText="Ultima pagina"
                                Mode="NextPreviousFirstLast"></PagerSettings>
                            <Columns >
                                <asp:TemplateField HeaderText=""  ItemStyle-CssClass="cart-catalog-col-price">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton2" CommandArgument='<%# Eval("Id") %>' CommandName="remove"
                                            runat="server" CssClass="icon_remov"> 
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:BoundField DataField="Count" HeaderText="Count" ReadOnly="True"
                                    SortExpression="Count" ItemStyle-CssClass="cart-catalog-col-price"   />
                                   
                                <asp:BoundField DataField="Description" HeaderText="Description" ReadOnly="True"
                                    SortExpression="Description" ItemStyle-CssClass="cart-catalog-col-desc"   />
                                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" Visible="false" SortExpression="Id"  />
                                <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="True" SortExpression="Price" ItemStyle-CssClass="cart-catalog-col-price"/>
                            </Columns>
                            <AlternatingRowStyle BackColor="White" BorderStyle="Solid"  />
                            <RowStyle BorderStyle="Solid"/>
                            
                        </asp:GridView>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div id ="todal_div" style="float:right; margin: 3px">
              <div class="frm_label_2">
                  <span class="frm_ast">*</span> Total 
              </div>
              <div class="frm_fieldvalue" style="margin-top: 4px">
                  <input id="txtTotal" runat="server" type="text" class="frm_fieldvalue" style="width: 300px;" readonly="readonly" />
              </div>
          </div>
    </div>

</asp:Content>
