using Confitec.Domain.Entities;
using Confitec.Infra.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Confitec.Infra.Mapping
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public override void Map(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(120);

            builder.Property(x => x.LastName)
                .HasMaxLength(120);

            builder.Property(s => s.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.BirthDate)
                .IsRequired();

            builder.Property(s => s.SchoolingId)
                .IsRequired();

            builder.HasOne(s => s.Schooling)
                .WithMany()
                .HasForeignKey(s => s.SchoolingId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(nameof(User));
        }
    }
}
