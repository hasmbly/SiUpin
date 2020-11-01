using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SiUpin.Application.Common;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.Systems.Commands.SeedAsalBantuan;

namespace SiUpin.Application.Systems.Commands.SeedAsalBantuan
{
    public class SeedAsalBantuanCommandHandler : IRequestHandler<SeedAsalBantuanRequest, SeedAsalBantuanResponse>
    {
        private readonly ISiUpinDBContext _context;
        private readonly IFileService _fileService;

        public SeedAsalBantuanCommandHandler(ISiUpinDBContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<SeedAsalBantuanResponse> Handle(SeedAsalBantuanRequest request, CancellationToken cancellationToken)
        {
            var result = new SeedAsalBantuanResponse();

            var dataJSON = _fileService.ReadJSONFile<AsalBantuanJSON>(FilePath.AsalBantuanJSON);

            List<AsalBantuan> asalBantuans = new List<AsalBantuan>();

            var listDataJSON = dataJSON.rows.ToList();

            foreach (var data in listDataJSON)
            {
                AsalBantuan asalBantuan = new AsalBantuan();

                asalBantuan = asalBantuans
                    .SingleOrDefault(x => x.AsalBantuanID == data.id_asal_bantuan);

                if (asalBantuan == null)
                {
                    asalBantuan = new AsalBantuan
                    {
                        Name = data.nama_asal_bantuan
                    };

                    asalBantuans.Add(asalBantuan);

                    _context.AsalBantuans.Add(asalBantuan);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}