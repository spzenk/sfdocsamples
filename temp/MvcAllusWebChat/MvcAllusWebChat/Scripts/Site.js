
// Define the namespace
window.SecurityPortalApi = {};

var httpHost = Getrootpath('');
var siteViewModel = null;
var _isClose = false;

$(function () {


    window.onbeforeunload = leaving;


    $('#span-version').html(_version); //<--- version
    $('#span-version-chat').html(_version); //<--- version


    $('#btn-End').on('click', function () {
        btn = $('#btn-End');
        btn.addClass("hide").removeClass("show"); //<--- oculta el boton (versiones lower)
        //btn.css("background-color", "rgb (44,90,160)");

        //$('#div-end-session-menu').css("margin-top", "170px");

        $('#div-end-option').show();


            $('#message-before-end').html("¿Desea terminar la sesión?");
            $('#btn-end-option-no').html("Cancelar");
            $('#btn-end-option-yes').html("Salir");
            $('#div-end-option').addClass('div-end-option-short');


    });

    $("#btn-end-option-no").on("click", function () {

            $('#div-end-option').hide();

            var btn = $('#btn-End');
            btn.css("background-color", "rgb(42,127,255)");
            btn.addClass("show").removeClass("hide"); //<--- oculta el boton (versiones lower)
    });

    $("#btn-end-option-yes").on("click", function () {
        //$('#div-end-option').css('margin-top', '10px');
        if (_isClose  && _isSurveyAvailable) { //<---el cliente aun no hizo la encuenta y respondio que si la quiere hacer
            openSurvey(); //<--abrimos la encuesta
            $("#div-end-option").hide();
        }
        else {
            if (sendEmailChat()) {
                //CloseChatRoom("Gracias por Comunicarse con nosotros");
                LeaveChatRoom(_isSurveyAvailable);
                $('#div-end-option').removeClass('div-end-option-short');
                $('#message-before-end').html("¿Desea calificar nuestro servicio?");
                $('#btn-end-option-no').html("No");
                $('#btn-end-option-yes').html("Sí");
                _isClose = true;

            }

        }

    });


    //Initialize the datepicker with the dateFormat option specified:
    //$.datepicker.regional[""].dateFormat = 'dd/mm/yy';
    //$.validator.addMethod('date',
    //function (value, element) {
    //    if (this.optional(element)) {
    //        return true;
    //    }
    //    var ok = true;
    //    try {
    //        $.datepicker.parseDate('dd/mm/yy', value);
    //    }
    //    catch (err) {
    //        ok = false;
    //    }
    //    return ok;
    //});
    //Init_datepicker();
    //$(".datefield").datepicker({
    //    dateFormat: 'dd/mm/yy',
    //    changeYear: true,
    //    autoclose: true,
    //    changeMonth: true,
    //    maxDate: "+1000Y",
    //    minDate: 0
    //});

    //Fix dsatapicker on modal bbootstrap
    // Since confModal is essentially a nested modal it's enforceFocus method
    // must be no-op'd or the following error results 
    // "Uncaught RangeError: Maximum call stack size exceeded"
    // But then when the nested modal is hidden we reset modal.enforceFocus
    var enforceModalFocusFn = $.fn.modal.Constructor.prototype.enforceFocus;

    $.fn.modal.Constructor.prototype.enforceFocus = function () { };

    //$confModal.on('hidden', function () {
    //    $.fn.modal.Constructor.prototype.enforceFocus = enforceModalFocusFn;
    //});

    //$confModal.modal({ backdrop: false });


    ////////////////siteViewModel = new SecurityPortalApi.siteViewModel();
    ////////////////ko.applyBindings(siteViewModel);

    //        var guid = $.urlParam('uniqueGuid');

    //        if (guid != null)
    //            $('.instance').each(function () {
    //                $(this).attr('href', $(this).attr('href') + guid);
    //  

    //Init all tooltips  custom
    ////////////////////////////$(document).tooltip({
    ////////////////////////////    position: {
    ////////////////////////////        my: "center bottom-20",
    ////////////////////////////        at: "center top",
    ////////////////////////////        using: function (position, feedback) {
    ////////////////////////////            $(this).css(position);
    ////////////////////////////            $("<div>")
    ////////////////////////////					.addClass("arrow")
    ////////////////////////////					.addClass(feedback.vertical)
    ////////////////////////////					.addClass(feedback.horizontal)
    ////////////////////////////					.appendTo(this);
    ////////////////////////////        }
    ////////////////////////////    }
    ////////////////////////////});

    /// Vamos a usar dialog modal fade de bootstrap
    //$("#dialog-alert").dialog({
    //    autoOpen: false,
    //    show: { effect: "highlight", duration: 1000 },
    //    hide: {
    //        effect: "explode", duration: 1000
    //    },
    //    resizable: false,
    //    height: 240,
    //    modal: true,
    //    buttons: {
    //        Ok: function () {
    //            $(this).dialog("close");
    //        }
    //    }
    //});

    $("#MessageBox").on("show", function () {    // wire up the OK button to dismiss the modal when shown
        $("#MessageBox a.btn").on("click", function (e) {
            console.log("button pressed");   // just as an example...
            $("#MessageBox").modal('hide');     // dismiss the dialog
        });
    });

    $("#MessageBox").on("hide", function () {    // remove the event listeners when the dialog is dismissed
        $("#MessageBox a.btn").off("click");
    });

    $("#MessageBox").on("hidden", function () {  // remove the actual elements from the DOM when fully hidden
        $("#MessageBox").remove();
    });

    $("#MessageBox").modal({                    // wire up the actual modal functionality and show the dialog
        "backdrop": "static",
        "keyboard": true,
        "show": true                     // ensure the modal is shown immediately
    });




    ///INIcia Los Tree View
    $('label.tree-toggler').click(function () {
        $(this).parent().children('ul.tree').toggle(300);
    });

    $('.tree li:has(ul)').addClass('parent_li').find(' > span').attr('title', 'Collapse this branch');
    $('.tree li.parent_li > span').on('click', function (e) {
        var children = $(this).parent('li.parent_li').find(' > ul > li');
        if (children.is(":visible")) {
            children.hide('fast');
            $(this).attr('title', 'Expand this branch').find(' > i').addClass('icon-plus-sign').removeClass('icon-minus-sign');
        } else {
            children.show('fast');
            $(this).attr('title', 'Collapse this branch').find(' > i').addClass('icon-minus-sign').removeClass('icon-plus-sign');
        }
        e.stopPropagation();
    });


    $("span.field-validation-valid, span.field-validation-error").addClass('help-inline');
    $("div.control-group").has("span.field-validation-error").addClass('error');
    $("div.validation-summary-errors").has("li:visible").addClass("alert alert-block alert-error");

});
jQuery.validator.setDefaults({
    highlight: function (element, errorClass, validClass) {
        if (element.type === 'radio') {
            this.findByName(element.name).addClass(errorClass).removeClass(validClass);
        } else {
            $(element).addClass(errorClass).removeClass(validClass);
            $(element).closest('.control-group').removeClass('success').addClass('error');
        }
    },
    unhighlight: function (element, errorClass, validClass) {
        if (element.type === 'radio') {
            this.findByName(element.name).removeClass(errorClass).addClass(validClass);
        } else {
            $(element).removeClass(errorClass).addClass(validClass);
            $(element).closest('.control-group').removeClass('error').addClass('success');
        }
    }
});
//var page = function () {
//    //Update the validator
//    $.validator.setDefaults({
//        highlight: function (element) {
//            $(element).closest(".form-group").addClass("has-error");
//            $(element).closest(".form-group").removeClass("has-success");
//        },
//        unhighlight: function (element) {
//            $(element).closest(".form-group").removeClass("has-error");
//            $(element).closest(".form-group").addClass("has-success");
//        }
//    });
//}();


//Funcion Ajax que obtine datos segun userId healtId
function FindSiteViewModel(userId, instId) {
    var IsAuthenticated = $('#IsAuthenticated').val();
    if (instId != null || instId != null && IsAuthenticated == true) {
        var req = { InstId: instId, UserId: userId };
        var varDataJSON = ko.toJSON(req);

        $.ajax(
                        {
                            url: httpHost + "/api/HomeApi/RetrivesiteViewModel/",
                            type: "POST",
                            contentType: "application/json;charset=utf-8",
                            datatype: "json",
                            data: varDataJSON,
                            success: function (result) {
                                var p = ko.toJS(result);
                                siteViewModel.RazonSocial(p.RazonSocial);
                                siteViewModel.Email(p.Email);
                                siteViewModel.FirstName(p.FirstName);
                                siteViewModel.LastName(p.LastName);
                                siteViewModel.PhotoURL(p.PhotoURL);
                                siteViewModel.ProfesionalId(p.ProfesionalId);
                                siteViewModel.LastUpdate = new Date();

                                $('#rofId').val(p.ProfesionalId);
                            },
                            error: ServiceFailed
                        });
    }
}

(function (SecurityPortalApi) {
    function siteViewModel() {

        var self = this;
        self.ProfesionalId = ko.observable("");
        self.ApellidoNombre = ko.observable("");
        self.RazonSocial = ko.observable("");
        self.Email = ko.observable("");
        self.FirstName = ko.observable("");
        self.LastName = ko.observable("");
        self.PhotoURL = ko.observable("");
        self.LastUpdate = new Date();

        self.TTL = ko.dependentObservable(function () {
            var now = new Date();
            var startTime = this.LastUpdate;
            var startMsec = startTime.getMilliseconds();
            var elapsedTime = ((now.getTime() - startMsec) / 1000);
            return elapsedTime;
        }, self);

        self.FullName = ko.computed(function () {
            return self.FirstName() + " " + self.LastName();
        }, self);
    }
    // add to our namespace
    SecurityPortalApi.siteViewModel = siteViewModel;
}(window.SecurityPortalApi));




function ServiceFailed(xhr, status, p3, p4) {
    var errMsg = status + " " + p3;
    //var errObj = JSON.parse(xhr.responseText);
    errMsg = errMsg + "\n" + xhr.responseText;

    alert(errMsg);
}






function Init_datepicker() {

    $(function () {

        $(".datefield").datepicker({
            dateFormat: 'dd/mm/yy',
            changeYear: true,
            autoclose: true,
            changeMonth: true,
            maxDate: "+1000Y",
            minDate: 0
        });
    });


}
function Getrootpath(href) {

    //return 'http://ws2008/SecPortal/';
    var url = document.location.protocol + '//' + document.location.host;
    var root = document.location + '/';
    var aux = '';
    var temp = new Array();
    temp = root.split('/');
    aux = temp[2].toString();

    if (aux.indexOf('localhost:', 0) == -1) {
        if (temp.length == 6)
            url = url + '/' + temp[3] + href;
        else
            url = url + '/' + href;
    }
    else {
        url = url + href;
    }

    return url;
}

function Showloading(show) {
    if (show) {
        //$('.loading').html('<img class="ajaxloader" src="@Url.Content("~/img/ajax-loader.gif")"/>');
        $('#ajaxloader').show();
        $('#alert-text-view1').hide('slow');
    }
    else {
        $('#ajaxloader').hide();
        //$('.loading').empty();
    }
}


function ShowloadingUrl(show) {
    if (show) {
        //$('.loading').html('<img class="ajaxloader" src="@Url.Content("~/img/ajax-loader.gif")"/>');
        $('#ajaxloader1').show();
        $('#alert-text-view1').hide('slow');
    }
    else {
        $('#ajaxloader1').hide();
        //$('.loading').empty();
    }
}


function Set_alert_text_info(message, replace) {
    var content = $('#alert-text-view-info');
    var content = content.find(".info-text")
    if (replace) {
        content.empty();
    }

    content.append(message);
}

function Set_alert_text_error(message, title) {
    $('#error-text-message').text(message);
    $('#alert-text-error-tittle').text(title);
    $('#alert-text-view1').show('slow');
}

///messagetype error,warning,info,help
function ShowAlertMessage(text, title, mesagetype, smalltitle) {
    if (!smalltitle)
        smalltitle = '';
    if (!title)
        title = 'Movistar';
    var _html = '<div class="media"> <a href="#" class="pull-left">';
    _html += '<img  id="message-alert-img" src="/img/indicator_error38.png" class="media-object img-rounded" alt=""></a>';

    _html += '<div class="media-body">';
    _html += '<h4 id = "message-title" class="media-heading">' + title + '<small><i>' + smalltitle + '</i></small></h4>';
    _html += '<br/>';
    _html += '<p>' + text + '</p>';
    _html += '</div> </div>';



    bootbox.alert(_html);
    if (mesagetype == 'error') {
        $('#message-alert-img').attr('src', '/img/indicator_error38.png');
    }
    if (mesagetype == 'warning') {
        $('#message-alert-img').attr('src', '/img/warning38.png');
    }
    if (mesagetype == 'info') {
        $('#message-alert-img').attr('src', '/img/info48.png');
    }
    if (mesagetype == 'help') {
        $('#message-alert-img').attr('src', '/img/ic_menu_help48.png');
    }
}

function OnFailure(ajaxContext) {
    var alertText = $('#alert-text-view1');
    alertText.show('slow');

    if (ajaxContext.responseText)
        alertText.find('.error-text').text(ajaxContext.responseText);
    else
        alertText.find('.error-text').text(ajaxContext.Message);
}

function OnFailureEmailOption(ajaxContext) {
    var alertText = $('#alert-text-view1');
    alertText.show('slow');
    $('#div-send-email-optional').show();
}
function OnFailureId(ajaxContext, alertId) {
    var alertText = $('#' + alertId);
    alertText.show('slow');

    if (ajaxContext.responseText)
        alertText.find('.error-text').text(ajaxContext.responseText);
    else
        alertText.find('.error-text').text(ajaxContext.Message);
}

function RefreshPage() {
    $.ajax({
        url: "",
        context: document.body,
        success: function (s, x) {
            $(this).html(s);
        }
    });
}

function SetPanel_CRUD(controlId, isEdit) {
    if (isEdit) {
        $('#' + controlId).addClass('panel-success');
        $('#' + controlId).removeClass('panel-warning');
    }
    else {
        $('#' + controlId).addClass('panel-warning');
        $('#' + controlId).removeClass('panel-success');

    }
}


function RefrechGrid(controller) {
    $.ajax(
     {
         url: httpHost + "/" + controller + "/RetriveGrid/",
         type: "POST",
         dataType: 'html',
         contentType: "application/json;charset=utf-8",
         data: null,
         success: function (result) {
             $('#grid').html(result);
         },
         error: ServiceFailed
     });
}

function amply(img, divId) {
    var elem1 = $("#" + divId);
    var image = elem1.find('img');

    //Amplia
    if (image.hasClass("news_divImag_190_210")) {

        elem1.removeClass("news_divImag_190_210");
        elem1.addClass("news_divImag_500_570").fadeIn({ speed: 500, easing: "swing" }, "true");;
        image.removeClass("news_divImag_190_210");
        image.addClass("news_divImag_500_570").fadeIn({ speed: 1500, easing: "swing" }, "true");


    }
    else {//Reduce

        elem1.removeClass("news_divImag_500_570");
        elem1.addClass("news_divImag_190_210").fadeIn({ speed: 500, easing: "swing" }, "true");;
        image.removeClass("news_divImag_500_570");
        image.addClass("news_divImag_190_210").fadeIn("slow");
    }
}


function JSON_TO_Date(value) {

    return new Date(parseInt(value.replace("/Date(", "").replace(")/", ""), 10));
}


function showToolTip(pElement, Plegend) {
    pElement.tooltip({ title: Plegend, placement: 'right' });
    pElement.tooltip('show');
    pElement.css("border-color", "#D11");
}


function hideToolTip(pElement) {
    pElement.tooltip('hide');
}

function destroyToolTip(pElement) {
    pElement.css("border-color", "#4B4B4B");
    pElement.tooltip('destroy')

}

function UpdateTimeToExpire() {
    current = new Date();
    timeToExpire = new Date(current);
    timeToExpire.setSeconds(current.getSeconds() + ClientInactivityTimeOut);
}

function RetriveAllMessage() {



    if (timeToExpire < new Date()) {
        //Se supero el tiempo  máximo de inactividad  
        TimeOutChatRoom();
        return;
        //termina el ciclo
    }


    var obj = {
        RecordId: _recordId,
        RoomId: _roomId,
    }

    $.ajax({
        url: "/EpironChatVersion1/RetriveMessages/",
        type: "POST",
        dataType: 'json',
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify(obj),
        success: function (result) {
            if (result.Result && result.Result == 'ERROR') {
                //ShowAlertMessage(result.Message, 'Error en el servidor', 'error');
                return;
            }

            UpdateOperatorName(result.pNameOperator);


            //ClosedByOperator
            if (result.ChatRoomStatus == '5')
            { CloseChatRoom("Sala de chat cerrada por el operador. </br>Gracias por Comunicarse con nosotros"); return; }
            if (result.ChatRoomStatus == '2')
            { CloseChatRoom("Gracias por Comunicarse con nosotros"); return; }




            if (result.Data.length > 0) {
                if (_LASTMESSAGETIME != null) {
                    if (JSON_TO_Date(result.Data[result.Data.length - 1].SendTime) <= _LASTMESSAGETIME) {
                        if (_roomId != -1) {
                            funcretriveAllMessage = setTimeout(function () { RetriveAllMessage(); }, _RetriveMessage_Timer);
                            if (result.OperatorWriting) {
                                $('#OperatorWritingDiv').html("El operador esta escribiendo ..");

                            }
                            else {
                                $('#OperatorWritingDiv').empty();
                            }
                        }
                        else {
                            $('#OperatorWritingDiv').empty();
                        }


                        return;
                    }

                    else {
                        UpdateTimeToExpire(); //<--han escrito algo, se incrementa el tiempo de timeOut
                        //hay nuevos comentarios. Alertar.
                    }
                }

                var container = $('#txtMessageList');
                var longDateFormat = 'HH:mm:ss';

                container.html("");

                if (result.OperatorWriting) {
                    $('#OperatorWritingDiv').html("El operador esta escribiendo ..");

                }
                else {
                    $('#OperatorWritingDiv').empty();
                }


                $(result.Data).each(function (i) {

                    var newMessage = this.MessageData.autoLink({ target: "_blank"});//formatea el texto agregando saltos de lineas
                    var linesquantity = (newMessage.length / 300).toFixed(0) + 1;//cantidad de renglones necesarios.

                    var div = document.createElement("DIV");
                    var dateFormat = jQuery.format.date(JSON_TO_Date(this.SendTime), longDateFormat);
                    _LASTMESSAGETIME = JSON_TO_Date(this.SendTime); //guardo la fecha del ultimo mensage para luego saber si hubo uno nuevo
                    $(div)
                                .appendTo(container)
                                .addClass((this.IsFriend ? "bubbleOwn" : "bubbleThey"))
                                .end()

                                .append("<span class=\"_time\">" + dateFormat + "</span>")
                                .append("<BR /> ")
                                .append("<span class=\"_msg\">" + $.emoticons.replace(newMessage) + "</span> ");

                    scrollToBotton();

                });
            }
            else {
                if (result.OperatorWriting) {
                    $('#OperatorWritingDiv').html("El operador esta escribiendo ..");

                }
                else {
                    $('#OperatorWritingDiv').empty();
                }
            }

            //container.scrollTop(container[0].scrollHeight - container.height());

            funcretriveAllMessage = setTimeout(function () { RetriveAllMessage(); }, _RetriveMessage_Timer);

        },

        error: ServiceFailed
    });


}

function cleanVariablesDisableItems(surveyPending) {
    //En esta función limpio todas las variables necesarias al cerrar el fomulario
    USER_SEND_EMAIL = false;
    $("#btn-End").prop("disabled", true);

    $("#txt-message").prop("disabled", true);
    $("#img-emoticon").prop("disabled", true);
    $("#img-upload-file").hide();
    $("#img-emoticon").hide();
    $("#div-end-session-menu").hide();
    Showloading(false);
    if (!surveyPending) {
        $("#div-end-option").hide();
    }
}



function CloseChatRoom(message,surveyPending) {
    clearTimeout(funcretriveAllMessage);
    clearTimeout(funcGetRecordId);
    stopTimerCount();
    cleanVariablesDisableItems(surveyPending);

    var container = $('#txtMessageList');

    var today = new Date();
    var div = document.createElement("DIV");
    var dateFormat = jQuery.format.date(today, 'HH:mm:ss');
    $(div)
                .appendTo(container)
                .addClass("bubbleOwn")
                .end()
                .append("<span class=\"_time\">" + dateFormat + "</span>")
                //.append("<span>: </span><BR /> ")
                .append("<span class=\"_msgClosed\">" + message + "</span> ");

    if (!surveyPending) {
        _userId = -1;
        _recordId = -1;
        _roomId = -1;
    }
    $('#OperatorWritingDiv').empty();
    scrollToBotton();
}

function LeaveChatRoom(surveyPending) {


    var obj = {
        recordId: _recordId,
        roomId: _roomId
    }
    $.ajax({
        url: "/EpironChatVersion1/LeaveChatRoom/",
        type: "POST",
        dataType: 'json',
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify(obj),
        success: function (result) {
            if (result.Result && result.Result == 'ERROR') {
                //ShowAlertMessage(result.Message, 'Error en el servidor', 'error');
                return;
            }
            CloseChatRoom(result.Message, surveyPending);
        },

        error: ServiceFailed
    });

}

function TimeOutChatRoom() {


    var obj = {
        recordId: _recordId,
        roomId: _roomId
    }
    $.ajax({
        url: "/EpironChatVersion1/TimeOutChatRoom/",
        type: "POST",
        dataType: 'json',
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify(obj),
        success: function (result) {
            if (result.Result && result.Result == 'ERROR') {
                //ShowAlertMessage(result.Message, 'Error en el servidor', 'error');
                return;
            }
            CloseChatRoom(result.Message);
        },

        error: ServiceFailed
    });

}

function ClosedByRecordIdNotFound() {
    var obj = {
        recordId: _recordId,
        roomId: _roomId
    }
    $.ajax({
        url: "/EpironChatVersion1/ClosedByRecordIdNotFound/",
        type: "POST",
        dataType: 'json',
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify(obj),
        success: function (result) {
            if (result.Result && result.Result == 'ERROR') {
                //ShowAlertMessage(result.Message, 'Error en el servidor', 'error');
                return;
            }
            //CloseChatRoom(result.Message);
        },

        error: ServiceFailed
    });

}

function SendMessage() {
    if ($.trim($("#txt-message").val()) === "")
        return;
    var obj = {
        Message: $("#txt-message").val(),
        RecordId: _recordId,
        UserId: _userId,
        RoomId: _roomId
    }
    $.ajax({
        url: "/EpironChatVersion1/SendMessage/",
        type: "POST",
        dataType: 'json',
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify(obj),
        success: function (result) {
            if (result.Result && result.Result == 'ERROR') {
                ShowAlertMessage(result.Message, 'Error en el servidor', 'error');
                return;
            }
        }
    });
    $("#txt-message").val('');
}

function sendEmailChat() {
    if (!_emailAvailable)
        return true; //<--- Si el envio de email no esta disponible retorno true;
    if ($("#check-Send-Email").is(':checked')) {
        email = $('#txtemailchat').val();
        if (!IsEmail(email)) {
            showToolTip($('#txtemailchat'), "Verifique su Email")
            return false;
        }

        cellphone = "11111";

        emailBody = $('#txtMessageList').html();
        pGuid = selectedChatConfigId == "-1" ? "0" : selectedChatConfigId;
        pRoomId = _roomId == "-1" ? "0" : _roomId;


        var pIsNoOperator = 0;
        if (pRoomId == "0")
            pIsNoOperator = 1;

        var params = { cellPhone: cellphone, email: email, emailBody: emailBody, toTheClientFlag: true, pGuid: pGuid, pRoomId: pRoomId, pIsNoOperator: pIsNoOperator }

        var obj = null;


        $.ajax({
            url: "/EpironChatEmail/sendEmail/",
            type: "POST",
            dataType: 'json',
            contentType: "application/json;charset=utf-8",
            data: JSON.stringify(params),
            success: function (result) {
                if (result.Result && result.Result == 'ERROR') {
                    //ShowAlertMessage(result.Message, 'Error en el servidor', 'error');
                    //return true;
                }
                if (result.Result && result.Result == 'OK') {
                    //ShowAlertMessage(result.Message, 'Movistar', 'info');
                    //Set_alert_text_infoChatRoom("Correo Enviado Correctamente", true)
                    //return true;
                }

                return true;
            },

            error: ServiceFailed
        });
        return true;

    }
    else {
        return true;
    }

}

function formatMessage(message) {
    var maxLetterByWord = screen.width > 481 ? 30 : 25;//determino la cantidad maxima de caracteres que puede tener una palabra segun el tamaño del dispositivo

    //insertamos saltos de linea para no romper el style de la burbuja
    var newMessage = message.split(" ");
    for (var i = 0 ; i < newMessage.length; i++) {

        if (newMessage[i].length > maxLetterByWord) {//supero el máximo de letras por palabra
            var wordToCorrect = newMessage[i].split(""); //<-- separo la palabra en letras
            var letterCounter = 0;
            var multiplier = 1;
            for (var x = 0; x < wordToCorrect.length; x++) {
                letterCounter++
                if (letterCounter >= maxLetterByWord) {
                    wordToCorrect.splice(letterCounter * multiplier, 1, ' </br> ');
                    letterCounter = 0;
                    multiplier++;
                }
            }
            newMessage[i] = wordToCorrect.join(''); //reemplazamos la palabra en el array
        }
        //var lastEmptyPosition = 0; //<-- la posicion donde se encontro el ultimo espacio

        //if (newMessage[i] = '')
        //    lastEmptyPosition = i;

        //if (i == 300) {
        //    newMessage.splice(lastEmptyPosition, 1, ' </br> ');
        //}
    }
    return (newMessage.join('')); //<--- unimos todos los string con los saltos de linea

}


function Show_Email_Option(option) {

    if (SHOWING_EMAIL_OPTION != 1) {
        switch (option) {
            case 1: //No se encontro Operador
                alert_text_info_containerHTML("No contamos con Operadores Disponibles" + showEmailLink(), false, true); break;

            case 2: //Demora en encontrar sala 
                //$('.panel-header').addClass("panel-headerMax");
                alert_text_info_containerHTML(showEmailLinkWaitting(), true, false); break;

            case 3: //No Hay configuraciones
                alert_text_info_containerHTML(showEmailLink(), false, false); break;
        }
        SHOWING_EMAIL_OPTION = 1 // se usa para saber si ya estamos mostrando la opción del menu.
    }

}

function showEmailLink() {
    if (_emailAvailable) {
        return "</br> Envíanos tu consulta <a href=\"#\" onclick=\"endEmailNoOperator();\" > aquí</a>";
    }
    else {
        return "";
    }
}

function showEmailLinkWaitting() {
    if (_emailAvailable) {
        return "</br> Recuerda que puedes enviarnos tu consulta <a href=\"#\" onclick=\"endEmailNoOperator();\" > aquí</a>";
    }
    else {
        return "";
    }
}





function UpdateOperatorName(NewName) {
    if (_userName != NewName) {
        _userName = NewName;
        $("#span-Epiron-User-Name").append(_userName);
        $("#span-Epiron-User-Name").show();
    }
}



function openSurvey() {

    var obj = {
        RecordId: _recordId,
        RoomId: _roomId
    }
    $.ajax({
        url: "/EpironChatVersion1/OpenSurvey/",
        type: "POST",
        dataType: 'json',
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify(obj),
        success: function (result) {

            window.open(_surveyUrl + result.NewRandomGuid);
        }
    });
}


function leaving(e) {
    if (!e) e = window.event;
    //e.cancelBubble is supported by IE - this will kill the bubbling process.
    e.cancelBubble = true;
    e.returnValue = 'Estas abandonando la conversación.'; //This is displayed on the dialog

    //e.stopPropagation works in Firefox.
    if (e.stopPropagation) {
        e.stopPropagation();
        e.preventDefault();
    }
}