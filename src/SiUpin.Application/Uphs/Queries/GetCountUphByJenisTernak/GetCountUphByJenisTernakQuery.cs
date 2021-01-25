using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Constants;
using SiUpin.Shared.Uphs.Queries.GetCountUphByJenisTernak;

namespace SiUpin.Application.Uphs.Queries.GetCountUphByJenisTernak
{
    public class GetCountUphByJenisTernakQuery : IRequestHandler<GetCountUphByJenisTernakRequest, GetCountUphByJenisTernakResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetCountUphByJenisTernakQuery(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetCountUphByJenisTernakResponse> Handle(GetCountUphByJenisTernakRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var jenisTernaks = await _context.JenisTernaks.AsNoTracking().ToListAsync(cancellationToken);
                var uphProduks = await _context.UphProduks
                    .Select(x => x.JenisTernakID)
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);

                List<UphByJenisTernakDTO> uphByJenisTernaks = new List<UphByJenisTernakDTO>();

                if (jenisTernaks.Count > 0)
                {
                    foreach (var jenisTernak in jenisTernaks)
                    {
                        var totalUphProdukByJenisTernak = uphProduks.Count(x => x == jenisTernak.JenisTernakID);

                        var entity = new UphByJenisTernakDTO
                        {
                            JenisTernakID = jenisTernak.JenisTernakID,
                            Name = jenisTernak.Name,
                            Total = totalUphProdukByJenisTernak
                        };

                        if (entity != null)
                            uphByJenisTernaks.Add(entity);
                    }
                }
                else
                {
                    throw new Exception(ErrorMessage.DataNotFound);
                }

                return new GetCountUphByJenisTernakResponse
                {
                    UphByJenisTernaks = uphByJenisTernaks
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}