using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.UphGmps.Commands;

namespace SiUpin.Application.UphGmps.Commands
{
    public class UpdateUphGmpCommand : IRequestHandler<UpdateUphGmpRequest, UpdateUphGmpResponse>
    {
        private readonly ISiUpinDBContext _context;

        public UpdateUphGmpCommand(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<UpdateUphGmpResponse> Handle(UpdateUphGmpRequest request, CancellationToken cancellationToken)
        {
            var result = new UpdateUphGmpResponse();

            var entity = await _context.UphGmps
                .FirstOrDefaultAsync(x => x.UphGmpID == request.UphGmpID, cancellationToken);

            entity.UphGmpID = request.UphGmpID;
            entity.UphID = request.UphID;
            entity.nama_gmp = string.Join(",", request.nama_gmps);
            entity.jml_gmp = request.nama_gmps.Count().ToString();

            await _context.SaveChangesAsync(cancellationToken);

            result.UphGmpID = entity.UphGmpID;

            return result;
        }
    }
}