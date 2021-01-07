using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.UphPasars.Commands;

namespace SiUpin.Application.UphPasars.Commands
{
    public class DeleteUphPasarCommand : IRequestHandler<DeleteUphPasarRequest, DeleteUphPasarResponse>
    {
        private readonly ISiUpinDBContext _context;

        public DeleteUphPasarCommand(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<DeleteUphPasarResponse> Handle(DeleteUphPasarRequest request, CancellationToken cancellationToken)
        {
            var result = new DeleteUphPasarResponse();

            if (request.UphPasarIDs.Count > 0)
            {
                var listOfData = request.UphPasarIDs;

                foreach (var Ids in listOfData)
                {
                    var entity = await _context.UphPasars.FirstOrDefaultAsync(x => x.UphPasarID == Ids, cancellationToken);

                    _context.UphPasars.Remove(entity);
                }

                await _context.SaveChangesAsync(cancellationToken);
            }

            return result;
        }
    }
}