using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiUpin.Domain.Entities;
using SiUpin.Infrastructure.Contants;

namespace SiUpin.Infrastructure.Persistence.Configurations
{
    public class KotaConfiguration : IEntityTypeConfiguration<Kota>
    {
        public void Configure(EntityTypeBuilder<Kota> builder)
        {
            builder.HasKey(e => e.KotaID);
            builder.Property(e => e.KotaID).HasColumnType(SQLDataType.Varchar50).ValueGeneratedOnAdd();

            builder.Property(e => e.id_kota).HasColumnType(SQLDataType.Varchar50);

            builder.Property(e => e.ProvinsiID).HasColumnType(SQLDataType.Varchar50);

            builder.Property(e => e.Name).HasColumnType(SQLDataType.Varchar50);

            builder.HasIndex(e => e.KotaID);
            builder.HasIndex(e => e.ProvinsiID);

            builder.HasOne(e => e.Provinsi)
                .WithMany(p => p.Kotas)
                .HasForeignKey(e => e.ProvinsiID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}