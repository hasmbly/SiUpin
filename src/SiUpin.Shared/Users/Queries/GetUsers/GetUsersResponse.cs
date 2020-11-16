using System.Collections.Generic;
using SiUpin.Shared.Common.Pagination;
using SiUpin.Shared.Users.Queries.Common;

namespace SiUpin.Shared.Users.Queries.GetUsers
{
    public class GetUsersResponse
    {
        public PaginationResponse Pagination { get; set; }

        public IList<UserDTO> Data { get; set; }

        public GetUsersResponse()
        {
            Data = new List<UserDTO>();
        }
    }
}
