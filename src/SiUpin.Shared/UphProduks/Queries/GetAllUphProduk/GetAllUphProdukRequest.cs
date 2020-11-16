using MediatR;
using SiUpin.Shared.Common.Pagination;

namespace SiUpin.Shared.UphProduks.Queries.GetAllUphProduk
{
    public class GetAllUphProdukRequest : PaginationRequest, IRequest<GetAllUphProdukResponse>
    {
        public string FilterJenisKomoditiID { get; set; }
        public string FilterByName { get; set; }
    }
}
