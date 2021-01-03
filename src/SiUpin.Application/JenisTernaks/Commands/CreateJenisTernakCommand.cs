using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.JenisTernaks.Commands;

namespace SiUpin.Application.JenisTernaks.Commands
{
    public class CreateJenisTernakCommand : IRequestHandler<CreateJenisTernakRequest, CreateJenisTernakResponse>
    {
        private readonly ISiUpinDBContext _context;

        public CreateJenisTernakCommand(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<CreateJenisTernakResponse> Handle(CreateJenisTernakRequest request, CancellationToken cancellationToken)
        {
            var result = new CreateJenisTernakResponse();

            var entity = new JenisTernak
            {
                Name = request.Name
            };

            await _context.JenisTernaks.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}