var helper = helper || {};

$(function() {
	//observableArray
    
	//filter
	ko.observableArray.fn.filter = function (callback) {
		return ko.utils.arrayFilter(this(), callback);
	};

	//foreeach
    ko.observableArray.fn.foreach = function(callback) {
        ko.utils.arrayForEach(this(), callback);
    };

    ko.observableArray.fn.count = function() {
        return this().length;
    };
});