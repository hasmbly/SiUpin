using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Common.Pagination;
using SiUpin.Shared.Constants;
using SiUpin.Shared.Uphs.Queries.GetAllUph;

namespace SiUpin.Application.Uphs.Queries.GetAllUph
{
    public class GetAllUphQueryHandler : IRequestHandler<GetAllUphRequest, GetAllUphResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetAllUphQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetAllUphResponse> Handle(GetAllUphRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var records = await _context.Uphs
                    .AsNoTracking()
                    .Where(x => x.Name.Contains(request.FilterUphName ?? ""))
                    .Include(a => a.Provinsi)
                    .Include(a => a.Kota)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync(cancellationToken);

                var totalRecords = _context.Uphs.Count(x => x.Name.Contains(request.FilterUphName ?? ""));

                List<UphDTO> listOfDTO = new List<UphDTO>();

                if (records.Count > 0)
                {
                    foreach (var data in records)
                    {
                        var uph = new UphDTO
                        {
                            UphID = data.UphID,
                            Name = data.Name,

                            Provinsi = data.Provinsi?.Name,
                            Kota = data.Kota?.Name,

                            Ketua = data.Ketua,
                            Handphone = data.Handphone,
                            Alamat = data.Alamat
                        };

                        if (uph != null)
                            listOfDTO.Add(uph);
                    }
                }
                else
                {
                    throw new Exception(ErrorMessage.DataNotFound);
                }

                return new GetAllUphResponse
                {
                    IsSuccessful = true,
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