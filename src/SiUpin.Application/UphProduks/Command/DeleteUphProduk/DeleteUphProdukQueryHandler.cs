using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Files.Commands.DeleteFile;
using SiUpin.Shared.UphProduks.Command.DeleteUphProduk;
using static SiUpin.Shared.Common.Constants;

namespace SiUpin.Application.UphProduks.Commands.DeleteUphProduk
{
    public class DeleteUphProdukQueryHandler : IRequestHandler<DeleteUphProdukRequest, DeleteUphProdukResponse>
    {
        private readonly ISiUpinDBContext _context;
        private readonly IMediator _mediator;

        public DeleteUphProdukQueryHandler(ISiUpinDBContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<DeleteUphProdukResponse> Handle(DeleteUphProdukRequest request, CancellationToken cancellationToken)
        {
            var result = new DeleteUphProdukResponse();

            if (request.UphProdukIDs.Count > 0)
            {
                foreach (var item in request.UphProdukIDs)
                {
                    var entity = await _context.UphProduks.FirstOrDefaultAsync(x => x.UphProdukID == item, cancellationToken);

                    if (entity != null)
                    {
                        // delete file uph produk
                        var file = await _context.Files.AsNoTracking()
                            .Where(x => x.EntityID == entity.UphProdukID && x.EntityType == FileEntityType.UphProduk)
                            .FirstOrDefaultAsync(cancellationToken);

                        await _mediator.Send(new DeleteFileRequest { EntityID = file.EntityID, EntityType = file.EntityType });

                        // delete uph produk
                        _context.UphProduks.Remove(entity);
                    }
                }

                await _context.SaveChangesAsync(cancellationToken);
            }

            return result;
        }
    }
}
