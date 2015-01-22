using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        static AppDbContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDbContext, MigrationManager<AppDbContext>>());
            //Database.SetInitializer(new AppContextInitializer());
        }

        public AppDbContext()
            : base("dbConnectionString")
        {

        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<VoteItem> VoteItems { get; set; }
        public DbSet<VoteUser> VoteUsers { get; set; }
        
       
    }

    public class MigrationManager<TDbContext> : DbMigrationsConfiguration<TDbContext>
    where TDbContext : DbContext
    {
        public MigrationManager()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }

    //public class AppContextInitializer :
    //             DropCreateDatabaseIfModelChanges<AppDbContext>
    //{
    //    protected override void Seed(AppDbContext context)
    //    {
    //        var role = new Role()
    //                       {
    //                           Name = "Admin",
    //                           Title = "مدیر سایت"
    //                       };
     
    //        context.Roles.Add(role);

    //        var user = new User()
    //                       {
    //                           FirstName = "امین",
    //                           LastName = "شیخی",
    //                           Username = "amin",
    //                           Password = "123",
    //                           RoleID = role.ID
    //                       };

    //        context.Users.Add(user);
           
    //        context.SaveChanges();
    //    }
    //}
}
