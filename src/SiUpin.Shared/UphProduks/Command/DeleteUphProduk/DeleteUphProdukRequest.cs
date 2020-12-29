using System.Collections.Generic;
using MediatR;

namespace SiUpin.Shared.UphProduks.Command.DeleteUphProduk
{
    public class DeleteUphProdukRequest : IRequest<DeleteUphProdukResponse>
    {
        public IList<string> UphProdukIDs { get; set; } = new List<string>();
    }
}
