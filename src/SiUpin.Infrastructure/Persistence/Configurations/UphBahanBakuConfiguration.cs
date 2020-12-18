using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiUpin.Domain.Entities;
using SiUpin.Infrastructure.Contants;

namespace SiUpin.Infrastructure.Persistence.Configurations
{
    public class UphBahanBakuConfiguration : IEntityTypeConfiguration<UphBahanBaku>
    {
        public void Configure(EntityTypeBuilder<UphBahanBaku> builder)
        {
            builder.HasKey(e => e.UphBahanBakuID);
            builder.Property(e => e.UphBahanBakuID).HasColumnType(SQLDataType.Varchar50).ValueGeneratedOnAdd();

            builder.Property(e => e.UphID).HasColumnType(SQLDataType.Varchar50);
            builder.Property(e => e.JenisTernakID).HasColumnType(SQLDataType.Varchar50);
            builder.Property(e => e.JenisKomoditiID).HasColumnType(SQLDataType.Varchar50);
            builder.Property(e => e.SatuanID).HasColumnType(SQLDataType.Varchar50);

            builder.Property(e => e.TotalKebutuhan).HasColumnType(SQLDataType.Varchar255);
            builder.Property(e => e.AsalBahanBaku).HasColumnType(SQLDataType.Varchar255);
            builder.Property(e => e.Nilai).HasColumnType(SQLDataType.Varchar255);

            builder.HasIndex(e => e.UphBahanBakuID);

            builder.HasIndex(e => e.UphID);
            builder.HasIndex(e => e.JenisTernakID);
            builder.HasIndex(e => e.JenisKomoditiID);
            builder.HasIndex(e => e.SatuanID);

            builder.HasOne(e => e.Uph).WithMany(p => p.UphBahanBakus).HasForeignKey(e => e.UphID).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.JenisTernak).WithMany(p => p.UphBahanBakus).HasForeignKey(e => e.JenisTernakID).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.JenisKomoditi).WithMany(p => p.UphBahanBakus).HasForeignKey(e => e.JenisKomoditiID).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.Satuan).WithMany(p => p.UphBahanBakus).HasForeignKey(e => e.SatuanID).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
