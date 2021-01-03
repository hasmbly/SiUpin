using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Beritas.Common;
using SiUpin.Shared.Beritas.Queries.GetAllBerita;

namespace SiUpin.Application.Beritas.Queries.GetAllBerita
{
    public class GetAllBeritaQuery : IRequestHandler<GetAllBeritaRequest, GetAllBeritaResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetAllBeritaQuery(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetAllBeritaResponse> Handle(GetAllBeritaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var records = await _context.Beritas
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);

                List<BeritaDTO> listOfDTO = new List<BeritaDTO>();

                if (records.Count > 0)
                {
                    var users = await _context.Users.ToListAsync(cancellationToken);

                    int no = 1;
                    foreach (var record in records)
                    {
                        string fullName = "";
                        if (!string.IsNullOrEmpty(record.CreatedBy))
                        {
                            fullName = users.FirstOrDefault(x => x.UserID == record.CreatedBy)?.Fullname;
                        }

                        var data = new BeritaDTO
                        {
                            No = no++,
                            BeritaID = record.BeritaID,
                            Title = string.IsNullOrEmpty(record.Title) ? "Unknown" : record.Title,
                            Description = record.Description,

                            Created = record.Created,
                            UserName = fullName
                        };

                        if (data != null)
                            listOfDTO.Add(data);
                    }
                }

                return new GetAllBeritaResponse
                {
                    Data = listOfDTO
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}