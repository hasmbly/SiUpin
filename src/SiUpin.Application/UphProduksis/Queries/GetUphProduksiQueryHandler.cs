using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Constants;
using SiUpin.Shared.UphProduksis.Queries;

namespace SiUpin.Application.UphProduksis.Queries
{
    public class GetUphProduksiQueryHandler : IRequestHandler<GetUphProduksiRequest, GetUphProduksiResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetUphProduksiQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetUphProduksiResponse> Handle(GetUphProduksiRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var record = await _context.UphProduksis
                    .AsNoTracking()
                    .Include(a => a.Uph)
                    .FirstOrDefaultAsync(x => x.UphProduksiID == request.UphProduksiID, cancellationToken);

                if (record != null)
                {
                    var data = record;

                    return new GetUphProduksiResponse
                    {
                        UphProduksiID = data.UphProduksiID,
                        UphID = data.UphID,

                        sertifikat = data.sertifikat,
                        sertifikats = data.sertifikat.Replace(", ", ",").Split(",").ToList(),
                        jml_sertifikat = data.jml_sertifikat,

                        bahan_baku = data.bahan_baku,
                        jml_produksi = data.jml_produksi,
                        satuan = data.satuan,
                        jml_hari_produksi = data.jml_hari_produksi,

                        izin_edar = data.izin_edar,
                        jml_edar = data.jml_edar,

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