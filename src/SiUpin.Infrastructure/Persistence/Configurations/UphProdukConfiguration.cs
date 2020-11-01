using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiUpin.Domain.Entities;
using SiUpin.Infrastructure.Contants;

namespace SiUpin.Infrastructure.Persistence.Configurations
{
    public class UphProdukConfiguration : IEntityTypeConfiguration<UphProduk>
    {
        public void Configure(EntityTypeBuilder<UphProduk> builder)
        {
            builder.HasKey(e => e.UphProdukID);
            builder.Property(e => e.UphProdukID).HasColumnType(SQLDataType.Varchar50).ValueGeneratedOnAdd();

            builder.Property(e => e.UphID).HasColumnType(SQLDataType.Varchar50);
            builder.Property(e => e.ProdukOlahanID).HasColumnType(SQLDataType.Varchar50);
            builder.Property(e => e.JenisTernakID).HasColumnType(SQLDataType.Varchar50);
            builder.Property(e => e.SatuanID).HasColumnType(SQLDataType.Varchar50);

            builder.Property(e => e.Name).HasColumnType(SQLDataType.Varchar100);
            builder.Property(e => e.Harga).HasColumnType(SQLDataType.Varchar50);
            builder.Property(e => e.Berat).HasColumnType(SQLDataType.Int5);
            builder.Property(e => e.Description).HasColumnType(SQLDataType.Text);

            builder.HasIndex(e => e.UphProdukID);

            builder.HasIndex(e => e.UphID);
            builder.HasIndex(e => e.ProdukOlahanID);
            builder.HasIndex(e => e.JenisTernakID);
            builder.HasIndex(e => e.SatuanID);

            builder.HasOne(e => e.Uph).WithMany(p => p.UphProduks).HasForeignKey(e => e.UphID);
            builder.HasOne(e => e.ProdukOlahan).WithMany(p => p.UphProduks).HasForeignKey(e => e.ProdukOlahanID);
            builder.HasOne(e => e.JenisTernak).WithMany(p => p.UphProduks).HasForeignKey(e => e.JenisTernakID);
            builder.HasOne(e => e.Satuan).WithMany(p => p.UphProduks).HasForeignKey(e => e.SatuanID);
        }
    }
}