using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Constants;
using SiUpin.Shared.Uphs.Queries.GetUphIDandNames;

namespace SiUpin.Application.Uphs.Queries.GetUphIDandNames
{
    public class GetUphIDandNamesQueryHandler : IRequestHandler<GetUphIDandNamesRequest, GetUphIDandNamesResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetUphIDandNamesQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetUphIDandNamesResponse> Handle(GetUphIDandNamesRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var records = await _context.Uphs
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);

                if (records == null)
                    throw new Exception(ErrorMessage.DataNotFound);

                IList<UphIDandNameDTO> uphIDandNames = new List<UphIDandNameDTO>();

                foreach (var data in records)
                {
                    uphIDandNames.Add(new UphIDandNameDTO
                    {
                        UphID = data.UphID,
                        Name = data.Name
                    });
                }

                return new GetUphIDandNamesResponse
                {
                    UphIDandNames = uphIDandNames
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}