using System.Collections.Generic;
using MediatR;

namespace SiUpin.Shared.UphMitras.Commands
{
    public class DeleteUphMitraRequest : IRequest<DeleteUphMitraResponse>
    {
        public IList<string> UphMitraIDs { get; set; } = new List<string>();
    }

    public class DeleteUphMitraResponse
    {
    }
}
