var helper = helper || {};

$(function () {

    Array.prototype.removeAll = function () {
        while (this.length != 0) {
            this.shift();
        }
    };

    Array.prototype.count = function () {
        return this.length;
    };
});