function onExit() {
    if (_userId == -1)
        return;
    if (confirm("Si preciona F5 va tener que reicniciar el chat con el operador. Desea reiciar?") == false) {
        console.log('blocked');
    }
}

$(document).ready(function () {
    $("#file").dropzone({ url: "/SaveUploadedFile" });

});

var _userId = -1;
var _recordId = -1;
var funcGetRecordId;
var funcretriveAllMessage;

$(function () {

    //$('#chatRoomView').modal({
    //    backdrop: 'static',
    //    keyboard: false
    //})
    //DisableControlsCreateChatRoom();

    $('#alert-text-info-container').hide();
    $('#alert-text-view').hide();



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


    $('#chatRoomView').dialog({
        autoOpen: false,
        width: 400,
        title: 'Chat room dialog',
        closeOnEscape: false,
        resizable: true,
        modal: false,
        show: {
            effect: "blind",
            duration: 1000
        },
        hide: {
            effect: "explode",
            duration: 1000
        },
        close: function (ev, ui) {

            clearTimeout(funcGetRecordId);
            ResetControlsCreateChatRoom();
            $(this).close();
        }
    });

    $("#btnOpenChat2").click(function () {
        $("#chatRoomView").dialog("open");
    });
});

function LeaveChatRoom() {
    var obj = {

        recordId: _recordId,
        chatRoomId: _chatRoomId
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
        UserId: _userId
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

function CreateChatRoomBefore_CallBack() {
    DisableControlsCreateChatRoom();
    alert_text_info_container("Conectando con uno de nuestros representantes", true);
}

function CreateChatRoom_CallBack(ajaxContext) {

    if (ajaxContext.Result && ajaxContext.Result == 'ERROR') {
        OnFailure(ajaxContext);
        return;
    }
    _userId = ajaxContext.userId;

    $('#newModal').modal('hide');
    $("#btnOpenChat").hide('slow');
    $('#alert-text-view').hide('slow');
    $('#alert-text-info-container').hide('slow');

    $("#chatRoomView").dialog("open");
    Showloading(false);
    setDateToTimer(ajaxContext.timeOnline);
    timedCount();

    //GetRecordId(ajaxContext.chatRoomId);
}

function GetRecordId(chatRoomId) {

    var obj = {
        ChatRoomId: chatRoomId,
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

            GetrecordId_CallBack(result, chatRoomId);

        },

        error: ServiceFailed
    });

}

function GetrecordId_CallBack(ajaxContext, chatRoomId) {

    //if (ajaxContext.Result && ajaxContext.Result == 'ERROR') {
    //    OnFailure(ajaxContext);
    //    return;
    //}
    //if (ajaxContext.recordId == null) {
    //    funcGetRecordId = setTimeout(function () { GetRecordId(chatRoomId); }, 4000);
    //    return;
    //}

    _recordId = ajaxContext.recordId;
    _chatRoomId = chatRoomId;
    $('#newModal').modal('hide');
    $("#btnOpenChat").hide('slow');
    $('#alert-text-view').hide('slow');
    $('#alert-text-info-container').hide('slow');

    $("#chatRoomView").dialog("open");
    Showloading(false);
    setDateToTimer(Seconds);
    timedCount();
    //RetriveAllMessage();
    //ResetControlsChat();
}




//aquí esta el contador de tiempo en pausa
var sec = -1; var min = 0; var hour = 0; var t = 0;


function setDateToTimer(Seconds) {
    var date = new Date(2000, 1, 0);
    date.setSeconds(Seconds);
    sec = date.getSeconds();
    min = date.getMinutes();
    hour = date.getHours();
}
function timedCount()
{

        sec++;
        if (sec == 60) {
            sec = 0;
            min = parseInt(min) + 1;
        }
        else {
            min = min;
        }

        if (min == 60) {
            min = 0;
            hour = hour + 1;

        }
        else {
            hour = hour;
        }

        if (sec.toString().length == 1)
        { sec = "0" + sec; }

        if (min.toString().length == 1) {
            min = "0" + min;
        }

        document.getElementById("txt").value = hour + ":" + min + ":" + sec;


        t = window.setTimeout(function () { timedCount() }, 1000);
}

function stopTimerCount() {
    window.clearTimeout(t);
    sec = 0; min = 0; t = 0; hour = 0;

}

function RetriveAllMessage() {

    var obj = {
        recordId: _recordId,
        chatRoomId: _chatRoomId
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

    _userId = -1;
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

    _userId = -1;
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