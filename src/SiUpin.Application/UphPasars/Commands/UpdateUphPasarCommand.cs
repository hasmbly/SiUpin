using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.UphPasars.Commands;

namespace SiUpin.Application.UphPasars.Commands
{
    public class UpdateUphPasarCommand : IRequestHandler<UpdateUphPasarRequest, UpdateUphPasarResponse>
    {
        private readonly ISiUpinDBContext _context;

        public UpdateUphPasarCommand(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<UpdateUphPasarResponse> Handle(UpdateUphPasarRequest request, CancellationToken cancellationToken)
        {
            var result = new UpdateUphPasarResponse();

            var entity = await _context.UphPasars
                .FirstOrDefaultAsync(x => x.UphPasarID == request.UphPasarID, cancellationToken);

            entity.UphPasarID = request.UphPasarID;
            entity.UphID = request.UphID;
            entity.mekanisme = string.Join(",", request.mekanismes);
            entity.nilai_mekanisme = request.mekanismes.Count().ToString();
            entity.jangkauan = request.jangkauan;
            entity.jml_penjualan = request.jml_penjualan;
            entity.omset = request.omset;
            entity.lain = request.lain;

            await _context.SaveChangesAsync(cancellationToken);

            result.UphPasarID = entity.UphPasarID;

            return result;
        }
    }
}