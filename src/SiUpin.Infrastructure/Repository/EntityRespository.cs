using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.OldEntities;

namespace SiUpin.Infrastructure.Repository
{
    public class EntityRepository : BaseRepository, IEntityRepository
    {
        private readonly IDapperCommand _dapperCommand;

        public EntityRepository(IConfiguration configuration, IDapperCommand dapperCommand) : base(configuration)
        {
            _dapperCommand = dapperCommand;
        }

        public async Task<IEnumerable<Provinsi>> GetAllProvinsi()
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Provinsi>(_dapperCommand.GetAllByEntityName("provinsi"));

                return query;
            });
        }

        public async Task<IEnumerable<Kota>> GetAllKota()
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Kota>(_dapperCommand.GetAllByEntityName("kota"));

                return query;
            });
        }

        public async Task<IEnumerable<Kecamatan>> GetAllKecamatan()
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Kecamatan>(_dapperCommand.GetAllByEntityName("kecamatan"));

                return query;
            });
        }

        public async Task<IEnumerable<Kelurahan>> GetAllKelurahan()
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Kelurahan>(_dapperCommand.GetAllByEntityName("kelurahan"));

                return query;
            });
        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<User>(_dapperCommand.GetAllByEntityName("tb_user"));

                return query;
            });
        }

        public async Task<IEnumerable<Uph>> GetAllUph()
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Uph>(_dapperCommand.GetAllByEntityName("tb_uph"));

                return query;
            });
        }

        public async Task<IEnumerable<Sarana>> GetAllSarana()
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Sarana>(_dapperCommand.GetAllByEntityName("tb_sarana"));

                return query;
            });
        }

        public async Task<IEnumerable<BahanBaku>> GetAllBahanBaku()
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<BahanBaku>(_dapperCommand.GetAllByEntityName("tb_bahan_baku"));

                return query;
            });
        }

        public async Task<IEnumerable<Gmp>> GetAllGmp()
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Gmp>(_dapperCommand.GetAllByEntityName("tb_gmp"));

                return query;
            });
        }

        public async Task<IEnumerable<Mitra>> GetAllMitra()
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Mitra>(_dapperCommand.GetAllByEntityName("tb_mitra"));

                return query;
            });
        }

        public async Task<IEnumerable<Pasar>> GetAllPasar()
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Pasar>(_dapperCommand.GetAllByEntityName("tb_pasar"));

                return query;
            });
        }

        public async Task<IEnumerable<Produksi>> GetAllProduksi()
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Produksi>(_dapperCommand.GetAllByEntityName("tb_produksi"));

                return query;
            });
        }

        public async Task<IEnumerable<Sdm>> GetAllSdm()
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Sdm>(_dapperCommand.GetAllByEntityName("tb_sdm"));

                return query;
            });
        }
    }
}
