using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SiUpin.Domain.Entities;

namespace SiUpin.Application.Common.Interfaces
{
    public interface ISiUpinDBContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }

        DbSet<File> Files { get; set; }

        #region Region
        DbSet<Provinsi> Provinsis { get; set; }
        DbSet<Kota> Kotas { get; set; }
        DbSet<Kecamatan> Kecamatans { get; set; }
        DbSet<Kelurahan> Kelurahans { get; set; }
        #endregion

        #region Data Master
        DbSet<JenisTernak> JenisTernaks { get; set; }
        DbSet<JenisKomoditi> JenisKomoditis { get; set; }
        DbSet<ProdukOlahan> ProdukOlahans { get; set; }
        DbSet<Satuan> Satuans { get; set; }
        DbSet<AsalBantuan> AsalBantuans { get; set; }
        #endregion

        #region Data Paremter Cluster
        DbSet<ParameterAspek> ParameterAspeks { get; set; }
        DbSet<ParameterKriteria> ParameterKriterias { get; set; }
        DbSet<ParameterIndikator> ParameterIndikators { get; set; }
        DbSet<ParameterJawaban> ParameterJawabans { get; set; }
        #endregion

        #region Data Main
        DbSet<Uph> Uphs { get; set; }
        DbSet<UphProduk> UphProduks { get; set; }
        DbSet<UphParameter> UphParameters { get; set; }

        DbSet<Berita> Beritas { get; set; }
        DbSet<Pesan> Pesans { get; set; }
        #endregion

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        int SaveChanges();
    }
}