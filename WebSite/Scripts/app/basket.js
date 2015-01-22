$(function () {
    var getThumbFilename = function (filename) {
        if (filename == undefined)
            return '';

        if (filename == '')
            return '';

        var dot = filename.lastIndexOf(".");
        if (dot == -1)
            return "";

        var extension = filename.substr(dot, filename.length);


        filename = filename.replace(extension, "");
        filename = filename.replace("~", "");

        return filename + "_Thumb" + extension;
    };

    var getFilename = function (filename) {
        if (filename == undefined)
            return '';

        if (filename == '')
            return '';

        filename = filename.replace("~", "");

        return filename;
    };

    var productCategory = function () {

        this.ID = ko.observable();
        this.Title = ko.observable();
        this.ImageUrl = ko.observable();
        this.ImageUrlThumb = ko.computed(function () {
            return getThumbFilename(this.ImageUrl());
        }, this);
    };

    var product = function () {
        this.ID = ko.observable();
        this.Title = ko.observable();
        this.ImageUrl = ko.observable();
        this.ImageUrlThumb = ko.computed(function () {
            return getThumbFilename(this.ImageUrl());
        }, this);
        this.Price = ko.observable();

    };

    var vm = {
        init: function () {
            var store = vm.manager.metadataStore;


            var orderDetail = function () {
                this.ImageUrlThumb = ko.computed({
                    read: function () {
                        if (this.Product() == null) return '';
                        return getThumbFilename(this.Product().ImageUrl());
                    },
                    deferEvaluation: true
                }, this),
                this.TotalPrice = ko.computed({
                    read: function () {
                        return this.Qty() * this.UnitPrice();
                    },
                    deferEvaluation: true
                }, this)


            };

            store.registerEntityTypeCtor('OrderDetail', orderDetail);

            vm.manager.executeQuery(breeze.EntityQuery.from('currentBasket'))
                .then(function (data) {
                    var orderId = data.results[0].ID;
                    vm.currentBasketId(orderId);
                    vm.manager.executeQuery(breeze.EntityQuery.from('OrderDetails').where('OrderID', '==', orderId).expand('Product'))
                        .then(function (data) {
                            vm.basket(data.results);
                        })
                        .fail(function (data) {
                            alert('fail to load basket');
                        });
                })
                .fail(function (data) {
                    alert('fail to load current basket');
                });


            var q = breeze.EntityQuery.from('ProductCategories');
            vm.manager.executeQuery(q)
                .then(function (data) {
                    $.each(data.results, function (i, p) {
                        vm.productCategories.push(new productCategory().ID(p.ID).Title(p.Title).ImageUrl(getFilename(p.ImageUrl())));
                    });
                })
                .fail(function () {
                    alert('fail....');
                });

            //vm.manager.executeQuery(breeze.EntityQuery.from('ProductCategories'))
            //               .then(function (data) {
            //                   vm.productCategories(data.results);
            //               })
            //               .fail(function (data) {
            //                   alert('fail to load product category');
            //               });

        },
        manager: new breeze.EntityManager('/breeze/Site/'),
        productCategories: ko.observableArray(),
        currentBasketId: ko.observable(),
        products: ko.observableArray([]),
        basket: ko.observableArray([]),
        selectedProductCategoryId: ko.observable(),
        loadProduct: function () {
            vm.products.removeAll();

            var q = breeze.EntityQuery.from('Products');
            q = q.where('ProductCategoryID', '==', vm.selectedProductCategoryId());

            vm.manager.executeQuery(q)
               .then(function (data) {
                   $.each(data.results, function (i, p) {
                       vm.products.push(new product().ID(p.ID()).Title(p.Title()).ImageUrl(getFilename(p.ImageUrl())).Price(p.Price()));
                   });
               })
               .fail(function () {
                   alert('fail....');
               });
        },
        addToBasket: function (item) {
            var entity = { ID: 0, OrderID: vm.currentBasketId(), ProductID: item.ID(), UnitPrice: item.Price(), Qty: 1 };

            if (vm.basket().length == 0) {
                add(entity);
                return;
            }

            var added = false;
            vm.basket.foreach(function (p) {
                if (p.ProductID() == item.ID()) {
                    p.Qty(p.Qty() + 1);
                    vm.manager.saveChanges();
                    added = true;
                }
            });

            if (added == false)
                add(entity);

            function add(param) {
                var type = vm.manager.metadataStore.getEntityType('OrderDetail');
                var newEntity = type.createEntity(param);
                vm.manager.addEntity(newEntity);

                vm.manager.saveChanges()
                .then(function () {
                    vm.basket.push(newEntity);
                    return;
                })
                .fail(function () {

                });
            }
        },
        removeFromBasket: function (item) {
            item.entityAspect.setDeleted();
            vm.manager.saveChanges()
                .then(function () {
                    vm.basket.remove(item);
                });
        },
        emptyBasket: function () {
            vm.basket.foreach(function (item) {
                item.entityAspect.setDeleted();
            });
            vm.manager.saveChanges();
            vm.basket.removeAll();
        },
        tmp: '<img src=\"${ImageUrlThumb}\" alt=\"${ID}\" /><h3>${ Title }</h3>'
    };

    vm.total = ko.computed(function () {
        var total = 0;

        vm.basket.foreach(function (item) {
            total += item.Qty() * item.UnitPrice();
        });
        return total;
    });
    vm.init();
    ko.applyBindings(vm);

    vm.selectedProductCategoryId.subscribe(function () {
        vm.loadProduct();
    });

});
