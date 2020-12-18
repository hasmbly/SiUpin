using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.JenisKomiditis.Common.GetAllJenisKomiditi;
using SiUpin.Shared.JenisKomiditis.Queries.GetAllJenisKomiditi;

namespace SiUpin.Application.JenisKomiditis.Queries.GetAllJenisKomiditi
{
    public class GetAllJenisKomiditiQueryHandler : IRequestHandler<GetAllJenisKomiditiRequest, GetAllJenisKomiditiResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetAllJenisKomiditiQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetAllJenisKomiditiResponse> Handle(GetAllJenisKomiditiRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var records = await _context.JenisKomoditis
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);

                List<JenisKomoditiDTO> listOfDTO = new List<JenisKomoditiDTO>();

                if (records.Count > 0)
                {
                    int no = 1;
                    foreach (var record in records)
                    {
                        var data = new JenisKomoditiDTO
                        {
                            No = no++,
                            JenisKomoditiID = record.JenisKomoditiID,
                            Name = record.Name
                        };

                        if (data != null)
                            listOfDTO.Add(data);
                    }
                }

                return new GetAllJenisKomiditiResponse
                {
                    JenisKomoditis = listOfDTO
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}