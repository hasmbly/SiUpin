using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.UphBahanBakus.Commands;

namespace SiUpin.Application.UphBahanBakus.Commands
{
    public class UpdateUphBahanBakuCommandHandler : IRequestHandler<UpdateUphBahanBakuRequest, UpdateUphBahanBakuResponse>
    {
        private readonly ISiUpinDBContext _context;

        public UpdateUphBahanBakuCommandHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<UpdateUphBahanBakuResponse> Handle(UpdateUphBahanBakuRequest request, CancellationToken cancellationToken)
        {
            var result = new UpdateUphBahanBakuResponse();

            var data = await _context.UphBahanBakus.FirstOrDefaultAsync(x => x.UphBahanBakuID == request.UphBahanBakuID, cancellationToken);

            var entity = new UphBahanBaku
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
                Nilai = data.Nilai
            };

            await _context.SaveChangesAsync(cancellationToken);

            result.UphBahanBakuID = entity.UphBahanBakuID;

            return result;
        }
    }
}