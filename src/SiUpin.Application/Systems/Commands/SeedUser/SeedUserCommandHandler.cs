using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.Systems.Commands.SeedUser;

namespace SiUpin.Application.Systems.Commands.SeedUser
{
    public class SeedUserCommandHandler : IRequestHandler<SeedUserRequest, SeedUserResponse>
    {
        private readonly ISiUpinDBContext _context;
        private readonly IEntityRepository _entityRepository;

        public SeedUserCommandHandler(ISiUpinDBContext context, IEntityRepository entityRepository)
        {
            _context = context;
            _entityRepository = entityRepository;
        }

        public async Task<SeedUserResponse> Handle(SeedUserRequest request, CancellationToken cancellationToken)
        {
            var result = new SeedUserResponse();

            List<Kelurahan> Kelurahans = await _context.Kelurahans.ToListAsync(cancellationToken);

            var listData = await _entityRepository.GetAllUser();

            var listkelurahanJSON = await _entityRepository.GetAllKelurahan();
            //var listRoleJSON = await _entityRepository.GetAllKelurahan(); // get all users

            // this is temporary just to make sure there is no duplicate data
            List<User> users = new List<User>();

            // collect data from db to temporary List
            var provinsi = await _context.Provinsis.AsNoTracking().ToListAsync(cancellationToken);
            var kota = await _context.Kotas.AsNoTracking().ToListAsync(cancellationToken);
            var kecamatan = await _context.Kecamatans.AsNoTracking().ToListAsync(cancellationToken);
            var kelurahan = await _context.Kelurahans.AsNoTracking().ToListAsync(cancellationToken);
            var role = await _context.Roles.AsNoTracking().ToListAsync(cancellationToken);

            var existingDatas = await _context.Users.AsNoTracking().ToListAsync(cancellationToken);

            if (listData.Count() > 0)
            {
                foreach (var data in listData)
                {
                    if (existingDatas.Any(x => x.id == data.id))
                        continue;

                    User user = new User();

                    user = users
                        .SingleOrDefault(x => x.id == data.id);

                    if (user == null)
                    {
                        var originRoleName = "";

                        if (data.level == "admin")
                        {
                            originRoleName = "ADMIN";
                        }
                        else if (data.level == "user")
                        {
                            originRoleName = "USER_PROVINSI";
                        }
                        else if (data.level == "usaha")
                        {
                            originRoleName = "USER_USAHA";
                        }
                        else if (data.level == "user_kab")
                        {
                            originRoleName = "USER_KABUPATEN";
                        }

                        var getRoleID = role.Where(x => x.Name.Contains(originRoleName)).FirstOrDefault();
                        System.Console.WriteLine($"getRoleID: {getRoleID?.RoleID} - {getRoleID?.Name}");

                        var getProvinsiID = provinsi.Where(x => x.id_provinsi == data.provinsi).FirstOrDefault();
                        var getKotaID = kota.Where(x => x.id_kota == data.kota).FirstOrDefault();
                        var getKecamatanID = kecamatan.Where(x => x.id_kecamatan == data.kecamatan).FirstOrDefault();

                        var id_kelurahan = listkelurahanJSON.Where(x => x.nama_kelurahan == data.desa).FirstOrDefault();
                        var getKelurahanID = kelurahan.Where(x => x.id_kelurahan == (id_kelurahan != null ? id_kelurahan.id_kelurahan : "")).FirstOrDefault();

                        string passwordSalt = AppUtility.CreatePasswordSalt();
                        string passwordHash = AppUtility.CreatePasswordHash(data.pass, passwordSalt);

                        System.Console.WriteLine($"INSERT - User");

                        user = new User
                        {
                            id = data.id,

                            Username = data.username,
                            Fullname = data.nama,
                            Email = data.email,
                            Alamat = data.alamat,
                            NIP = data.nip,
                            Jabatan = data.jabatan,
                            Instansi = data.instansi,
                            Telepon = data.telpon,

                            PasswordHash = passwordHash,
                            PasswordSalt = passwordSalt,

                            RoleID = getRoleID != null ? getRoleID.RoleID : null,
                            ProvinsiID = getProvinsiID != null ? getProvinsiID.ProvinsiID : null,
                            KotaID = getKotaID != null ? getKotaID.KotaID : null,
                            KecamatanID = getKecamatanID != null ? getKecamatanID.KecamatanID : null,
                            KelurahanID = getKelurahanID != null ? getKelurahanID.KelurahanID : null
                        };

                        users.Add(user);

                        _context.Users.Add(user);
                    }
                }

            }

            await _context.SaveChangesAsync(cancellationToken);

            result.IsSuccessful = true;

            return result;
        }
    }
}