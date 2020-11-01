using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.Systems.Commands.SeedKota;

namespace SiUpin.Application.Systems.Commands.SeedKota
{
    public class SeedKotaCommandHandler : IRequestHandler<SeedKotaRequest, SeedKotaResponse>
    {
        private readonly ISiUpinDBContext _context;
        private readonly IFileService _fileService;

        public SeedKotaCommandHandler(ISiUpinDBContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<SeedKotaResponse> Handle(SeedKotaRequest request, CancellationToken cancellationToken)
        {
            var result = new SeedKotaResponse();

            var dataJSON = _fileService.ReadJSONFile<KotaJSON>(FilePath.KotaJSON);

            // this is temporary just to make sure there is no duplicate data
            List<Kota> Kotas = new List<Kota>();

            var listDataJSON = dataJSON.rows.ToList();

            // collect provinsi's data from db to temporary List
            var provinsis = await _context.Provinsis
                .ToListAsync(cancellationToken);

            foreach (var data in listDataJSON)
            {
                Kota Kota = new Kota();

                Kota = Kotas
                    .SingleOrDefault(x => x.id_kota == data.id_kota);

                if (Kota == null)
                {
                    string provinsiID = provinsis.Where(x => x.id_provinsi == data.id_provinsi_fk).FirstOrDefault().ProvinsiID ?? "";

                    Kota = new Kota
                    {
                        id_kota = data.id_kota,
                        ProvinsiID = provinsiID,
                        Name = data.nama_kota
                    };

                    Kotas.Add(Kota);

                    _context.Kotas.Add(Kota);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            result.IsSuccessful = true;

            return result;
        }
    }
}