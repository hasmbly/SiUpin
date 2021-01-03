using MediatR;
using SiUpin.Shared.ProdukOlahans.Common;

namespace SiUpin.Shared.ProdukOlahans.Commands.UpdateProdukOlahan
{
    public class UpdateProdukOlahanRequest : ProdukOlahanDTO, IRequest<UpdateProdukOlahanResponse>
    {
    }
}
