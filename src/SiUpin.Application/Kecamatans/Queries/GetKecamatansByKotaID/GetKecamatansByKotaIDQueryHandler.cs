using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Kecamatans.Queries.GetKecamatansByKotaID;

namespace SiUpin.Application.Kecamatans.Queries.GetKecamatansByKotaID
{
    public class GetKecamatansByKotaIDQueryHandler : IRequestHandler<GetKecamatansByKotaIDRequest, GetKecamatansByKotaIDResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetKecamatansByKotaIDQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetKecamatansByKotaIDResponse> Handle(GetKecamatansByKotaIDRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var records = await _context.Kecamatans
                    .AsNoTracking()
                    .Where(x => x.KotaID == request.KotaID)
                    .ToListAsync(cancellationToken);

                List<KecamatanDTO> listOfDTO = new List<KecamatanDTO>();

                if (records.Count > 0)
                {
                    foreach (var record in records)
                    {
                        var data = new KecamatanDTO
                        {
                            KecamatanID = record.KecamatanID,
                            KotaID = record.KotaID,
                            Name = record.Name
                        };

                        if (data != null)
                            listOfDTO.Add(data);
                    }
                }

                return new GetKecamatansByKotaIDResponse
                {
                    Data = listOfDTO
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}