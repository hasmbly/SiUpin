using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiUpin.Domain.Entities;
using SiUpin.Infrastructure.Contants;

namespace SiUpin.Infrastructure.Persistence.Configurations
{
    public class JenisTernakConfiguration : IEntityTypeConfiguration<JenisTernak>
    {
        public void Configure(EntityTypeBuilder<JenisTernak> builder)
        {
            builder.HasKey(e => e.JenisTernakID);
            builder.Property(e => e.JenisTernakID).HasColumnType(SQLDataType.Varchar50).ValueGeneratedOnAdd();

            builder.Property(e => e.id_ternak).HasColumnType(SQLDataType.Varchar50);
            builder.Property(e => e.Name).HasColumnType(SQLDataType.Varchar50);

            builder.HasIndex(e => e.JenisTernakID);
        }
    }
}