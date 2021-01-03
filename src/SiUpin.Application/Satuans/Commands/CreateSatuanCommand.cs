using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.Satuans.Command;

namespace SiUpin.Application.Satuans.Commands
{
    public class CreateSatuanCommand : IRequestHandler<CreateSatuanRequest, CreateSatuanResponse>
    {
        private readonly ISiUpinDBContext _context;

        public CreateSatuanCommand(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<CreateSatuanResponse> Handle(CreateSatuanRequest request, CancellationToken cancellationToken)
        {
            var result = new CreateSatuanResponse();

            var entity = new Satuan
            {
                Name = request.Name
            };

            await _context.Satuans.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}