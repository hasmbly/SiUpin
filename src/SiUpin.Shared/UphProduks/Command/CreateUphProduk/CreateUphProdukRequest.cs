using MediatR;

namespace SiUpin.Shared.UphProduks.Command.CreateUphProduk
{
    public class CreateUphProdukRequest : UphProdukDTO, IRequest<CreateUphProdukResponse>
    {
    }
}
