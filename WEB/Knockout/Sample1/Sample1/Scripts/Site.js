
// Define the namespace
window.SecurityPortalApi = {};

var httpHost = Getrootpath('');
var siteViewModel = null;
$(function () {

   
   
});




function ServiceFailed(xhr, status, p3, p4) {
    var errMsg = status + " " + p3;
    //var errObj = JSON.parse(xhr.responseText);
    errMsg = errMsg + "\n" + xhr.responseText;

    alert(errMsg);
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
        $('.ajaxloader').show();
        $('#alert-text-view').hide('slow');
    }
    else {
        $('.ajaxloader').hide();
        //$('.loading').empty();
    }
}

function OnFailure(ajaxContext) {
    var alertText = $('#alert-text-view');
    alertText.show('slow');

    if (ajaxContext.responseText)
        alertText.find('.error-text').text(ajaxContext.responseText);
    else
        alertText.find('.error-text').text(ajaxContext.Message);
}

function OnFailureId(ajaxContext,alertId) {
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

function SetPanel_CRUD(controlId,isEdit)
{
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