using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Provinsis.Queries.GetProvinsis;

namespace SiUpin.Application.Provinsis.Queries.GetProvinsis
{
    public class GetProvinsisQueryHandler : IRequestHandler<GetProvinsisRequest, GetProvinsisResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetProvinsisQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetProvinsisResponse> Handle(GetProvinsisRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var records = await _context.Provinsis
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);

                List<ProvinsiDTO> listOfDTO = new List<ProvinsiDTO>();

                if (records.Count > 0)
                {
                    foreach (var record in records)
                    {
                        var data = new ProvinsiDTO
                        {
                            ProvinsiID = record.ProvinsiID,
                            Name = record.Name
                        };

                        if (data != null)
                            listOfDTO.Add(data);
                    }
                }

                return new GetProvinsisResponse
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