using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiUpin.Domain.Entities;
using SiUpin.Infrastructure.Contants;

namespace SiUpin.Infrastructure.Persistence.Configurations
{
    public class ParameterAspekConfiguration : IEntityTypeConfiguration<ParameterAspek>
    {
        public void Configure(EntityTypeBuilder<ParameterAspek> builder)
        {
            builder.HasKey(e => e.ParameterAspekID);
            builder.Property(e => e.ParameterAspekID).HasColumnType(SQLDataType.Varchar50).ValueGeneratedOnAdd();

            builder.Property(e => e.Name).HasColumnType(SQLDataType.Varchar50);

            builder.HasIndex(e => e.ParameterAspekID);
        }
    }
}