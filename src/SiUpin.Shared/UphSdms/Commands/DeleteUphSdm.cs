using System.Collections.Generic;
using MediatR;

namespace SiUpin.Shared.UphSdms.Commands
{
    public class DeleteUphSdmRequest : IRequest<DeleteUphSdmResponse>
    {
        public IList<string> UphSdmIDs { get; set; } = new List<string>();
    }

    public class DeleteUphSdmResponse
    {
    }
}
