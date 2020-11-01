using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiUpin.Domain.Entities;
using SiUpin.Infrastructure.Contants;

namespace SiUpin.Infrastructure.Persistence.Configurations
{
    public class SatuanConfiguration : IEntityTypeConfiguration<Satuan>
    {
        public void Configure(EntityTypeBuilder<Satuan> builder)
        {
            builder.HasKey(e => e.SatuanID);
            builder.Property(e => e.SatuanID).HasColumnType(SQLDataType.Varchar50).ValueGeneratedOnAdd();

            builder.Property(e => e.Name).HasColumnType(SQLDataType.Varchar50);

            builder.HasIndex(e => e.SatuanID);
        }
    }
}