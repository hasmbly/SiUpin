using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiUpin.Domain.Entities;
using SiUpin.Infrastructure.Contants;

namespace SiUpin.Infrastructure.Persistence.Configurations
{
    public class ProdukOlahanConfiguration : IEntityTypeConfiguration<ProdukOlahan>
    {
        public void Configure(EntityTypeBuilder<ProdukOlahan> builder)
        {
            builder.HasKey(e => e.ProdukOlahanID);
            builder.Property(e => e.ProdukOlahanID).HasColumnType(SQLDataType.Varchar50).ValueGeneratedOnAdd();

            builder.Property(e => e.id_olahan).HasColumnType(SQLDataType.Varchar50);

            builder.Property(e => e.JenisKomoditiID).HasColumnType(SQLDataType.Varchar50);

            builder.Property(e => e.Name).HasColumnType(SQLDataType.Varchar200);

            builder.HasIndex(e => e.ProdukOlahanID);
            builder.HasIndex(e => e.JenisKomoditiID);

            builder.HasOne(e => e.JenisKomoditi).WithMany(p => p.ProdukOlahans).HasForeignKey(e => e.JenisKomoditiID).OnDelete(DeleteBehavior.Restrict);
        }
    }
}