using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.Beritas.Queries.GetBeritas;
using SiUpin.Shared.Common;
using SiUpin.Shared.Common.Pagination;

namespace SiUpin.Application.Beritas.Queries.GetBeritas
{
    public class GetBeritasQueryHandler : IRequestHandler<GetBeritasRequest, GetBeritasResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetBeritasQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetBeritasResponse> Handle(GetBeritasRequest request, CancellationToken cancellationToken)
        {
            try
            {
                List<Berita> records;
                List<File> files;

                int totalRecords;

                records = await _context.Beritas
                    .AsNoTracking()
                    .Where(x => x.Title.Contains(request.FilterByName ?? ""))
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync(cancellationToken);

                totalRecords = _context.Beritas.AsNoTracking().Count(x => x.Title.Contains(request.FilterByName ?? ""));

                files = await _context.Files.Where(x => x.EntityType == Constants.File.EntityType.BERITA).ToListAsync(cancellationToken);

                List<BeritaDTO> listOfDTO = new List<BeritaDTO>();

                foreach (var record in records)
                {
                    var file = files.Where(x => x.EntityID == record.BeritaID).FirstOrDefault();
                    string fileName = file != null ? $"images/{file.Name}" : $"images/image_not_available.png";

                    BeritaDTO dto = new BeritaDTO
                    {
                        BeritaID = record.BeritaID,
                        UrlOriginPhoto = fileName,
                        Title = string.IsNullOrEmpty(record.Title) ? "Unknown" : record.Title
                    };

                    if (dto != null)
                        listOfDTO.Add(dto);
                }

                return new GetBeritasResponse
                {
                    Data = listOfDTO,
                    Pagination = new PaginationResponse()
                    {
                        TotalCount = totalRecords,
                        PageSize = request.PageSize,
                        CurrentPage = request.PageNumber
                    }
                };
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}