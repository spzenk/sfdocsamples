//function onExit() {
//    if (_userId == -1)
//        return;
//    if (confirm("Si preciona F5 va tener que reicniciar el chat con el operador. Desea reiciar?") == false) {
//        console.log('blocked');
//    }
//}

var _userId = -1;
var _recordId = -1;
var _firstMessageId = -1;
var funcGetRecordId;
var funcretriveAllMessage;
var NO_OPERATOR = 0;//0:Primer momento 1:reintentando 2:cancelado
var USER_SEND_EMAIL = false // true =  usuario decide enviar email
var selectedChatConfigId = null;
$(function () {
   
    
    $('textarea').bind("enterKey", function (e) {
        //do stuff here
    });
    
    $('#alert-text-info-container').hide();
    $('#alert-text-view').hide();
    $('#chatDialog').hide();
    

    $('#btnSendMessage').on('click', function () {
        SendMessage();
    });

    $('#btnExitChat').on('click', function () {
        clearTimeout(funcretriveAllMessage);
        clearTimeout(funcGetRecordId);

        LeaveChatRoom();
    });

    $('#btnClose').on('click', function () {
        clearTimeout(funcGetRecordId);
        ResetControlsCreateChatRoom();
    });
    $('#btnOpenChat').on('click', function () {
        ResetControlsCreateChatRoom();
    });
    $('#txtMessage').keyup(function (e) {
        if (e.keyCode == 13) {
            SendMessage();
        }
    });
    $('#div_emoticons').html($.emoticons.toString());				   

    $("#ChatConfigId").change(function () {
        selectedChatConfigId = $("#ChatConfigId :selected").val();
    });
    selectedChatConfigId = $("#ChatConfigId :selected").val();
});

function LeaveChatRoom() {
    cleanVariables();

    var obj = {
        recordId: _recordId,
        chatRoomId: _roomId
    }
    $.ajax({
        url: "/EpironChat/LeaveChatRoom/",
        type: "POST",
        dataType: 'json',
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify(obj),
        success: function (result) {
            if (result.Result && result.Result == 'ERROR') {
                ShowAlertMessage(result.Message, 'Error en el servidor', 'error');
                return;
            }
            ShowAlertMessage(result.Message, 'Allus', 'info');

            CloseChatRoom(result.Message);
        },

        error: ServiceFailed
    });

}

function SendMessage() {
    if ($.trim($("#txtMessage").val()) === "")
        return;
    var obj = {
        Message: $("#txtMessage").val(),
        RecordId: _recordId,
        UserId: _userId,
        RoomId: _roomId
    }
    $.ajax({
        url: "/EpironChat/SendMessage/",
        type: "POST",
        dataType: 'json',
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify(obj),
        success: function (result) {
            if (result.Result && result.Result == 'ERROR') {
                ShowAlertMessage(result.Message, 'Error en el servidor', 'error');
                return;
            }
        },

        error: ServiceFailed
    });
    $("#txtMessage").val('');
}

function CreateChatRoomBefore_CallBack() {
    DisableControlsCreateChatRoom();
    alert_text_info_container("Conectando con uno de nuestros representantes", true);
}

function CreateChatRoom_CallBack(ajaxContext) {

    if (ajaxContext.Result && ajaxContext.Result == 'ERROR') {
        OnFailure(ajaxContext);
        //$('#alert-text-info-container').hide();
        return;
    }


    ///Si no hay operadores y es la primera vez que pregunta NO_OPERATOR=0
        if (ajaxContext.Result && ajaxContext.Result == 'NO-OPERATORS') {
            
            if (NO_OPERATOR == 0) {
                Show_NO_OPERATOR();
                NO_OPERATOR = 1;
            }
            if (!USER_SEND_EMAIL)
            setTimeout(function () { retryCreateChatRoom(); }, 10000);
            //$('#alert-text-info-container').hide();
            return;
        }
        
        _userId = ajaxContext.userId;
    _roomId = ajaxContext.roomId;
    _firstMessageId = ajaxContext.messageId;
    alert_text_info_container("Aguardando por una sala", true);
    GetRecordId();
}
function Show_NO_OPERATOR() {
    var msg = "En este momento no hay operadores disponibles.  ";
    var title = "Chat no disponible";
    Set_alert_text_error(msg, title);
    Set_alert_error_link("Envíenos su consulta <a href=\"#\" onclick=\"endEmailNoOperator();\" > aquí</a>");

}
function retryCreateChatRoom() {
    var obj = {
        ClientName: $('#ClientName').val(),
        Phone: $('#Phone').val(),
        InitialMessage: $('#InitialMessage').val(),
        ChatConfigId: selectedChatConfigId
    }
    $.ajax({
        url: "/EpironChat/CreateChatRoom/",
        type: "POST",
        dataType: 'json',
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify(obj),
        success: function (result) {
            CreateChatRoom_CallBack(result);
        },

        error: ServiceFailed
    });
}

function GetRecordId() {

    var obj = {
        UserId: _userId,
        RoomId: _roomId,
        MessageId: _firstMessageId,
    }
    $.ajax({
        url: "/EpironChat/GetRecordId/",
        type: "POST",
        dataType: 'json',
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify(obj),
        success: function (result) {
            if (result.Result && result.Result == 'ERROR') {
                ShowAlertMessage(result.Message, 'Error en el servidor', 'error');
                return;
            }

            GetrecordId_CallBack(result);

        },

        error: ServiceFailed
    });

}

function GetrecordId_CallBack(ajaxContext) {

    if (ajaxContext.Result && ajaxContext.Result == 'ERROR') {
        OnFailure(ajaxContext);
        return;
    }
    if (ajaxContext.recordId == null) {
        funcGetRecordId = setTimeout(function () { GetRecordId(); }, 4000);
        return;
    }

    _recordId = ajaxContext.recordId;
    
    $('#newModal').hide('slow');
    $("#chatDialog").show('slow');
    $('#alert-text-view').hide('slow');
    $('#alert-text-info-container').hide('slow');
    
    Showloading(false);
    RetriveAllMessage();
    ResetControlsChat();
}

function RetriveAllMessage() {

    var obj = {
        RecordId: _recordId,
        RoomId: _roomId,
    }

    $.ajax({
        url: "/EpironChat/RetriveMessages/",
        type: "POST",
        dataType: 'json',
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify(obj),
        success: function (result) {
            if (result.Result && result.Result == 'ERROR') {
                ShowAlertMessage(result.Message, 'Error en el servidor', 'error');
                return;
            }
            //ClosedByOperator
            if (result.ChatRoomStatus == '5')
            { CloseChatRoom("Sala de chat cerrada por el operador"); return; }
            if (result.ChatRoomStatus == '2')
            { CloseChatRoom("Sala de chat cerrada por el cliente"); return; }

            var container = $('#txtMessageList');

            container.html("");
            $(result.Data).each(function (i) {
                var div = document.createElement("DIV");
                var dateFormat = $.datepicker.formatDate('dd-mm-yy hh:mm:ss', JSON_TO_Date(this.SendTime));
                $(div)
                            .appendTo(container)
                            .addClass((this.IsFriend ? "_tlkFriend" : "_tlkMe"))
                            .end()
                            .append("<span class=\"_talker\">" + (this.IsFriend ? this.Talker : "Yo:") + "</span>")
                            //.append("<span>" + (this.IsFriend ? " dice  " : " dijo") + "</span>")
                            .append("<span class=\"_time\">" + dateFormat + "</span>")
                            .append("<span>: </span><BR /> ")
                            .append("<span class=\"_msg\">" + this.MessageData + "</span> ");

            });

            container.scrollTop(container[0].scrollHeight - container.height());

            funcretriveAllMessage = setTimeout(function () { RetriveAllMessage(); }, 1000);

        },

        error: ServiceFailed
    });


}

function CloseChatRoom(message) {
    clearTimeout(funcretriveAllMessage);
    clearTimeout(funcGetRecordId);

    ShowAlertMessage(message, 'Allus', 'info');

    $('#btnSendMessage').attr('disabled', 'true');
    $('#btnExitChat').attr('disabled', 'true');
    $('#txtMessage').attr('disabled', 'true');

    var container = $('#txtMessageList');

    var today = new Date();
    var div = document.createElement("DIV");
    var dateFormat = $.datepicker.formatDate('dd-mm-yy hh:mm:ss', today);
    $(div)
                .appendTo(container)
                .addClass("_tlkMe")
                .end()
                .append("<span class=\"_time\">" + dateFormat + "</span>")
                //.append("<span>: </span><BR /> ")
                .append("<span class=\"_msgClosed\">" + message + "</span> ");

    _userId = -1;
    _recordId = -1;

}

function DisableControlsCreateChatRoom() {
    //$('button[type="submit"]').attr('disabled', 'true');

    $('#ClientName').attr('disabled', 'true');
    $('#Phone').attr('disabled', 'true');
    $('#InitialMessage').attr('disabled', 'true');
    $('#btnCreateNew').attr('disabled', 'true');
    $('#ChatConfigId').attr('disabled', 'true');



}

function ResetControlsChat() {
    $('#btnSendMessage').removeAttr('disabled');
    $('#txtMessage').removeAttr('disabled');
    $('#btnExitChat').removeAttr('disabled');
    $('#ChatConfigId').removeAttr('disabled');
}

function ResetControlsCreateChatRoom() {

    _userId = -1;
    _recordId = -1;
    selectedChatConfigId = null;

    $('#ClientName').removeAttr('disabled');
    $('#Phone').removeAttr('disabled');
    $('#InitialMessage').removeAttr('disabled');
    $('#ChatConfigId').removeAttr('disabled');

    Showloading(false);
    $('#alert-text-view').hide('slow');
    $('#alert-text-info-container').hide('slow');

}
function alert_text_info_container(msg, showImage) {
    $('#alert-text-info-container').show('slow');
    Showloading(showImage);
    Set_alert_text_info(msg);
}

function endEmailNoOperator() {
    USER_SEND_EMAIL = true;
    $('#txt-cellphone').text($('#txt-Phone').text()); //<-- escribo el telefono que usuario ingreso en el primer formulario
    $('#txt-EmailBody').text($('#txt-InitialMessage').text()); //<-- escribo la consulta que usuario ingreso en el primer formulario
    $('#emailForm').modal('show');//<-- muestro el formulario
    $('#newModal').hide();
}
function cleanVariables() {
    //En esta función limpio todas las variables necesarias al cerrar el fomulario
    NO_OPERATOR = 0; //0:Primer momento 1:reintentando 2:cancelado
}