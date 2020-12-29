using MediatR;
using SiUpin.Shared.UphBahanBakus.Common;

namespace SiUpin.Shared.UphBahanBakus.Queries
{
    public class GetUphBahanBakuRequest : IRequest<GetUphBahanBakuResponse>
    {
        public string UphBahanBakuID { get; set; }
    }

    public class GetUphBahanBakuResponse : UphBahanBakuDTO
    {
    }
}
