using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.Systems.Commands.SeedProvinsi;

namespace SiUpin.Application.Systems.Commands.SeedProvinsi
{
    public class SeedProvinsiCommandHandler : IRequestHandler<SeedProvinsiRequest, SeedProvinsiResponse>
    {
        private readonly ISiUpinDBContext _context;
        private readonly IEntityRepository _entityRepository;

        public SeedProvinsiCommandHandler(ISiUpinDBContext context, IEntityRepository entityRepository)
        {
            _context = context;
            _entityRepository = entityRepository;
        }

        public async Task<SeedProvinsiResponse> Handle(SeedProvinsiRequest request, CancellationToken cancellationToken)
        {
            var result = new SeedProvinsiResponse();

            var dataOld = await _entityRepository.GetAllProvinsi();

            List<Provinsi> provinsis = await _context.Provinsis.ToListAsync(cancellationToken);

            foreach (var data in dataOld)
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