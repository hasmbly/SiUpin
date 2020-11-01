using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiUpin.Domain.Entities;
using SiUpin.Infrastructure.Contants;

namespace SiUpin.Infrastructure.Persistence.Configurations
{
    public class FileConfiguration : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> builder)
        {
            builder.HasKey(e => e.FileID);
            builder.Property(e => e.FileID).HasColumnType(SQLDataType.Varchar50).ValueGeneratedOnAdd();

            builder.Property(e => e.EntityID).HasColumnType(SQLDataType.Varchar50);
            builder.Property(e => e.EntityType).HasColumnType(SQLDataType.Varchar10);

            builder.Property(e => e.Name).HasColumnType(SQLDataType.Varchar100);
            builder.Property(e => e.Description).HasColumnType(SQLDataType.Varchar200);

            builder.HasIndex(e => e.FileID);
            builder.HasIndex(e => e.EntityID);
        }
    }
}