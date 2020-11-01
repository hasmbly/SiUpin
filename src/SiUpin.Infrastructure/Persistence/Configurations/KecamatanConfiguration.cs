using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiUpin.Domain.Entities;
using SiUpin.Infrastructure.Contants;

namespace SiUpin.Infrastructure.Persistence.Configurations
{
    public class KecamatanConfiguration : IEntityTypeConfiguration<Kecamatan>
    {
        public void Configure(EntityTypeBuilder<Kecamatan> builder)
        {
            builder.HasKey(e => e.KecamatanID);
            builder.Property(e => e.KecamatanID).HasColumnType(SQLDataType.Varchar50).ValueGeneratedOnAdd();

            builder.Property(e => e.id_kecamatan).HasColumnType(SQLDataType.Varchar50);

            builder.Property(e => e.KotaID).HasColumnType(SQLDataType.Varchar50);

            builder.Property(e => e.Name).HasColumnType(SQLDataType.Varchar50);

            builder.HasIndex(e => e.KecamatanID);
            builder.HasIndex(e => e.KotaID);

            builder.HasOne(e => e.Kota)
                .WithMany(p => p.Kecamatans)
                .HasForeignKey(e => e.KotaID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}