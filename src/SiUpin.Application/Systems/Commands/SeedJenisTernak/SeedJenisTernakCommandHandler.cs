using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SiUpin.Application.Common;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.Systems.Commands.SeedJenisTernak;

namespace SiUpin.Application.Systems.Commands.SeedJenisTernak
{
    public class SeedJenisTernakCommandHandler : IRequestHandler<SeedJenisTernakRequest, SeedJenisTernakResponse>
    {
        private readonly ISiUpinDBContext _context;
        private readonly IFileService _fileService;

        public SeedJenisTernakCommandHandler(ISiUpinDBContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<SeedJenisTernakResponse> Handle(SeedJenisTernakRequest request, CancellationToken cancellationToken)
        {
            var result = new SeedJenisTernakResponse();

            var dataJSON = _fileService.ReadJSONFile<JenisTernakJSON>(FilePath.JenisTernakJSON);

            List<JenisTernak> jenisTernaks = new List<JenisTernak>();

            var listDataJSON = dataJSON.rows.ToList();

            foreach (var data in listDataJSON)
            {
                JenisTernak jenisTernak = new JenisTernak();

                jenisTernak = jenisTernaks
                    .SingleOrDefault(x => x.JenisTernakID == data.id_ternak);

                if (jenisTernak == null)
                {
                    jenisTernak = new JenisTernak
                    {
                        Name = data.nama_ternak,
                        id_ternak = data.id_ternak
                    };

                    jenisTernaks.Add(jenisTernak);

                    _context.JenisTernaks.Add(jenisTernak);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            result.IsSuccessful = true;

            return result;
        }
    }
}