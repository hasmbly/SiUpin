using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SiUpin.Application.Common;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.Systems.Commands.SeedParameterAspek;

namespace SiUpin.Application.Systems.Commands.SeedParameterAspek
{
    public class SeedParameterAspekCommandHandler : IRequestHandler<SeedParameterAspekRequest, SeedParameterAspekResponse>
    {
        private readonly ISiUpinDBContext _context;
        private readonly IFileService _fileService;

        public SeedParameterAspekCommandHandler(ISiUpinDBContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<SeedParameterAspekResponse> Handle(SeedParameterAspekRequest request, CancellationToken cancellationToken)
        {
            var result = new SeedParameterAspekResponse();

            var dataJSON = _fileService.ReadJSONFile<ParameterAspekJSON>(FilePath.ParameterAspekJSON);

            List<ParameterAspek> parameterAspeks = new List<ParameterAspek>();

            var listDataJSON = dataJSON.rows.ToList();

            foreach (var data in listDataJSON)
            {
                ParameterAspek parameterAspek = new ParameterAspek();

                parameterAspek = parameterAspeks
                    .SingleOrDefault(x => x.ParameterAspekID == data.id_aspek);

                if (parameterAspek == null)
                {
                    parameterAspek = new ParameterAspek
                    {
                        Name = data.nama_aspek,
                        id_aspek = data.id_aspek
                    };

                    parameterAspeks.Add(parameterAspek);

                    _context.ParameterAspeks.Add(parameterAspek);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}