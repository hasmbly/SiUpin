using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.Systems.Commands.SeedKelurahan;
using SiUpin.Shared.Systems.Commands.SeedUser;

namespace SiUpin.Application.Systems.Commands.SeedUser
{
    public class SeedUserCommandHandler : IRequestHandler<SeedUserRequest, SeedUserResponse>
    {
        private readonly ISiUpinDBContext _context;
        private readonly IFileService _fileService;

        public SeedUserCommandHandler(ISiUpinDBContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<SeedUserResponse> Handle(SeedUserRequest request, CancellationToken cancellationToken)
        {
            var result = new SeedUserResponse();

            var dataJSON = _fileService.ReadJSONFile<UserJSON>(FilePath.UserJSON);
            var kelurahanJSON = _fileService.ReadJSONFile<KelurahanJSON>(FilePath.KelurahanJSON);

            var listDataJSON = dataJSON.rows.ToList();
            var listkelurahanJSON = kelurahanJSON.rows.ToList();

            // this is temporary just to make sure there is no duplicate data
            List<User> users = new List<User>();

            // collect data from db to temporary List
            var provinsi = await _context.Provinsis.ToListAsync(cancellationToken);
            var kota = await _context.Kotas.ToListAsync(cancellationToken);
            var kecamatan = await _context.Kecamatans.ToListAsync(cancellationToken);
            var kelurahan = await _context.Kelurahans.ToListAsync(cancellationToken);
            var role = await _context.Roles.ToListAsync(cancellationToken);

            foreach (var data in listDataJSON)
            {
                User user = new User();

                user = users
                    .SingleOrDefault(x => x.id == data.id);

                if (user == null)
                {
                    string roleID = role.Where(x => x.Name.Contains(data.level)).FirstOrDefault().RoleID ?? "";

                    var getProvinsiID = provinsi.Where(x => x.id_provinsi == data.provinsi).FirstOrDefault();
                    var getKotaID = kota.Where(x => x.id_kota == data.kota).FirstOrDefault();
                    var getKecamatanID = kecamatan.Where(x => x.id_kecamatan == data.kecamatan).FirstOrDefault();

                    var id_kelurahan = listkelurahanJSON.Where(x => x.nama_kelurahan == data.desa).FirstOrDefault();
                    var getKelurahanID = kelurahan.Where(x => x.id_kelurahan == (id_kelurahan != null ? id_kelurahan.id_kelurahan : "")).FirstOrDefault();

                    string passwordSalt = AppUtility.CreatePasswordSalt();
                    string passwordHash = AppUtility.CreatePasswordHash(data.pass, passwordSalt);

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

                        RoleID = roleID,
                        ProvinsiID = getProvinsiID != null ? getProvinsiID.ProvinsiID : null,
                        KotaID = getKotaID != null ? getKotaID.KotaID : null,
                        KecamatanID = getKecamatanID != null ? getKecamatanID.KecamatanID : null,
                        KelurahanID = getKelurahanID != null ? getKelurahanID.KelurahanID : null
                    };

                    users.Add(user);

                    _context.Users.Add(user);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            result.IsSuccessful = true;

            return result;
        }
    }
}