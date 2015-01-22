using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData;
using DataAccess;
using Model;
using Tools.Convertors;
using WebSite.Classes.BLogic;

namespace WebSite.Controller
{
    public class OrderDetailsController : EntitySetController<OrderDetail, int>
    {
        [Queryable]
        public override IQueryable<OrderDetail> Get()
        {
            var userId = HttpContext.Current.User.Identity.Name.ToInt32();
            if (userId == 0) userId = 1;
            return OrderDetailManagement.Query().Where(od => od.Order.UserID == userId && od.Order.OrderType == OrderType.Basket);
        }

        protected override OrderDetail GetEntityByKey(int key)
        {
            return OrderDetailManagement.Query().FirstOrDefault(od => od.ID == key);
        }

        protected override OrderDetail CreateEntity(OrderDetail entity)
        {
            var order = OrderManagement.Query().FirstOrDefault(o => o.OrderType == OrderType.Basket);

            if (order == null)
            {
                order = new Order()
                            {
                                Date = DateTime.Now,
                                UserID = 1,
                                OrderType = OrderType.Basket
                            };
                OrderManagement.Insert(order);
                entity.OrderID = order.ID;
                OrderDetailManagement.Insert(entity);
                return entity;
            }

            var context = new AppDbContext();

            var orderDetail =
                context.OrderDetails
                       .FirstOrDefault(od => od.OrderID == order.ID && od.ProductID == entity.ProductID);

            if (orderDetail!=null)
            {
                orderDetail.Qty += 1;
                context.SaveChanges();
            }
            else
            {
                entity.OrderID = order.ID;
                OrderDetailManagement.Insert(entity);
            }

            return entity;
        }

        protected override OrderDetail UpdateEntity(int key, OrderDetail update)
        {
            update.ID = key;
            OrderDetailManagement.Update(update);
            return update;
        }
    }
}