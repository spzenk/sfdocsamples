function onExit() {
    if (_userId == -1)
        return;
    if (confirm("Si preciona F5 va tener que reicniciar el chat con el operador. Desea reiciar?") == false) {
        console.log('blocked');
    }
}

var _recordId = -1;
//var _firstMessageId = -1;
var funcGetRecordId;
var funcretriveAllMessage;
var _tel;
var _url;
var _case;
var _LASTMESSAGETIME = null;
var _userName = "";


var fromTimeFirstCall = null;
var timeToExpire = null;
var USER_SEND_EMAIL = false // true =  usuario decide enviar email
var GET_RECORDID_TRY_NUMBER = 0; //cantidad de veces que busco sala
var SHOWING_EMAIL_OPTION = 0;//0:Primer momento 1:reintentando 2:cancelado

$(function () {

    //window.resizeTo(580, 540);

    disableChat();
    alert_text_info_container("Conectando con uno de nuestros representantes", true);

    $("#div-end-session-menu").hide();//<--oculto el panel para finalizar sesion 
    _tel = $.urlParam('tel');
    _url = $.urlParam('url');
    _case = $.urlParam('case');

    $('#txt-message').on("keypress", function (e) {
        if (e.keyCode == 13) {
            if (e.shiftKey) //<-- Consulto si oprimio shift
                $('#txt-message').val($('#txt-message').val() + '\n');
            else
                SendMessage();
        }
    });

   


    if (_HaveException) {
        Show_Exception();
        clearTimeout(funcretriveAllMessage);
        clearTimeout(funcGetRecordId);
        stopTimerCount();
        cleanVariablesDisableItems();
        disableChat();
    }
    else if (!_IsConfigavailable) {// chequea si tenemos configuraciones disponibles
        Show_No_Config();
        clearTimeout(funcretriveAllMessage);
        clearTimeout(funcGetRecordId);
        stopTimerCount();
        cleanVariablesDisableItems();
    }
   else if (_opCount == 0) { //Pregunto si hay operadores. Sino hay se termina
       //Chat();
        Show_Email_Option(1);
    }
    else if (_userAlreadySigned) { //pregunto si el usuario ya esta en una room activo
        Show_User_Signed();
        clearTimeout(funcretriveAllMessage);
        clearTimeout(funcGetRecordId);
        stopTimerCount();
        cleanVariablesDisableItems();
    }
    else {//curso normal
        alert_text_info_container("Aguardando por una sala", true);
        GetRecordId();
        if (_emailAvailable) { //si el email esta configuracion, muestro las cajas para el envio
            $('#div-attr-send-email-label').show();
            $('#div-attr-send-email-input').show();
            $('#div-end-session-menu').removeClass("div-end-session-menu-no-email").addClass("div-end-session-menu-with-email");
        }
    }


    $(document).on("keypress", function (e) { //<-- para ocultar los emoticones cuando se aprieta scape
        if (e.keyCode == 27) {
            $("#div_emoticones").hide();
        }

    });

    $(document).mouseup(function (e) { //<-- para ocultar los emoticones cuando se clickea en otro lado
        var container = $("#div_emoticones");

        if (!container.is(e.target)
            && container.has(e.target).length === 0) {
            container.hide();
        }
    });


    $("#img-emoticon").on("click", function (e) {
        $("#div_emoticones").show();
    });

    $("#div_emoticones").html($.emoticons.toString());//<-- carga los emoticones en el div

   
    $(".emoticon").on("click", function () {
        //Agrega el simbolo del emoticon al texto
        var wText = $('#txt-message').val() + ' ' + $(this).html();
        $('#txt-message').val(wText);
        $('#txt-message').focus();
        $("#div_emoticones").hide();
    });


    $("#txtemailchat").on("focus", function () {
        destroyToolTip($("#txtemailchat"));
    });

   

});


function Chat() {
    //NO SE USA - HUGO 06/04/2015
    $.ajax({
        url: "/EpironChatVersion1/chat/",
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

        return;
    }

    if (ajaxContext.count == 0) {

            Show_Email_Option(1);
        return;
    }

    _userId = ajaxContext.userId;
    _roomId = ajaxContext.roomId;
    _firstMessageId = ajaxContext.messageId;
    alert_text_info_container("Aguardando por una sala", true);
    GetRecordId();

   
}


function GetRecordId() {
    if (fromTimeFirstCall == null) {
        //Seteo el tiempo maximo de espera por una sala
        current = new Date();
        fromTimeFirstCall = new Date(current);
        fromTimeFirstCall.setSeconds(current.getSeconds() + GetRecord_TimeOut);
    }
    else {
        if (fromTimeFirstCall < new Date()) {
            ClosedByRecordIdNotFound();
            //Se termino el tiempo de espera para buscar una sala.  
            Show_GetRecord_TimeOut();
            //Elimino todas las llamadas al servidor
            clearTimeout(funcretriveAllMessage);
            clearTimeout(funcGetRecordId);
            stopTimerCount();
            return;
            //termina el ciclo
        }

    }

    var obj = {
        UserId: _userId,
        RoomId: _roomId,
        MessageId: _firstMessageId,
    }
    $.ajax({
        url: "/EpironChatVersion1/GetRecordId/",
        type: "POST",
        dataType: 'json',
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify(obj),
        success: function (result) {
            if (result.Result && result.Result == 'ERROR') {
                //ShowAlertMessage(result.Message, 'Error en el servidor', 'error');
                return;
            }

            GetrecordId_CallBack(result);

        },

        error: ServiceFailed
    });


}

function GetrecordId_CallBack(ajaxContext) {
    GET_RECORDID_TRY_NUMBER++;
    if (ajaxContext.Result && ajaxContext.Result == 'ERROR') {
        //OnFailure(ajaxContext);
        return;
    }
    if (ajaxContext.recordId == null) {
        if (GET_RECORDID_TRY_NUMBER > GET_RECORDID_TRIES) {
            Show_Email_Option(2);//Luego del 5to intento muestro la opción de email 
        }
        if (!USER_SEND_EMAIL)
            funcGetRecordId = setTimeout(function () { GetRecordId(); }, _GetRecord_Timer);

        return;
    }

    ChatStart(ajaxContext);
    enableChat();

}
    
function ChatStart(ajaxContext) {
    _recordId = ajaxContext.recordId;
    _userName = ajaxContext.userName;

    $('#newModal').modal('hide');
    $("#btnOpenChat").hide('slow');
    $('#alert-text-view').hide('slow');
    $('#alert-text-info-container').hide('slow');

    $("#div-end-session-menu").show();//<---muestro el panel para que pueda finalizar session

    timedCount(); //<--- comienza a correr el tiempo del contador
    ShowloadingUrl(false);
    UpdateTimeToExpire(); //<--- incrementamos o instanciamos el tiempo de timeout(abandono por inactividad)
    RetriveAllMessage();
    clearTimeout(funcGetRecordId); //<---dejamos de consultar por una sala

   if( _MaxLength_Message >0)
       $("#txt-message").attr('maxlength', _MaxLength_Message); //<--seteo el tamaño máximo del mensaje

    //Asigno el nombre del operador que respondio la llamada
    $("#span-Epiron-User-Name").append(_userName);
    $("#span-Epiron-User-Name").show();
}

function enableChat() {

    $("#btn-End").prop("disabled", false);
    $("#div-end-session-menu").show();
    $("#txt-message").prop("disabled", false);
    $("#img-emoticon").prop("disabled", false);
    $("#img-upload-file").show();
    $("#img-emoticon").show();
}

function disableChat() {

    $("#btn-End").prop("disabled", true);
    $("#div-end-session-menu").hide();
    $("#txt-message").prop("disabled", true);
    $("#img-emoticon").prop("disabled", true);
    $("#img-upload-file").hide();
    $("#img-emoticon").hide();
}


/*FUNCION MIGRADA DE CHATVERSION*/
function scrollToBotton() {
    //lleva la vision del chat al ultimo item.
    if (!$('txtMessageList').is(':focus')) { //<---valida que el usuario no este leyendo el chat
        var wtf = $('#txtMessageList');
        var height = wtf[0].scrollHeight;
        wtf.scrollTop(height);
    }

}


function alert_text_info_container(msg, showImage) {
    $('#alert-text-info-container').show('slow');
    ShowloadingUrl(showImage);
    Set_alert_text_infoChatRoom(msg, true);
}


function Show_User_Signed() {
    //$('.panel-header').css("height", "130px");
    alert_text_info_containerHTML("El cliente ingresado<br> esta siendo atendido en este momento <br> Aguarde unos minutos <br> e intente conectarse nuevamente", false, true);
}

function Show_GetRecord_TimeOut() {
    alert_text_info_containerHTML("Se ha excedido el tiempo de espera de sala. <br> Por favor vuelva a intentarlo más tarde", false, true);
}

function Show_No_Config(option) {
    alert_text_info_containerHTML("En este momento no disponemos de salas.", false, true);
    Show_Email_Option(3);
}

function Show_Exception() {
    alert_text_info_containerHTML("En este momento el chat no esta disponible.", false, true);
}

function alert_text_info_containerHTML(msg, showImage, replace) {
    $('#alert-text-info-container').show('slow');
    ShowloadingUrl(showImage);
    Set_alert_text_infoChatRoom(msg, replace);
}

function endEmailNoOperator() {
    USER_SEND_EMAIL = true;
    $('#emailForm').modal('show');//<-- muestro el formulario
    $('#div-chatRoomView').hide();
}




function Set_alert_text_infoChatRoom(message, replace) {
    var content = $('#alert-text-view-info-ChatRoom');
    var content = content.find(".info-text")
    if (replace) {
        content.empty();
    }

    content.append(message);
}



//aquí esta el contador de tiempo en pausa
var sec = -1; var min = 0; var hour = 0; var t = 0;

function timedCount() {

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



function IsEmail(email) {
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email);
}