using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.UphProduks.Command.DeleteUphProduk;
using SiUpin.Shared.Uphs.Command.DeleteUph;

namespace SiUpin.Application.Uphs.Commands.DeleteUph
{
    public class DeleteUphQueryHandler : IRequestHandler<DeleteUphRequest, DeleteUphResponse>
    {
        private readonly ISiUpinDBContext _context;
        private readonly IMediator _mediator;

        public DeleteUphQueryHandler(ISiUpinDBContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<DeleteUphResponse> Handle(DeleteUphRequest request, CancellationToken cancellationToken)
        {
            var result = new DeleteUphResponse();

            var entity = await _context.Uphs.FirstOrDefaultAsync(x => x.UphID == request.UphID, cancellationToken);

            if (entity != null)
            {
                // find all related uphproduks
                var uphProduks = await _context.UphProduks.AsNoTracking().Where(x => x.UphID == entity.UphID).ToListAsync(cancellationToken);

                if (uphProduks.Count > 0)
                {
                    // remove uph produk + file
                    await _mediator.Send(new DeleteUphProdukRequest { UphProdukIDs = uphProduks.Select(x => x.UphProdukID).ToList() });
                }

                _context.Uphs.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }

            return result;
        }
    }
}