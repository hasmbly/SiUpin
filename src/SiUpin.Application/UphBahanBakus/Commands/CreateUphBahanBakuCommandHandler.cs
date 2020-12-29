using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.UphBahanBakus.Commands;

namespace SiUpin.Application.UphBahanBakus.Commands
{
    public class CreateUphBahanBakuCommandHandler : IRequestHandler<CreateUphBahanBakuRequest, CreateUphBahanBakuResponse>
    {
        private readonly ISiUpinDBContext _context;

        public CreateUphBahanBakuCommandHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<CreateUphBahanBakuResponse> Handle(CreateUphBahanBakuRequest request, CancellationToken cancellationToken)
        {
            var result = new CreateUphBahanBakuResponse();

            var data = request;

            var entity = new UphBahanBaku
            {
                UphID = data.UphID,
                id_uph = data.id_uph,

                id_bahan_baku = data.id_bahan_baku,
                JenisKomoditiID = data.JenisKomoditiID,
                JenisTernakID = data.JenisTernakID,
                SatuanID = data.SatuanID,
                TotalKebutuhan = data.TotalKebutuhan,
                AsalBahanBaku = string.Join(",", request.AsalBahanBakus),
                Nilai = data.Nilai
            };

            await _context.UphBahanBakus.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);

            result.UphBahanBakuID = entity.UphBahanBakuID;

            return result;
        }
    }
}