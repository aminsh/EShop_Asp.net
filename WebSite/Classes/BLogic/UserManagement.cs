using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;
using Model;

namespace WebSite.Classes.BLogic
{
    public class UserManagement : EntityManagement
    {
        public static void Insert(User user)
        {
            IWorkUnit workUnit = new EfWorkUnit();
            var rep = workUnit.GetRepository<User>();
            rep.AddEntity(user);
            workUnit.SaveChanges();
        }

        public static void Update(User user)
        {
            IWorkUnit workUnit = new EfWorkUnit();
            var rep = workUnit.GetRepository<User>();
            rep.ModifyEntity(user);
            workUnit.SaveChanges();
        }

        public static void Delete(Int32 id)
        {
            IWorkUnit workUnit = new EfWorkUnit();
            var rep = workUnit.GetRepository<User>();
            var user = rep.Query().FirstOrDefault(u => u.ID == id);
            rep.DeleteEntity(user);
            workUnit.SaveChanges();
        }

        public static IQueryable<User> Query()
        {
            IWorkUnit workUnit = new EfWorkUnit();
            var rep = workUnit.GetRepository<User>();
            return rep.Query();
        }
    }
}