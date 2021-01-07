using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Constants;
using SiUpin.Shared.UphGmps.Queries;

namespace SiUpin.Application.UphGmps.Queries
{
    public class GetUphGmpQueryHandler : IRequestHandler<GetUphGmpRequest, GetUphGmpResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetUphGmpQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetUphGmpResponse> Handle(GetUphGmpRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var record = await _context.UphGmps
                    .AsNoTracking()
                    .Include(a => a.Uph)
                    .FirstOrDefaultAsync(x => x.UphGmpID == request.UphGmpID, cancellationToken);

                if (record != null)
                {
                    var data = record;

                    return new GetUphGmpResponse
                    {
                        UphGmpID = data.UphGmpID,
                        UphID = data.UphID,

                        nama_gmp = data.nama_gmp,
                        nama_gmps = data.nama_gmp.Replace(", ", ",").Split(",").ToList(),

                        jml_gmp = data.jml_gmp,

                        Uph = new Shared.Uphs.Common.UphDTO
                        {
                            Name = data.Uph?.Name
                        },
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