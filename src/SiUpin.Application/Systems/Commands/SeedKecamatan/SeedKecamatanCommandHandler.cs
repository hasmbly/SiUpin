using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.Systems.Commands.SeedKecamatan;

namespace SiUpin.Application.Systems.Commands.SeedKecamatan
{
    public class SeedKecamatanCommandHandler : IRequestHandler<SeedKecamatanRequest, SeedKecamatanResponse>
    {
        private readonly ISiUpinDBContext _context;
        private readonly IEntityRepository _entityRepository;

        public SeedKecamatanCommandHandler(ISiUpinDBContext context, IEntityRepository entityRepository)
        {
            _context = context;
            _entityRepository = entityRepository;
        }

        public async Task<SeedKecamatanResponse> Handle(SeedKecamatanRequest request, CancellationToken cancellationToken)
        {
            var result = new SeedKecamatanResponse();

            var dataOld = await _entityRepository.GetAllKecamatan();

            List<Kecamatan> Kecamatans = await _context.Kecamatans.ToListAsync(cancellationToken);

            var kotas = await _context.Kotas
                .ToListAsync(cancellationToken);

            foreach (var data in dataOld)
            {
                Kecamatan Kecamatan = new Kecamatan();

                Kecamatan = Kecamatans
                    .SingleOrDefault(x => x.id_kecamatan == data.id_kecamatan);

                if (Kecamatan == null)
                {
                    System.Console.WriteLine($"siupin - kecamatan doAdd(): {data.nama_kecamatan} ({data.id_kecamatan})");

                    string kotaID = kotas.Where(x => x.id_kota == data.id_kota_fk).FirstOrDefault().KotaID ?? "";

                    Kecamatan = new Kecamatan
                    {
                        id_kecamatan = data.id_kecamatan,
                        KotaID = kotaID,
                        Name = data.nama_kecamatan
                    };

                    _context.Kecamatans.Add(Kecamatan);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            result.IsSuccessful = true;

            return result;
        }
    }
}