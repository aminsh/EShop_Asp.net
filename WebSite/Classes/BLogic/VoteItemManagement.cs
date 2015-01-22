using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;
using Model;

namespace WebSite.Classes.BLogic
{
    public class VoteItemManagement : EntityManagement
    {
        public static void Insert(VoteItem voteItem)
        {
            IWorkUnit workUnit = new EfWorkUnit();
            var rep = workUnit.GetRepository<VoteItem>();
            rep.AddEntity(voteItem);
            workUnit.SaveChanges();
        }

        public static void Update(VoteItem voteItem)
        {
            IWorkUnit workUnit = new EfWorkUnit();
            var rep = workUnit.GetRepository<VoteItem>();
            rep.ModifyEntity(voteItem);
            workUnit.SaveChanges();
        }

        public static void Delete(Int32 id)
        {
            IWorkUnit workUnit = new EfWorkUnit();
            var rep = workUnit.GetRepository<VoteItem>();
            var voteItem = rep.Query().FirstOrDefault(u => u.ID == id);
            rep.DeleteEntity(voteItem);
            workUnit.SaveChanges();
        }

        public static IQueryable<VoteItem> Query()
        {
            IWorkUnit workUnit = new EfWorkUnit();
            var rep = workUnit.GetRepository<VoteItem>();
            return rep.Query();
        }
    }
}