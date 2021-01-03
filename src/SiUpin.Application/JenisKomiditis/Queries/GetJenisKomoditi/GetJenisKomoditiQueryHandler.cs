using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Constants;
using SiUpin.Shared.JenisKomiditis.Queries.GetJenisKomoditi;

namespace SiUpin.Application.JenisKomiditis.Queries.GetJenisKomoditi
{
    public class GetJenisKomoditiQueryHandler : IRequestHandler<GetJenisKomoditiRequest, GetJenisKomoditiResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetJenisKomoditiQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetJenisKomoditiResponse> Handle(GetJenisKomoditiRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var record = await _context.JenisKomoditis
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.JenisKomoditiID == request.JenisKomoditiID, cancellationToken);

                if (record != null)
                {
                    var data = record;

                    return new GetJenisKomoditiResponse
                    {
                        JenisKomoditiID = data.JenisKomoditiID,
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