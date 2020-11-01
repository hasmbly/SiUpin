using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiUpin.Domain.Entities;
using SiUpin.Infrastructure.Contants;

namespace SiUpin.Infrastructure.Persistence.Configurations
{
    public class ProvinsiConfiguration : IEntityTypeConfiguration<Provinsi>
    {
        public void Configure(EntityTypeBuilder<Provinsi> builder)
        {
            builder.HasKey(e => e.ProvinsiID);
            builder.Property(e => e.ProvinsiID).HasColumnType(SQLDataType.Varchar50).ValueGeneratedOnAdd();

            builder.Property(e => e.id_provinsi).HasColumnType(SQLDataType.Varchar50);

            builder.Property(e => e.Name).HasColumnType(SQLDataType.Varchar50);

            builder.HasIndex(e => e.ProvinsiID);
        }
    }
}