using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Constants;
using SiUpin.Shared.UphMitras.Queries;

namespace SiUpin.Application.UphMitras.Queries
{
    public class GetUphMitraQueryHandler : IRequestHandler<GetUphMitraRequest, GetUphMitraResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetUphMitraQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetUphMitraResponse> Handle(GetUphMitraRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var record = await _context.UphMitras
                    .AsNoTracking()
                    .Include(a => a.Uph)
                    .FirstOrDefaultAsync(x => x.UphMitraID == request.UphMitraID, cancellationToken);

                if (record != null)
                {
                    var data = record;

                    return new GetUphMitraResponse
                    {
                        UphMitraID = data.UphMitraID,
                        UphID = data.UphID,

                        status = data.status,
                        satuan_bahan = data.satuan_bahan,
                        sasaran = data.sasaran,
                        penanggungjawab = data.penanggungjawab,
                        akhir_periode = data.akhir_periode,
                        alamat = data.alamat,
                        awal_periode = data.awal_periode,
                        bermitra = data.bermitra,
                        detail_bahan = data.detail_bahan,
                        detail_kopetensi = data.detail_kopetensi,
                        jenis_usaha = data.jenis_usaha,

                        lembaga = data.lembaga,
                        jenis_mitra = data.jenis_mitra,
                        detail_promosi = data.detail_promosi,
                        detail_sarana = data.detail_sarana,
                        detail_fasilitasi = data.detail_fasilitasi,

                        lembagas = data.lembaga.Replace(", ", ",").Split(",").ToList(),
                        jenis_mitras = data.jenis_mitra.Replace(", ", ",").Split(",").ToList(),
                        detail_promosis = data.detail_promosi.Replace(", ", ",").Split(",").ToList(),
                        detail_saranas = data.detail_sarana.Replace(", ", ",").Split(",").ToList(),
                        detail_fasilitasis = data.detail_fasilitasi.Replace(", ", ",").Split(",").ToList(),

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
                            Name = data.Uph?.Name
                        },
                    };
                }
                else
                {
                    throw new Exception(ErrorMessage.DataNotFound);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}