using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.Systems.Commands.SeedKecamatan;

namespace SiUpin.Application.Systems.Commands.SeedKecamatan
{
    public class SeedKecamatanCommandHandler : IRequestHandler<SeedKecamatanRequest, SeedKecamatanResponse>
    {
        private readonly ISiUpinDBContext _context;
        private readonly IFileService _fileService;

        public SeedKecamatanCommandHandler(ISiUpinDBContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<SeedKecamatanResponse> Handle(SeedKecamatanRequest request, CancellationToken cancellationToken)
        {
            var result = new SeedKecamatanResponse();

            var dataJSON = _fileService.ReadJSONFile<RoleSON>(FilePath.KecamatanJSON);

            // this is temporary just to make sure there is no duplicate data
            List<Kecamatan> Kecamatans = new List<Kecamatan>();

            var listDataJSON = dataJSON.rows.ToList();

            // collect data from db to temporary List
            var kotas = await _context.Kotas
                .ToListAsync(cancellationToken);

            foreach (var data in listDataJSON)
            {
                Kecamatan Kecamatan = new Kecamatan();

                Kecamatan = Kecamatans
                    .SingleOrDefault(x => x.id_kecamatan == data.id_kecamatan);

                if (Kecamatan == null)
                {
                    string kotaID = kotas.Where(x => x.id_kota == data.id_kota_fk).FirstOrDefault().KotaID ?? "";

                    Kecamatan = new Kecamatan
                    {
                        id_kecamatan = data.id_kecamatan,
                        KotaID = kotaID,
                        Name = data.nama_kecamatan
                    };

                    Kecamatans.Add(Kecamatan);

                    _context.Kecamatans.Add(Kecamatan);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            result.IsSuccessful = true;

            return result;
        }
    }
}