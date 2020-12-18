using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SiUpin.Application.Common;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.Systems.Commands.SeedBerita;
using SiUpin.Shared.Systems.Commands.SeedFile;

namespace SiUpin.Application.Systems.Commands.SeedBerita
{
    public class SeedBeritaCommandHandler : IRequestHandler<SeedBeritaRequest, SeedBeritaResponse>
    {
        private readonly ISiUpinDBContext _context;
        private readonly IFileService _fileService;
        private IMediator _mediator;

        public SeedBeritaCommandHandler(ISiUpinDBContext context, IFileService fileService, IMediator mediator)
        {
            _context = context;
            _fileService = fileService;
            _mediator = mediator;
        }

        public async Task<SeedBeritaResponse> Handle(SeedBeritaRequest request, CancellationToken cancellationToken)
        {
            var result = new SeedBeritaResponse();

            var dataJSON = _fileService.ReadJSONFile<BeritaJSON>(FilePath.BeritaJSON);

            List<Berita> beritas = new List<Berita>();

            var listDataJSON = dataJSON.rows.ToList();

            foreach (var data in listDataJSON)
            {
                Berita berita = new Berita();

                berita = beritas
                    .SingleOrDefault(x => x.id_berita == data.id_berita);

                if (berita == null)
                {
                    berita = new Berita
                    {
                        Title = data.judul,
                        Created = DateTimeOffset.Parse(data.tanggal),
                        Description = data.uraian,
                        id_berita = data.id_berita
                    };

                    beritas.Add(berita);

                    _context.Beritas.Add(berita);

                    await _context.SaveChangesAsync(cancellationToken);

                    if (!string.IsNullOrEmpty(data.foto))
                    {
                        await _mediator.Send(new SeedFileRequest()
                        {
                            EntityID = berita.BeritaID,
                            EntityType = "BERITA",
                            Name = data.foto
                        });
                    }
                }
            }

            result.IsSuccessful = true;

            return result;
        }
    }
}