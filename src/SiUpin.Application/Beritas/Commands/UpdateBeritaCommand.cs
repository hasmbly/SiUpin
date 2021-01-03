using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Beritas.Commands.UpdateBerita;

namespace SiUpin.Application.Beritas.Commands
{
    public class UpdateBeritaCommand : IRequestHandler<UpdateBeritaRequest, UpdateBeritaResponse>
    {
        private readonly ISiUpinDBContext _context;

        public UpdateBeritaCommand(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<UpdateBeritaResponse> Handle(UpdateBeritaRequest request, CancellationToken cancellationToken)
        {
            var result = new UpdateBeritaResponse();

            var entity = await _context.Beritas.FirstOrDefaultAsync(x => x.BeritaID == request.BeritaID, cancellationToken);

            entity.Title = request.Title;
            entity.Description = request.Description;

            await _context.SaveChangesAsync(cancellationToken);

            result.BeritaID = entity.BeritaID;

            return result;
        }
    }
}