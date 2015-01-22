var helper = helper || {};

$(function () {
   
    helper.datacontext = function (entityname,pluralEntityname ,observableArray) {
        var servicename = "/api/" + entityname,
            manager = new breeze.EntityManager(servicename),
            list = observableArray,
            mainList = ko.observableArray([]),
            hasChanges = ko.observable(false),
            query = function () {
                return breeze.EntityQuery.from(pluralEntityname);
            },
            executeQuery = function (query) {
                return this.manager.executeQuery(query)
                    .then(function (data) {
                        list(data.results);
                        mainList(data.results);
                    })
                    .fail(function(error) {
                        helper.note.error(error.message);
                    });
            },
            addEntity = function (value) {
                var type = manager.metadataStore.getEntityType(entityname);
                var newEntity = type.createEntity(value);
                manager.addEntity(newEntity);
                list.push(newEntity);
                return newEntity;
            },
            removeEntity = function (entity) {
                if (entity.entityAspect.entityState == "Added") {
                    list.remove(entity);
                    return;
                }

                entity.entityAspect.setDeleted();

                var filter = list.filter(function(item) {
                    return item.entityAspect.entityState != "Deleted";
                });

                list(filter);
            },
            saveChanges = function () {
                return manager.saveChanges().then(function () {
                    helper.note.successDefault();
                    hasChanges(false);
                    mainList(list);
                }).fail(function (error) {
                    helper.note.error(error.message);
                });
            },
            cancelChanges = function () {
                manager.rejectChanges();
                list(mainList());

                var filter = list.filter(function(item) {
                    return item.entityAspect.entityState != "Detached";
                });
                
                list(filter);
                helper.note.info("به درخواست کاربر عملیات لغو شد");
            }
        
        manager.hasChangesChanged.subscribe(function() {
            hasChanges(manager.hasChanges());
        });

        return {
            manager: manager,
            query: query,
            executeQuery: executeQuery,
            saveChanges: saveChanges,
            hasChanges: hasChanges,
            cancelChanges: cancelChanges,
            addEntity: addEntity,
            removeEntity: removeEntity,
            list: list,
            mainList: mainList
        };


    }
    
});