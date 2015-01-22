using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData;
using Model;
using WebSite.Classes.BLogic;
using WebSite.Classes;

namespace WebSite
{
    public class OrdersControllers : EntitySetController<Order, int>
    {
        [Queryable]
        public override IQueryable<Order> Get()
        {
            return base.Get();
        }
    }
}