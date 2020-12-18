using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.JenisTernaks.Queries.GetJenisTernaks;

namespace SiUpin.Application.JenisTernaks.Queries.GetJenisTernaks
{
    public class GetJenisTernaksQueryHandler : IRequestHandler<GetJenisTernaksRequest, GetJenisTernaksResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetJenisTernaksQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetJenisTernaksResponse> Handle(GetJenisTernaksRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var records = await _context.JenisTernaks
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);

                List<JenisTernakDTO> listOfDTO = new List<JenisTernakDTO>();

                if (records.Count > 0)
                {
                    int no = 1;
                    foreach (var record in records)
                    {
                        var data = new JenisTernakDTO
                        {
                            No = no++,
                            JenisTernakID = record.JenisTernakID,
                            Name = record.Name
                        };

                        if (data != null)
                            listOfDTO.Add(data);
                    }
                }

                return new GetJenisTernaksResponse
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