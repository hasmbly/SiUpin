using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Constants;
using SiUpin.Shared.UphPasars.Queries;

namespace SiUpin.Application.UphPasars.Queries
{
    public class GetUphPasarQueryHandler : IRequestHandler<GetUphPasarRequest, GetUphPasarResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetUphPasarQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetUphPasarResponse> Handle(GetUphPasarRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var record = await _context.UphPasars
                    .AsNoTracking()
                    .Include(a => a.Uph)
                    .FirstOrDefaultAsync(x => x.UphPasarID == request.UphPasarID, cancellationToken);

                if (record != null)
                {
                    var data = record;

                    return new GetUphPasarResponse
                    {
                        UphPasarID = data.UphPasarID,
                        UphID = data.UphID,

                        mekanisme = data.mekanisme,
                        mekanismes = data.mekanisme.Replace(", ", ",").Split(",").ToList(),
                        nilai_mekanisme = data.nilai_mekanisme,
                        lain = data.lain,

                        jangkauan = data.jangkauan,
                        jml_penjualan = data.jml_penjualan,
                        omset = data.omset,

                        Uph = new Shared.Uphs.Common.UphDTO
                        {
                            Name = data.Uph?.Name
                        },
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