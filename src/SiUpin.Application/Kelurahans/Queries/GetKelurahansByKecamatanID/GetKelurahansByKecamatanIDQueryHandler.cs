using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Kelurahans.Queries.GetKelurahansByKecamatanID;

namespace SiUpin.Application.Kelurahans.Queries.GetKelurahansByKecamatanID
{
    public class GetKelurahansByKecamatanIDQueryHandler : IRequestHandler<GetKelurahansByKecamatanIDRequest, GetKelurahansByKecamatanIDResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetKelurahansByKecamatanIDQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetKelurahansByKecamatanIDResponse> Handle(GetKelurahansByKecamatanIDRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var records = await _context.Kelurahans
                    .AsNoTracking()
                    .Where(x => x.KecamatanID == request.KecamatanID)
                    .ToListAsync(cancellationToken);

                List<KelurahanDTO> listOfDTO = new List<KelurahanDTO>();

                if (records.Count > 0)
                {
                    foreach (var record in records)
                    {
                        var data = new KelurahanDTO
                        {
                            KecamatanID = record.KecamatanID,
                            KelurahanID = record.KelurahanID,
                            Name = record.Name
                        };

                        if (data != null)
                            listOfDTO.Add(data);
                    }
                }

                return new GetKelurahansByKecamatanIDResponse
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