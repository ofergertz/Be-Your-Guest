using BeMyGuest.Shared.Model.BusinessComponents.Identity;
using BeMyGuest.Shared.Model.BusinessComponents.ProfessionalClassification;
using BeMyGuest.Shared.Model.BusinessComponents.Roles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Model.BusinessComponents.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Conectivity.Context
{
    public class AppDbContext : DbContext, IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public AppDbContext()
        {
           
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserCredential>  UserCredentials { get; set; }
        //public DbSet<UserProfessionalClassification> UserProfessionalClassification { get; set; }
        public DbSet<AppRole> AppRole { get; set; }
        public DbSet<ProfessionalClassification> ProfessionalClassification { get; set; }
        //public DbSet<AppUserRoles> AppUserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var config = new ConfigurationBuilder()
                .AddJsonFile(@"C:\Repos\BeYourGuest\BeMyGuest\Server\appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

            return new AppDbContext(optionsBuilder.Options);
        }
    }  
}
