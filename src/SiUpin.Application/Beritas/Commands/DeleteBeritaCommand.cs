using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Beritas.Commands.DeleteBerita;
using SiUpin.Shared.Common;
using SiUpin.Shared.Files.Commands.DeleteFile;

namespace SiUpin.Application.Beritas.Commands
{
    public class DeleteBeritaCommand : IRequestHandler<DeleteBeritaRequest, DeleteBeritaResponse>
    {
        private readonly ISiUpinDBContext _context;
        private readonly IMediator _mediator;

        public DeleteBeritaCommand(ISiUpinDBContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<DeleteBeritaResponse> Handle(DeleteBeritaRequest request, CancellationToken cancellationToken)
        {
            var result = new DeleteBeritaResponse();

            var entity = await _context.Beritas.FirstOrDefaultAsync(x => x.BeritaID == request.BeritaID, cancellationToken);

            var file = await _context.Files.AsNoTracking()
                .FirstOrDefaultAsync(x => x.EntityID == entity.BeritaID && x.EntityType == Constants.File.EntityType.BERITA, cancellationToken);

            if (file != null)
            {
                await _mediator.Send(new DeleteFileRequest { EntityID = file.EntityID, EntityType = file.EntityType });
            }

            _context.Beritas.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}