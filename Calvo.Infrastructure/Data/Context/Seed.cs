using Microsoft.EntityFrameworkCore;
using Calvo.Domain.Entities.General;
using System;

namespace Calvo.Infrastructure.Data.Context
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().HasData(
            //    new User
            //    {
            //        Id = 1,
            //        Name = "admin",
            //        Digest = "YWRtaW4=",
            //        Email = "admin@admin.admin",
            //        BirthDate = new DateTime(1997, 1, 1),
            //        CreationDate = DateTime.Now,
            //        LastUpdated = DateTime.Now
            //    }
            //);
        }
    }
}
