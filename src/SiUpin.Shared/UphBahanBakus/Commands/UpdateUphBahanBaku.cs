using MediatR;
using SiUpin.Shared.UphBahanBakus.Common;

namespace SiUpin.Shared.UphBahanBakus.Commands
{
    public class UpdateUphBahanBakuRequest : UphBahanBakuDTO, IRequest<UpdateUphBahanBakuResponse>
    {
    }

    public class UpdateUphBahanBakuResponse
    {
        public string UphBahanBakuID { get; set; }
    }
}
