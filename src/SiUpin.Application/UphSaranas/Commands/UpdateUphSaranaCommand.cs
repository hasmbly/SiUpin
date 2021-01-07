using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.UphSaranas.Commands;

namespace SiUpin.Application.UphSaranas.Commands
{
    public class UpdateUphSaranaCommand : IRequestHandler<UpdateUphSaranaRequest, UpdateUphSaranaResponse>
    {
        private readonly ISiUpinDBContext _context;

        public UpdateUphSaranaCommand(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<UpdateUphSaranaResponse> Handle(UpdateUphSaranaRequest request, CancellationToken cancellationToken)
        {
            var result = new UpdateUphSaranaResponse();

            var entity = await _context.UphSaranas
                .FirstOrDefaultAsync(x => x.UphSaranaID == request.UphSaranaID, cancellationToken);

            entity.UphSaranaID = request.UphSaranaID;
            entity.UphID = request.UphID;

            entity.asal_bantuan = string.Join(",", request.asal_bantuans);
            entity.lain = request.lain;

            entity.tahun = request.tahun;
            entity.nama_alat = request.nama_alat;
            entity.kapasitas_terpakai = request.kapasitas_terpakai;
            entity.kapasitas_terpasang = request.kapasitas_terpasang;
            entity.satuan = request.satuan;
            entity.jenis_mesin = request.jenis_mesin;
            entity.status = request.status;

            entity.alasan = string.Join(",", request.alasans);
            entity.lain_alasan = request.lain_alasan;

            await _context.SaveChangesAsync(cancellationToken);

            result.UphSaranaID = entity.UphSaranaID;

            return result;
        }
    }
}