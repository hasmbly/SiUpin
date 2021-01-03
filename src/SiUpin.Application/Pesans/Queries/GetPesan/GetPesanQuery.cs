using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Pesans.Queries.GetPesan;

namespace SiUpin.Application.Pesans.Queries.GetPesan
{
    public class GetPesanQuery : IRequestHandler<GetPesanRequest, GetPesanResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetPesanQuery(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetPesanResponse> Handle(GetPesanRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var record = await _context.Pesans.AsNoTracking().FirstOrDefaultAsync(x => x.PesanID == request.PesanID, cancellationToken);

                return new GetPesanResponse
                {
                    PesanID = record.PesanID,
                    Name = record.Name,
                    Email = record.Email,
                    Description = record.Description
                };
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}