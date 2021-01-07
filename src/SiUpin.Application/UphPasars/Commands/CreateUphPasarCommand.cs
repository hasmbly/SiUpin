using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.UphPasars.Commands;

namespace SiUpin.Application.UphPasars.Commands
{
    public class CreateUphPasarCommand : IRequestHandler<CreateUphPasarRequest, CreateUphPasarResponse>
    {
        private readonly ISiUpinDBContext _context;

        public CreateUphPasarCommand(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<CreateUphPasarResponse> Handle(CreateUphPasarRequest request, CancellationToken cancellationToken)
        {
            var result = new CreateUphPasarResponse();

            var entity = new UphPasar
            {
                UphID = request.UphID,

                mekanisme = string.Join(",", request.mekanismes),
                nilai_mekanisme = request.mekanismes.Count().ToString(),

                jangkauan = request.jangkauan,
                jml_penjualan = request.jml_penjualan,
                omset = request.omset,
            };

            await _context.UphPasars.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);

            result.UphPasarID = entity.UphPasarID;

            return result;
        }
    }
}