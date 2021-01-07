using System.Collections.Generic;
using MediatR;

namespace SiUpin.Shared.UphGmps.Commands
{
    public class DeleteUphGmpRequest : IRequest<DeleteUphGmpResponse>
    {
        public IList<string> UphGmpIDs { get; set; } = new List<string>();
    }

    public class DeleteUphGmpResponse
    {
    }
}
