using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Constants;
using SiUpin.Shared.JenisTernaks.Queries.GetJenisTernak;

namespace SiUpin.Application.JenisTernaks.Queries.GetJenisTernak
{
    public class GetJenisTernakQueryHandler : IRequestHandler<GetJenisTernakRequest, GetJenisTernakResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetJenisTernakQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetJenisTernakResponse> Handle(GetJenisTernakRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var record = await _context.JenisTernaks
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.JenisTernakID == request.JenisTernakID, cancellationToken);

                if (record != null)
                {
                    var data = record;

                    return new GetJenisTernakResponse
                    {
                        JenisTernakID = data.JenisTernakID,
                        Name = data.Name
                    };
                }
                else
                {
                    throw new Exception(ErrorMessage.DataNotFound);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}