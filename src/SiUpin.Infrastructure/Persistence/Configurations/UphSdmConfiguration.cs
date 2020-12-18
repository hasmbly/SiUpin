using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiUpin.Domain.Entities;
using SiUpin.Infrastructure.Contants;

namespace SiUpin.Infrastructure.Persistence.Configurations
{
    public class UphSdmConfiguration : IEntityTypeConfiguration<UphSdm>
    {
        public void Configure(EntityTypeBuilder<UphSdm> builder)
        {
            builder.HasKey(e => e.UphSdmID);
            builder.Property(e => e.UphSdmID).HasColumnType(SQLDataType.Varchar50).ValueGeneratedOnAdd();

            builder.Property(e => e.UphID).HasColumnType(SQLDataType.Varchar50);

            builder.HasIndex(e => e.UphID);
            builder.HasIndex(e => e.UphSdmID);

            builder.HasOne(e => e.Uph).WithMany(p => p.UphSdms).HasForeignKey(e => e.UphID).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
