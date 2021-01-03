using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Satuans.Command;

namespace SiUpin.Application.Satuans.Commands
{
    public class DeleteSatuanCommand : IRequestHandler<DeleteSatuanRequest, DeleteSatuanResponse>
    {
        private readonly ISiUpinDBContext _context;

        public DeleteSatuanCommand(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<DeleteSatuanResponse> Handle(DeleteSatuanRequest request, CancellationToken cancellationToken)
        {
            var result = new DeleteSatuanResponse();

            var entity = await _context.Satuans.FirstOrDefaultAsync(x => x.SatuanID == request.SatuanID, cancellationToken);

            _context.Satuans.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}