using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiUpin.Domain.Entities;
using SiUpin.Infrastructure.Contants;

namespace SiUpin.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.UserID);
            builder.Property(e => e.UserID).HasColumnType(SQLDataType.Varchar50).ValueGeneratedOnAdd();

            builder.Property(e => e.id).HasColumnType(SQLDataType.Varchar50);

            builder.Property(e => e.RoleID).HasColumnType(SQLDataType.Varchar50);
            builder.Property(e => e.ProvinsiID).HasColumnType(SQLDataType.Varchar50);
            builder.Property(e => e.KotaID).HasColumnType(SQLDataType.Varchar50);
            builder.Property(e => e.KecamatanID).HasColumnType(SQLDataType.Varchar50);
            builder.Property(e => e.KelurahanID).HasColumnType(SQLDataType.Varchar50);

            builder.Property(e => e.Username).HasColumnType(SQLDataType.Varchar50);
            builder.Property(e => e.Fullname).HasColumnType(SQLDataType.Varchar200);
            builder.Property(e => e.Email).HasColumnType(SQLDataType.Varchar50);
            builder.Property(e => e.NIP).HasColumnType(SQLDataType.Varchar100);

            builder.Property(e => e.Jabatan).HasColumnType(SQLDataType.Varchar100);
            builder.Property(e => e.Instansi).HasColumnType(SQLDataType.Varchar100);
            builder.Property(e => e.Telepon).HasColumnType(SQLDataType.Varchar100);
            builder.Property(e => e.Alamat).HasColumnType(SQLDataType.Varchar100);

            builder.Property(e => e.PasswordHash).HasColumnType(SQLDataType.NVarchar200);
            builder.Property(e => e.PasswordSalt).HasColumnType(SQLDataType.NVarchar200);
            builder.Property(e => e.PictureURL).HasColumnType(SQLDataType.Varchar2000);

            builder.Property(e => e.CreatedBy).HasColumnType(SQLDataType.Varchar50);

            builder.HasIndex(e => e.UserID);
            builder.HasIndex(e => e.RoleID);
            builder.HasIndex(e => e.ProvinsiID);
            builder.HasIndex(e => e.KotaID);
            builder.HasIndex(e => e.KecamatanID);
            builder.HasIndex(e => e.KelurahanID);

            builder.HasOne(e => e.Role).WithMany(p => p.Users).HasForeignKey(e => e.RoleID).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.Provinsi).WithMany(p => p.Users).HasForeignKey(e => e.ProvinsiID).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.Kota).WithMany(p => p.Users).HasForeignKey(e => e.KotaID).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.Kecamatan).WithMany(p => p.Users).HasForeignKey(e => e.KecamatanID).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.Kelurahan).WithMany(p => p.Users).HasForeignKey(e => e.KelurahanID).OnDelete(DeleteBehavior.Restrict);
        }
    }
}