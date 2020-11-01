using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiUpin.Domain.Entities;
using SiUpin.Infrastructure.Contants;

namespace SiUpin.Infrastructure.Persistence.Configurations
{
    public class UphConfiguration : IEntityTypeConfiguration<Uph>
    {
        public void Configure(EntityTypeBuilder<Uph> builder)
        {
            builder.HasKey(e => e.UphID);
            builder.Property(e => e.UphID).HasColumnType(SQLDataType.Varchar50).ValueGeneratedOnAdd();

            builder.Property(e => e.ProvinsiID).HasColumnType(SQLDataType.Varchar50);
            builder.Property(e => e.KotaID).HasColumnType(SQLDataType.Varchar50);
            builder.Property(e => e.KecamatanID).HasColumnType(SQLDataType.Varchar50);
            builder.Property(e => e.KelurahanID).HasColumnType(SQLDataType.Varchar50);

            builder.Property(e => e.Name).HasColumnType(SQLDataType.Varchar100);
            builder.Property(e => e.Ketua).HasColumnType(SQLDataType.Varchar50);
            builder.Property(e => e.Handphone).HasColumnType(SQLDataType.Varchar50);
            builder.Property(e => e.Alamat).HasColumnType(SQLDataType.Varchar200);
            builder.Property(e => e.TahunBerdiri).HasColumnType(SQLDataType.Char5);

            builder.HasIndex(e => e.UphID);
            builder.HasIndex(e => e.ProvinsiID);
            builder.HasIndex(e => e.KotaID);
            builder.HasIndex(e => e.KecamatanID);
            builder.HasIndex(e => e.KelurahanID);

            builder.HasOne(e => e.Provinsi).WithMany(p => p.Uphs).HasForeignKey(e => e.ProvinsiID).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.Kota).WithMany(p => p.Uphs).HasForeignKey(e => e.KotaID).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.Kecamatan).WithMany(p => p.Uphs).HasForeignKey(e => e.KecamatanID).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.Kelurahan).WithMany(p => p.Uphs).HasForeignKey(e => e.KelurahanID).OnDelete(DeleteBehavior.Restrict);
        }
    }
}