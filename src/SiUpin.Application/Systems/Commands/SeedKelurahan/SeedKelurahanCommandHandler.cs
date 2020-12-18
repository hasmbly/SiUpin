using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.Systems.Commands.SeedKelurahan;

namespace SiUpin.Application.Systems.Commands.SeedKelurahan
{
    public class SeedKelurahanCommandHandler : IRequestHandler<SeedKelurahanRequest, SeedKelurahanResponse>
    {
        private readonly ISiUpinDBContext _context;
        private readonly IEntityRepository _entityRepository;

        public SeedKelurahanCommandHandler(ISiUpinDBContext context, IEntityRepository entityRepository)
        {
            _context = context;
            _entityRepository = entityRepository;
        }

        public async Task<SeedKelurahanResponse> Handle(SeedKelurahanRequest request, CancellationToken cancellationToken)
        {
            var result = new SeedKelurahanResponse();

            var dataOld = await _entityRepository.GetAllKelurahan();

            List<Kelurahan> Kelurahans = await _context.Kelurahans.ToListAsync(cancellationToken);

            var kecamatans = await _context.Kecamatans
                .ToListAsync(cancellationToken);

            foreach (var data in dataOld)
            {
                Kelurahan Kelurahan = new Kelurahan();

                Kelurahan = Kelurahans
                    .SingleOrDefault(x => x.id_kelurahan == data.id_kelurahan);

                if (Kelurahan == null)
                {
                    System.Console.WriteLine($"siupin - kelurahan doAdd(): {data.nama_kelurahan} ({data.id_kelurahan})");

                    string kecamatanID = kecamatans.Where(x => x.id_kecamatan == data.id_kecamatan_fk).FirstOrDefault().KecamatanID ?? "";

                    Kelurahan = new Kelurahan
                    {
                        id_kelurahan = data.id_kelurahan,
                        KecamatanID = kecamatanID,
                        Name = data.nama_kelurahan
                    };

                    _context.Kelurahans.Add(Kelurahan);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            result.IsSuccessful = true;

            return result;
        }
    }
}