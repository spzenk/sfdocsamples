<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="buycart.aspx.cs" Inherits="ShoppingCart.buycart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        div.f1c
        {
            background: url('/img/bgr_box.png') repeat scroll -1004px 0 transparent;
            padding: 5px 15px;
            width: 450px;
        }
        
        div.f1b
        {
            background: url("/img/bgr_2.jpg") repeat scroll -176px -361px transparent;
            height: 8px;
            width: 480px;
        }
        
        div.f1st
        {
            background: url("/img/bgr_2.jpg") repeat scroll -176px -320px transparent;
            color: #FFFFFF;
            display: table-cell;
            height: 27px;
            text-align: center;
            vertical-align: middle;
            width: 500px;
        }
    </style>
    <script type="text/javascript" >

        var varType;
        var varUrl;
        var varData;
        var varContentType;
        var varDataType;
        var varProcessData;
        //Generic function to call AXMX/WCF  Service        
        function CallService() {
            $.ajax({
                type: varType, //GET or POST or PUT or DELETE verb
                url: varUrl, // Location of the service
                data: varData, //Data sent to server
                contentType: varContentType, // content type sent to server
                dataType: varDataType, //Expected data format from server
                processdata: varProcessData, //True or False
                success: function (msg) {//On Successfull service call
                    ServiceSucceeded(msg);
                },
                error: ServiceFailed// When Service call fails
            });
        }

        function ServiceSucceeded(result) {//When service call is sucessful

            alert('El pedido se envio correctamente ');

            $('#messageDiv').append('<p>El pedido se envio correctamente</p>');
            $('#messageDiv').show();
            varType = null; varUrl = null; varData = null; varContentType = null; varDataType = null; varProcessData = null;
        }
        function ServiceFailed(result) {
            alert('Service call failed: ' + result.status + '' + result.statusText);

            varType = null; varUrl = null; varData = null; varContentType = null; varDataType = null; varProcessData = null;
        }


        function SendMessage() {

            $('#messageDiv').hide();
            if (validate_cotrols() == false) {
                alert('Por favor verifique todos los datos !!!');
                return;
            }

            varType = "POST";
            varUrl = "../../service/wcf_service.svc/SendMessage";

            //varData = '{"contactName": "' + $('#txtUserName').val() + '","message": "' + $('#txtComment').val() + '"}';
            varData = '{"contactName": "' + $('#txtUserName').val() +
                       '","message": "' + $('#txtComment').val() +
                       '","email": "' + $('#txtEmail').val() +
                       '","phone": "' + $('#txtPhone').val() +
                       '","city": "' + $('#txtCity').val() +
                       '","state": "' + $('#txtRegion').val() +
                                     '"}';


            varContentType = "application/json; charset=utf-8";
            varDataType = "xml";
            varProcessData = true;
            CallService();
        }

        function validate_cotrols() {


            var ctrl_error_msg = $('#messageDiv');
            ctrl_error_msg.hide();
            ctrl_error_msg.html('');

            var ctrl_mail = $('#txtEmail');

            var ctrl_comment = $('#txtComment');
            var ctrl_userName = $('#txtUserName');

            var valid = true;
            if (ctrl_userName.val() == '') {
                ctrl_error_msg.show();
                ctrl_error_msg.append('<p>El nombre de contacto es requerido.-</p>');
                valid = false;
            }

            if (ctrl_mail.val() == '') {
                ctrl_error_msg.show();
                ctrl_error_msg.append('<p>El e-mail es requerido.-</p>');
                valid = false;
            }

            if (ctrl_comment.val() == '') {
                ctrl_error_msg.show();
                ctrl_error_msg.append('<p>El mensage es requerido.-</p>');
                valid = false;
            }
            if (Validate_Email(ctrl_mail.val()) == false) {
                ctrl_error_msg.show();
                ctrl_error_msg.append('<p>El formato de e-mail no es correcto.-</p>');
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
    <div class="" style="margin-left: 30px; width: 800px;height: 500px">
        
        <div id="messageDiv" class="frm-error-message" style="display: none; color: Black;
            background-color: #BBCBFF">
    
        </div>

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
                </div>
            </div>
            <div style="margin: 3px">
                <div class="frm_label_2">
                    <span class="frm_ast">*</span> E-mail (para que puedan responderle)
                </div>
                <div class="frm_fieldvalue" style="margin-top: 5px">
                    <input id="txtEmail" type="text" class="frm_fieldvalue" style="width: 300px" />
                </div>
            </div>
            
        </div>
        <div class="frm_row" style="height: 200px">
            <div id="div1" style="margin: 15px;">
                <div class="frm_label_2">
                    Telefono</div>
                <div>
                    <input id="txtPhone" type="text" class="frm_fieldvalue" style="width: 300px" />
                </div>
            </div>
            <div id="divReg" style="margin: 15px;">
                <div class="frm_label_2">
                    Provincia</div>
                <div>
                    <input id="txtRegion" type="text" class="frm_fieldvalue" style="width: 300px" />
                </div>
            </div>
            <div id="divCity" style="margin: 15px;">
                <div class="frm_label_2">
                    Ciudad o Localidad</div>
                <div>
                    <input id="txtCity" type="text" class="frm_fieldvalue" style="width: 300px" />
                </div>
            </div>

            <div style="margin: 3px">
                <div class="frm_label_2">
                    <span class="frm_ast">*</span> Comentarios
                </div>
                <div class="frm_fieldvalue">
                    <textarea id="txtComment" class="frm_fieldvalue" cols="40" rows="5"></textarea>
                </div>
                <div class="f1b">
                </div>
            </div>
        </div>
          <div class="clearfix"></div>
        <%--<div class = "frm_group_buttons" style="height:30px; background: url('/img/sprites-t1.gif') repeat-x scroll 0 -281px #000000 ; width:638px;clear: both; height:40px">--%>
        <div class="frm_group_buttons frm_row" style="height: 30px; width: 638px; clear: both; height: 40px;
            background-color: White">
            <input type="image" name="Enviar" alt="Enviar" class="img_box" src="img/submit.gif"
                style="margin-top: 7; width: 120px; height: 40; border: 1px" onmousedown="SendMessage();" />
        </div>
    </div>

        <div class="clearfix"></div>

       <div id="centerContent_div" class="grid_12">

            <div class="frm_title_2" style="margin-top:9px">Listado de su compra</div> 
      
             <asp:Label ID="Label1" Width="641px" CssClass="frm-message" runat="server" 
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


