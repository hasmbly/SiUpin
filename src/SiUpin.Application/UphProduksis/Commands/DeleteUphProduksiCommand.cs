using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.UphProduksis.Commands;

namespace SiUpin.Application.UphProduksis.Commands
{
    public class DeleteUphProduksiCommand : IRequestHandler<DeleteUphProduksiRequest, DeleteUphProduksiResponse>
    {
        private readonly ISiUpinDBContext _context;

        public DeleteUphProduksiCommand(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<DeleteUphProduksiResponse> Handle(DeleteUphProduksiRequest request, CancellationToken cancellationToken)
        {
            var result = new DeleteUphProduksiResponse();

            if (request.UphProduksiIDs.Count > 0)
            {
                var listOfData = request.UphProduksiIDs;

                foreach (var Ids in listOfData)
                {
                    var entity = await _context.UphProduksis.FirstOrDefaultAsync(x => x.UphProduksiID == Ids, cancellationToken);

                    _context.UphProduksis.Remove(entity);
                }

                await _context.SaveChangesAsync(cancellationToken);
            }

            return result;
        }
    }
}