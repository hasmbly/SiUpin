using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiUpin.Domain.Entities;
using SiUpin.Infrastructure.Contants;

namespace SiUpin.Infrastructure.Persistence.Configurations
{
    public class UphGmpConfiguration : IEntityTypeConfiguration<UphGmp>
    {
        public void Configure(EntityTypeBuilder<UphGmp> builder)
        {
            builder.HasKey(e => e.UphGmpID);
            builder.Property(e => e.UphGmpID).HasColumnType(SQLDataType.Varchar50).ValueGeneratedOnAdd();

            builder.Property(e => e.UphID).HasColumnType(SQLDataType.Varchar50);

            builder.HasIndex(e => e.UphID);
            builder.HasIndex(e => e.UphGmpID);

            builder.HasOne(e => e.Uph).WithMany(p => p.UphGmps).HasForeignKey(e => e.UphID).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
