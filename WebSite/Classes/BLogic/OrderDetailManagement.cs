using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;
using Model;

namespace WebSite.Classes.BLogic
{
    public class OrderDetailManagement
    {
        public static void Insert(OrderDetail orderDetail)
        {
            IWorkUnit workUnit = new EfWorkUnit();
            var rep = workUnit.GetRepository<OrderDetail>();
            rep.AddEntity(orderDetail);
            workUnit.SaveChanges();
        }

        public static void Update(OrderDetail orderDetail)
        {
            IWorkUnit workUnit = new EfWorkUnit();
            var rep = workUnit.GetRepository<OrderDetail>();
            rep.ModifyEntity(orderDetail);
            workUnit.SaveChanges();
        }

        public static void Delete(Int32 id)
        {
            IWorkUnit workUnit = new EfWorkUnit();
            var rep = workUnit.GetRepository<OrderDetail>();
            var orderDetail = rep.Query().FirstOrDefault(u => u.ID == id);
            rep.DeleteEntity(orderDetail);
            workUnit.SaveChanges();
        }

        public static IQueryable<OrderDetail> Query()
        {
            IWorkUnit workUnit = new EfWorkUnit();
            var rep = workUnit.GetRepository<OrderDetail>();
            return rep.Query();
        }
    }
}