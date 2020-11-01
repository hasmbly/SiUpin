using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiUpin.Domain.Entities;
using SiUpin.Infrastructure.Contants;

namespace SiUpin.Infrastructure.Persistence.Configurations
{
    public class BeritaConfiguration : IEntityTypeConfiguration<Berita>
    {
        public void Configure(EntityTypeBuilder<Berita> builder)
        {
            builder.HasKey(e => e.BeritaID);
            builder.Property(e => e.BeritaID).HasColumnType(SQLDataType.Varchar50).ValueGeneratedOnAdd();

            builder.Property(e => e.Title).HasColumnType(SQLDataType.Varchar200);
            builder.Property(e => e.Description).HasColumnType(SQLDataType.Text);

            builder.HasIndex(e => e.BeritaID);
        }
    }
}