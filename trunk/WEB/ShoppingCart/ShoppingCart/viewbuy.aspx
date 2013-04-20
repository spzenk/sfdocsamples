<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="viewbuy.aspx.cs" Inherits="ShoppingCart.viewbuy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <div id="centerContent_div" class="grid_9">

            <div class="frm_title_2" style="margin-top:9px">Listado de su compra</div> 
        <div class="cart-div"> 

            <%--PRODUCT PANEL GRID VIEW--%>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                
                    <div id="divGridView" class="cart-div">
                        <asp:GridView ID="GridView_Prod" runat="server" AutoGenerateColumns="False" CSSSelectorClass="YodaGrilla"
                            ToolTip="Lista de productos" BorderColor="White" CaptionAlign="Left" Width="900"
                            ShowHeader="False" OnRowCommand="GridView_Prod_RowCommand" OnRowDataBound="GridView_Prod_RowDataBound">
                            <PagerSettings Position="TopAndBottom" FirstPageText="Ir al inicio" LastPageText="Ultima pagina"
                                Mode="NextPreviousFirstLast"></PagerSettings>
                            <Columns >
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton2" CommandArgument='<%# Eval("Id") %>' CommandName="View"
                                            runat="server" CssClass="icon_search"> 
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
        <div style="margin: 3px">
              <div class="frm_label_2">
                  <span class="frm_ast">*</span> Total 
              </div>
              <div class="frm_fieldvalue" style="margin-top: 4px">
                  <input id="txtTotal" runat="server" type="text" class="frm_fieldvalue" style="width: 300px;" />
              </div>
          </div>
    </div>

</asp:Content>
