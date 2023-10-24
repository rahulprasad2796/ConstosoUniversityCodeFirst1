using ConstosoUniversityCodeFirst1.Infrastructure;
using ConstosoUniversityCodeFirst1.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ConstosoUniversityCodeFirst1.DAL
{
    public class SchoolContext : IdentityDbContext<ApplicationUser>
    {
        public SchoolContext() : base("SchoolContext", throwIfV1Schema: false) {}

        public DbSet<Student> Student { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //add this when adding migration for identity
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public static SchoolContext Create()
        {
            return new SchoolContext();
        }
    }
}