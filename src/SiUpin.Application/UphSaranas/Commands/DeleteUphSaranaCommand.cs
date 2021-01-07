using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.UphSaranas.Commands;

namespace SiUpin.Application.UphSaranas.Commands
{
    public class DeleteUphSaranaCommand : IRequestHandler<DeleteUphSaranaRequest, DeleteUphSaranaResponse>
    {
        private readonly ISiUpinDBContext _context;

        public DeleteUphSaranaCommand(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<DeleteUphSaranaResponse> Handle(DeleteUphSaranaRequest request, CancellationToken cancellationToken)
        {
            var result = new DeleteUphSaranaResponse();

            if (request.UphSaranaIDs.Count > 0)
            {
                var listOfData = request.UphSaranaIDs;

                foreach (var Ids in listOfData)
                {
                    var entity = await _context.UphSaranas.FirstOrDefaultAsync(x => x.UphSaranaID == Ids, cancellationToken);

                    _context.UphSaranas.Remove(entity);
                }

                await _context.SaveChangesAsync(cancellationToken);
            }

            return result;
        }
    }
}