using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.JenisTernaks.Commands;

namespace SiUpin.Application.JenisTernaks.Commands
{
    public class DeleteJenisTernakCommand : IRequestHandler<DeleteJenisTernakRequest, DeleteJenisTernakResponse>
    {
        private readonly ISiUpinDBContext _context;

        public DeleteJenisTernakCommand(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<DeleteJenisTernakResponse> Handle(DeleteJenisTernakRequest request, CancellationToken cancellationToken)
        {
            var result = new DeleteJenisTernakResponse();

            var entity = await _context.JenisTernaks.FirstOrDefaultAsync(x => x.JenisTernakID == request.JenisTernakID, cancellationToken);

            _context.JenisTernaks.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}