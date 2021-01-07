using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.UphGmps.Commands;

namespace SiUpin.Application.UphGmps.Commands
{
    public class CreateUphGmpCommand : IRequestHandler<CreateUphGmpRequest, CreateUphGmpResponse>
    {
        private readonly ISiUpinDBContext _context;

        public CreateUphGmpCommand(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<CreateUphGmpResponse> Handle(CreateUphGmpRequest request, CancellationToken cancellationToken)
        {
            var result = new CreateUphGmpResponse();

            var entity = new UphGmp
            {
                UphID = request.UphID,

                nama_gmp = string.Join(",", request.nama_gmps),
                jml_gmp = request.nama_gmps.Count().ToString(),
            };

            await _context.UphGmps.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);

            result.UphGmpID = entity.UphGmpID;

            return result;
        }
    }
}