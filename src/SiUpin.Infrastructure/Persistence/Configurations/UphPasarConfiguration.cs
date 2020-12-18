using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiUpin.Domain.Entities;
using SiUpin.Infrastructure.Contants;

namespace SiUpin.Infrastructure.Persistence.Configurations
{
    public class UphPasarConfiguration : IEntityTypeConfiguration<UphPasar>
    {
        public void Configure(EntityTypeBuilder<UphPasar> builder)
        {
            builder.HasKey(e => e.UphPasarID);
            builder.Property(e => e.UphPasarID).HasColumnType(SQLDataType.Varchar50).ValueGeneratedOnAdd();

            builder.Property(e => e.UphID).HasColumnType(SQLDataType.Varchar50);

            builder.HasIndex(e => e.UphID);
            builder.HasIndex(e => e.UphPasarID);
        }
    }
}
