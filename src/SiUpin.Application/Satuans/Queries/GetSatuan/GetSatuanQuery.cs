using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Constants;
using SiUpin.Shared.Satuans.Queries.GetSatuan;

namespace SiUpin.Application.Satuans.Queries.GetSatuan
{
    public class GetSatuanQuery : IRequestHandler<GetSatuanRequest, GetSatuanResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetSatuanQuery(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetSatuanResponse> Handle(GetSatuanRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var record = await _context.Satuans.AsNoTracking().FirstOrDefaultAsync(x => x.SatuanID == request.SatuanID, cancellationToken);

                if (record != null)
                {
                    var data = record;

                    return new GetSatuanResponse
                    {
                        SatuanID = data.SatuanID,
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