using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.JenisKomiditis.Common.GetAllJenisKomiditi;
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
                    .Include(a => a.JenisKomoditi)
                    .ToListAsync(cancellationToken);

                List<ProdukOlahanDTO> listOfDTO = new List<ProdukOlahanDTO>();

                if (records.Count > 0)
                {
                    int no = 1;
                    foreach (var record in records)
                    {
                        var data = new ProdukOlahanDTO
                        {
                            No = no++,
                            ProdukOlahanID = record.ProdukOlahanID,
                            Name = record.Name,
                            JenisKomoditi = new JenisKomoditiDTO
                            {
                                JenisKomoditiID = record.JenisKomoditi.JenisKomoditiID,
                                Name = record.JenisKomoditi.Name
                            }
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