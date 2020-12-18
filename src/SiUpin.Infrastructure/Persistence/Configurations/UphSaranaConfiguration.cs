using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiUpin.Domain.Entities;
using SiUpin.Infrastructure.Contants;

namespace SiUpin.Infrastructure.Persistence.Configurations
{
    public class UphSaranaConfiguration : IEntityTypeConfiguration<UphSarana>
    {
        public void Configure(EntityTypeBuilder<UphSarana> builder)
        {
            builder.HasKey(e => e.UphSaranaID);
            builder.Property(e => e.UphSaranaID).HasColumnType(SQLDataType.Varchar50).ValueGeneratedOnAdd();

            builder.Property(e => e.UphID).HasColumnType(SQLDataType.Varchar50);

            builder.HasIndex(e => e.UphID);
            builder.HasIndex(e => e.UphSaranaID);

            builder.HasOne(e => e.Uph).WithMany(p => p.UphSaranas).HasForeignKey(e => e.UphID).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
