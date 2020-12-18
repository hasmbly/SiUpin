using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiUpin.Domain.Entities;
using SiUpin.Infrastructure.Contants;

namespace SiUpin.Infrastructure.Persistence.Configurations
{
    public class UphProduksiConfiguration : IEntityTypeConfiguration<UphProduksi>
    {
        public void Configure(EntityTypeBuilder<UphProduksi> builder)
        {
            builder.HasKey(e => e.UphProduksiID);
            builder.Property(e => e.UphProduksiID).HasColumnType(SQLDataType.Varchar50).ValueGeneratedOnAdd();

            builder.Property(e => e.UphID).HasColumnType(SQLDataType.Varchar50);

            builder.HasIndex(e => e.UphID);
            builder.HasIndex(e => e.UphProduksiID);
        }
    }
}
