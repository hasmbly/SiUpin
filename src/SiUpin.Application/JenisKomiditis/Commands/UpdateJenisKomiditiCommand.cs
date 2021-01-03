using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.JenisKomiditis.Commands.UpdateJenisKomoditi;

namespace SiUpin.Application.JenisKomoditis.Commands
{
    public class UpdateJenisKomiditiCommand : IRequestHandler<UpdateJenisKomoditiRequest, UpdateJenisKomoditiResponse>
    {
        private readonly ISiUpinDBContext _context;

        public UpdateJenisKomiditiCommand(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<UpdateJenisKomoditiResponse> Handle(UpdateJenisKomoditiRequest request, CancellationToken cancellationToken)
        {
            var result = new UpdateJenisKomoditiResponse();

            var entity = await _context.JenisKomoditis.FirstOrDefaultAsync(x => x.JenisKomoditiID == request.JenisKomoditiID, cancellationToken);

            entity.Name = request.Name;

            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}