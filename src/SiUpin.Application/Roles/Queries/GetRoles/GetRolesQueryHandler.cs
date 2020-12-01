using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Roles.Queries.GetRoles;

namespace SiUpin.Application.Roles.Queries.GetRoles
{
    public class GetRolesQueryHandler : IRequestHandler<GetRolesRequest, GetRolesResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetRolesQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetRolesResponse> Handle(GetRolesRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var records = await _context.Roles
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);

                List<RoleDTO> listOfDTO = new List<RoleDTO>();

                if (records.Count > 0)
                {
                    foreach (var record in records)
                    {
                        var data = new RoleDTO
                        {
                            RoleID = record.RoleID,
                            Name = record.Name
                        };

                        if (data != null)
                            listOfDTO.Add(data);
                    }
                }

                return new GetRolesResponse
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