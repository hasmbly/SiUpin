using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Constants;
using SiUpin.Shared.Uphs.Queries.GetUph;

namespace SiUpin.Application.Uphs.Queries.GetUph
{
    public class GetUphQueryHandler : IRequestHandler<GetUphRequest, GetUphResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetUphQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetUphResponse> Handle(GetUphRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var records = await _context.Uphs
                    .AsNoTracking()
                    .Include(p => p.Provinsi)
                    .Include(k => k.Kota)
                    .Include(kec => kec.Kecamatan)
                    .Include(kel => kel.Kelurahan)
                    .Where(x => x.UphID == request.UphID)
                    .SingleOrDefaultAsync(cancellationToken);

                if (records == null)
                    throw new Exception(ErrorMessage.DataNotFound);

                return new GetUphResponse
                {
                    UphID = !string.IsNullOrEmpty(records.UphID) ? records.UphID : "-",
                    Name = !string.IsNullOrEmpty(records.Name) ? records.Name : "-",
                    Ketua = !string.IsNullOrEmpty(records.Ketua) ? records.Ketua : "-",
                    Handphone = !string.IsNullOrEmpty(records.Handphone) ? records.Handphone : "-",
                    Alamat = !string.IsNullOrEmpty(records.Alamat) ? records.Alamat : "-",
                    TahunBerdiri = !string.IsNullOrEmpty(records.TahunBerdiri) ? records.TahunBerdiri : "-",

                    Provinsi = records.Provinsi?.Name ?? "-",
                    Kota = records.Kota?.Name ?? "-",
                    Kecamatan = records.Kecamatan?.Name ?? "-",
                    Kelurahan = records.Kelurahan?.Name ?? "-"
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}