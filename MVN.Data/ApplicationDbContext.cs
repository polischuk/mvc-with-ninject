using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using MWN.Data.Entities;

namespace MWN.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {
        }

        static ApplicationDbContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, ApplicationDbInitializer>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        // public DbSet<MyClass> Educations { get; set; } //Example for creating db table 
    }
}
