using Confitec.Domain.Entities;
using Confitec.Infra.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Confitec.Infra.Mapping
{
    public class SchoolingMapping : EntityTypeConfiguration<Schooling>
    {
        public override void Map(EntityTypeBuilder<Schooling> builder)
        {
            builder.Property(x => x.Id);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(20);

            builder.ToTable(nameof(Schooling));
        }
    }
}
