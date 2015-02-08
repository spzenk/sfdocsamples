
// Define the namespace
window.SecurityPortalApi = {};

var httpHost = Getrootpath('');
var siteViewModel = null;
$(function () {

    //Initialize the datepicker with the dateFormat option specified:
    $.datepicker.regional[""].dateFormat = 'dd/mm/yy';
    $.validator.addMethod('date',
    function (value, element) {
        if (this.optional(element)) {
            return true;
        }
        var ok = true;
        try {
            $.datepicker.parseDate('dd/mm/yy', value);
        }
        catch (err) {
            ok = false;
        }
        return ok;
    });
    Init_datepicker();
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






function Init_datepicker()
{
    
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
        $('.ajaxloader').show();
        $('#alert-text-view').hide('slow');
    }
    else {
        $('.ajaxloader').hide();
        //$('.loading').empty();
    }
}


function Set_alert_text(message) {
    var alertText = $('#alert-text-view');
    alertText.show('slow');
    alertText.find('.error-text').text(message);
}

function Set_alert_text_info(message) {
    var alertText = $('#alert-text-view-info');
    alertText.show('slow');
    alertText.find('.info-text').text(message);
}

///messagetype error,warning,info,help
function ShowAlertMessage(text, title, mesagetype, smalltitle) {
    if (!smalltitle)
        smalltitle = '';
    if (!title)
        title = 'Allus';
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
    var alertText = $('#alert-text-view');
    alertText.show('slow');

    if (ajaxContext.responseText)
        alertText.find('.error-text').text(ajaxContext.responseText);
    else
        alertText.find('.error-text').text(ajaxContext.Message);
}

function OnFailureEmailOption(ajaxContext) {
    var alertText = $('#alert-text-view');
    alertText.show('slow');
   $('#div-send-email-optional').show();
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