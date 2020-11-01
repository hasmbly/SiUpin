using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.Systems.Commands.SeedParameterIndikator;

namespace SiUpin.Application.Systems.Commands.SeedParameterIndikator
{
    public class SeedParameterIndikatorCommandHandler : IRequestHandler<SeedParameterIndikatorRequest, SeedParameterIndikatorResponse>
    {
        private readonly ISiUpinDBContext _context;
        private readonly IFileService _fileService;

        public SeedParameterIndikatorCommandHandler(ISiUpinDBContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<SeedParameterIndikatorResponse> Handle(SeedParameterIndikatorRequest request, CancellationToken cancellationToken)
        {
            var result = new SeedParameterIndikatorResponse();

            var dataJSON = _fileService.ReadJSONFile<ParameterIndikatorJSON>(FilePath.ParameterIndikatorJSON);

            // this is temporary just to make sure there is no duplicate data
            List<ParameterIndikator> ParameterIndikators = new List<ParameterIndikator>();

            var listDataJSON = dataJSON.rows.ToList();

            // collect provinsi's data from db to temporary List
            var parentData = await _context.ParameterKriterias
                .ToListAsync(cancellationToken);

            foreach (var data in listDataJSON)
            {
                ParameterIndikator ParameterIndikator = new ParameterIndikator();

                ParameterIndikator = ParameterIndikators
                    .SingleOrDefault(x => x.id_indikator == data.id_indikator);

                if (ParameterIndikator == null)
                {
                    string parentID = parentData.Where(x => x.id_kriteria == data.id_kriteria).FirstOrDefault().ParameterKriteriaID ?? "";

                    ParameterIndikator = new ParameterIndikator
                    {
                        id_indikator = data.id_indikator,
                        ParameterKriteriaID = parentID,
                        Name = data.nama_indikator
                    };

                    ParameterIndikators.Add(ParameterIndikator);

                    _context.ParameterIndikators.Add(ParameterIndikator);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}