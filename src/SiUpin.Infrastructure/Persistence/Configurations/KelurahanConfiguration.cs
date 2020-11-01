using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiUpin.Domain.Entities;
using SiUpin.Infrastructure.Contants;

namespace SiUpin.Infrastructure.Persistence.Configurations
{
    public class KelurahanConfiguration : IEntityTypeConfiguration<Kelurahan>
    {
        public void Configure(EntityTypeBuilder<Kelurahan> builder)
        {
            builder.HasKey(e => e.KelurahanID);
            builder.Property(e => e.KelurahanID).HasColumnType(SQLDataType.Varchar50).ValueGeneratedOnAdd();

            builder.Property(e => e.id_kelurahan).HasColumnType(SQLDataType.Varchar50);

            builder.Property(e => e.KecamatanID).HasColumnType(SQLDataType.Varchar50);

            builder.Property(e => e.Name).HasColumnType(SQLDataType.Varchar50);

            builder.HasIndex(e => e.KelurahanID);
            builder.HasIndex(e => e.KecamatanID);

            builder.HasOne(e => e.Kecamatan)
                .WithMany(p => p.Kelurahans)
                .HasForeignKey(e => e.KecamatanID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}