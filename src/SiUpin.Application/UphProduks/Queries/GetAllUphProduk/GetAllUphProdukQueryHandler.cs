using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.Common;
using SiUpin.Shared.Common.Pagination;
using SiUpin.Shared.Constants;
using SiUpin.Shared.UphProduks.Queries.GetAllUphProduk;

namespace SiUpin.Application.Uphs.Queries.GetAllUphProduk
{
    public class GetAllUphProdukQueryHandler : IRequestHandler<GetAllUphProdukRequest, GetAllUphProdukResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetAllUphProdukQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetAllUphProdukResponse> Handle(GetAllUphProdukRequest request, CancellationToken cancellationToken)
        {
            try
            {
                List<UphProduk> records;
                List<File> files;

                int totalRecords;

                if (!string.IsNullOrEmpty(request.FilterJenisKomoditiID))
                {
                    records = await _context.UphProduks
                        .AsNoTracking()
                        .Include(u => u.Uph).ThenInclude(p => p.Provinsi)
                        .Include(a => a.ProdukOlahan).ThenInclude(b => b.JenisKomoditi)
                        .Where(x => x.Name.Contains(request.FilterByName ?? "") &&
                                x.ProdukOlahan.JenisKomoditi.JenisKomoditiID == request.FilterJenisKomoditiID)
                        .Skip((request.PageNumber - 1) * request.PageSize)
                        .Take(request.PageSize)
                        .ToListAsync(cancellationToken);

                    var photos = await _context.Files.AsNoTracking().ToListAsync(cancellationToken);

                    totalRecords = _context.UphProduks
                        .AsNoTracking()
                        .Include(a => a.ProdukOlahan).ThenInclude(b => b.JenisKomoditi)
                        .Where(x => x.Name.Contains(request.FilterByName ?? "") &&
                                x.ProdukOlahan.JenisKomoditi.JenisKomoditiID == request.FilterJenisKomoditiID)
                        .Count();
                }
                else
                {
                    records = await _context.UphProduks
                        .AsNoTracking()
                        .Include(u => u.Uph).ThenInclude(p => p.Provinsi)
                        .Include(a => a.ProdukOlahan).ThenInclude(b => b.JenisKomoditi)
                        .Where(x => x.Name.Contains(request.FilterByName ?? ""))
                        .Skip((request.PageNumber - 1) * request.PageSize)
                        .Take(request.PageSize)
                        .ToListAsync(cancellationToken);

                    totalRecords = _context.UphProduks.AsNoTracking().Count(x => x.Name.Contains(request.FilterByName ?? ""));
                }

                files = await _context.Files.Where(x => x.EntityType == Constants.File.EntityType.UPH_PRODUK).ToListAsync(cancellationToken);

                List<UphProdukDTO> listOfDTO = new List<UphProdukDTO>();

                if (records.Count() > 0)
                {
                    foreach (var record in records)
                    {
                        var file = files.Where(x => x.EntityID == record.UphProdukID).FirstOrDefault();
                        string fileName = file != null ? $"images/{file.Name}" : $"images/image_not_available.png";

                        UphProdukDTO dto = new UphProdukDTO
                        {
                            UphProdukID = record.UphProdukID,
                            UrlOriginPhoto = fileName,
                            Name = string.IsNullOrEmpty(record.Name) ? "Unknown" : record.Name,
                            Harga = string.IsNullOrEmpty(record.Harga) ? "Rp 0" : $"Rp{record.Harga}",
                            Provinsi = record.Uph.Provinsi?.Name
                        };

                        if (dto != null)
                            listOfDTO.Add(dto);
                    }
                }
                else
                {
                    throw new Exception(ErrorMessage.DataNotFound);
                }

                return new GetAllUphProdukResponse
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}