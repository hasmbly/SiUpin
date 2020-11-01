using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.Systems.Commands.SeedFile;

namespace SiUpin.Application.Systems.Commands.SeedFile
{
    public class SeedFileCommandHandler : IRequestHandler<SeedFileRequest, SeedFileResponse>
    {
        private readonly ISiUpinDBContext _context;
        private readonly IFileService _fileService;

        public SeedFileCommandHandler(ISiUpinDBContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<SeedFileResponse> Handle(SeedFileRequest request, CancellationToken cancellationToken)
        {
            var result = new SeedFileResponse();

            File file = new File
            {
                EntityID = request.EntityID,
                EntityType = request.EntityType,
                Name = request.Name
            };

            _context.Files.Add(file);

            await _context.SaveChangesAsync(cancellationToken);

            result.IsSuccessful = true;

            return result;
        }
    }
}