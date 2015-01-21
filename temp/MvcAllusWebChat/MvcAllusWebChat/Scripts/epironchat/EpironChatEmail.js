var casita = null;
$(function () {
    $("#btnAccept").click(function () {
        sendEmail();
    });
});

function sendEmail() {

    cellphone = $('#txt-cellphone').val();
    email = $('#txt-emailFrom').val();
    emailBody = $('#txt-EmailBody').val();
    var params = { cellPhone:cellphone , email:email, emailBody:emailBody, toTheClientFlag:true}

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
           casite = result;
        },

        error: ServiceFailed
    });
}
