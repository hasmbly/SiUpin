using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Constants;
using SiUpin.Shared.UphSaranas.Queries;

namespace SiUpin.Application.UphSaranas.Queries
{
    public class GetUphSaranaQueryHandler : IRequestHandler<GetUphSaranaRequest, GetUphSaranaResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetUphSaranaQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetUphSaranaResponse> Handle(GetUphSaranaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var record = await _context.UphSaranas
                    .AsNoTracking()
                    .Include(a => a.Uph)
                    .FirstOrDefaultAsync(x => x.UphSaranaID == request.UphSaranaID, cancellationToken);

                if (record != null)
                {
                    var data = record;

                    return new GetUphSaranaResponse
                    {
                        UphSaranaID = data.UphSaranaID,
                        UphID = data.UphID,

                        tahun = data.tahun,

                        asal_bantuans = data.asal_bantuan.Replace(", ", ",").Split(",").ToList(),
                        lain = data.lain,

                        nama_alat = data.nama_alat,
                        kapasitas_terpakai = data.kapasitas_terpakai,
                        kapasitas_terpasang = data.kapasitas_terpasang,
                        satuan = data.satuan,
                        jenis_mesin = data.jenis_mesin,
                        status = data.status,

                        alasans = data.alasan.Replace(", ", ",").Split(",").ToList(),
                        lain_alasan = data.lain_alasan,

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