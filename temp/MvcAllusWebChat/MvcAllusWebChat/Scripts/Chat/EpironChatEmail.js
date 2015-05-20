
$(function () {
    //$("#btnSendEMail").click(function () {
    //    //sendEmail();
    //    //window.close();
 
    //});

    $("#btnCloseEmail").click(function () {
        window.close();
    });
});

function sendEmail() {

    cellphone = $('#txt-Phone').val();
    email = $('#txt-Email').val();
    emailBody = $('#txt-InitialMessageEmail').val();
    pGuid = selectedChatConfigId == "-1" ? "0" : selectedChatConfigId;
    pRoomId =_roomId == "-1" ? "0" : _roomId;

    var pIsNoOperator = 0;
    if (pRoomId == "0")
        pIsNoOperator = 1;

    var params = { cellPhone: cellphone, email: email, emailBody: emailBody, toTheClientFlag: false, pGuid: pGuid, pRoomId: pRoomId, pIsNoOperator: pIsNoOperator }

    var obj = null;

    $.ajax({
        url: "/EpironChatEmail/sendEmail/",
        type: "POST",
        dataType: 'json',
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify(params),
        success: function (result) {
            if (result.Result && result.Result == 'ERROR') {
                ShowAlertMessage(result.Message, 'Error en el servidor', 'error');
                return;
            }
            if (result.Result && result.Result == 'OK') {
                $("#span-version-email").hide();
                $("#img-message-email").attr("src", "../../img/mail-ok.png");
                $(".panel-header-email").css("height", "135px");
                $('#alert-text-info-container .info-text').append(result.Message);

                $('#btnSendEMail').attr('disabled', 'true');

            }
        },

        error: ServiceFailed
    });
}



