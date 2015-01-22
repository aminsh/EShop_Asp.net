<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true" CodeBehind="PagePayment.aspx.cs" Inherits="WebSite.Customer.PagePayment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
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
            var vm = {
                init: function () {
                    var store = vm.manager.metadataStore;
                    var orderDetail = function() {
                        this.ImageUrlThumb = ko.computed({
                            read: function () {
                                if (this.Product() == null) return '';
                                return getThumbFilename(this.Product().ImageUrl());
                            },
                            deferEvaluation: true
                        }, this),
                        this.TotalPrice = ko.computed({
                            read: function() {
                                return this.Qty() * this.UnitPrice();
                            },
                            deferEvaluation: true
                        },this)


                    };

                    store.registerEntityTypeCtor('OrderDetail', orderDetail);
                    
                  vm.manager.executeQuery(breeze.EntityQuery.from('currentBasket'))
                           .then(function (data) {
                               var orderId = data.results[0].ID;
                               vm.manager.executeQuery(breeze.EntityQuery.from('Orders').where('ID', '==', orderId).expand('User'))
                                   .then(function(data) {
                                       vm.order(data.results[0]);
                                   })
                                   .fail(function(data) {
                                       alert('error in load order ....');
                                   });
                               vm.manager.executeQuery(breeze.EntityQuery.from('OrderDetails').where('OrderID', '==', orderId).expand('Product'))
                                   .then(function (data) {
                                       vm.orderDetails(data.results);
                                   });
                           }).fail(function (data) {
                               alert('error in load currentBasket ....');
                           });
              },
              order: ko.observable(),
              orderDetails: ko.observableArray(),
              manager: new breeze.EntityManager('/breeze/Site/'),
              remove: function(item) {
                  item.entityAspect.setDeleted();
                  vm.orderDetails.remove(item);
              },
              save: function() {
                  vm.manager.saveChanges();
              },
              saveAndGoToPaymentPage: function () {
                  vm.order().OrderType('Order');
                  vm.save();
                  vm.view('success');
              },
              cancel: function() {
                  vm.manager.rejectChanges();
                  vm.orderDetails(vm.manager.executeQueryLocally(
                      breeze.EntityQuery.from('OrderDetails')
                          .where('OrderID', '==', vm.order().ID())));
              },
              emptyBasket: function() {
                  vm.orderDetails.foreach(function(item) {
                      item.entityAspect.setDeleted();
                  });
              },
              view: ko.observable('order')
            };
            
            vm.init();
            vm.total = ko.computed(function () {
                var total = 0;

                vm.orderDetails.foreach(function (item) {
                    total += item.Qty() * item.UnitPrice();
                });
                return total + ' ریال ';
            });
            ko.applyBindings(vm);

            
        });
    </script>
    
    <div data-bind="visible: view()=='order'">
        <br/>

    <a class="btn btn-success" href="#" data-bind="click: save"><i class="icon-ok icon-white"></i> ذخیره </a>
    <a class="btn btn-primary" href="#" data-bind="click: saveAndGoToPaymentPage"><i class="icon-tags icon-white"></i> ذخیره و ارسال به صفحه پرداخت </a>
    <a class="btn" href="#" data-bind="click: cancel"><i class="icon-repeat"></i> انصراف </a>

<br/>
<br/>
        <form class="form-inline">
            <fieldset data-bind="with: $root.order" >
                     <legend>صورتحساب خرید&nbsp;&nbsp;&nbsp;&nbsp; </legend>
                    <p>
                        شماره :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        تاریخ : <span data-bind="text: Date"></span>
                    </p>
                     <p>
                         نام و نام خانوادگی : <span data-bind="text: User().FirstName"></span>
                         <span data-bind="text: User().LastName"></span>
                     </p>
                     <p>
                         آدرس : <span data-bind="text: User().Address"></span>
                         <br/>
                         تلفن : <span data-bind="text: User().Phone"></span>
                     </p>
                 </fieldset>
        </form>
    <br/>
    <table class="table table-condensed table-hover table-striped"  >
        <thead>
            <tr>
                <th></th>
                <th>نام کالا</th>
                <th>تعداد</th>
                <th>قیمت واحد</th>
                <th>قیمت کل</th>
                <th></th>
            </tr>
        </thead>
        <tbody data-bind="foreach: $root.orderDetails">
            <tr>
                <td><img data-bind="attr: {src: ImageUrlThumb}" style="width: 70px;height: 70px"></td>
                <td data-bind="text: Product().Title"></td>
                <td><input type="number" data-bind="value: Qty" style="width: 100px"/></td>
                <td data-bind="text: UnitPrice"></td>
                <td data-bind="text: TotalPrice"></td>
                <td>
                    <a class="btn btn-danger" href="#" data-bind="click: $root.remove"><i class="icon-trash icon-white"></i> حذف </a>
                </td>
            </tr>
        </tbody>
        <tfoot>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td><h6 data-bind="text: $root.total"></h6></td>
            <td></td>
        </tfoot>
    </table>
    </div>
    <br/><br/>
    <div data-bind="visible: view()=='success'" align="center">
      <fieldset>
          <legend>کاربر گرامی</legend>
             از خرید شما متشکریم
        شماره پیگیری : 4572325
      </fieldset>
    </div>
</asp:Content>
