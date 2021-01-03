using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.JenisKomiditis.Commands.CreateJenisKomoditi;

namespace SiUpin.Application.JenisKomoditis.Commands
{
    public class CreateJenisKomoditiCommand : IRequestHandler<CreateJenisKomoditiRequest, CreateJenisKomoditiResponse>
    {
        private readonly ISiUpinDBContext _context;

        public CreateJenisKomoditiCommand(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<CreateJenisKomoditiResponse> Handle(CreateJenisKomoditiRequest request, CancellationToken cancellationToken)
        {
            var result = new CreateJenisKomoditiResponse();

            var entity = new JenisKomoditi
            {
                Name = request.Name
            };

            await _context.JenisKomoditis.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}