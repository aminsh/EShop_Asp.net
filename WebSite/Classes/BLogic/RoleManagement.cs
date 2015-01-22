using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;
using Model;

namespace WebSite.Classes.BLogic
{
    public class RoleManagement : EntityManagement
    {
        public static void Insert(Role role)
        {
            IWorkUnit workUnit = new EfWorkUnit();
            var rep = workUnit.GetRepository<Role>();
            rep.AddEntity(role);
            workUnit.SaveChanges();
        }

        public static void Update(Role role)
        {
            IWorkUnit workUnit = new EfWorkUnit();
            var rep = workUnit.GetRepository<Role>();
            rep.ModifyEntity(role);
            workUnit.SaveChanges();
        }

        public static void Delete(Int32 id)
        {
            IWorkUnit workUnit = new EfWorkUnit();
            var rep = workUnit.GetRepository<Role>();
            var role = rep.Query().FirstOrDefault(u => u.ID == id);
            rep.DeleteEntity(role);
            workUnit.SaveChanges();
        }

        public static IQueryable<Role> Query()
        {
            IWorkUnit workUnit = new EfWorkUnit();
            var rep = workUnit.GetRepository<Role>();
            return rep.Query();
        }
    }
}