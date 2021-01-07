using MediatR;
using SiUpin.Shared.UphProduksis.Common;

namespace SiUpin.Shared.UphProduksis.Queries
{
    public class GetUphProduksiRequest : IRequest<GetUphProduksiResponse>
    {
        public string UphProduksiID { get; set; }
    }

    public class GetUphProduksiResponse : UphProduksiDTO
    {
    }
}
