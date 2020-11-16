using MediatR;
using SiUpin.Shared.Common.Pagination;

namespace SiUpin.Shared.Beritas.Queries.GetBeritas
{
    public class GetBeritasRequest : PaginationRequest, IRequest<GetBeritasResponse>
    {
        public string FilterByName { get; set; }
    }
}
