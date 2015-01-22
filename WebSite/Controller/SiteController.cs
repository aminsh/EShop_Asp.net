using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Model;
using WebSite.Classes.BLogic;
using Tools.Convertors;

namespace WebSite.Controller
{
    public class SiteController :BreezeBaseController
    {
        [HttpGet]
        public IQueryable<Order> Orders()
        {
            return _contextProvider.Context.Orders;
        }


        [HttpGet]
        public IQueryable<OrderDetail> OrderDetails()
        {
            return _contextProvider.Context.OrderDetails;
        }


        [HttpGet]
        public IQueryable<Product> Products()
        {
            return _contextProvider.Context.Products;
        }


        [HttpGet]
        public IQueryable<ProductCategory> ProductCategories()
        {
            return _contextProvider.Context.ProductCategories;
        }

        [HttpGet]
        [ActionName("currentBasket")]
        public Order GetBasket()
        {
            var userId = HttpContext.Current.User.Identity.Name.ToInt32();
            if (userId == 0) userId = 3;
            var currentBasket = OrderManagement.Query().FirstOrDefault(o => o.UserID == userId && o.OrderType == OrderType.Basket);

            if (currentBasket != null)
                return currentBasket;
            currentBasket = new Order()
                {
                    Date = DateTime.Now,
                    UserID = userId,
                    OrderType = OrderType.Basket
                };
            OrderManagement.Insert(currentBasket);
            return currentBasket;
        }
    }
}