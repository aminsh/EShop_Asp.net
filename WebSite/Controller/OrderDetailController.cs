using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http;
using DataAccess;
using Model;
using Tools.Convertors;
using WebSite.Classes.BLogic;

namespace WebSite.Controller
{
    public class OrderDetailController :ApiController
    {
        [HttpGet]
        public IQueryable<OrderDetail> Get()
        {
            var userId = HttpContext.Current.User.Identity.Name.ToInt32();
            if (userId == 0) userId = 1;
            
            return OrderDetailManagement.Query().Where(od => od.Order.UserID == userId && od.Order.OrderType == OrderType.Basket);
        }

        [HttpPost]
        public HttpResponseMessage Insert(OrderDetail entity)
        {
            var response = Request.CreateResponse(HttpStatusCode.Created, entity);
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
                return response;
            }

            var context = new AppDbContext();

            var orderDetail =
                context.OrderDetails
                       .FirstOrDefault(od => od.OrderID == order.ID && od.ProductID == entity.ProductID);

            if (orderDetail != null)
            {
                orderDetail.Qty += 1;
                context.SaveChanges();
            }
            else
            {
                entity.OrderID = order.ID;
                OrderDetailManagement.Insert(entity);
            }

            return response;
        } 
    }
}