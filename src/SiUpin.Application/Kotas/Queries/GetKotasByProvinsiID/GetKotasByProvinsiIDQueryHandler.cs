using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Kotas.Queries.GetKotasByProvinsiID;

namespace SiUpin.Application.Kotas.Queries.GetKotasByProvinsiID
{
    public class GetKotasByProvinsiIDQueryHandler : IRequestHandler<GetKotasByProvinsiIDRequest, GetKotasByProvinsiIDResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetKotasByProvinsiIDQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetKotasByProvinsiIDResponse> Handle(GetKotasByProvinsiIDRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var records = await _context.Kotas
                    .AsNoTracking()
                    .Where(x => x.ProvinsiID == request.ProvinsiID)
                    .ToListAsync(cancellationToken);

                List<KotaDTO> listOfDTO = new List<KotaDTO>();

                if (records.Count > 0)
                {
                    foreach (var record in records)
                    {
                        var data = new KotaDTO
                        {
                            KotaID = record.KotaID,
                            ProvinsiID = record.ProvinsiID,
                            Name = record.Name
                        };

                        if (data != null)
                            listOfDTO.Add(data);
                    }
                }

                return new GetKotasByProvinsiIDResponse
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