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
using SiUpin.Shared.Uphs.Queries.GetUphClusterByGrade;

namespace SiUpin.Application.Uphs.Queries.GetUphClusterByGrade
{
    public class GetUphClusterByGradeQueryHandler : IRequestHandler<GetUphClusterByGradeRequest, GetUphClusterByGradeResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetUphClusterByGradeQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetUphClusterByGradeResponse> Handle(GetUphClusterByGradeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var records = await _context.Uphs
                    .AsNoTracking()
                    .Where(x => x.Name.Contains(request.FilterUphName ?? ""))
                    .Include(a => a.Provinsi)
                    .Include(a => a.Kota)
                    .OrderByDescending(o => o.Created)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync(cancellationToken);

                var totalRecords = _context.Uphs.Count(x => x.Name.Contains(request.FilterUphName ?? ""));

                List<ClustersUphByGradeDTO> listOfDTO = new List<ClustersUphByGradeDTO>();

                if (records.Count > 0)
                {
                    int no = 1;
                    foreach (var data in records)
                    {
                        var uph = new ClustersUphByGradeDTO
                        {
                            No = no++,
                            UphID = data.UphID,
                            Name = data.Name,

                            Provinsi = data.Provinsi?.Name,
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

                return new GetUphClusterByGradeResponse
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