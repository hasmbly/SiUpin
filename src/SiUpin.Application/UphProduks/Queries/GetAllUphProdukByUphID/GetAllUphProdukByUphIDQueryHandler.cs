﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.Common.Pagination;
using SiUpin.Shared.Constants;
using SiUpin.Shared.UphProduks.Queries.GetAllUphProdukByUphID;
using static SiUpin.Shared.Common.Constants;

namespace SiUpin.Application.Uphs.Queries.GetAllUphProdukByUphID
{
    public class GetAllUphProdukByUphIDQueryHandler : IRequestHandler<GetAllUphProdukByUphIDRequest, GetAllUphProdukByUphIDResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetAllUphProdukByUphIDQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetAllUphProdukByUphIDResponse> Handle(GetAllUphProdukByUphIDRequest request, CancellationToken cancellationToken)
        {
            try
            {
                int totalRecords;

                List<UphProduk> records;
                List<File> files = await _context.Files
                    .AsNoTracking()
                    .Where(x => x.EntityType == FileEntityType.UphProduk && !x.Name.Contains(".docx"))
                    .ToListAsync(cancellationToken);

                //var filesUph = files.Select(s => s.EntityID);

                records = await _context.UphProduks
                    .AsNoTracking()
                    .Include(u => u.Uph).ThenInclude(p => p.Provinsi)
                    .Include(a => a.ProdukOlahan).ThenInclude(b => b.JenisKomoditi)
                    .Where(x => x.Name.Contains(request.FilterByName ?? "") && x.UphID == request.UphID)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync(cancellationToken);

                totalRecords = _context.UphProduks
                    .AsNoTracking()
                    .Count(x => x.Name.Contains(request.FilterByName ?? "") && x.UphID == request.UphID);

                List<UphProdukDTO> listOfDTO = new List<UphProdukDTO>();

                if (records.Count() > 0)
                {
                    foreach (var record in records)
                    {
                        string fileName;

                        var file = files.Where(x => x.EntityID == record.UphProdukID).FirstOrDefault();

                        if (file != null && !string.IsNullOrEmpty(file.Name))
                            fileName = $"images/{file.Name}";
                        else
                            fileName = $"images/image_not_available.png";

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
                    throw new Exception($"{ErrorMessage.DataNotFound} Produk");
                }

                return new GetAllUphProdukByUphIDResponse
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