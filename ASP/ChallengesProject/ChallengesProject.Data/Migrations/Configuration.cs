namespace ChallengesProject.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ChallengesProject.Data.ChallengesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ChallengesProject.Data.ChallengesDbContext context)
        {
            var adminRoleName = "Admin";
            var adminEmailAdress = "admin@admin.com";

            if (!context.Roles.Any(r => r.Name == adminRoleName))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var roleAdmin = new IdentityRole { Name = adminRoleName };

                manager.Create(roleAdmin);
            }

            if (!context.Users.Any(u => u.UserName == adminEmailAdress))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = adminEmailAdress, Email = adminEmailAdress };

                var identityResult = manager.Create(user, "1234");
                if (identityResult.Succeeded) {
                    manager.AddToRole(user.Id, adminRoleName);
                }
                
            }
        }
    }
}
