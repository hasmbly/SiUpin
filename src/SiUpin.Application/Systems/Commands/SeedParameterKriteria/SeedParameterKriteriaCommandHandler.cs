using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.Systems.Commands.SeedParameterKriteria;

namespace SiUpin.Application.Systems.Commands.SeedParameterKriteria
{
    public class SeedParameterKriteriaCommandHandler : IRequestHandler<SeedParameterKriteriaRequest, SeedParameterKriteriaResponse>
    {
        private readonly ISiUpinDBContext _context;
        private readonly IFileService _fileService;

        public SeedParameterKriteriaCommandHandler(ISiUpinDBContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<SeedParameterKriteriaResponse> Handle(SeedParameterKriteriaRequest request, CancellationToken cancellationToken)
        {
            var result = new SeedParameterKriteriaResponse();

            var dataJSON = _fileService.ReadJSONFile<ParameterKriteriaJSON>(FilePath.ParameterKriteriaJSON);

            // this is temporary just to make sure there is no duplicate data
            List<ParameterKriteria> ParameterKriterias = new List<ParameterKriteria>();

            var listDataJSON = dataJSON.rows.ToList();

            // collect provinsi's data from db to temporary List
            var parentData = await _context.ParameterAspeks
                .ToListAsync(cancellationToken);

            foreach (var data in listDataJSON)
            {
                ParameterKriteria ParameterKriteria = new ParameterKriteria();

                ParameterKriteria = ParameterKriterias
                    .SingleOrDefault(x => x.id_kriteria == data.id_kriteria);

                if (ParameterKriteria == null)
                {
                    string parentID = parentData.Where(x => x.id_aspek == data.id_aspek).FirstOrDefault().ParameterAspekID ?? "";

                    ParameterKriteria = new ParameterKriteria
                    {
                        id_kriteria = data.id_kriteria,
                        ParameterAspekID = parentID,
                        Name = data.nama_kriteria
                    };

                    ParameterKriterias.Add(ParameterKriteria);

                    _context.ParameterKriterias.Add(ParameterKriteria);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}