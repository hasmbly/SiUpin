using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiUpin.Domain.Entities;
using SiUpin.Infrastructure.Contants;

namespace SiUpin.Infrastructure.Persistence.Configurations
{
    public class ParameterKriteriaConfiguration : IEntityTypeConfiguration<ParameterKriteria>
    {
        public void Configure(EntityTypeBuilder<ParameterKriteria> builder)
        {
            builder.HasKey(e => e.ParameterKriteriaID);
            builder.Property(e => e.ParameterKriteriaID).HasColumnType(SQLDataType.Varchar50).ValueGeneratedOnAdd();

            builder.Property(e => e.ParameterAspekID).HasColumnType(SQLDataType.Varchar50);

            builder.Property(e => e.Name).HasColumnType(SQLDataType.Varchar100);

            builder.HasIndex(e => e.ParameterKriteriaID);
            builder.HasIndex(e => e.ParameterAspekID);

            builder.HasOne(e => e.ParameterAspek)
                .WithMany(p => p.ParameterKriterias)
                .HasForeignKey(e => e.ParameterAspekID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}