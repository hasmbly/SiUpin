using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Constants;
using SiUpin.Shared.ProdukOlahans.Queries.GetProdukOlahan;

namespace SiUpin.Application.ProdukOlahans.Queries.GetProdukOlahan
{
    public class GetProdukOlahanQueryHandler : IRequestHandler<GetProdukOlahanRequest, GetProdukOlahanResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetProdukOlahanQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetProdukOlahanResponse> Handle(GetProdukOlahanRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var record = await _context.ProdukOlahans
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.ProdukOlahanID == request.ProdukOlahanID, cancellationToken);

                if (record != null)
                {
                    var data = record;

                    return new GetProdukOlahanResponse
                    {
                        ProdukOlahanID = data.ProdukOlahanID,
                        JenisKomoditiID = data.JenisKomoditiID,
                        Name = data.Name
                    };
                }
                else
                {
                    throw new Exception(ErrorMessage.DataNotFound);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}