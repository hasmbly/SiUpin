using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.ProdukOlahans.Queries.GetProdukOlahans;

namespace SiUpin.Application.ProdukOlahans.Queries.GetProdukOlahans
{
    public class GetProdukOlahansQueryHandler : IRequestHandler<GetProdukOlahansRequest, GetProdukOlahansResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetProdukOlahansQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetProdukOlahansResponse> Handle(GetProdukOlahansRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var records = await _context.ProdukOlahans
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);

                List<ProdukOlahanDTO> listOfDTO = new List<ProdukOlahanDTO>();

                if (records.Count > 0)
                {
                    foreach (var record in records)
                    {
                        var data = new ProdukOlahanDTO
                        {
                            ProdukOlahanID = record.ProdukOlahanID,
                            Name = record.Name,
                            JenisKomoditiID = record.JenisKomoditiID
                        };

                        if (data != null)
                            listOfDTO.Add(data);
                    }
                }

                return new GetProdukOlahansResponse
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