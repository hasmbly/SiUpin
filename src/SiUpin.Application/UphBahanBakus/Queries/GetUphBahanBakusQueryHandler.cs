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
using SiUpin.Shared.JenisKomiditis.Common.GetAllJenisKomiditi;
using SiUpin.Shared.JenisTernaks.Queries.GetJenisTernaks;
using SiUpin.Shared.Satuans.Queries.GetSatuans;
using SiUpin.Shared.UphBahanBakus.Common;
using SiUpin.Shared.UphBahanBakus.Queries;

namespace SiUpin.Application.UphBahanBakus.Queries
{
    public class GetUphBahanBakusQueryHandler : IRequestHandler<GetUphBahanBakusRequest, GetUphBahanBakusResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetUphBahanBakusQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetUphBahanBakusResponse> Handle(GetUphBahanBakusRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var records = await _context.UphBahanBakus
                    .AsNoTracking()
                    .Include(a => a.Uph)
                    .Include(b => b.JenisKomoditi)
                    .Include(c => c.JenisTernak)
                    .Include(d => d.Satuan)
                    .Where(x => x.Uph.Name.Contains(request.FilterByName ?? ""))
                    .OrderByDescending(o => o.Created)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync(cancellationToken);

                var totalRecords = _context.UphBahanBakus.AsNoTracking().Count(x => x.Uph.Name.Contains(request.FilterByName ?? ""));

                List<UphBahanBakuDTO> listOfDTO = new List<UphBahanBakuDTO>();

                if (records.Count > 0)
                {
                    int no = 1;
                    foreach (var data in records)
                    {
                        if (data != null)
                        {
                            var entity = new UphBahanBakuDTO
                            {
                                No = no++,
                                UphBahanBakuID = data.UphBahanBakuID,
                                UphID = data.UphID,
                                id_uph = data.id_uph,

                                id_bahan_baku = data.id_bahan_baku,
                                JenisKomoditiID = data.JenisKomoditiID,
                                JenisTernakID = data.JenisTernakID,
                                SatuanID = data.SatuanID,

                                TotalKebutuhan = data.TotalKebutuhan,
                                AsalBahanBaku = data.AsalBahanBaku,
                                Nilai = data.Nilai,
                                CreatedBy = data.CreatedBy,

                                Uph = new Shared.Uphs.Common.UphDTO
                                {
                                    Name = data.Uph?.Name
                                },

                                JenisKomoditi = new JenisKomoditiDTO
                                {
                                    Name = data.JenisKomoditi?.Name
                                },

                                JenisTernak = new JenisTernakDTO
                                {
                                    Name = data.JenisTernak?.Name
                                },

                                Satuan = new SatuanDTO
                                {
                                    Name = data.Satuan?.Name
                                }
                            };

                            listOfDTO.Add(entity);
                        }
                    }
                }
                else
                {
                    throw new Exception(ErrorMessage.DataNotFound);
                }

                return new GetUphBahanBakusResponse
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