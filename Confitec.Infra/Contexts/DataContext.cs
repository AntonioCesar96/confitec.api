
using Confitec.Domain.Entities;
using Confitec.Infra.Extensions;
using Confitec.Infra.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Confitec.Infra.Contexts
{
    public class DataContext : DbContext, IDesignTimeDbContextFactory<DataContext>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Schooling> Schooling { get; set; }

        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.AddConfiguration(new UserMapping());
            modelBuilder.AddConfiguration(new SchoolingMapping());
        }

        public DataContext CreateDbContext(string[] args)
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseSqlServer(config["ConnectionStrings:dataBase"]);

            return new DataContext(builder.Options);
        }
    }
}
