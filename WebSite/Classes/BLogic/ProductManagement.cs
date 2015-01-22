using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;
using Model;

namespace WebSite.Classes.BLogic
{
    public class ProductManagement :EntityManagement
    {
        public static void Insert(Product product)
        {
            IWorkUnit workUnit= new EfWorkUnit();
            var rep = workUnit.GetRepository<Product>();
            rep.AddEntity(product);
            workUnit.SaveChanges();
        }

        public static void Update(Product product)
        {
            IWorkUnit workUnit= new EfWorkUnit();
            var rep = workUnit.GetRepository<Product>();
            rep.ModifyEntity(product);
            workUnit.SaveChanges();
        }

        public static void Delete(Int32 id)
        {
            IWorkUnit workUnit = new EfWorkUnit();
            var rep = workUnit.GetRepository<Product>();
            var product = rep.Query().FirstOrDefault(u => u.ID == id);
            rep.DeleteEntity(product);
            workUnit.SaveChanges();
        }

        public static IQueryable<Product> Query()
        {
            IWorkUnit workUnit = new EfWorkUnit();
            var rep = workUnit.GetRepository<Product>();
            return rep.Query();
        }
    }
}