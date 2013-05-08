<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="buycart.aspx.cs" Inherits="ShoppingCart.buycart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .frm_ast{ color:#990000;}
        .frm-error-message{color: #990000; background-color: #F3F3F3}
    </style>
    <script type="text/javascript" >
        var svcRootPath;
        $(document).ready(function () {
            svcRootPath = Getrootpath("/service/wcf_service.svc");
        });
    
        var varUrl;
        var varData;
        var varDataType;
       
        //Generic function to call AXMX/WCF  Service        
        function CallService() {
            $.ajax({
                type: "POST", //GET or POST or PUT or DELETE verb
                url: varUrl, // Location of the service
                data: varData, //Data sent to server
                contentType: "application/json; charset=utf-8",
                dataType: "json", //Expected data format from server
                processdata: true, //True or False
                success: function (msg) {//On Successfull service call
                    ServiceSucceeded(msg);
                },
                error: ServiceFailed// When Service call fails
            });
        }

        function ServiceSucceeded(result) {//When service call is sucessful

            alert('El pedido se envio correctamente ');

            var path = Getrootpath('');
            document.location.href = path + "/buycart_ok.aspx";
            
             
        }
        function ServiceFailed(result) {
            alert('Service call failed: ' + result.status + '' + result.statusText);

        }


        function SendMessage() {
            if (validate_cotrols() == false) {
                alert('Por favor verifique todos los datos !!!');
                return;
            }
            //varUrl = "../../service/wcf_service.svc/SendMessage";
            varUrl = svcRootPath + "/SendMessage";
            varData = '{"contactName": "' + $('#txtUserName').val() +
                       '","message": "' + $('#txtComment').val() +
                       '","email": "' + $('#txtEmail').val() +
                       '","phone": "' + $('#txtPhone').val() +
                       '","city": "' + $('#txtCity').val() +
                       '","state": "' + $('#txtRegion').val() +
                                     '"}';
         
            
            CallService();
        }

        function validate_cotrols() {


           

            var ctrl_mail = $('#txtEmail');
            var ctrl_mail_err = $('#txtEmail_err');
            ctrl_mail_err.hide();
            ctrl_mail_err.html('');

            var ctrl_phone = $('#txtPhone');
            var ctrl_phone_err = $('#txtPhone_err');
            ctrl_phone_err.hide();
            ctrl_phone_err.html('');
            
            var ctrl_userName = $('#txtUserName');
            var ctrl_userName_err = $('#txtUserName_err');
            ctrl_userName_err.hide();
            

            var valid = true;
            if (ctrl_userName.val() == '') {
                ctrl_userName_err.show();
                valid = false;
            }

            if (ctrl_mail.val() == '') {
                ctrl_mail_err.show();
                ctrl_mail_err.append('<p>El e-mail es requerido.-</p>');
                valid = false;
            }

            if (ctrl_phone.val() == '') {
                ctrl_phone_err.show();
                ctrl_phone_err.append('<p>El telefono es requerido.-</p>');
                valid = false;
            }
            if (Validate_Email(ctrl_mail.val()) == false) {
                ctrl_mail_err.show();
                ctrl_mail_err.append('<p>El formato de e-mail no es correcto.-</p>');
                valid = false;
            }

            return valid;

        }
    </script>

<div style="margin-top: 20px; margin-left: 5px;" >
        <div class="frm_title_2" >
            GRACIAS POR SU COMPRA!!!!
        </div>
        <div class="" style="font-size:12px; font-weight:bold;line-height: 12px;width:900px;color:#293955;margin: 10px 0 5px;
	padding: 8px" >
         <p>Con el objetivo de enviarle información de su interés, solicitamos por favor complete el siguiente formulario. </p>
            <p>Los campos indicados con un asterisco <span class="frm_ast">*</span> son obligatorios para concluir esta transacción; los otros campos son opcionales.</p>
           
             
        </div>
    </div>
    <div class="" style="margin-left: 30px; width: 800px;height: 400px">
        
     

        <div style="margin-left: 60px;">
            <div class="">
                <asp:Label ID="Msg" ForeColor="maroon" runat="server" /><br />
            </div>
            <div style="margin: 3px">
                <div class="frm_label_2">
                    <span class="frm_ast">*</span> Su nombre
                </div>
                <div class="frm_fieldvalue" style="margin-top: 4px">
                    <input id="txtUserName" type="text" class="frm_fieldvalue" style="width: 300px;" />
                    <div id="txtUserName_err" class="frm-error-message" style="display: none;">
                            <p>El nombre de contacto es requerido.-</p>
                        </div>
                </div>
            </div>
            <div style="margin: 3px">
                <div class="frm_label_2">
                    <span class="frm_ast">*</span> E-mail (para que puedan responderle)
                </div>
                <div class="frm_fieldvalue" style="margin-top: 5px">
                    <input id="txtEmail" type="text" class="frm_fieldvalue" style="width: 300px" />
                     <div id="txtEmail_err" class="frm-error-message" style="display: none; color: Black; background-color: #BBCBFF">
                            <p>El e-mail es requerido.-</p>
                        </div>
                </div>
            </div>
            
        </div>
        <div class="frm_row" style="height: 200px">
            <div id="div1" style="margin: 12px;">
                <div class="frm_label_2">
                    <span class="frm_ast">*</span>Telefono</div>
                <div id="txtPhone_div">
                    <input id="txtPhone" type="text" class="frm_fieldvalue" style="width: 300px" />
                      <div id="txtPhone_err" class="frm-error-message" style="display: none; color: Black; background-color: #BBCBFF">
                            <p>El Nro de teléfono es requerido.-</p>
                        </div>
                </div>
            </div>
            <div id="divReg" style="margin: 10px;">
                <div class="frm_label_2">
                    Provincia</div>
                <div>
                    <input id="txtRegion" type="text" class="frm_fieldvalue" style="width: 300px" />
                </div>
            </div>
            <div id="divCity" style="margin: 12px;">
                <div class="frm_label_2">
                    Ciudad o Localidad</div>
                <div>
                    <input id="txtCity" type="text" class="frm_fieldvalue" style="width: 370px" />
                </div>
            </div>

            <div style="margin: 12px">
                <div class="frm_label_2">
                    <span class="frm_ast"></span> Comentarios
                </div>
                <div class="frm_fieldvalue">
                    <textarea id="txtComment" class="frm_fieldvalue" cols="90" rows="2"></textarea>
                </div>
               
            </div>
        </div>
          
        <%--<div class = "frm_group_buttons" style="height:30px; background: url('/img/sprites-t1.gif') repeat-x scroll 0 -281px #000000 ; width:638px;clear: both; height:40px">--%>
      
    </div>
      
            <input type="image" name="Enviar" alt="Enviar" class="frm_btn_send" src="img/submit.gif"
                style="margin-left:700px; margin-top:20px" onmousedown="SendMessage();" />
      
        <div class="clearfix"></div>

    <div id="centerContent_div" class="grid_12">
        <div class="frm_title_2" style="margin-top: 9px; color: #990000;">
            Listado de su compra</div>
        <asp:Label ID="Label1" Width="641px" CssClass="frm-message" runat="server" Text="No productos en su carrito de compras"
            Font-Bold="True" Visible="false"></asp:Label>
        <div id="cart-div-container" class="cart-div" style="margin-left: 30px; width: 850px">
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
                                            runat="server" ToolTip="Eliminar artículo" CssClass="icon_remov"> 
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Count" HeaderText="Count" ReadOnly="True" SortExpression="Count"
                                    ItemStyle-CssClass="cart-catalog-col" />
                                <asp:BoundField DataField="Description" HeaderText="Description" ReadOnly="True"
                                    SortExpression="Description" ItemStyle-CssClass="cart-catalog-col-desc" />
                                 <asp:BoundField DataField="Marca" HeaderText="Marca" ReadOnly="True"
                                    SortExpression="Marca" ItemStyle-CssClass="cart-catalog-col-marca"   />
                                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" Visible="false" SortExpression="Id" />
                                <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="True" SortExpression="Price"
                                    ItemStyle-CssClass="cart-catalog-col-price"  DataFormatString="{0:c}" />
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
                <input id="txtTotal" runat="server" type="text" class="frm_fieldvalue" style="width: 230px;"
                    readonly="readonly" />
            </div>
        </div>
    </div>

</asp:Content>


