using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.Beritas.Commands.CreateBerita;

namespace SiUpin.Application.Beritas.Commands
{
    public class CreateBeritaCommand : IRequestHandler<CreateBeritaRequest, CreateBeritaResponse>
    {
        private readonly ISiUpinDBContext _context;

        public CreateBeritaCommand(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<CreateBeritaResponse> Handle(CreateBeritaRequest request, CancellationToken cancellationToken)
        {
            var result = new CreateBeritaResponse();

            var entity = new Berita
            {
                Title = request.Title,
                CreatedBy = request.UserID,
                Description = request.Description
            };

            await _context.Beritas.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);

            result.BeritaID = entity.BeritaID;

            return result;
        }
    }
}