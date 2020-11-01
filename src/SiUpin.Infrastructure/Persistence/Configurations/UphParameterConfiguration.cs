using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiUpin.Domain.Entities;
using SiUpin.Infrastructure.Contants;

namespace SiUpin.Infrastructure.Persistence.Configurations
{
    public class UphParameterConfiguration : IEntityTypeConfiguration<UphParameter>
    {
        public void Configure(EntityTypeBuilder<UphParameter> builder)
        {
            builder.HasKey(e => new { e.UphID, e.ParameterJawabanID });

            builder.Property(e => e.UphID).HasColumnType(SQLDataType.Varchar50);
            builder.Property(e => e.ParameterJawabanID).HasColumnType(SQLDataType.Varchar50);

            builder.Property(e => e.Description).HasColumnType(SQLDataType.Text);

            builder.HasIndex(e => e.UphID);
            builder.HasIndex(e => e.ParameterJawabanID);

            builder.HasOne(e => e.Uph).WithMany(p => p.UphParameters).HasForeignKey(e => e.UphID);
            builder.HasOne(e => e.ParameterJawaban).WithMany(p => p.UphParameters).HasForeignKey(e => e.ParameterJawabanID);
        }
    }
}