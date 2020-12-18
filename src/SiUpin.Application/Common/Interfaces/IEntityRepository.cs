using System.Collections.Generic;
using System.Threading.Tasks;
using SiUpin.Domain.OldEntities;

namespace SiUpin.Application.Common.Interfaces
{
    public interface IEntityRepository
    {
        Task<IEnumerable<Provinsi>> GetAllProvinsi();
        Task<IEnumerable<Kota>> GetAllKota();
        Task<IEnumerable<Kecamatan>> GetAllKecamatan();
        Task<IEnumerable<Kelurahan>> GetAllKelurahan();
        Task<IEnumerable<User>> GetAllUser();
        Task<IEnumerable<Uph>> GetAllUph();

        Task<IEnumerable<Sarana>> GetAllSarana();
        Task<IEnumerable<BahanBaku>> GetAllBahanBaku();
        Task<IEnumerable<Gmp>> GetAllGmp();
        Task<IEnumerable<Mitra>> GetAllMitra();
        Task<IEnumerable<Pasar>> GetAllPasar();
        Task<IEnumerable<Produksi>> GetAllProduksi();
        Task<IEnumerable<Sdm>> GetAllSdm();
    }
}
