using MediatR;
using SiUpin.Shared.ProdukOlahans.Common;

namespace SiUpin.Shared.ProdukOlahans.Commands.CreateProdukOlahan
{
    public class CreateProdukOlahanRequest : ProdukOlahanDTO, IRequest<CreateProdukOlahanResponse>
    {
    }
}
