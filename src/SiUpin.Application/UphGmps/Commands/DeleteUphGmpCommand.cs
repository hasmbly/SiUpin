using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.UphGmps.Commands;

namespace SiUpin.Application.UphGmps.Commands
{
    public class DeleteUphGmpCommand : IRequestHandler<DeleteUphGmpRequest, DeleteUphGmpResponse>
    {
        private readonly ISiUpinDBContext _context;

        public DeleteUphGmpCommand(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<DeleteUphGmpResponse> Handle(DeleteUphGmpRequest request, CancellationToken cancellationToken)
        {
            var result = new DeleteUphGmpResponse();

            if (request.UphGmpIDs.Count > 0)
            {
                var listOfData = request.UphGmpIDs;

                foreach (var Ids in listOfData)
                {
                    var entity = await _context.UphGmps.FirstOrDefaultAsync(x => x.UphGmpID == Ids, cancellationToken);

                    _context.UphGmps.Remove(entity);
                }

                await _context.SaveChangesAsync(cancellationToken);
            }

            return result;
        }
    }
}