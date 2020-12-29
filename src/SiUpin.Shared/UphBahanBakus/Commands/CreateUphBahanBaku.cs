using MediatR;
using SiUpin.Shared.UphBahanBakus.Common;

namespace SiUpin.Shared.UphBahanBakus.Commands
{
    public class CreateUphBahanBakuRequest : UphBahanBakuDTO, IRequest<CreateUphBahanBakuResponse>
    {
    }

    public class CreateUphBahanBakuResponse
    {
        public string UphBahanBakuID { get; set; }
    }
}
