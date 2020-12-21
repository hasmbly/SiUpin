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
using SiUpin.Shared.GetUphSdmss.Queries;

namespace SiUpin.Application.UphSdms.Queries
{
    public class GetUphSdmsQueryHandler : IRequestHandler<GetUphSdmsRequest, GetUphSdmsResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetUphSdmsQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetUphSdmsResponse> Handle(GetUphSdmsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var records = await _context.UphSdms
                    .AsNoTracking()
                    .Include(a => a.Uph)
                    .Where(x => x.Uph.Name.Contains(request.FilterByName ?? ""))
                    .OrderByDescending(o => o.Created)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync(cancellationToken);

                var totalRecords = _context.UphSaranas.AsNoTracking().Count(x => x.Uph.Name.Contains(request.FilterByName ?? ""));

                List<UphSdmDTO> listOfDTO = new List<UphSdmDTO>();

                if (records.Count > 0)
                {
                    int no = 1;
                    foreach (var data in records)
                    {
                        var entity = new UphSdmDTO
                        {
                            No = no++,
                            UphSdmID = data.UphSdmID,
                            UphID = data.UphID,
                            id_uph = data.id_uph,
                            id_sdm = data.id_sdm,
                            jml_modal = data.jml_modal,
                            jml_sdm = data.jml_sdm,
                            lokasi = data.lokasi,
                            nama_pelatihan = data.nama_pelatihan,
                            nama_uph = data.nama_uph,
                            penyelenggara = data.penyelenggara,
                            sop = data.sop,
                            struktur_modal = data.struktur_modal,
                            sumber_modal = data.sumber_modal,
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

                return new GetUphSdmsResponse
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