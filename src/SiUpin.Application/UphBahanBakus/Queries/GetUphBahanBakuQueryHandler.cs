using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Constants;
using SiUpin.Shared.JenisKomiditis.Common.GetAllJenisKomiditi;
using SiUpin.Shared.JenisTernaks.Queries.Common;
using SiUpin.Shared.Satuans.Queries.GetSatuans;
using SiUpin.Shared.UphBahanBakus.Queries;

namespace SiUpin.Application.UphBahanBakus.Queries
{
    public class GetUphBahanBakuQueryHandler : IRequestHandler<GetUphBahanBakuRequest, GetUphBahanBakuResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetUphBahanBakuQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetUphBahanBakuResponse> Handle(GetUphBahanBakuRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var record = await _context.UphBahanBakus
                    .AsNoTracking()
                    .Include(a => a.Uph)
                    .Include(b => b.JenisKomoditi)
                    .Include(c => c.JenisTernak)
                    .Include(d => d.Satuan)
                    .FirstOrDefaultAsync(x => x.UphBahanBakuID == request.UphBahanBakuID, cancellationToken);

                if (record != null)
                {
                    var data = record;

                    return new GetUphBahanBakuResponse
                    {
                        UphBahanBakuID = data.UphBahanBakuID,
                        UphID = data.UphID,
                        id_uph = data.id_uph,

                        id_bahan_baku = data.id_bahan_baku,
                        JenisKomoditiID = data.JenisKomoditiID,
                        JenisTernakID = data.JenisTernakID,
                        SatuanID = data.SatuanID,

                        TotalKebutuhan = data.TotalKebutuhan,
                        AsalBahanBaku = data.AsalBahanBaku,
                        AsalBahanBakus = data.AsalBahanBaku.Replace(", ", ",").Split(",").ToList(),
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