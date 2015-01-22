using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;
using Model;

namespace WebSite.Classes.BLogic
{
    public class ProductCategoryManagement :EntityManagement
    {
        public static void Insert(ProductCategory productCategory)
        {
            IWorkUnit workUnit= new EfWorkUnit();
            var rep = workUnit.GetRepository<ProductCategory>();
            rep.AddEntity(productCategory);
            workUnit.SaveChanges();
        }

        public static void Update(ProductCategory productCategory)
        {
            IWorkUnit workUnit= new EfWorkUnit();
            var rep = workUnit.GetRepository<ProductCategory>();
            rep.ModifyEntity(productCategory);
            workUnit.SaveChanges();
        }

        public static void Delete(Int32 id)
        {
            IWorkUnit workUnit = new EfWorkUnit();
            var rep = workUnit.GetRepository<ProductCategory>();
            var productCategory = rep.Query().FirstOrDefault(u => u.ID == id);
            rep.DeleteEntity(productCategory);
            workUnit.SaveChanges();
        }

        public static IQueryable<ProductCategory> Query()
        {
            IWorkUnit workUnit = new EfWorkUnit();
            var rep = workUnit.GetRepository<ProductCategory>();
            return rep.Query();
        }
    }
}