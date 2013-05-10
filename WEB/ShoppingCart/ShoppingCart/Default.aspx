<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ShoppingCart._Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="t" runat="server" ContentPlaceHolderID="MainContent">


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
             htmlTable +='</tbody>'
            shoppingCartDiv.append(htmlTable);

            shoppingCartDiv.append('<br />');
            shoppingCartDiv.append('<input type="text" name="total" value="Total: ' + totalprice.toFixed(2) + '" class="cart-total" />');

        }
        function ServiceFailed(result) {
            alert('Service failed: ' + result.status + '' + result.statusText);
        }

        function Add(txtNumberToBuy, Id, price, description, marca,index) {

            var numberToBuy = document.getElementById(txtNumberToBuy).value;

            if (lastArray[index] == numberToBuy || lastArray[index] == null) {
                lastArray[index] = numberToBuy;
                return;
            }
            lastArray[index] = numberToBuy;

            //varUrl = rootPath + "/service/wcf_service.svc/AddToCart";
            varUrl = svcRootPath + "/AddToCart";
            varData = '{"numberToBuy": "' + numberToBuy +
                       '","id": "' + Id +
                        '","price": "' + price +
                         '","description": "' + description +
                         '","marca": "' + marca +
                               '"}';

            varProcessData = true;
            CallService();
        }

        function ClearCart() {

            //varUrl = rootPath + "/service/wcf_service.svc/ClearCart";
            varUrl = svcRootPath + "/ClearCart";
            varData = '{}';

            varProcessData = true;
            CallService();
            CallWebMethod_ClearGrid();
        }

        function CallWebMethod_ClearGrid() {
            $.ajax({
                type: "POST", //GET or POST or PUT or DELETE verb
                url: "~/Default.aspx/ClearGrid", // Location of the service
                data: "{}", //Data sent to server
                contentType: "application/json; charset=utf-8", // content type sent to server
                dataType: "json", //Expected data format from server
                async: true,
                cache: false,
                success: function (data) {

                    alert('limpio');
                },
                error: ServiceFailed// When Service call fails
            });
        }
    </script>
    
    <div id="ProductCategory_div" class="grid_3 alpha">
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:TreeView ID="trvCategories" ExpandDepth="0" runat="server" Width="168px" 
                    ImageSet="BulletedList2" NodeIndent="5"              NodeStyle-Height="20" ShowExpandCollapse="true" ShowLines="false"                >
                    <LevelStyles>
                        <asp:TreeNodeStyle CssClass="nodeLevel1" ChildNodesPadding="8" />
                        <asp:TreeNodeStyle CssClass="nodeLevel2" ChildNodesPadding="5" />
                        <asp:TreeNodeStyle CssClass="nodeLevel3" ChildNodesPadding="5" />
                        
                    </LevelStyles>
                    
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
                            ToolTip="Lista de productos" BorderColor="White" CaptionAlign="Left" Width="100%"
                            ShowHeader="False" OnRowCommand="GridView_Prod_RowCommand" 
                            OnRowDataBound="GridView_Prod_RowDataBound">
                            <PagerSettings Position="TopAndBottom" FirstPageText="Ir al inicio" LastPageText="Ultima pagina"
                                Mode="NextPreviousFirstLast"></PagerSettings>
                            <Columns >
                     
                                <asp:TemplateField HeaderText="# to Buy">
                                    <ItemTemplate>
                                        <div style="height: 60px;border-style:none">
                                            <asp:TextBox ID="txtNumberToBuy" runat="server" AutoPostBack="False" BorderStyle="None"
                                                BorderWidth="1px" CausesValidation="True" SkinID="TextBoxSkin" TabIndex="20"
                                                Width="30px">1px</asp:TextBox>
                                            <ajaxToolkit:NumericUpDownExtender ID="txtNumberToBuy_NumericUpDownExtender" runat="server"
                                                Enabled="True" Maximum="1000" Minimum="0" RefValues="" ServiceDownMethod="" ServiceDownPath=""
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
                        <asp:BoundField DataField="Marca" HeaderText="Marca" ReadOnly="True"
                                    SortExpression="Marca" ItemStyle-CssClass="cart-catalog-col-marca"   />
                                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" Visible="false" SortExpression="Id"  />
                                <asp:BoundField DataField="Price" HeaderText="Price"  ReadOnly="True" SortExpression="Price" ItemStyle-CssClass="cart-catalog-col-price" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:c}"  />
                            </Columns>
                            <AlternatingRowStyle  BorderStyle="Solid" BorderWidth="1" BorderColor="#A8A7A6" />
                            <RowStyle BorderStyle="Solid" BorderWidth="1"  BorderColor="#A8A7A6" />
                            
                        </asp:GridView>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </div>
   
    <div id="righContent" class="grid_4 omega">
    <div>
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
                        <a class="frm_label_1 href" href="/viewbuy.aspx">Ver</a>
                    </div>
                </td>
                <td>
                    <div class="shoppingCartDiv_buy">
                        <a class="frm_label_1 href" href="/buycart.aspx">Comprar</a>
                    </div>
                </td>
            </tr>
        </table>
        
        </div>

        <div class="left_box_white left_box_st" style="height:300px">
            <div class="left_box_panel_white left_box_panel_st box_roun_shadow">
                <div class="left_box_panel_title_white left_box_panel_title_st">
                    <img class="img_menu" src="/img/vineta_star.png" alt="" />
                    <span>Contacto</span>
                </div>
                <div class="frm_container_border" style="margin-top:10px; height:64px">
                    <img class="src" border="0" src="/img/callus01.jpg" title="" alt="" height="60"
                        width="50" style="float: left" />
                    <div style="margin-top: 10PX; color: GrayText; font-weight: bold">
                        Guardia y Reclamos</div>
                    <table>
                        <tr>
                            <td>
                                03585-420159
                            </td>
                        </tr>
                        <tr>
                            <td>
                                03585-153-15407627
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="frm_container_border" style="margin-top: 10px; height: 64px">
                    <img class="img_menu"  border="0" src="/img/contactus.jpg" title="" alt="" height="50"
                        width="50" style="float: left" />
                    <div style="margin-top: 20PX; color: #333333; font-weight: bold">
                        <ul style="list-style-type: none;">
                            <li><a class="menuv_a" href="/img/inf/Contactenos.aspx" target="_self" style="
                            font-size: 11px;text-decoration: none;margin-left:10px">
                                Contactenos </a></li>
                        </ul>
                    </div>

                    
                </div>
            </div>
        </div>
    </div>
</asp:Content>
