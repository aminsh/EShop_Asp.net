using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData;
using Model;
using WebSite.Classes.BLogic;
using WebSite.Classes;

namespace WebSite.Controller
{
    public class OrdersController : EntitySetController<Order, int>
    {
        [Queryable]
        public override IQueryable<Order> Get()
        {
            return OrderManagement.Query();
        }

        protected override Order GetEntityByKey(int key)
        {
            return OrderManagement.Query().FirstOrDefault(o => o.ID == key);
        }

        [Queryable] // odata/Orders(6)/OrderDetails
        public IQueryable<OrderDetail> GetOrderDetailsFromOrder([FromODataUri]int key)
        {
            var order = OrderManagement.Query().FirstOrDefault(o => o.ID == key);
            return order != null ? order.OrderDetails.AsQueryable() : null;
        }

        protected override Order CreateEntity(Order entity)
        {
            OrderManagement.Insert(entity);
            return entity;
        }

        protected override Order UpdateEntity(int key, Order update)
        {
            update.ID = key;
            OrderManagement.Update(update);
            return update;
        }
    }
}