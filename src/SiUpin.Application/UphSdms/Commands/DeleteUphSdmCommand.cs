using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.UphSdms.Commands;

namespace SiUpin.Application.UphSdms.Commands
{
    public class DeleteUphSdmCommand : IRequestHandler<DeleteUphSdmRequest, DeleteUphSdmResponse>
    {
        private readonly ISiUpinDBContext _context;

        public DeleteUphSdmCommand(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<DeleteUphSdmResponse> Handle(DeleteUphSdmRequest request, CancellationToken cancellationToken)
        {
            var result = new DeleteUphSdmResponse();

            if (request.UphSdmIDs.Count > 0)
            {
                var listOfData = request.UphSdmIDs;

                foreach (var Ids in listOfData)
                {
                    var entity = await _context.UphSdms.FirstOrDefaultAsync(x => x.UphSdmID == Ids, cancellationToken);

                    _context.UphSdms.Remove(entity);
                }

                await _context.SaveChangesAsync(cancellationToken);
            }

            return result;
        }
    }
}