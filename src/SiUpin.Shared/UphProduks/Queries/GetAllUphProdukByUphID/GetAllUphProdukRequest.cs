using MediatR;
using SiUpin.Shared.Common.Pagination;

namespace SiUpin.Shared.UphProduks.Queries.GetAllUphProdukByUphID
{
    public class GetAllUphProdukByUphIDRequest : PaginationRequest, IRequest<GetAllUphProdukByUphIDResponse>
    {
        public string UphID { get; set; }
        public string FilterByName { get; set; }
    }
}
