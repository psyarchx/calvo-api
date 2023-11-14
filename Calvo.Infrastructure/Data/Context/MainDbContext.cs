using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Calvo.Domain.Entities.General;
using System.Reflection;

namespace Calvo.Infrastructure.Data.Context
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            ModelBuilderExtensions.Seed(modelBuilder);
        }

        // DbSet
        public virtual DbSet<User> User { get; set; }
    }
}

// CREATE MIGRATION ON MAPPING CHANGE:
// dotnet-ef migrations add InitialCreate -s Calvo.API -p Calvo.Infrastructure
// RUN MIGRATIONS TO RECREATE DATABASE OR UPDATE IT WITH NEW MIGRATIONS:
// dotnet-ef database update -p Calvo.API