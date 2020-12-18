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
using SiUpin.Shared.UphPasars.Queries;

namespace SiUpin.Application.UphPasars.Queries
{
    public class GetUphPasarsQueryHandler : IRequestHandler<GetUphPasarsRequest, GetUphPasarsResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetUphPasarsQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetUphPasarsResponse> Handle(GetUphPasarsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var records = await _context.UphPasars
                    .AsNoTracking()
                    .Include(a => a.Uph)
                    .Where(x => x.nama_uph.Contains(request.FilterByName ?? ""))
                    .OrderByDescending(o => o.Created)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync(cancellationToken);

                var totalRecords = _context.UphPasars.AsNoTracking().Count(x => x.nama_uph.Contains(request.FilterByName ?? ""));

                List<UphPasarDTO> listOfDTO = new List<UphPasarDTO>();

                if (records.Count > 0)
                {
                    int no = 1;
                    foreach (var data in records)
                    {
                        var entity = new UphPasarDTO
                        {
                            No = no++,
                            UphID = data.UphID,
                            UphPasarID = data.UphPasarID,
                            id_uph = data.id_uph,
                            id_pasar = data.id_pasar,
                            jangkauan = data.jangkauan,
                            jml_penjualan = data.jml_penjualan,
                            lain = data.lain,
                            mekanisme = data.mekanisme,
                            nama_uph = data.nama_uph,
                            nilai_mekanisme = data.nilai_mekanisme,
                            omset = data.omset,

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

                return new GetUphPasarsResponse
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