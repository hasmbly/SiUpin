using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Common.Pagination;
using SiUpin.Shared.Constants;
using SiUpin.Shared.UphSaranas.Common;
using SiUpin.Shared.UphSaranas.Queries;

namespace SiUpin.Application.UphSaranas.Queries
{
    public class GetUphSaranasQueryHandler : IRequestHandler<GetUphSaranasRequest, GetUphSaranasResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetUphSaranasQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetUphSaranasResponse> Handle(GetUphSaranasRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var records = await _context.UphSaranas
                    .AsNoTracking()
                    .Include(a => a.Uph)
                    .Where(x => x.Uph.Name.Contains(request.FilterByName ?? ""))
                    .OrderByDescending(o => o.Created)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync(cancellationToken);

                var totalRecords = _context.UphSaranas.AsNoTracking().Count(x => x.Uph.Name.Contains(request.FilterByName ?? ""));

                List<UphSaranaDTO> listOfDTO = new List<UphSaranaDTO>();

                if (records.Count > 0)
                {
                    int no = 1;
                    foreach (var data in records)
                    {
                        var entity = new UphSaranaDTO
                        {
                            No = no++,
                            UphSaranaID = data.UphSaranaID,
                            UphID = data.UphID,
                            id_uph = data.id_uph,
                            id_sarana = data.id_sarana,
                            alasan = data.alasan,
                            asal_bantuan = data.asal_bantuan,
                            jenis_mesin = data.jenis_mesin,
                            kapasitas_terpakai = data.kapasitas_terpakai,
                            kapasitas_terpasang = data.kapasitas_terpasang,
                            lain = data.lain,
                            lain_alasan = data.lain_alasan,
                            nama_alat = data.nama_alat,
                            nama_uph = data.nama_uph,
                            satuan = data.satuan,
                            status = data.status,
                            tahun = data.tahun,

                            Uph = new Shared.Uphs.Common.UphDTO
                            {
                                Name = data.Uph.Name
                            }
                        };

                        if (entity != null)
                            listOfDTO.Add(entity);
                    }
                }
                else
                {
                    throw new Exception(ErrorMessage.DataNotFound);
                }

                return new GetUphSaranasResponse
                {
                    IsSuccessful = true,
                    Data = listOfDTO,
                    Pagination = new PaginationResponse()
                    {
                        TotalCount = totalRecords,
                        PageSize = request.PageSize,
                        CurrentPage = request.PageNumber
                    }
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}