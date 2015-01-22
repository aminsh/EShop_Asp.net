using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;
using Model;

namespace WebSite.Classes.BLogic
{
    public class VoteUserManagement : EntityManagement
    {
        public static void Insert(VoteUser voteUser)
        {
            IWorkUnit workUnit = new EfWorkUnit();
            var rep = workUnit.GetRepository<VoteUser>();
            rep.AddEntity(voteUser);
            workUnit.SaveChanges();
        }

        public static void Update(VoteUser voteUser)
        {
            IWorkUnit workUnit = new EfWorkUnit();
            var rep = workUnit.GetRepository<VoteUser>();
            rep.ModifyEntity(voteUser);
            workUnit.SaveChanges();
        }

        public static void Delete(Int32 id)
        {
            IWorkUnit workUnit = new EfWorkUnit();
            var rep = workUnit.GetRepository<VoteUser>();
            var voteUser = rep.Query().FirstOrDefault(u => u.ID == id);
            rep.DeleteEntity(voteUser);
            workUnit.SaveChanges();
        }

        public static IQueryable<VoteUser> Query()
        {
            IWorkUnit workUnit = new EfWorkUnit();
            var rep = workUnit.GetRepository<VoteUser>();
            return rep.Query();
        }
    }
}