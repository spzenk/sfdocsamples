var _LASTMESSAGETIME = null;
var _userId = -1;
var _recordId = -1;
var _firstMessageId = -1;
var _roomId =-1;
var funcGetRecordId;
var funcretriveAllMessage;
var SHOWING_EMAIL_OPTION = 0;//0:Primer momento 1:reintentando 2:cancelado
var USER_SEND_EMAIL = false // true =  usuario decide enviar email
//var GET_RECORDID_TRIES; //cantidad de veces que busco sala
var selectedChatConfigId = null; //configuracion seleccionada
var _userName = "";


var fromTimeFirstCall = null;
var timeToExpire = null;

var GET_RECORDID_TRY_NUMBER = 0;


$(function () {


    //var myDropzone = new Dropzone("#txt-message", {
    //    url: "/EpironChatVersion1/SaveUploadedFile",
    //    autoProcessQueue: true,
    //    clickable: false,
    //    sending: function (file, xhr, formData) {
    //        formData.append("roomid", "0");
    //    }
    //});
    if (_HaveException) {
        Show_Exception();
        DisableControlsCreateChatRoom();
    }


    $('#option-config').focus();
    
    var myDropzone = new Dropzone("#img-upload-file", {
        url: "/EpironChatVersion1/SaveUploadedFile",
        autoProcessQueue: true,
        clickable: false,
        sending: function (file, xhr, formData) {
            formData.append("roomid", "0");
        }
    });

    $('#txt-message').on("keypress", function (e) {
        if (e.keyCode == 13) {
            //SendMessage();
            if (e.shiftKey) //<-- Consulto si oprimio shift
                $('#txt-message').val($('#txt-message').val()+'\n');
            else
                SendMessage();
        }
    });

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

    $('#txtMessageList').html("");
  



    $('#alert-text-info-container').hide();
    $('#alert-text-view').hide();
    $('#chatDialog').hide();


    $('#div_emoticons').html($.emoticons.toString());


    $("#ChatConfigId").change(function () {
        selectedChatConfigId = $("#ChatConfigId :selected").val();
    });
    selectedChatConfigId = $("#ChatConfigId :selected").val();


    $("#txt-ClientName").on("focus", function () {
        destroyToolTip($("#txt-ClientName") );
    });

    $("#txt-clientEmail").on("focus", function () {
        destroyToolTip($("#txt-clientEmail"));
    });

    $("#txt-Phone").on("focus", function () {
        destroyToolTip($("#txt-Phone"));
    });

    $("#txt-InitialMessage").on("focus", function () {
        destroyToolTip($("#txt-InitialMessage"));
    });

    $("#txtemailchat").on("focus", function () {
        destroyToolTip($("#txtemailchat"));
    });
    
    if (!_IsConfigavailable) { // chequea si tenemos configuraciones disponibles
        Show_No_Config();
        DisableControlsCreateChatRoom();
    }

});


function CreateChatRoomBefore_CallBack() {
    if (!validateForm())
        return false;
    DisableControlsCreateChatRoom();
    alert_text_info_container("Conectando con uno de nuestros representantes", true);
  
}

function CreateChatRoom_CallBack(ajaxContext) {

    if (ajaxContext.Result && ajaxContext.Result == 'ERROR') {
        //OnFailure(ajaxContext);
        return;
    }


    if (ajaxContext.Result && ajaxContext.Result == 'NO-OPERATORS') {
        _emailAvailable = ajaxContext.EmailAvailable;
        Show_Email_Option(1);
        return;
    }

    if (ajaxContext.Result && ajaxContext.Result == 'USER-SIGNED') {
        Show_User_Signed();
        return;
    }
    _emailAvailable = ajaxContext.EmailAvailable;
    _userId = ajaxContext.userId;
    _roomId = ajaxContext.roomId;
    _firstMessageId = ajaxContext.messageId;
    _surveyText = ajaxContext.surveyText;
    _isSurveyAvailable = ajaxContext.isSurveyAvailable;
    _surveyUrl = ajaxContext.surveyUrl;
    alert_text_info_container("Aguardando por una sala", true);
    GetRecordId();
}



function Show_User_Signed(option) {
    $('.panel-header').addClass("panel-headerMax");
    alert_text_info_containerHTML("El cliente ingresado<br> esta siendo atendido en este momento <br> Aguarde unos minutos <br> e intente conectarse nuevamente", false, true);
}

function Show_GetRecord_TimeOut() {
    alert_text_info_containerHTML("Se ha excedido el tiempo de espera de sala. <br> Por favor vuelva a intentarlo más tarde", false, true);
}

function Show_No_Config(option) {
    alert_text_info_containerHTML("En este momento no disponemos de salas.", false, true);
    Show_Email_Option(3);
}

function Show_Exception()
{
    alert_text_info_containerHTML("En este momento el chat no esta disponible.", false, true);
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
            if (GET_RECORDID_TRY_NUMBER > GET_RECORDID_TRIES ) {
                Show_Email_Option(2);//Luego del 5to intento muestro la opción de email 
            }
            if (!USER_SEND_EMAIL)
                funcGetRecordId = setTimeout(function () { GetRecordId(); }, _GetRecord_Timer);

            return;
        }

        ChatStart(ajaxContext);

       

    }

    function ChatStart(ajaxContext) {
        if (!_emailAvailable) { //si la app no esta configurada para mandar email. entonces quitamos la op de envio de charla
            $('#div-attr-send-email-label').hide();
            $('#div-attr-send-email-input').hide();
        }


        if (_MaxLength_Message > 0)
            $("#txt-message").attr('maxlength', _MaxLength_Message); //<--seteo el tamaño máximo del mensaje

        $('#txtemailchat').val($('#txt-clientEmail').val());
        _userName = ajaxContext.userName;
        _recordId = ajaxContext.recordId;
        $('#div-chatRoomView').show();
        $('#newModal').hide('slow');
        $('#alert-text-view').hide('slow');
        $('#alert-text-info-container').hide('slow');
        timedCount(); //<--- comienza a correr el tiempo del contador
        Showloading(false);
        UpdateTimeToExpire(); //<--Calculo el tiempo en el que deberia expirar la session
        RetriveAllMessage();
        ResetControlsChat();
        scrollToBotton();
        clearTimeout(funcGetRecordId);

        if (_emailAvailable) { //si el email esta configuracion, muestro las cajas para el envio
            $('#div-attr-send-email-label').show();
            $('#div-attr-send-email-input').show();
            $('#div-end-session-menu').removeClass("div-end-session-menu-no-email").addClass("div-end-session-menu-with-email");
        }

        //Asigno el nombre del operador que respondio la llamada
        $("#span-Epiron-User-Name").append(_userName);
        $("#span-Epiron-User-Name").show();
    }

    function DisableControlsCreateChatRoom() {
        //$('button[type="submit"]').attr('disabled', 'true');
        $('#img-message').hide();
        $('#span-version').hide();
        $('#txt-ClientName').attr('disabled', 'true');
        $('#txt-Phone').attr('disabled', 'true');
        $('#txt-InitialMessage').attr('disabled', 'true');
        $('#btnCreateNew').attr('disabled', 'true');
        $('#ChatConfigId').attr('disabled', 'true');
        $('#txt-clientEmail').attr('disabled', 'true');
        $('#option-config').attr('disabled', 'true');
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
        Set_alert_text_info(msg, true);
    }

    function alert_text_info_containerHTML(msg, showImage, replace) {
        $('#alert-text-info-container').show('slow');
        Showloading(showImage);
        Set_alert_text_info(msg, replace);
    }

    function Set_alert_text_infoChatRoom(message, replace) {
        var content = $('#alert-text-view-info-ChatRoom');
        var content = content.find(".info-text")
        if (replace) {
            content.empty();
        }

        content.append(message);
    }


    function endEmailNoOperator() {
        USER_SEND_EMAIL = true;
        clearTimeout(funcretriveAllMessage);
        clearTimeout(funcGetRecordId);
        $('#txt-phoneEmail').val($('#txt-Phone').val()); //<-- escribo el telefono que usuario ingreso en el primer formulario
        $('#txt-Email').val($('#txt-clientEmail').val());
        $('#txt-InitialMessageEmail').val($('#txt-InitialMessage').val()); //<-- escribo la consulta que usuario ingreso en el primer formulario
        $('#emailForm').modal('show');//<-- muestro el formulario
        $('#newModal').hide();
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

    function validateForm() {
    
        var result = true;

        //valido el nombre
        if ($("#txt-ClientName").val().length == 0) {
            showToolTip($("#txt-ClientName"),"Debe Ingresar su Nombre");
            result = false;
        } 

        //valido el email
        if (!IsEmail($('#txt-clientEmail').val())) {
            showToolTip($('#txt-clientEmail'), "Verifique su Email");
            result = false;
        }

        //valido el telefono
        if ($("#txt-Phone").val().length == 0) {
            showToolTip($("#txt-Phone"), "Debe Ingresar su Teléfono");
            result = false;
        }

        //valido el mensaje inicial
        if ($("#txt-InitialMessage").val().length == 0) {
            showToolTip($("#txt-InitialMessage"), "Debe Ingresar su Consulta");
            result = false;
        }

        return result;

    }