using MediatR;
using SiUpin.Shared.UphProduksis.Common;

namespace SiUpin.Shared.UphProduksis.Commands
{
    public class CreateUphProduksiRequest : UphProduksiDTO, IRequest<CreateUphProduksiResponse>
    {
    }

    public class CreateUphProduksiResponse
    {
        public string UphProduksiID { get; set; }
    }
}
