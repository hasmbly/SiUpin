using System.Collections.Generic;
using MediatR;

namespace SiUpin.Shared.UphBahanBakus.Commands
{
    public class DeleteUphBahanBakuRequest : IRequest<DeleteUphBahanBakuResponse>
    {
        public IList<string> UphBahanBakuIDs { get; set; } = new List<string>();
    }

    public class DeleteUphBahanBakuResponse
    {
    }
}
