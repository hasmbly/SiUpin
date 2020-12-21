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
using SiUpin.Shared.UphMitras.Queries;

namespace SiUpin.Application.UphMitras.Queries
{
    public class GetUphMitraQueryHandler : IRequestHandler<GetUphMitrasRequest, GetUphMitrasResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetUphMitraQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetUphMitrasResponse> Handle(GetUphMitrasRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var records = await _context.UphMitras
                    .AsNoTracking()
                    .Include(a => a.Uph)
                    .Where(x => x.Uph.Name.Contains(request.FilterByName ?? ""))
                    .OrderByDescending(o => o.Created)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync(cancellationToken);

                var totalRecords = _context.UphMitras.AsNoTracking().Count(x => x.Uph.Name.Contains(request.FilterByName ?? ""));

                List<UphMitrasDTO> listOfDTO = new List<UphMitrasDTO>();

                if (records.Count > 0)
                {
                    int no = 1;
                    foreach (var data in records)
                    {
                        var entity = new UphMitrasDTO
                        {
                            No = no++,
                            UphMitraID = data.UphMitraID,
                            UphID = data.UphID,
                            id_uph = data.id_uph,
                            id_mitra = data.id_mitra,
                            upload_doc = data.upload_doc,
                            status = data.status,
                            satuan_bahan = data.satuan_bahan,
                            sasaran = data.sasaran,
                            penanggungjawab = data.penanggungjawab,
                            akhir_periode = data.akhir_periode,
                            alamat = data.alamat,
                            awal_periode = data.awal_periode,
                            bermitra = data.bermitra,
                            detail_bahan = data.detail_bahan,
                            detail_fasilitasi = data.detail_fasilitasi,
                            detail_kopetensi = data.detail_kopetensi,
                            detail_mitra = data.detail_mitra,
                            detail_promosi = data.detail_promosi,
                            detail_sarana = data.detail_sarana,
                            jenis_mitra = data.jenis_mitra,
                            jenis_usaha = data.jenis_usaha,
                            lain_kopetensi = data.lain_kopetensi,
                            lembaga = data.lembaga,
                            lembaga_lain = data.lembaga_lain,
                            manajemen_limbah = data.manajemen_limbah,
                            nama_perusahaan = data.nama_perusahaan,
                            nilai_lembaga = data.nilai_lembaga,
                            nilai_mitra = data.nilai_mitra,
                            nilai_promosi = data.nilai_promosi,
                            nilai_sarana = data.nilai_sarana,
                            no_hp = data.no_hp,
                            perjanjian = data.perjanjian,

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

                return new GetUphMitrasResponse
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