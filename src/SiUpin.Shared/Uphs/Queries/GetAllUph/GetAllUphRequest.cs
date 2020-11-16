using MediatR;
using SiUpin.Shared.Common.Pagination;

namespace SiUpin.Shared.Uphs.Queries.GetAllUph
{
    public class GetAllUphRequest : PaginationRequest, IRequest<GetAllUphResponse>
    {
        public string FilterUphName { get; set; }
    }
}
