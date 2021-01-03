using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.ProdukOlahans.Commands.CreateProdukOlahan;

namespace SiUpin.Application.ProdukOlahans.Commands
{
    public class CreateProdukOlahanCommand : IRequestHandler<CreateProdukOlahanRequest, CreateProdukOlahanResponse>
    {
        private readonly ISiUpinDBContext _context;

        public CreateProdukOlahanCommand(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<CreateProdukOlahanResponse> Handle(CreateProdukOlahanRequest request, CancellationToken cancellationToken)
        {
            var result = new CreateProdukOlahanResponse();

            var entity = new ProdukOlahan
            {
                Name = request.Name,
                JenisKomoditiID = request.JenisKomoditiID
            };

            await _context.ProdukOlahans.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}