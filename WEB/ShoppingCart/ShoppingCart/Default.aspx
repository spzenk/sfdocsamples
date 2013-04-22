<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ShoppingCart._Default" %>
   
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="t" runat="server" ContentPlaceHolderID="MainContent">


    <script type="text/javascript" language="javascript">
        var varUrl;
        var varData;

        var lastArray = new Array();

        $(document).ready(function () {



            varUrl = "../../service/wcf_service.svc/RetriveCart";
            CallService();

        });

        //Generic function to call AXMX/WCF  Service
        function CallService() {
            $.ajax({
                type: "POST", //GET or POST or PUT or DELETE verb
                url: varUrl, // Location of the service
                data: varData, //Data sent to server
                contentType: "application/json; charset=utf-8", // content type sent to server
                dataType: "json", //Expected data format from server
                processdata: true, //True or False
                success: function (data) {

                    ServiceSucceeded(data);
                },
                error: ServiceFailed// When Service call fails
            });
        }
        function ServiceSucceeded(result) {
            var htmlTable = '<table class="hor-minimalist-b">';
            var htmlRow = '';
            var totalprice = 0;
            var list = result.AddToCartResult;
            if (list == undefined)
                list = result.RetriveCartResult;
            if (list == undefined)
                list = result.ClearCartResult;
            var shoppingCartDiv = $('#shoppingCartDiv');
            shoppingCartDiv.html('');
            htmlTable += '<thead><tr> <td>Producto</td><td>Cantidad</td> <td>Precio</td></tr></thead><tbody>';
            for (var i = 0; i < list.length; i++) {
                htmlTable += '<tr> <td  class ="cart-col-description" >' + list[i]['Description'] + '</td><td>' + list[i]['Count'] + '</td> <td  class ="cart-col-price" >' + list[i]['Price'] + '</td></tr>';
                totalprice += list[i]['Price'];
            }
             htmlTable +='</tbody>'
            shoppingCartDiv.append(htmlTable);

            shoppingCartDiv.append('<br />');
            shoppingCartDiv.append('<input type="text" name="total" value="Total: ' + totalprice.toFixed(2) + '" class="cart-total" />');

        }
        function ServiceFailed(result) {
            alert('Service failed: ' + result.status + '' + result.statusText);


        }
        function Add(txtNumberToBuy, Id, price, description, index) {

            var numberToBuy = document.getElementById(txtNumberToBuy).value;

            if (lastArray[index] == numberToBuy || lastArray[index] == null) {
                lastArray[index] = numberToBuy;
                return;
            }
            lastArray[index] = numberToBuy;

            varUrl = "../../service/wcf_service.svc/AddToCart";
            varData = '{"numberToBuy": "' + numberToBuy +
                       '","id": "' + Id +
                        '","price": "' + price +
                         '","description": "' + description +
                               '"}';

            varProcessData = true;
            CallService();
        }

        function ClearCart() {

          

            varUrl = "../../service/wcf_service.svc/ClearCart";
            varData = '{}';

            varProcessData = true;
            CallService();
        }
    </script>
    <div id="ProductCategory_div" class="grid_3 alpha">
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:TreeView ID="trvCategories" ExpandDepth="0" runat="server" Width="168px" ExpandImageUrl="~/img/expand_collapse_plus.gif"
                    CollapseImageUrl="~/img/expand_collapse_minus.gif" 
                    ImageSet="BulletedList2" NodeIndent="5"
                    NodeStyle-Height="20" ShowExpandCollapse="true" ShowLines="false" 
                    ontreenodecheckchanged="trvCategories_TreeNodeCheckChanged">
                    <LevelStyles>
                        <asp:TreeNodeStyle CssClass="nodeLevel1" ChildNodesPadding="8" />
                        <asp:TreeNodeStyle CssClass="nodeLevel2" ChildNodesPadding="5" />
                        <asp:TreeNodeStyle CssClass="nodeLevel3" ChildNodesPadding="5" />
                        <%-- <asp:TreeNodeStyle ChildNodesPadding="10" Font-Bold="true" Font-Size="12pt" ForeColor="DarkGreen" />
                            <asp:TreeNodeStyle ChildNodesPadding="5" Font-Bold="true" Font-Size="10pt" />
                            <asp:TreeNodeStyle ChildNodesPadding="5" Font-Underline="true" Font-Size="10pt" />
                            <asp:TreeNodeStyle ChildNodesPadding="10" Font-Size="8pt" />--%>
                    </LevelStyles>
                    <%--<HoverNodeStyle Font-Underline="False" />
                        <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />--%>
                    <%-- <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" 
                            HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
                        <ParentNodeStyle Font-Bold="False" />
                        <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" 
                            HorizontalPadding="0px" VerticalPadding="0px" />--%>
                </asp:TreeView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    
    <div id="centerContent_div" class="grid_9">
        
            <div class="frm_title_2" style="margin-top:14px">Listado de productos</div> 
        <div class="cart-div"  style="margin-top:30px"> 

            <%--PRODUCT PANEL GRID VIEW--%>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>

                
                    <div id="divGridView" class="">
                        <asp:GridView ID="GridView_Prod" runat="server" AutoGenerateColumns="False" CSSSelectorClass="YodaGrilla"
                            ToolTip="Lista de productos" BorderColor="White" CaptionAlign="Left" Width="540px"
                            ShowHeader="False" OnRowCommand="GridView_Prod_RowCommand" 
                            OnRowDataBound="GridView_Prod_RowDataBound">
                            <PagerSettings Position="TopAndBottom" FirstPageText="Ir al inicio" LastPageText="Ultima pagina"
                                Mode="NextPreviousFirstLast"></PagerSettings>
                            <Columns >
                         <%--       <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton2" CommandArgument='<%# Eval("Id") %>' CommandName="View"
                                            runat="server" CssClass="icon_search"> 
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="# to Buy">
                                    <ItemTemplate>
                                        <div style="height: 60px;border-style:none">
                                            <asp:TextBox ID="txtNumberToBuy" runat="server" AutoPostBack="False" BorderColor="#759CAC"
                                                BorderWidth="1px" CausesValidation="True" SkinID="TextBoxSkin" TabIndex="20"
                                                Width="30px">1px</asp:TextBox>
                                            <ajaxToolkit:NumericUpDownExtender ID="txtNumberToBuy_NumericUpDownExtender" runat="server"
                                                Enabled="True" Maximum="10" Minimum="0" RefValues="" ServiceDownMethod="" ServiceDownPath=""
                                                ServiceUpMethod="" Tag="" TargetButtonDownID="" TargetButtonUpID="" TargetControlID="txtNumberToBuy"
                                                Width="75">
                                            </ajaxToolkit:NumericUpDownExtender>
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtNumberToBuy"
                                                Display="Dynamic" ErrorMessage="Integer Value Required" Operator="DataTypeCheck"
                                                Type="Integer"></asp:CompareValidator>
                                        </div>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                </asp:TemplateField>
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

    </div>
    <div id="righContent" class="grid_4 omega">
        <div class="frm_label_2">
            Sus compras</div>
        <div id="shoppingCartDiv" class="cart-div" style="margin-top: 10px; margin-left: 3px ;width:250px">
        </div>
        <div class="clear">
        </div>
        <table style="margin-left: 10px">
            <tr>
                <td>
                    <div id="Div1" class="shoppingCartDiv_buy">
                        
                        <input type ="button" value="Limpiar" onclick="javascript:ClearCart();" />
                    </div>
                </td>
                <td>
                    <div id="Div3" class="shoppingCartDiv_buy">
                        <a class="frm_label_1" href="/viewbuy.aspx">Ver</a>
                    </div>
                </td>
                <td>
                    <div class="shoppingCartDiv_buy">
                        <a class="frm_label_1" href="/buy.aspx">Comprar</a>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
