using MediatR;

namespace SiUpin.Shared.Uphs.Queries.GetUphAndProduk
{
    public class GetUphAndProdukRequest : IRequest<GetUphAndProdukResponse>
    {
        public string UphID { get; set; }
    }
}
