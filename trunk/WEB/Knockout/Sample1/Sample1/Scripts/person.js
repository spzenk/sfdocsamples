
window.PelsoftSite = {};
var personA = null;
var httpHost = '';

$(function () {

    httpHost = Getrootpath('');
    personA = new PelsoftSite.Person();
    personA.Name('Marcelo ');
    personA.Surname(' Oviedo');
    personA.Age(38);
    personA.BDate("01/01/1974");

    ko.applyBindings(personA);




});





(function (PelsoftSite) {
    function Person() {
        var self = this;
        self.Id = ko.observable();
        self.Name = ko.observable("");
        self.Surname = ko.observable("");
        self.Age = ko.observable(0);
        self.BDate = ko.observable("01/01/2000");

        self.FullName = ko.computed(function () {
            return self.Name() + " " + self.Surname();
        }, self);

        self.getApellido = function () {
            var currentVal = this.FullName();        // Read the current value
            self.Surname(currentVal.toUpperCase()); // Write back a modified value

        };

        self.getById = function () {
        };

    }

    PelsoftSite.Person = Person;


}(window.PelsoftSite));


function GetPerson() {
    var id = $("#txtPersonId").val();
    $.ajax(
       {
           url: httpHost + "/Home/GetPerson/?id=" + id,
           type: "GET",
           contentType: "application/json;charset=utf-8",
           //data: varDataJSON,
           success: function (result) {

               var p = ko.toJS(result);
               personA.Name(p.Name);
               personA.Surname(p.Surname);
               personA.Age(p.Age);
               personA.BDate(p.BDate);

           },
           error: ServiceFailed
       });
}

function UpdatePerson() {

    var varDataJSON = ko.toJSON(personA);
    $.ajax(
                            {
                                url: httpHost + "/api/HomeApi/update/instance",
                                type: "POST",
                                contentType: "application/json;charset=utf-8",
                                data: varDataJSON,
                                success: function (result) {
                                    alert('updated ');
                                },
                                error: ServiceFailed
                            });
}

function ServiceFailed(xhr, status, p3, p4) {
    var errObj = JSON.parse(xhr.responseText);
    errMsg = errObj.Message;
    alert(errMsg);
}