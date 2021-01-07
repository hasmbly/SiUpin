using MediatR;
using SiUpin.Shared.UphProduksis.Common;

namespace SiUpin.Shared.UphProduksis.Commands
{
    public class UpdateUphProduksiRequest : UphProduksiDTO, IRequest<UpdateUphProduksiResponse>
    {
    }

    public class UpdateUphProduksiResponse
    {
        public string UphProduksiID { get; set; }
    }
}
