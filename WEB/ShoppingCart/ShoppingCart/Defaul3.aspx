<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Defaul3.aspx.cs" Inherits="ShoppingCart.Defaul3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript" language="javascript">
        var varUrl;
        var varData;
        var svcRootPath;
        var lastArray = new Array();

        $(document).ready(function () {
            svcRootPath = Getrootpath("/service/wcf_service.svc");
            varUrl = svcRootPath + "/RetriveCart";
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
            htmlTable += '</tbody>'
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
            varUrl = svcRootPath + "/AddToCart";
            varData = '{"numberToBuy": "' + numberToBuy +
                       '","id": "' + Id +
                        '","price": "' + price +
                         '","description": "' + description +
                               '"}';

            varProcessData = true;
            CallService();
        }

        function ClearCart() {

            
            varUrl = svcRootPath + "/ClearCart";
            varData = '{}';
            varProcessData = true;
            CallService();
            CallWebMethod_ClearGrid();
        }

        function RetriveProducts() {

            var categoryId = $("#txtCategory").val();
            varUrl = svcRootPath + "/RetriveProducts";
            varData = '{"categoryId": "' + categoryId + '"}';
       
            $.ajax({
                type: "POST",
                url: varUrl,
                data: varData, 
                contentType: "application/json; charset=utf-8", 
                dataType: "json", 
                async: true,
                cache: false,
                success: function (result) {
                    var list = result.RetriveProductsResult;
                    var row = $("[id*=GridView_Prod] tr:last-child").clone(true);

                    for (var i = 0; i < list.length; i++) {
                    //Set product attributes to the row and add it to the gridview
                    $("td", row).eq(0).html(list[i]['Count']);
                    $("td", row).eq(1).html(list[i]['Description']);
                    $("td", row).eq(2).html(list[i]['Price']);

                    $("[id*=GridView_Prod]").append(row);
                    //get the copy of the last row again.
                    row = $("[id*=GridView_Prod] tr:last-child").clone(true);
                }        
                },
                error: ServiceFailed// When Service call fails
            });
        }
    </script>

    <div id="ProductCategory_div" class="grid_3 alpha">
       <input id="txtCategory" type="text" name="total" value="" style="width:200px" />
    <input type ="button" style="width:200px"  name="btnSend" onclick="javascript:RetriveProducts();" />
        
    </div>

    <div id="centerContent_div" class="grid_9">
        <div class="frm_title_2" style="margin-top: 14px">
            Listado de productos</div>
        <div class="cart-div" style="margin-top: 30px">
            <%--PRODUCT PANEL GRID VIEW--%>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div id="divGridView" class="">
                        <asp:GridView ID="GridView_Prod" runat="server" AutoGenerateColumns="False" CSSSelectorClass="YodaGrilla"
                            ToolTip="Lista de productos" BorderColor="White" CaptionAlign="Left" Width="100%"
                            ShowHeader="False"  >
                            <PagerSettings Position="TopAndBottom" FirstPageText="Ir al inicio" LastPageText="Ultima pagina"
                                Mode="NextPreviousFirstLast"></PagerSettings>
                            <Columns>
                                <asp:TemplateField HeaderText="# to Buy">
                                    <ItemTemplate>
                                        <div style="height: 60px; border-style: none">
                                            <asp:TextBox ID="txtNumberToBuy" runat="server" AutoPostBack="False" BorderStyle="None"
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
                                    SortExpression="Description" ItemStyle-CssClass="cart-catalog-col-desc" />
                                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" Visible="false" SortExpression="Id" />
                                <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="True" SortExpression="Price"
                                    ItemStyle-CssClass="cart-catalog-col-price" ItemStyle-HorizontalAlign="Center" />
                            </Columns>
                            <AlternatingRowStyle BorderStyle="Solid" BorderWidth="1" BorderColor="#A8A7A6" />
                            <RowStyle BorderStyle="Solid" BorderWidth="1" BorderColor="#A8A7A6" />
                        </asp:GridView>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
