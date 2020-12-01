using System.Collections.Generic;

namespace SiUpin.Shared.Roles.Queries.GetRoles
{
    public class GetRolesResponse
    {
        public IList<RoleDTO> Data { get; set; }

        public GetRolesResponse() => Data = new List<RoleDTO>();
    }
}
