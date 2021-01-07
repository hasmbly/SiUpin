using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.UphProduksis.Commands;

namespace SiUpin.Application.UphProduksis.Commands
{
    public class CreateUphProduksiCommand : IRequestHandler<CreateUphProduksiRequest, CreateUphProduksiResponse>
    {
        private readonly ISiUpinDBContext _context;

        public CreateUphProduksiCommand(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<CreateUphProduksiResponse> Handle(CreateUphProduksiRequest request, CancellationToken cancellationToken)
        {
            var result = new CreateUphProduksiResponse();

            var entity = new UphProduksi
            {
                UphID = request.UphID,

                sertifikat = string.Join(",", request.sertifikats),
                jml_sertifikat = request.sertifikats.Count().ToString(),

                bahan_baku = request.bahan_baku,
                jml_produksi = request.jml_produksi,
                satuan = request.satuan,
                jml_hari_produksi = request.jml_hari_produksi,
                izin_edar = request.izin_edar,
            };

            await _context.UphProduksis.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);

            result.UphProduksiID = entity.UphProduksiID;

            return result;
        }
    }
}