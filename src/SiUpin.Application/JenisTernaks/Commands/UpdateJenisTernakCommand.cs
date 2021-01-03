using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.JenisTernaks.Commands;

namespace SiUpin.Application.JenisTernaks.Commands
{
    public class UpdateJenisTernakCommand : IRequestHandler<UpdateJenisTernakRequest, UpdateJenisTernakResponse>
    {
        private readonly ISiUpinDBContext _context;

        public UpdateJenisTernakCommand(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<UpdateJenisTernakResponse> Handle(UpdateJenisTernakRequest request, CancellationToken cancellationToken)
        {
            var result = new UpdateJenisTernakResponse();

            var entity = await _context.JenisTernaks.FirstOrDefaultAsync(x => x.JenisTernakID == request.JenisTernakID, cancellationToken);

            entity.Name = request.Name;

            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}