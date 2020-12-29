using MediatR;
using SiUpin.Shared.UphProduks.Command.Common;

namespace SiUpin.Shared.UphProduks.Command.CreateUphProduk
{
    public class CreateUphProdukRequest : UphProdukDTO, IRequest<CreateUphProdukResponse>
    {
    }
}
