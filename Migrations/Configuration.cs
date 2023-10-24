namespace ConstosoUniversityCodeFirst1.Migrations
{
    using ConstosoUniversityCodeFirst1.Infrastructure;
    using ConstosoUniversityCodeFirst1.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ConstosoUniversityCodeFirst1.DAL;

    internal sealed class Configuration : DbMigrationsConfiguration<ConstosoUniversityCodeFirst1.DAL.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ConstosoUniversityCodeFirst1.DAL.SchoolContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var students = new List<Student>
            {
                new Student { FirstName = "Carson",   LastName = "Alexander",
                    EnrollDate = DateTime.Parse("2010-09-01") },
                new Student { FirstName = "Meredith", LastName = "Alonso",
                    EnrollDate = DateTime.Parse("2012-09-01") },
                new Student { FirstName = "Arturo",   LastName = "Anand",
                    EnrollDate = DateTime.Parse("2013-09-01") },
                new Student { FirstName = "Gytis",    LastName = "Barzdukas",
                    EnrollDate = DateTime.Parse("2012-09-01") },
            };
            students.ForEach(s => context.Student.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            // This method will be called after migrating to the latest version.

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new SchoolContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new SchoolContext()));

            var user = new ApplicationUser()
            {
                UserName = "SuperPowerUser",
                Email = "taiseer.joudeh@gmail.com",
                EmailConfirmed = true,
                FirstName = "Taiseer",
                LastName = "Joudeh",
                Level = 1,
                JoinDate = DateTime.Now.AddYears(-3)
            };

            manager.Create(user, "MySuperP@ss!");

            if (roleManager.Roles.Count() == 0)
            {
                roleManager.Create(new IdentityRole { Name = "SuperAdmin" });
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByName("SuperPowerUser");

            manager.AddToRoles(adminUser.Id, new string[] { "SuperAdmin", "Admin" });
        }
    }
}
