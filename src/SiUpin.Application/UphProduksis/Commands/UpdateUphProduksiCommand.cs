using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.UphProduksis.Commands;

namespace SiUpin.Application.UphProduksis.Commands
{
    public class UpdateUphProduksiCommand : IRequestHandler<UpdateUphProduksiRequest, UpdateUphProduksiResponse>
    {
        private readonly ISiUpinDBContext _context;

        public UpdateUphProduksiCommand(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<UpdateUphProduksiResponse> Handle(UpdateUphProduksiRequest request, CancellationToken cancellationToken)
        {
            var result = new UpdateUphProduksiResponse();

            var entity = await _context.UphProduksis
                .FirstOrDefaultAsync(x => x.UphProduksiID == request.UphProduksiID, cancellationToken);

            entity.UphProduksiID = request.UphProduksiID;
            entity.UphID = request.UphID;

            entity.sertifikat = string.Join(",", request.sertifikats);
            entity.jml_sertifikat = request.sertifikats.Count().ToString();

            entity.bahan_baku = request.bahan_baku;
            entity.jml_produksi = request.jml_produksi;
            entity.satuan = request.satuan;
            entity.jml_hari_produksi = request.jml_hari_produksi;
            entity.izin_edar = request.izin_edar;

            await _context.SaveChangesAsync(cancellationToken);

            result.UphProduksiID = entity.UphProduksiID;

            return result;
        }
    }
}