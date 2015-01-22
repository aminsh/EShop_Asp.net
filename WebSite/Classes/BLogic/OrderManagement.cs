using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;
using Model;

namespace WebSite.Classes.BLogic
{
    public class OrderManagement
    {
        public static void Insert(Order order)
        {
            IWorkUnit workUnit = new EfWorkUnit();
            var rep = workUnit.GetRepository<Order>();
            rep.AddEntity(order);
            workUnit.SaveChanges();
        }

        public static void Update(Order order)
        {
            IWorkUnit workUnit = new EfWorkUnit();
            var rep = workUnit.GetRepository<Order>();
            rep.ModifyEntity(order);
            workUnit.SaveChanges();
        }

        public static void Delete(Int32 id)
        {
            IWorkUnit workUnit = new EfWorkUnit();
            var rep = workUnit.GetRepository<Order>();
            var order = rep.Query().FirstOrDefault(u => u.ID == id);
            rep.DeleteEntity(order);
            workUnit.SaveChanges();
        }

        public static IQueryable<Order> Query()
        {
            IWorkUnit workUnit = new EfWorkUnit();
            var rep = workUnit.GetRepository<Order>();
            return rep.Query();
        }
    }
}