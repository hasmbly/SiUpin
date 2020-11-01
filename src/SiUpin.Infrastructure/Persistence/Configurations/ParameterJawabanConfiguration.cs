using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiUpin.Domain.Entities;
using SiUpin.Infrastructure.Contants;

namespace SiUpin.Infrastructure.Persistence.Configurations
{
    public class ParameterJawabanConfiguration : IEntityTypeConfiguration<ParameterJawaban>
    {
        public void Configure(EntityTypeBuilder<ParameterJawaban> builder)
        {
            builder.HasKey(e => e.ParameterJawabanID);
            builder.Property(e => e.ParameterJawabanID).HasColumnType(SQLDataType.Varchar50).ValueGeneratedOnAdd();

            builder.Property(e => e.ParameterIndikatorID).HasColumnType(SQLDataType.Varchar50);

            builder.Property(e => e.Name).HasColumnType(SQLDataType.Varchar200);
            builder.Property(e => e.Skor).HasColumnType(SQLDataType.Char5);

            builder.HasIndex(e => e.ParameterJawabanID);
            builder.HasIndex(e => e.ParameterIndikatorID);

            builder.HasOne(e => e.ParameterIndikator)
                .WithMany(p => p.ParameterJawabans)
                .HasForeignKey(e => e.ParameterIndikatorID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}