using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;
using Model;

namespace WebSite.Classes.BLogic
{
    public class VoteManagement : EntityManagement
    {
        public static void Insert(Vote vote)
        {
            IWorkUnit workUnit = new EfWorkUnit();
            var rep = workUnit.GetRepository<Vote>();
            rep.AddEntity(vote);
            workUnit.SaveChanges();
        }

        public static void Update(Vote vote)
        {
            IWorkUnit workUnit = new EfWorkUnit();
            var rep = workUnit.GetRepository<Vote>();
            rep.ModifyEntity(vote);
            workUnit.SaveChanges();
        }

        public static void Delete(Int32 id)
        {
            IWorkUnit workUnit = new EfWorkUnit();
            var rep = workUnit.GetRepository<Vote>();
            var vote = rep.Query().FirstOrDefault(u => u.ID == id);
            rep.DeleteEntity(vote);
            workUnit.SaveChanges();
        }

        public static IQueryable<Vote> Query()
        {
            IWorkUnit workUnit = new EfWorkUnit();
            var rep = workUnit.GetRepository<Vote>();
            return rep.Query();
        }
    }
}