using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiUpin.Domain.Entities;
using SiUpin.Infrastructure.Contants;

namespace SiUpin.Infrastructure.Persistence.Configurations
{
    public class UphMitraConfiguration : IEntityTypeConfiguration<UphMitra>
    {
        public void Configure(EntityTypeBuilder<UphMitra> builder)
        {
            builder.HasKey(e => e.UphMitraID);
            builder.Property(e => e.UphMitraID).HasColumnType(SQLDataType.Varchar50).ValueGeneratedOnAdd();

            builder.Property(e => e.UphID).HasColumnType(SQLDataType.Varchar50);

            builder.HasIndex(e => e.UphID);
            builder.HasIndex(e => e.UphMitraID);

            builder.HasOne(e => e.Uph).WithMany(p => p.UphMitras).HasForeignKey(e => e.UphID).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
