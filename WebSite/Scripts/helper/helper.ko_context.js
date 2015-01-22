var helper = helper || {};

$(function() {

    
    ko.observableArray.fn.removeEntity = function(entity) {
        if (entity.entityAspect.entityState == "Added") {
            this.remove(entity);
            return;
        }

        entity.entityAspect.setDeleted();

        var filter = this.filter(function (item) {
            return item.entityAspect.entityState != "Deleted";
        });

        this(filter);
    };

    ko.observableArray.fn.addEntity = function (context, entityname, initialValue) {
        var newEntity = context.addEntity(entityname, initialValue);
        this.push(newEntity);
        return newEntity;
    };
    
    ko.observableArray.fn.executeQuery = function (context, query) {
        var list = this;
        context.executeQuery(query).then(function(data) {
            list(data.results);
        });
    };

    ko.observableArray.fn.executeQueryLocally = function(context, query) {
        var list = this;
        list(context.executeQueryLocally(query));
    };
});