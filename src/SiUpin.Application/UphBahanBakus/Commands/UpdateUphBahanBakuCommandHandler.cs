using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
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

            var entity = await _context.UphBahanBakus
                .FirstOrDefaultAsync(x => x.UphBahanBakuID == request.UphBahanBakuID, cancellationToken);

            entity.UphBahanBakuID = request.UphBahanBakuID;
            entity.UphID = request.UphID;
            entity.id_uph = request.id_uph;
            entity.id_bahan_baku = request.id_bahan_baku;
            entity.JenisKomoditiID = request.JenisKomoditiID;
            entity.JenisTernakID = request.JenisTernakID;
            entity.SatuanID = request.SatuanID;
            entity.TotalKebutuhan = request.TotalKebutuhan;
            entity.AsalBahanBaku = string.Join(",", request.AsalBahanBakus);
            entity.Nilai = request.Nilai;

            await _context.SaveChangesAsync(cancellationToken);

            result.UphBahanBakuID = entity.UphBahanBakuID;

            return result;
        }
    }
}