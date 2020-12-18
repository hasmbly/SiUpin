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
using SiUpin.Shared.UphGmps.Queries;

namespace SiUpin.Application.UphGmps.Queries
{
    public class GetUphGmpQueryHandler : IRequestHandler<GetUphGmpsRequest, GetUphGmpsResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetUphGmpQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetUphGmpsResponse> Handle(GetUphGmpsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var records = await _context.UphGmps
                    .AsNoTracking()
                    .Include(a => a.Uph)
                    .Where(x => x.nama_gmp.Contains(request.FilterByName ?? ""))
                    .OrderByDescending(o => o.Created)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync(cancellationToken);

                var totalRecords = _context.UphGmps.AsNoTracking().Count(x => x.nama_gmp.Contains(request.FilterByName ?? ""));

                List<UphGmpDTO> listOfDTO = new List<UphGmpDTO>();

                if (records.Count > 0)
                {
                    int no = 1;
                    foreach (var data in records)
                    {
                        var entity = new UphGmpDTO
                        {
                            No = no++,
                            UphGmpID = data.UphGmpID,
                            UphID = data.UphID,
                            id_uph = data.id_uph,
                            nama_gmp = data.nama_gmp,
                            id_gmp = data.id_gmp,
                            jml_gmp = data.jml_gmp,

                            Uph = new Shared.Uphs.Common.UphDTO
                            {
                                Name = data.Uph.Name
                            }
                        };

                        if (entity != null)
                            listOfDTO.Add(entity);
                    }
                }
                else
                {
                    throw new Exception(ErrorMessage.DataNotFound);
                }

                return new GetUphGmpsResponse
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