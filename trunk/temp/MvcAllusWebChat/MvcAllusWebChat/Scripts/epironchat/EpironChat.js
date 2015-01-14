function onExit() {
    if (_phoneId == -1)
        return;
    if (confirm("Si preciona F5 va tener que reicniciar el chat con el operador. Desea reiciar?") == false) {
        console.log('blocked');
    }
}

var _phoneId = -1;
var _recordId = -1;
var funcGetRecordId;
var funcretriveAllMessage;

$(function () {
    $('#btnOpenChat2').hide();
    $('#btnOpenChat2').on('click', function () {
        CloseChatRoom("hola ");
    });
    //$('#newModal').modal({
    //    backdrop: 'static',
    //    keyboard: true
    //})
    //DisableControlsCreateChatRoom();

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

});

function LeaveChatRoom() {
    var obj = {

        recordId: _recordId,
        smsId: _smsId
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
        PhoneId: _phoneId
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
        return;
    }
    _phoneId = ajaxContext.phoneId;

    GetRecordId(ajaxContext.smsId);
}

function GetRecordId(smsId) {

    var obj = {
        smsId: smsId,
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

            GetrecordId_CallBack(result, smsId);

        },

        error: ServiceFailed
    });

}

function GetrecordId_CallBack(ajaxContext, smsId) {

    if (ajaxContext.Result && ajaxContext.Result == 'ERROR') {
        OnFailure(ajaxContext);
        return;
    }
    if (ajaxContext.recordId == null) {
        funcGetRecordId = setTimeout(function () { GetRecordId(smsId); }, 4000);
        return;
    }

    _recordId = ajaxContext.recordId;
    _smsId = smsId;
    $('#newModal').modal('hide');
    $("#btnOpenChat").hide('slow');
    $('#alert-text-view').hide('slow');
    $('#alert-text-info-container').hide('slow');
    $("#chatDialog").show('slow');
    Showloading(false);
    RetriveAllMessage();
    ResetControlsChat();
}

function RetriveAllMessage() {

    var obj = {
        recordId: _recordId,
        smsId: _smsId
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
    $("#btnOpenChat").show('slow');
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

    _phoneId = -1;
    _recordId = -1;

}

function DisableControlsCreateChatRoom() {
    //$('button[type="submit"]').attr('disabled', 'true');

    $('#ClientName').attr('disabled', 'true');
    $('#Phone').attr('disabled', 'true');
    $('#InitialMessage').attr('disabled', 'true');
    $('#btnCreateNew').attr('disabled', 'true');



}

function ResetControlsChat() {
    $('#btnSendMessage').removeAttr('disabled');
    $('#txtMessage').removeAttr('disabled');
    $('#btnExitChat').removeAttr('disabled');
}

function ResetControlsCreateChatRoom() {

    _phoneId = -1;
    _recordId = -1;

    $('#ClientName').removeAttr('disabled');
    $('#Phone').removeAttr('disabled');
    $('#InitialMessage').removeAttr('disabled');
    $('#btnCreateNew').removeAttr('disabled');

    Showloading(false);
    $('#alert-text-view').hide('slow');
    $('#alert-text-info-container').hide('slow');

}
function alert_text_info_container(msg, showImage) {
    $('#alert-text-info-container').show('slow');
    Showloading(showImage);
    Set_alert_text_info(msg);
}