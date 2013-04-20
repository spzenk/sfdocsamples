function amply(img, divId) {
    var elem1 = $("#" + divId);
    //Amplia
    if (img.width < 570) {
        elem1.removeClass("news_divImag_190_210");
        elem1.addClass("news_divImag_500_570");
        elem1.fadeSliderE({ speed: 500, easing: "swing" }, "true");
        img.width = 570;
        img.height = 500;
    }
    else {//Reduce
        elem1.removeClass("news_divImag_500_570");
        elem1.addClass("news_divImag_190_210");
        elem1.fadeSliderE({ speed: 500, easing: "swing" }, "false");
        img.width = 210;
        img.height = 190;
    }
}

/*
    Busca un control por nombre *+nombre se usa desde   $(document).ready de las Master page
*/
jQuery.fn.findControl = function (clientId) {
return $('*[id*="_' + clientId + '"]');
}

/*
* Fade Slider Toggle plugin
*
* Copyright(c) 2009, Cedric Dugas
* http://www.position-relative.net
*
* A sliderToggle() with opacity
* Licenced under the MIT Licence
*/
jQuery.fn.fadeSliderToggle = function (settings) {
    /* Damn you jQuery opacity:'toggle' that dosen't work!~!!!*/
    settings = jQuery.extend({
        speed: 500,
        easing: "swing"
    }, settings)
    caller = this
    if ($(caller).css("display") == "none") {
        $(caller).animate({
            opacity: 1,
            height: 'toggle'
        }, settings.speed, settings.easing);
    } else {
        $(caller).animate({
            opacity: 0,
            height: 'toggle'
        }, settings.speed, settings.easing);
    }
};

jQuery.fn.fadeSliderE = function (settings, exp) {

    settings = jQuery.extend({ speed: 500, easing: "swing" }, settings);

    caller = this;
    if (exp == "true") {
        $(caller).animate({
            opacity: 1,
            height: '500px'
        }, settings.speed, settings.easing);
    } else {
        $(caller).animate({
            opacity: 1,
            height: '190px'
        }, settings.speed, settings.easing);
    }
};



function Getrootpath(href) {

    var url = document.location.protocol + '//' + document.location.host;
    var root = document.location + '/';
    var aux = '';
    var temp = new Array();
    temp = root.split('/');
    aux = temp[2].toString();

    if (aux.indexOf('localhost:', 0) == -1) {
        url = url + '/' + temp[3] + href;
    }
    else {
        url = url + href;
    }

    return url;
}

function fieldOnBlur(ref) {
    $(ref).css("border", "1px solid #000");
}

function fieldOnFocus(ref) {
    $(ref).css("border", "1px solid #CC9900");
}

//the purpose of this function is to allow the enter key to 
//point to the correct button to click.
//Funcion cargada dimnamicamente en el load de una funcion para el atributo keypress
// Ej: txtUserName.Attributes.Add("onKeyPress", "doClick('" + btnFind.ClientID + "',event)");
function doClick(buttonName, e) {

    var key;

    if (window.event)
        key = window.event.keyCode;     //IE
    else
        key = e.which;     //firefox

    if (key == 13) {
        //Get the button the user wants to have clicked
        var btn = document.getElementById(buttonName);
        if (btn != null) { //If we find the button click it
            btn.click();
            event.keyCode = 0
        }
    } 
}