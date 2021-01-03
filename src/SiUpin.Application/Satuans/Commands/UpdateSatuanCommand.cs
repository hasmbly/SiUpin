using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Satuans.Command;

namespace SiUpin.Application.Satuans.Commands
{
    public class UpdateSatuanCommand : IRequestHandler<UpdateSatuanRequest, UpdateSatuanResponse>
    {
        private readonly ISiUpinDBContext _context;

        public UpdateSatuanCommand(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<UpdateSatuanResponse> Handle(UpdateSatuanRequest request, CancellationToken cancellationToken)
        {
            var result = new UpdateSatuanResponse();

            var entity = await _context.Satuans.FirstOrDefaultAsync(x => x.SatuanID == request.SatuanID, cancellationToken);

            entity.Name = request.Name;

            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}