using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.Pesans.Commands;

namespace SiUpin.Application.Pesans.Commands
{
    public class CreatePesanCommand : IRequestHandler<CreatePesanRequest, CreatePesanResponse>
    {
        private readonly ISiUpinDBContext _context;

        public CreatePesanCommand(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<CreatePesanResponse> Handle(CreatePesanRequest request, CancellationToken cancellationToken)
        {
            var result = new CreatePesanResponse();

            var entity = new Pesan
            {
                Name = request.Name,
                Email = request.Email,
                Description = request.Description
            };

            await _context.Pesans.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}