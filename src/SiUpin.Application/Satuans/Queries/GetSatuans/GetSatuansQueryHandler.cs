using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Satuans.Queries.GetSatuans;

namespace SiUpin.Application.Satuans.Queries.GetSatuans
{
    public class GetSatuansQueryHandler : IRequestHandler<GetSatuansRequest, GetSatuansResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetSatuansQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetSatuansResponse> Handle(GetSatuansRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var records = await _context.Satuans
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);

                List<SatuanDTO> listOfDTO = new List<SatuanDTO>();

                if (records.Count > 0)
                {
                    foreach (var record in records)
                    {
                        var data = new SatuanDTO
                        {
                            SatuanID = record.SatuanID,
                            Name = record.Name
                        };

                        if (data != null)
                            listOfDTO.Add(data);
                    }
                }

                return new GetSatuansResponse
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