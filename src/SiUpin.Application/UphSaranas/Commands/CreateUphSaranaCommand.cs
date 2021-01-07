using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.UphSaranas.Commands;

namespace SiUpin.Application.UphSaranas.Commands
{
    public class CreateUphSaranaCommand : IRequestHandler<CreateUphSaranaRequest, CreateUphSaranaResponse>
    {
        private readonly ISiUpinDBContext _context;

        public CreateUphSaranaCommand(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<CreateUphSaranaResponse> Handle(CreateUphSaranaRequest request, CancellationToken cancellationToken)
        {
            var result = new CreateUphSaranaResponse();

            var entity = new UphSarana
            {
                UphID = request.UphID,

                asal_bantuan = string.Join(",", request.asal_bantuans),
                lain = request.lain,

                tahun = request.tahun,
                nama_alat = request.nama_alat,
                kapasitas_terpakai = request.kapasitas_terpakai,
                kapasitas_terpasang = request.kapasitas_terpasang,
                satuan = request.satuan,
                jenis_mesin = request.jenis_mesin,
                status = request.status,

                alasan = string.Join(",", request.alasans),
                lain_alasan = request.lain_alasan,
            };

            await _context.UphSaranas.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);

            result.UphSaranaID = entity.UphSaranaID;

            return result;
        }
    }
}