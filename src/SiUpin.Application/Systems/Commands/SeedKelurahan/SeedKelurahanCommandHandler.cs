using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.Systems.Commands.SeedKelurahan;

namespace SiUpin.Application.Systems.Commands.SeedKelurahan
{
    public class SeedKelurahanCommandHandler : IRequestHandler<SeedKelurahanRequest, SeedKelurahanResponse>
    {
        private readonly ISiUpinDBContext _context;
        private readonly IFileService _fileService;

        public SeedKelurahanCommandHandler(ISiUpinDBContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<SeedKelurahanResponse> Handle(SeedKelurahanRequest request, CancellationToken cancellationToken)
        {
            var result = new SeedKelurahanResponse();

            var dataJSON = _fileService.ReadJSONFile<KelurahanJSON>(FilePath.KelurahanJSON);

            // this is temporary just to make sure there is no duplicate data
            List<Kelurahan> Kelurahans = new List<Kelurahan>();

            var listDataJSON = dataJSON.rows.ToList();

            // collect data from db to temporary List
            var kecamatans = await _context.Kecamatans
                .ToListAsync(cancellationToken);

            foreach (var data in listDataJSON)
            {
                Kelurahan Kelurahan = new Kelurahan();

                Kelurahan = Kelurahans
                    .SingleOrDefault(x => x.id_kelurahan == data.id_kelurahan);

                if (Kelurahan == null)
                {
                    string kecamatanID = kecamatans.Where(x => x.id_kecamatan == data.id_kecamatan_fk).FirstOrDefault().KecamatanID ?? "";

                    Kelurahan = new Kelurahan
                    {
                        id_kelurahan = data.id_kelurahan,
                        KecamatanID = kecamatanID,
                        Name = data.nama_kelurahan
                    };

                    Kelurahans.Add(Kelurahan);

                    _context.Kelurahans.Add(Kelurahan);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            result.IsSuccessful = true;

            return result;
        }
    }
}