namespace PeadeApp_.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using PeadeApp_.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PeadeApp_.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "PeadeApp_.Models.ApplicationDbContext";
        }

        protected override void Seed(PeadeApp_.Models.ApplicationDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            //1. Loo admin roll
            if(!context.Roles.Any(r => r.Name == "Admin"))
            {
                var role = new IdentityRole { Name = "Admin" };
                roleManager.Create(role);
            }

            //2. Loo admin kasutaja
            //var adminEmail = "admin@test.com";
            //var adminUser = userManager.FindById(adminEmail);
            //if (adminUser == null)
            //{
            //    adminUser = new ApplicationUser
            //    {
            //        UserName = adminEmail,
            //        Email = adminEmail,
            //        EmailConfirmed = true
            //    };
            //    userManager.Create(adminUser, "Admin@123");
            //}
            var adminEmail = "admin@test.com";
            var adminUser = context.Users.FirstOrDefault(u => u.Email == adminEmail);
            if (adminUser == null)
            {
                var user = new ApplicationUser { UserName = adminEmail, Email = adminEmail };
                userManager.Create(user, "Parool123!"); //Vali turvaline parool
                adminUser = user;
            }
            //3. Lisa admin kasutaja admin rolli
            if (!userManager.IsInRole(adminUser.Id, "Admin"))
            {
                userManager.AddToRole(adminUser.Id, "Admin");
            }
        }
    }
}
