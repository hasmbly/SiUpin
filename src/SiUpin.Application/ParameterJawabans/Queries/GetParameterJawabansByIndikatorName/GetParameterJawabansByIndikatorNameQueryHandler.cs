using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.ParameterJawabans.Common;
using SiUpin.Shared.ParameterJawabans.Queries.GetParameterJawabansByIndikatorName;

namespace SiUpin.Application.ParameterJawabans.Queries.GetParameterJawabansByIndikatorName
{
    public class GetParameterJawabansByIndikatorNameQueryHandler : IRequestHandler<GetParameterJawabansByIndikatorNameRequest, GetParameterJawabansByIndikatorNameResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetParameterJawabansByIndikatorNameQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetParameterJawabansByIndikatorNameResponse> Handle(GetParameterJawabansByIndikatorNameRequest request, CancellationToken cancellationToken)
        {
            var result = new GetParameterJawabansByIndikatorNameResponse();

            try
            {
                var records = await _context.ParameterJawabans
                    .AsNoTracking()
                    .Include(a => a.ParameterIndikator)
                    .Where(x => x.ParameterIndikator.Name.Contains(request.ParameterIndikatorName))
                    .ToListAsync(cancellationToken);

                if (records.Count > 0)
                {
                    foreach (var record in records)
                    {
                        var data = new ParameterJawabanDTO
                        {
                            ParameterJawabanID = record.ParameterJawabanID,
                            ParameterIndikatorID = record.ParameterIndikatorID,
                            Name = record.Name
                        };

                        if (data != null)
                            result.ParameterJawabans.Add(data);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
}