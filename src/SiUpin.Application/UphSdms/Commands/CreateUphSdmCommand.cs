using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.UphSdms.Commands;

namespace SiUpin.Application.UphSdms.Commands
{
    public class CreateUphSdmCommand : IRequestHandler<CreateUphSdmRequest, CreateUphSdmResponse>
    {
        private readonly ISiUpinDBContext _context;

        public CreateUphSdmCommand(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<CreateUphSdmResponse> Handle(CreateUphSdmRequest request, CancellationToken cancellationToken)
        {
            var result = new CreateUphSdmResponse();

            var entity = new UphSdm
            {
                UphID = request.UphID,

                jml_sdm = request.jml_sdm,
                struktur_modal = request.struktur_modal,

                sop = string.Join(",", request.sops),

                sumber_modal = string.Join(",", request.sumber_modals),
                jml_modal = request.sumber_modals.Count().ToString(),

                nama_pelatihan = request.nama_pelatihan,
                penyelenggara = request.penyelenggara,
                lokasi = request.lokasi,
                tahun = request.tahun,
            };

            await _context.UphSdms.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);

            result.UphSdmID = entity.UphSdmID;

            return result;
        }
    }
}