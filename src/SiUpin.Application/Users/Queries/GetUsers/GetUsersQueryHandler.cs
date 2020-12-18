using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.Common.Pagination;
using SiUpin.Shared.Users.Queries.Common;
using SiUpin.Shared.Users.Queries.GetUsers;

namespace SiUpin.Application.Users.Queries.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetUsersQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            try
            {
                List<User> records;
                int totalRecords;

                if (!string.IsNullOrEmpty(request.FilterProvinsiID) || !string.IsNullOrEmpty(request.FilterKotaID) || !string.IsNullOrEmpty(request.FilterKecamatanID))
                {
                    records = await _context.Users
                        .AsNoTracking()
                        .Include(r => r.Role)
                        .Include(u => u.Provinsi)
                        .Include(u => u.Kota)
                        .Include(u => u.Kecamatan)
                        .Where(x => x.Username.Contains(request.FilterByUsernameOrEmail ?? "") || x.Email.Contains(request.FilterByUsernameOrEmail ?? "") ||
                                x.Fullname.Contains(request.FilterByUsernameOrEmail ?? "") &&
                                x.Provinsi.ProvinsiID == request.FilterProvinsiID ||
                                x.Kota.KotaID == request.FilterKotaID ||
                                x.Kecamatan.KecamatanID == request.FilterKecamatanID)
                        .OrderByDescending(o => o.Created)
                        .Skip((request.PageNumber - 1) * request.PageSize)
                        .Take(request.PageSize)
                        .ToListAsync(cancellationToken);

                    totalRecords = _context.Users
                        .AsNoTracking()
                        .Include(r => r.Role)
                        .Include(u => u.Provinsi)
                        .Include(u => u.Kota)
                        .Include(u => u.Kecamatan)
                        .Where(x => x.Username.Contains(request.FilterByUsernameOrEmail ?? "") || x.Email.Contains(request.FilterByUsernameOrEmail ?? "") ||
                                x.Fullname.Contains(request.FilterByUsernameOrEmail ?? "") &&
                                x.Provinsi.ProvinsiID == request.FilterProvinsiID ||
                                x.Kota.KotaID == request.FilterKotaID ||
                                x.Kecamatan.KecamatanID == request.FilterKecamatanID)
                        .Count();
                }
                else
                {
                    records = await _context.Users
                        .AsNoTracking()
                        .Include(r => r.Role)
                        .Include(u => u.Provinsi)
                        .Include(u => u.Kota)
                        .Include(u => u.Kecamatan)
                        .Where(x => x.Username.Contains(request.FilterByUsernameOrEmail ?? "") || x.Email.Contains(request.FilterByUsernameOrEmail ?? "") ||
                            x.Fullname.Contains(request.FilterByUsernameOrEmail ?? ""))
                        .OrderByDescending(o => o.Created)
                        .Skip((request.PageNumber - 1) * request.PageSize)
                        .Take(request.PageSize)
                        .ToListAsync(cancellationToken);

                    totalRecords = _context.Users.AsNoTracking().Count(x => x.Username.Contains(request.FilterByUsernameOrEmail ?? "") ||
                        x.Email.Contains(request.FilterByUsernameOrEmail ?? "") || x.Fullname.Contains(request.FilterByUsernameOrEmail ?? ""));
                }

                List<UserDTO> listOfDTO = new List<UserDTO>();

                int no = 1;
                foreach (var record in records)
                {
                    var dto = new UserDTO
                    {
                        No = no++,
                        UserID = record.UserID,
                        Username = record.Username,
                        Alamat = record.Alamat,
                        Email = record.Email,
                        Fullname = record.Fullname,
                        Instansi = record.Instansi,
                        Jabatan = record.Jabatan,
                        NIP = record.NIP,
                        Telepon = record.Telepon,

                        RoleID = record.Role?.RoleID,
                        RoleName = record.Role?.Name,

                        ProvinsiID = record.Provinsi?.ProvinsiID,
                        ProvinsiName = record.Provinsi?.Name,

                        KotaID = record.Kota?.KotaID,
                        KotaName = record.Kota?.Name,

                        KecamatanID = record.Kecamatan?.KecamatanID,
                        KecamatanName = record.Kecamatan?.Name,

                        KelurahanID = record.Kelurahan?.KelurahanID,
                        KelurahanName = record.Kelurahan?.Name
                    };

                    if (dto != null)
                        listOfDTO.Add(dto);
                }

                return new GetUsersResponse
                {
                    Data = listOfDTO,
                    Pagination = new PaginationResponse()
                    {
                        TotalCount = totalRecords,
                        PageSize = request.PageSize,
                        CurrentPage = request.PageNumber
                    }
                };
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}