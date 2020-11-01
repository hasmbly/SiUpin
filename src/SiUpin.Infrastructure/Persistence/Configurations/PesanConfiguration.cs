using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiUpin.Domain.Entities;
using SiUpin.Infrastructure.Contants;

namespace SiUpin.Infrastructure.Persistence.Configurations
{
    public class PesanConfiguration : IEntityTypeConfiguration<Pesan>
    {
        public void Configure(EntityTypeBuilder<Pesan> builder)
        {
            builder.HasKey(e => e.PesanID);
            builder.Property(e => e.PesanID).HasColumnType(SQLDataType.Varchar50).ValueGeneratedOnAdd();

            builder.Property(e => e.Name).HasColumnType(SQLDataType.Varchar50);
            builder.Property(e => e.Email).HasColumnType(SQLDataType.Varchar50);
            builder.Property(e => e.Description).HasColumnType(SQLDataType.Varchar2000);

            builder.HasIndex(e => e.PesanID);
        }
    }
}