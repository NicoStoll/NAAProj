
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NAAProject.Data.Models.Domain;

namespace NAAProject.Data.Models.Repository
{
    public class NAAContext : DbContext
    {
        public NAAContext() { }

        public DbSet<User>  Users { get; set; }
        public DbSet<University> Universities { get; set;}
        public DbSet<Application> Applications { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionsString = configuration
                    .GetConnectionString("NAAContext");
                optionsBuilder.UseSqlServer(connectionsString);
                base.OnConfiguring(optionsBuilder);
            }
        }

    }
}
