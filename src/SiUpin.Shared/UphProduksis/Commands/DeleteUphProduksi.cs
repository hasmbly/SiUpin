using System.Collections.Generic;
using MediatR;

namespace SiUpin.Shared.UphProduksis.Commands
{
    public class DeleteUphProduksiRequest : IRequest<DeleteUphProduksiResponse>
    {
        public IList<string> UphProduksiIDs { get; set; } = new List<string>();
    }

    public class DeleteUphProduksiResponse
    {
    }
}
