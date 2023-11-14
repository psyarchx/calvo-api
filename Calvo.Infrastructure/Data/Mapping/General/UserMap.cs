using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calvo.Domain.Entities.General;

namespace Calvo.Infrastructure.Data.Mapping.General
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.CreationDate);
            builder
                .Property(x => x.LastUpdated);

            builder
                .Property(x => x.Name);
            builder
                .Property(x => x.Digest);
            builder
                .Property(x => x.Email);
            builder
                .Property(x => x.BirthDate);
        }
    }
}
