using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiUpin.Domain.Entities;
using SiUpin.Infrastructure.Contants;

namespace SiUpin.Infrastructure.Persistence.Configurations
{
    public class ParameterIndikatorConfiguration : IEntityTypeConfiguration<ParameterIndikator>
    {
        public void Configure(EntityTypeBuilder<ParameterIndikator> builder)
        {
            builder.HasKey(e => e.ParameterIndikatorID);
            builder.Property(e => e.ParameterIndikatorID).HasColumnType(SQLDataType.Varchar50).ValueGeneratedOnAdd();

            builder.Property(e => e.ParameterKriteriaID).HasColumnType(SQLDataType.Varchar50);

            builder.Property(e => e.Name).HasColumnType(SQLDataType.Varchar200);

            builder.HasIndex(e => e.ParameterIndikatorID);
            builder.HasIndex(e => e.ParameterKriteriaID);

            builder.HasOne(e => e.ParameterKriteria)
                .WithMany(p => p.ParameterIndikators)
                .HasForeignKey(e => e.ParameterKriteriaID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}