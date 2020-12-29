using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.UphBahanBakus.Commands;

namespace SiUpin.Application.UphBahanBakus.Commands
{
    public class DeleteUphBahanBakuCommandHandler : IRequestHandler<DeleteUphBahanBakuRequest, DeleteUphBahanBakuResponse>
    {
        private readonly ISiUpinDBContext _context;

        public DeleteUphBahanBakuCommandHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<DeleteUphBahanBakuResponse> Handle(DeleteUphBahanBakuRequest request, CancellationToken cancellationToken)
        {
            var result = new DeleteUphBahanBakuResponse();

            if (request.UphBahanBakuIDs.Count > 0)
            {
                var listOfData = request.UphBahanBakuIDs;

                foreach (var Ids in listOfData)
                {
                    var entity = await _context.UphBahanBakus.FirstOrDefaultAsync(x => x.UphBahanBakuID == Ids, cancellationToken);

                    _context.UphBahanBakus.Remove(entity);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}