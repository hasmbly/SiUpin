using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SiUpin.Application.Common;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.Systems.Commands.SeedRole;

namespace SiUpin.Application.Systems.Commands.SeedRole
{
    public class SeedRoleCommandHandler : IRequestHandler<SeedRoleRequest, SeedRoleResponse>
    {
        private readonly ISiUpinDBContext _context;
        private readonly IFileService _fileService;

        public SeedRoleCommandHandler(ISiUpinDBContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<SeedRoleResponse> Handle(SeedRoleRequest request, CancellationToken cancellationToken)
        {
            var result = new SeedRoleResponse();

            var dataJSON = _fileService.ReadJSONFile<RoleJSON>(FilePath.RoleJSON);

            List<Role> roles = new List<Role>();

            var listDataJSON = dataJSON.rows.ToList();

            foreach (var data in listDataJSON)
            {
                Role role = new Role();

                role = roles
                    .SingleOrDefault(x => x.RoleID == data.id_role);

                if (role == null)
                {
                    role = new Role
                    {
                        Name = data.nama_role
                    };

                    roles.Add(role);

                    _context.Roles.Add(role);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            result.IsSuccessful = true;

            return result;
        }
    }
}