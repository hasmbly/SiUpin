using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Common;
using SiUpin.Domain.Entities;

namespace SiUpin.Infrastructure.Persistence
{
    public class SiUpinDBContext : DbContext, ISiUpinDBContext
    {
        private readonly IDateTimeOffsetService _dateTimeOffset;

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<File> Files { get; set; }

        #region Regions
        public DbSet<Provinsi> Provinsis { get; set; }
        public DbSet<Kota> Kotas { get; set; }
        public DbSet<Kecamatan> Kecamatans { get; set; }
        public DbSet<Kelurahan> Kelurahans { get; set; }
        #endregion

        #region Data Master
        public DbSet<JenisTernak> JenisTernaks { get; set; }
        public DbSet<JenisKomoditi> JenisKomoditis { get; set; }
        public DbSet<ProdukOlahan> ProdukOlahans { get; set; }
        public DbSet<Satuan> Satuans { get; set; }
        public DbSet<AsalBantuan> AsalBantuans { get; set; }
        #endregion

        #region Data Paramter Cluster
        public DbSet<ParameterAspek> ParameterAspeks { get; set; }
        public DbSet<ParameterKriteria> ParameterKriterias { get; set; }
        public DbSet<ParameterIndikator> ParameterIndikators { get; set; }
        public DbSet<ParameterJawaban> ParameterJawabans { get; set; }
        #endregion

        #region Data Main
        public DbSet<Uph> Uphs { get; set; }
        public DbSet<UphBahanBaku> UphBahanBakus { get; set; }
        public DbSet<UphProduk> UphProduks { get; set; }

        public DbSet<UphGmp> UphGmps { get; set; }
        public DbSet<UphMitra> UphMitras { get; set; }
        public DbSet<UphPasar> UphPasars { get; set; }
        public DbSet<UphProduksi> UphProduksis { get; set; }
        public DbSet<UphSarana> UphSaranas { get; set; }
        public DbSet<UphSdm> UphSdms { get; set; }
        //public DbSet<UphParameter> UphParameters { get; set; }

        public DbSet<Berita> Beritas { get; set; }
        public DbSet<Pesan> Pesans { get; set; }
        #endregion

        public SiUpinDBContext(DbContextOptions<SiUpinDBContext> options) : base(options)
        {
        }

        public SiUpinDBContext(DbContextOptions<SiUpinDBContext> options, IDateTimeOffsetService dateTimeOffset) : base(options)
        {
            _dateTimeOffset = dateTimeOffset;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTimeOffset.Now;
                        entry.Entity.LastModified = _dateTimeOffset.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTimeOffset.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTimeOffset.Now;
                        entry.Entity.LastModified = _dateTimeOffset.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTimeOffset.Now;
                        break;
                }
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SiUpinDBContext).Assembly);
        }
    }
}