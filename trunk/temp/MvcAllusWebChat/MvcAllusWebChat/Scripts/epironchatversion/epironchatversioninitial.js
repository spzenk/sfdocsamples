var NO_OPERATOR = 0; //!=0 cuando ya se informo que no se encontraron operadores
var USER_SEND_EMAIL = false; //True cuando el usuario decidio enviar un email con la consulta en vez de chatear
var _userId = -1;
var _recordId = -1;
var _firstMessageId = -1;
var _roomId = -1;
var _UserName = "";
$(function () {

    $('.initial-selection').on('click', function () {
        $('#div-initial-selection').hide();
        $("#div-section-client-info").show();
    });

    $('#btn-in').on('click', function () {
        $("#div-section-client-info").hide();
        $("#div-waiting-connection").show();
        CreateChatRoom();
    });



});

function CreateChatRoom() {
    var obj = {
        ClientName: 'Hugo', //$('#ClientName').val(),
        Phone:'152427486', // $('#Phone').val(),
        InitialMessage:'hi how are you?',// $('#InitialMessage').val(),
        ChatConfigId: '1' // selectedChatConfigId
    }
    $.ajax({
        url: "/EpironChatVersion/CreateChatRoom/",
        type: "POST",
        dataType: 'json',
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify(obj),
        success: function (result) {
            CreateChatRoom_CallBack(result);
        }
        //,

        //error: ServiceFailed
    });
}

function CreateChatRoom_CallBack(ajaxContext) {

    if (ajaxContext.Result && ajaxContext.Result == 'ERROR') {
        OnFailure(ajaxContext);
        //INFORMAR ERROR
        return;
    }

    ///Si no hay operadores y es la primera vez que pregunta NO_OPERATOR=0
    if (ajaxContext.Result && ajaxContext.Result == 'NO-OPERATORS') {
        //INFORMAR QUE NO HAY OPERADOR Y DAR OPCION DE ENVIO DE EMAIL
        if (NO_OPERATOR == 0) {

            NO_OPERATOR = 1;
        }
        if (!USER_SEND_EMAIL)
            setTimeout(function () { CreateChatRoom(); }, 10000);
        
        return;
    }

    _userId = ajaxContext.userId;
    _roomId = ajaxContext.roomId;
    _firstMessageId = ajaxContext.messageId;
    _UserName = ajaxContext.UserName;
    //alert_text_info_container("Aguardando por una sala", true);
    GetRecordId();
}

function GetRecordId() {

    var obj = {
        UserId: _userId,
        RoomId: _roomId,
        MessageId: _firstMessageId,
    }
    $.ajax({
        url: "/EpironChatVersion/GetRecordId/",
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

        //error: ServiceFailed
    });

}

function GetrecordId_CallBack(ajaxContext) {


    if (ajaxContext.Result && ajaxContext.Result == 'ERROR') {
        //INFORMAR ERROR
        return;
    }
    if (ajaxContext.recordId == null) {
        //INFORMAR QUE ESTAMOS BUSCANDO UNA SALA
        funcGetRecordId = setTimeout(function () { GetRecordId(); }, 4000);
        return;
    }

    _recordId = ajaxContext.recordId;
    //var obj = {
    //    UserId: _userId,
    //    RoomId: _roomId,
    //    MessageId: _firstMessageId,
    //    RecordID: _recordId
    //}


        $('<form action="/EpironChatVersion/ChatSession/" method="POST">' +
          '<input type="hidden" name="UserId" value="' + _userId + '">' +
          '<input type="hidden" name="RoomId" value="' + _roomId + '">' +
          '<input type="hidden" name="MessageId" value="' + _firstMessageId + '">' +
          '<input type="hidden" name="RecordID" value="' + _recordId + '">' +
          '<input type="hidden" name="UserName" value="' + _UserName + '">' +
          '</form>').submit();


    //window.location.replace("/EpironChatVersion/ChatSession$UserId=" + _userId + "&RoomId=" + _roomId + "&MessageId=" + _firstMessageId + "&RecordID=" + _recordId);

    //$.getJSON("/EpironChatVersion/ChatSession/", {
    //    UserId: _userId,
    //    RoomId: _roomId,
    //    MessageId: _firstMessageId,
    //    RecordID: _recordId
    //});

    //$.ajax({
    //    url: "/EpironChatVersion/ChatSession/",
    //    type: "POST",
    //    dataType: 'json',
    //    contentType: "application/json;charset=utf-8",
    //    data: JSON.stringify(obj),
    //    success: function (result) {
    //        if (result.Result && result.Result == 'ERROR') {
    //            ShowAlertMessage(result.Message, 'Error en el servidor', 'error');
    //            return;
    //        }

    //        //GetrecordId_CallBack(result);

    //    }

    //    //error: ServiceFailed
    //});


}

function OnFailure(ajaxContext) {
    var alertText = $('#alert-text-view1');
    alertText.show('slow');

    if (ajaxContext.responseText)
        alertText.find('.error-text').text(ajaxContext.responseText);
    else
        alertText.find('.error-text').text(ajaxContext.Message);
}