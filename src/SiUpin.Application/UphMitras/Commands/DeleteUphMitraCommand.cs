using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.UphMitras.Commands;

namespace SiUpin.Application.UphMitras.Commands
{
    public class DeleteUphMitraCommand : IRequestHandler<DeleteUphMitraRequest, DeleteUphMitraResponse>
    {
        private readonly ISiUpinDBContext _context;

        public DeleteUphMitraCommand(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<DeleteUphMitraResponse> Handle(DeleteUphMitraRequest request, CancellationToken cancellationToken)
        {
            var result = new DeleteUphMitraResponse();

            if (request.UphMitraIDs.Count > 0)
            {
                var listOfData = request.UphMitraIDs;

                foreach (var Ids in listOfData)
                {
                    var entity = await _context.UphMitras.FirstOrDefaultAsync(x => x.UphMitraID == Ids, cancellationToken);

                    _context.UphMitras.Remove(entity);
                }

                await _context.SaveChangesAsync(cancellationToken);
            }

            return result;
        }
    }
}