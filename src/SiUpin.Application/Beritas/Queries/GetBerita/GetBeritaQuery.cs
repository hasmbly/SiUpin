using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Beritas.Queries.GetBerita;
using static SiUpin.Shared.Common.Constants;

namespace SiUpin.Application.Beritas.Queries.GetBerita
{
    public class GetBeritaQuery : IRequestHandler<GetBeritaRequest, GetBeritaResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetBeritaQuery(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetBeritaResponse> Handle(GetBeritaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var record = await _context.Beritas.AsNoTracking().FirstOrDefaultAsync(x => x.BeritaID == request.BeritaID, cancellationToken);

                var file = await _context.Files
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.EntityID == record.BeritaID && x.EntityType == FileEntityType.Berita, cancellationToken);

                string fileName = file != null && !string.IsNullOrEmpty(file.Name) ?
                    $"images/{file.Name}" : $"images/image_not_available.png";

                return new GetBeritaResponse
                {
                    BeritaID = record.BeritaID,
                    UrlOriginPhoto = fileName,
                    Title = string.IsNullOrEmpty(record.Title) ? "Unknown" : record.Title,
                    Description = record.Description,
                    Created = record.Created
                };
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}