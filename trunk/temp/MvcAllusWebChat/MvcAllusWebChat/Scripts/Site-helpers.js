

function callback_error(XMLHttpRequest, textStatus, errorThrown) {
    alert(errorThrown);
}
function checkEmail(email) {
    var bValid = true;
    bValid = bValid && checkRegexp(email, /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i, "eg. ui@jquery.com");
    return bValid;
}

function checkUserName(name) {

    var bValid = true;
    bValid = bValid && checkRegexp(name, /^[a-z]([0-9a-z_])+$/i, "Username may consist of a-z, 0-9, underscores, begin with a letter.");

    return bValid;
}

function checkRegexp(o, regexp, n) {
    if (!(regexp.test(o.val()))) {
        o.addClass("ui-state-error");
        updateTips(n);
        return false;
    } else {
        return true;
    }
}

function updateTips(t) {
    var tips = $(".validateTips");
    tips.text(t).addClass("ui-state-highlight");
    setTimeout(function () {
        tips.removeClass("ui-state-highlight", 1500);
    }, 500);
}




//var Example = (function () {
//    "use strict";

//    var elem,
//        hideHandler,
//        that = {};

//    that.init = function (options) {
//        elem = $(options.selector);
//    };

//    that.show = function (text) {
//        clearTimeout(hideHandler);

//        elem.find("span").html(text);
//        elem.fadeIn();

//        hideHandler = setTimeout(function () {
//            that.hide();
//        }, 4000);
//    };

//    that.hide = function () {
//        elem.fadeOut();
//    };

//    return that;
//}());

//Permite obtener un parametro de una url:
//Mode de uso:
//  var guid = $.urlParam('uniqueGuid');
$.urlParam = function (name) {
    var results = new RegExp('[\\?&]' + name + '=([^&#]*)').exec(window.location.href);
    if (results == null) return null;
    return results[1] || 0;
}

//busca un objeto por id dentro de una coleccion json
$.getObjectById = function (id, idPropertyName, jsonObjectList) {
    var selectedObj = null;
    for (var i = 0; i < jsonObjectList.length; i++)
        if (jsonObjectList[i][idPropertyName] == id)
            selectedObj = jsonObjectList[i];


    return selectedObj;
}

//Permite filtrar un select con el contenido de un texbox o input
//Realiza filter contain
jQuery.fn.filterByText = function (textbox, selectSingleMatch) {
    return this.each(function () {
        var select = this;
        var options = [];
        $(select).find('option').each(function () {
            options.push({ value: $(this).val(), text: $(this).text() });
        });
        $(select).data('options', options);
        $(textbox).bind('change keyup', function () {
            var options = $(select).empty().scrollTop(0).data('options');
            var search = $.trim($(this).val());
            var regex = new RegExp(search, 'gi');

            $.each(options, function (i) {
                var option = options[i];
                if (option.text.match(regex) !== null) {
                    $(select).append(
                       $('<option>').text(option.text).val(option.value)
                    );
                }
            });
            if (selectSingleMatch === true &&
                $(select).children().length === 1) {
                $(select).children().get(0).selected = true;
            }
        });
    });
};