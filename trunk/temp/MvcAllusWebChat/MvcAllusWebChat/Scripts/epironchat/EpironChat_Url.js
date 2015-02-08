function onExit() {
    if (_userId == -1)
        return;
    if (confirm("Si preciona F5 va tener que reicniciar el chat con el operador. Desea reiciar?") == false) {
        console.log('blocked');
    }
}

var _recordId = -1;
var funcGetRecordId;
var funcretriveAllMessage;
var _tel;
var _url;
var _case;

$(function () {
    _tel = $.urlParam('tel');
    _url = $.urlParam('url');
    _case = $.urlParam('case');

    $('#alert-text-info-container').hide();
    $('#alert-text-view').hide();

    $('#btnSendMessage').on('click', function () {
        SendMessage();
    });
    $('#btnOpenChat').on('click', function () {
        Chat();
    });
    //Si no hay operadores se reintenta medante llamada ajax directamente
     if (_opCount == 0)
     {
         alert('Empiesa a ver si hay op');
         Chat();
     }
    $('#btnExitChat').on('click', function () {
        clearTimeout(funcretriveAllMessage);
        clearTimeout(funcGetRecordId);

        LeaveChatRoom();
    });

    $('#btnSendCHat').on('click', function () {
        alert("hey");
            //cellphone = "1";
            //email = "hugo.lesiuk@allus.com.ar";
            //emailBody = $('#txtMessageList');
            //pGuid = 1;
            //pchatUserId = 1;
            //var params = { cellPhone: cellphone, email: email, emailBody: emailBody, toTheClientFlag: true, pGuid: pGuid, pchatUserId: pchatUserId }

            //var obj = null;

            //$.ajax({
            //    url: "/EpironChatEmail/sendEmail/",
            //    type: "POST",
            //    dataType: 'json',
            //    contentType: "application/json;charset=utf-8",
            //    data: JSON.stringify(params),
            //    success: function (result) {
            //        if (result.Result && result.Result == 'ERROR') {
            //            ShowAlertMessage(result.Message, 'Error en el servidor', 'error');
            //            return;
            //        }
            //        casite = result;
            //    },

            //    error: ServiceFailed
            //});
            });

    
    $('#btnClose').on('click', function () {
        clearTimeout(funcGetRecordId);
    });

    $('#txtMessage').keyup(function (e) {
        if (e.keyCode == 13) {
            SendMessage();
        }
    });

    $('#div_emoticons').html($.emoticons.toString());

   
    alert_text_info_container("Conectando con uno de nuestros representantes", true);


    set_debug();

});


function Chat() {

   

    $.ajax({
        url: "/EpironChat/chat/",
        type: "GET",
        dataType: 'json',
        contentType: "application/json;charset=utf-8",
        data: ({
            tel: _tel,
            url: _url,
            case: _case,
            isAjaxCall: true,
        }),
        success: function (result) {

            Chat_CallBack(result);

        },

        error: ServiceFailed
    });

}

function Chat_CallBack(ajaxContext) {
    if (ajaxContext.Result && ajaxContext.Result == 'ERROR') {
        ShowAlertMessage(ajaxContext.Message, 'Error en el servidor', 'error');
        return;
    }
    //if (ajaxContext.Result && ajaxContext.Result == 'ERROR') {
    //    OnFailure(ajaxContext);
    //    return;
    //}

    //reintenta crear chat
    if (ajaxContext.count == 0) {
        funcGetRecordId = setTimeout(function () { Chat(); }, 4000);
        return;
    }

    _userId = ajaxContext.userId;
    _roomId = ajaxContext.roomId;
    _opCount = ajaxContext.count;

    $('#alert-text-info-container').hide('slow');

    set_debug();
    GetRecordId();
    RetriveAllMessage();

}

function set_debug() {

    $('#userId').text(_userId);
    $('#roomId').text(_roomId);
    $('#count').text(_opCount);
    $('#recordId').text(_recordId);
}

function LeaveChatRoom() {
    var obj = {
        RecordId: _recordId,
        RoomId: _roomId
    }
    $.ajax({
        url: "/EpironChatTest/LeaveChatRoom/",
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
        url: "/EpironChatTest/SendMessage/",
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



function GetRecordId() {

    var obj = {
        UserId: _userId,
        RoomId: _roomId
    }
    $.ajax({
        url: "/EpironChatTest/GetRecordId/",
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

    $('#newModal').modal('hide');
    $("#btnOpenChat").hide('slow');
    $('#alert-text-view').hide('slow');
    $('#alert-text-info-container').hide('slow');
    
  
    Showloading(false);
    RetriveAllMessage();

}

function RetriveAllMessage() {

    var obj = {
        recordId: _recordId,
        roomId: _roomId
    }

    $.ajax({
        url: "/EpironChatTest/RetriveMessages/",
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

            funcretriveAllMessage = setTimeout(function () { RetriveAllMessage(); }, 2000);

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
    //$("#btnOpenChat").show('slow');
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




function alert_text_info_container(msg, showImage) {
    $('#alert-text-info-container').show('slow');
    Showloading(showImage);
    Set_alert_text_info(msg);
}