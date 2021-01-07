using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.UphSdms.Commands;

namespace SiUpin.Application.UphSdms.Commands
{
    public class UpdateUphSdmCommand : IRequestHandler<UpdateUphSdmRequest, UpdateUphSdmResponse>
    {
        private readonly ISiUpinDBContext _context;

        public UpdateUphSdmCommand(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<UpdateUphSdmResponse> Handle(UpdateUphSdmRequest request, CancellationToken cancellationToken)
        {
            var result = new UpdateUphSdmResponse();

            var entity = await _context.UphSdms
                .FirstOrDefaultAsync(x => x.UphSdmID == request.UphSdmID, cancellationToken);

            entity.UphSdmID = request.UphSdmID;
            entity.UphID = request.UphID;

            entity.jml_sdm = request.jml_sdm;
            entity.struktur_modal = request.struktur_modal;
            entity.sop = string.Join(",", request.sops);
            entity.sumber_modal = string.Join(",", request.sumber_modals);
            entity.jml_modal = request.sumber_modals.Count().ToString();
            entity.nama_pelatihan = request.nama_pelatihan;
            entity.penyelenggara = request.penyelenggara;
            entity.lokasi = request.lokasi;
            entity.tahun = request.tahun;

            await _context.SaveChangesAsync(cancellationToken);

            result.UphSdmID = entity.UphSdmID;

            return result;
        }
    }
}