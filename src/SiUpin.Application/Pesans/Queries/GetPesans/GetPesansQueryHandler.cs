using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Pesans.Queries.Common;
using SiUpin.Shared.Pesans.Queries.GetPesans;

namespace SiUpin.Application.Pesans.Queries.GetPesans
{
    public class GetPesansQueryHandler : IRequestHandler<GetPesansRequest, GetPesansResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetPesansQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetPesansResponse> Handle(GetPesansRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var records = await _context.Pesans
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);

                List<PesanDTO> listOfDTO = new List<PesanDTO>();

                if (records.Count > 0)
                {
                    foreach (var record in records)
                    {
                        var data = new PesanDTO
                        {
                            PesanID = record.PesanID,
                            Description = record.Description,
                            Name = record.Name,
                            Email = record.Email
                        };

                        if (data != null)
                            listOfDTO.Add(data);
                    }
                }

                return new GetPesansResponse
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