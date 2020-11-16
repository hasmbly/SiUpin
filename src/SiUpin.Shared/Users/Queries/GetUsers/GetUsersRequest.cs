using MediatR;
using SiUpin.Shared.Common.Pagination;

namespace SiUpin.Shared.Users.Queries.GetUsers
{
    public class GetUsersRequest : PaginationRequest, IRequest<GetUsersResponse>
    {
        public string FilterByUsernameOrEmail { get; set; }

        public string FilterProvinsiID { get; set; }
        public string FilterKotaID { get; set; }
        public string FilterKecamatanID { get; set; }
    }
}
