using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Pesans.Commands;

namespace SiUpin.Application.Pesans.Commands
{
    public class DeletePesanCommand : IRequestHandler<DeletePesanRequest, DeletePesanResponse>
    {
        private readonly ISiUpinDBContext _context;

        public DeletePesanCommand(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<DeletePesanResponse> Handle(DeletePesanRequest request, CancellationToken cancellationToken)
        {
            var result = new DeletePesanResponse();

            var entity = await _context.Pesans.FirstOrDefaultAsync(x => x.PesanID == request.PesanID, cancellationToken);

            _context.Pesans.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}