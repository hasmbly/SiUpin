using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SiUpin.Application.Common;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.Systems.Commands.SeedSatuan;

namespace SiUpin.Application.Systems.Commands.SeedSatuan
{
    public class SeedSatuanCommandHandler : IRequestHandler<SeedSatuanRequest, SeedSatuanResponse>
    {
        private readonly ISiUpinDBContext _context;
        private readonly IFileService _fileService;

        public SeedSatuanCommandHandler(ISiUpinDBContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<SeedSatuanResponse> Handle(SeedSatuanRequest request, CancellationToken cancellationToken)
        {
            var result = new SeedSatuanResponse();

            var dataJSON = _fileService.ReadJSONFile<SatuanJSON>(FilePath.SatuanJSON);

            List<Satuan> satuans = new List<Satuan>();

            var listDataJSON = dataJSON.rows.ToList();

            foreach (var data in listDataJSON)
            {
                Satuan satuan = new Satuan();

                satuan = satuans
                    .SingleOrDefault(x => x.SatuanID == data.id_satuan);

                if (satuan == null)
                {
                    satuan = new Satuan
                    {
                        Name = data.nama_satuan
                    };

                    satuans.Add(satuan);

                    _context.Satuans.Add(satuan);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}