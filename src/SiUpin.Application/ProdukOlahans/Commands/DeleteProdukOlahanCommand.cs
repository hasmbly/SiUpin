using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.ProdukOlahans.Commands.DeleteProdukOlahan;

namespace SiUpin.Application.ProdukOlahans.Commands
{
    public class DeleteProdukOlahanCommand : IRequestHandler<DeleteProdukOlahanRequest, DeleteProdukOlahanResponse>
    {
        private readonly ISiUpinDBContext _context;

        public DeleteProdukOlahanCommand(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<DeleteProdukOlahanResponse> Handle(DeleteProdukOlahanRequest request, CancellationToken cancellationToken)
        {
            var result = new DeleteProdukOlahanResponse();

            var entity = await _context.ProdukOlahans.FirstOrDefaultAsync(x => x.ProdukOlahanID == request.ProdukOlahanID, cancellationToken);

            _context.ProdukOlahans.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}