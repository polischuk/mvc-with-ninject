using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MWN.Data.Entities;
using MWN.Data.Managers;

namespace MWN.Data
{
    internal sealed class ApplicationDbInitializer : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public ApplicationDbInitializer()
        {
            AutomaticMigrationsEnabled = false;

        }

        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new ApplicationRoleManager(new RoleStore<IdentityRole>(context));

            const string adminRoleName = "Administrator";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = adminRoleName
                },
                new IdentityRole
                {
                    Name = "User"
                }
            };

            foreach (var identityRole in roles)
            {
                var existingRole = roleManager.FindByName(identityRole.Name);

                if (existingRole == null)
                {
                    context.Roles.Add(identityRole);
                }
            }
            base.Seed(context);
        }
    }
}
