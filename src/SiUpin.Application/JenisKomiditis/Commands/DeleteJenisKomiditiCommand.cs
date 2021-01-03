using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.JenisKomiditis.Commands.DeleteJenisKomoditi;

namespace SiUpin.Application.JenisKomoditis.Commands
{
    public class DeleteJenisKomiditiCommand : IRequestHandler<DeleteJenisKomoditiRequest, DeleteJenisKomoditiResponse>
    {
        private readonly ISiUpinDBContext _context;

        public DeleteJenisKomiditiCommand(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<DeleteJenisKomoditiResponse> Handle(DeleteJenisKomoditiRequest request, CancellationToken cancellationToken)
        {
            var result = new DeleteJenisKomoditiResponse();

            var entity = await _context.JenisKomoditis.FirstOrDefaultAsync(x => x.JenisKomoditiID == request.JenisKomoditiID, cancellationToken);

            _context.JenisKomoditis.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}