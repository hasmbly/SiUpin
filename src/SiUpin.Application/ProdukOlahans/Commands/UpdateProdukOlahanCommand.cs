using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.ProdukOlahans.Commands.UpdateProdukOlahan;

namespace SiUpin.Application.ProdukOlahans.Commands
{
    public class UpdateProdukOlahanCommand : IRequestHandler<UpdateProdukOlahanRequest, UpdateProdukOlahanResponse>
    {
        private readonly ISiUpinDBContext _context;

        public UpdateProdukOlahanCommand(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<UpdateProdukOlahanResponse> Handle(UpdateProdukOlahanRequest request, CancellationToken cancellationToken)
        {
            var result = new UpdateProdukOlahanResponse();

            var entity = await _context.ProdukOlahans.FirstOrDefaultAsync(x => x.ProdukOlahanID == request.ProdukOlahanID, cancellationToken);

            entity.JenisKomoditiID = request.JenisKomoditiID;
            entity.Name = request.Name;

            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}