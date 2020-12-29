using MediatR;
using SiUpin.Shared.UphProduks.Command.Common;

namespace SiUpin.Shared.UphProduks.Command.UpdateUphProduk
{
    public class UpdateUphProdukRequest : UphProdukDTO, IRequest<UpdateUphProdukResponse>
    {
    }
}
