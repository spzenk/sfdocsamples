
var _userId = -1;
var _recordId = -1;
var _firstMessageId = -1;
var _roomId = -1;

$(function () {

    $('#btn-End').on('click', function () {
        $('#div-end-chat').css('display',"block");
    });

    $('#btn-add-own').on('click', function () {
        var message = "Lorem ipsum ad his scripta blandit partiendo, eum fastidii accumsan euripidis in, eum liber hendrerit an. Qui ut wisi vocibus suscipiantur, quo dicit ridens inciderint id. Quo mundi lobortis reformidans eu, legimus senserit definiebas an eos. Eu sit tincidunt incorrupte definitionem, vis mutat affert percipit cu, eirmod consectetuer signiferumque eu per. In usu latine equidem dolores. Quo no falli viris intellegam, ut fugit veritus placerat per."
      + " Ius id vidit volumus mandamus, vide veritus democritum te nec, ei eos debet libris consulatu. No mei ferri graeco dicunt, ad cum veri accommodare. Sed at malis omnesque delicata, usu et iusto zzril meliore. Dicunt maiorum eloquentiam cum cu, sit summo dolor essent te. Ne quodsi nusquam legendos has, ea dicit voluptua eloquentiam pro, ad sit quas qualisque. Eos vocibus deserunt quaestio ei."
       +" Blandit incorrupte quaerendum in quo, nibh impedit id vis, vel no nullam semper audiam. Ei populo graeci consulatu mei, has ea stet modus phaedrum. Inani oblique ne has, duo et veritus detraxit. Tota ludus oratio ea mel, offendit persequeris ei vim. Eos dicat oratio partem ut, id cum ignota senserit intellegat. Sit inani ubique graecis ad, quando graecis liberavisse et cum, dicit option eruditi at duo. Homero salutatus suscipiantur eum id, tamquam voluptaria expetendis ad sed, nobis feugiat similique usu ex."
   
        var newMessage = formatMessage(message);

        var linesquantity = (message.length / 300).toFixed(0) + 1;//cantidad de renglones necesarios.


        var container = $('#txtMessageList');
        var div = document.createElement("DIV");

        $(div)
                    .appendTo(container)
                    .addClass("bubbleOwn")
                    .end()
                    .append("<span class=\"_talker\">" + ("Representante") + "</span>")
                    //.append("<span>" + (this.IsFriend ? " dice  " : " dijo") + "</span>")
                    .append("<span class=\"_time\">" + "15/12/2015 08:05am" + "</span>")
                    .append("<span>: </span><BR /> ")
                    .append("<span class=\"_msg\">" + newMessage + "</span> ")
        .css("height", linesquantity * 5 + "px");

        scrollToBotton();
    });


    $('#btn-add-external').on('click', function () {
        var message = "Lorem ipsum";
        var newMessage = formatMessage(message);

        var linesquantity = (message.length / 300).toFixed(0) + 1;//cantidad de renglones necesarios.


        var container = $('#txtMessageList');
       
        var div = document.createElement("DIV");
        $(div)
                    .appendTo(container)
                    .addClass("bubbleFriend")
                    .end()
                    .append("<span class=\"_talker\">" + ("Cliente") + "</span>")
                    //.append("<span>" + (this.IsFriend ? " dice  " : " dijo") + "</span>")
                    .append("<span class=\"_time\">" + "15/12/2015 08:05am" + "</span>")
                    .append("<span>: </span><BR /> ")
                    .append("<span class=\"_msg\">" + newMessage + "</span> ")
        .css("height", linesquantity * 5 + "px");

        scrollToBotton();


    });

});

function scrollToBotton() {

    var wtf = $('#txtMessageList');
        var height = wtf[0].scrollHeight;
        wtf.scrollTop(height);

}

function formatMessage(message) {
    //insertamos saltos de linea para no romper el stile de la burbuja
    var newMessage = message.split("");
    for (var i = 0 ; i >= message.lenght; i++) {
        var lastEmptyPosition= 0; //<-- la posicion donde se encontro el ultimo espacio

        if (newMessage[i] = '')
            lastEmptyPosition = i;

        if (i == 300) {
            newMessage.splice(lastEmptyPosition, 1, ' </br> ');
        }
    }
    return (newMessage.join('')); //<--- unimos todos los string con los saltos de linea

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