using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SiUpin.Application.Common;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.Systems.Commands.SeedProvinsi;

namespace SiUpin.Application.Systems.Commands.SeedProvinsi
{
    public class SeedProvinsiCommandHandler : IRequestHandler<SeedProvinsiRequest, SeedProvinsiResponse>
    {
        private readonly ISiUpinDBContext _context;
        private readonly IFileService _fileService;

        public SeedProvinsiCommandHandler(ISiUpinDBContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<SeedProvinsiResponse> Handle(SeedProvinsiRequest request, CancellationToken cancellationToken)
        {
            var result = new SeedProvinsiResponse();

            var dataJSON = _fileService.ReadJSONFile<ProvinsiJSON>(FilePath.ProvinsiJSON);

            // this is temporary just to make sure there is no duplicate data
            List<Provinsi> provinsis = new List<Provinsi>();

            var listDataJSON = dataJSON.rows.ToList();

            foreach (var data in listDataJSON)
            {
                Provinsi provinsi = new Provinsi();

                provinsi = provinsis
                    .SingleOrDefault(x => x.id_provinsi == data.id_provinsi);

                if (provinsi == null)
                {
                    provinsi = new Provinsi
                    {
                        id_provinsi = data.id_provinsi,
                        Name = data.nama_provinsi
                    };

                    provinsis.Add(provinsi);

                    _context.Provinsis.Add(provinsi);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            result.IsSuccessful = true;

            return result;
        }
    }
}