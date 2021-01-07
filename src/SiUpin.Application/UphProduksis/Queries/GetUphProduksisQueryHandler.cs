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
using SiUpin.Shared.UphProduksis.Common;
using SiUpin.Shared.UphProduksis.Queries;

namespace SiUpin.Application.UphProduksis.Queries
{
    public class GetUphProduksisQueryHandler : IRequestHandler<GetUphProduksisRequest, GetUphProduksisResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetUphProduksisQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetUphProduksisResponse> Handle(GetUphProduksisRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var records = await _context.UphProduksis
                    .AsNoTracking()
                    .Include(a => a.Uph)
                    .Where(x => x.Uph.Name.Contains(request.FilterByName ?? ""))
                    .OrderByDescending(o => o.Created)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync(cancellationToken);

                var totalRecords = _context.UphProduksis.AsNoTracking().Count(x => x.Uph.Name.Contains(request.FilterByName ?? ""));

                List<UphProduksiDTO> listOfDTO = new List<UphProduksiDTO>();

                if (records.Count > 0)
                {
                    int no = 1;
                    foreach (var data in records)
                    {
                        var entity = new UphProduksiDTO
                        {
                            No = no++,
                            UphProduksiID = data.UphProduksiID,
                            UphID = data.UphID,
                            id_uph = data.id_uph,
                            id_produksi = data.id_produksi,
                            nama_uph = data.nama_uph,
                            bahan_baku = data.bahan_baku,
                            gmp = data.gmp,
                            izin_edar = data.izin_edar,
                            jml_edar = data.jml_edar,
                            jml_gmp = data.jml_gmp,
                            jml_hari_produksi = data.jml_hari_produksi,
                            jml_produksi = data.jml_produksi,
                            jml_sertifikat = data.jml_sertifikat,
                            satuan = data.satuan,
                            sertifikat = data.sertifikat,

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

                return new GetUphProduksisResponse
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