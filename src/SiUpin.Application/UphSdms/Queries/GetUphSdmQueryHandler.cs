using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Constants;
using SiUpin.Shared.UphSdms.Queries;

namespace SiUpin.Application.UphSdms.Queries
{
    public class GetUphSdmQueryHandler : IRequestHandler<GetUphSdmRequest, GetUphSdmResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetUphSdmQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetUphSdmResponse> Handle(GetUphSdmRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var record = await _context.UphSdms
                    .AsNoTracking()
                    .Include(a => a.Uph)
                    .FirstOrDefaultAsync(x => x.UphSdmID == request.UphSdmID, cancellationToken);

                if (record != null)
                {
                    var data = record;

                    return new GetUphSdmResponse
                    {
                        UphSdmID = data.UphSdmID,
                        UphID = data.UphID,

                        jml_sdm = data.jml_sdm,
                        struktur_modal = data.struktur_modal,

                        sop = data.sop,
                        sops = data.sop.Replace(", ", ",").Split(",").ToList(),

                        sumber_modal = data.sumber_modal,
                        sumber_modals = data.sumber_modal.Replace(", ", ",").Split(",").ToList(),
                        jml_modal = data.jml_modal,

                        nama_pelatihan = data.nama_pelatihan,
                        penyelenggara = data.penyelenggara,
                        lokasi = data.lokasi,
                        tahun = data.tahun,

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