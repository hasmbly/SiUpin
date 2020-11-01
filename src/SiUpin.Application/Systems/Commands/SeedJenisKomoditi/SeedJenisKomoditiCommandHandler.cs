using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SiUpin.Application.Common;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.Systems.Commands.SeedJenisKomoditi;

namespace SiUpin.Application.Systems.Commands.SeedJenisKomoditi
{
    public class SeedJenisKomoditiCommandHandler : IRequestHandler<SeedJenisKomoditiRequest, SeedJenisKomoditiResponse>
    {
        private readonly ISiUpinDBContext _context;
        private readonly IFileService _fileService;

        public SeedJenisKomoditiCommandHandler(ISiUpinDBContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<SeedJenisKomoditiResponse> Handle(SeedJenisKomoditiRequest request, CancellationToken cancellationToken)
        {
            var result = new SeedJenisKomoditiResponse();

            var dataJSON = _fileService.ReadJSONFile<JenisKomoditiJSON>(FilePath.JenisKomoditiJSON);

            List<JenisKomoditi> entities = new List<JenisKomoditi>();

            var listDataJSON = dataJSON.rows.ToList();

            foreach (var data in listDataJSON)
            {
                JenisKomoditi entity = new JenisKomoditi();

                entity = entities
                    .SingleOrDefault(x => x.JenisKomoditiID == data.id_komoditi);

                if (entity == null)
                {
                    entity = new JenisKomoditi
                    {
                        Name = data.nama_komoditi,
                        id_komoditi = data.id_komoditi
                    };

                    entities.Add(entity);

                    _context.JenisKomoditis.Add(entity);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            result.IsSuccessful = true;

            return result;
        }
    }
}