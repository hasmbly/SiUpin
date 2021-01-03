using MediatR;

namespace SiUpin.Shared.ProdukOlahans.Queries.GetProdukOlahan
{
    public class GetProdukOlahanRequest : IRequest<GetProdukOlahanResponse>
    {
        public string ProdukOlahanID { get; set; }
    }
}
