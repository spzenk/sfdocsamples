//  Define an extendable base class. Is used for the viewmodels combined with KnockOut to be able to add 
//  new observables/computables on the viewmodel
//  Cfr: http://stackoverflow.com/questions/10299919/are-computed-observables-on-prototypes-feasible-in-knockoutjs
var extendable = function () {
    var extenders = [];

    this.extend = function (extender) {
        extenders.push(extender);
    };

    this.init = function () {
        var self = this; // capture the class that inherits off of the 'extendable' class

        if (ko) {
            ko.utils.arrayForEach(extenders, function (extender) {
                // call each extender with the correct context to ensure all
                // inheriting classes have the same functionality added by the extender
                extender.call(self);
            });
        }
    };
};

//  Helper function to track the state of viewmodels. Pass the viewmodel to track to the function,
//  it'll return a computed observable that will change to true at the first change of the viewmodel. It'll
//  stay in this state until it's reset manually.
//  cfr: http://www.knockmeout.net/2011/05/creating-smart-dirty-flag-in-knockoutjs.html
function trackDirty(root) {
    var _isDirty = ko.observable(false);

    var result = ko.computed(
        {
            read: function () {
                if (!_isDirty()) {
                    ko.toJS(root); //just for subscriptions
                }

                return _isDirty();
            },
            write: function (value) {
                _isDirty(value);
            }
        });

    result.subscribe(function () {
        if (!_isDirty()) {
            _isDirty(true);
        }
    });

    return result;
}