using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiUpin.Domain.Entities;
using SiUpin.Infrastructure.Contants;
namespace SiUpin.Infrastructure.Persistence.Configurations
{
    public class JenisKomoditiConfiguration : IEntityTypeConfiguration<JenisKomoditi>
    {
        public void Configure(EntityTypeBuilder<JenisKomoditi> builder)
        {
            builder.HasKey(e => e.JenisKomoditiID);
            builder.Property(e => e.JenisKomoditiID).HasColumnType(SQLDataType.Varchar50).ValueGeneratedOnAdd();

            builder.Property(e => e.id_komoditi).HasColumnType(SQLDataType.Varchar50);
            builder.Property(e => e.Name).HasColumnType(SQLDataType.Varchar50);

            builder.HasIndex(e => e.JenisKomoditiID);
        }
    }
}