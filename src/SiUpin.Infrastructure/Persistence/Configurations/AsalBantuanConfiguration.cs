using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiUpin.Domain.Entities;
using SiUpin.Infrastructure.Contants;

namespace SiUpin.Infrastructure.Persistence.Configurations
{
    public class AsalBantuanConfiguration : IEntityTypeConfiguration<AsalBantuan>
    {
        public void Configure(EntityTypeBuilder<AsalBantuan> builder)
        {
            builder.HasKey(e => e.AsalBantuanID);
            builder.Property(e => e.AsalBantuanID).HasColumnType(SQLDataType.Varchar50).ValueGeneratedOnAdd();

            builder.Property(e => e.Name).HasColumnType(SQLDataType.Varchar50);

            builder.HasIndex(e => e.AsalBantuanID);
        }
    }
}