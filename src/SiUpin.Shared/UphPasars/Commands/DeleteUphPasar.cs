using System.Collections.Generic;
using MediatR;

namespace SiUpin.Shared.UphPasars.Commands
{
    public class DeleteUphPasarRequest : IRequest<DeleteUphPasarResponse>
    {
        public IList<string> UphPasarIDs { get; set; } = new List<string>();
    }

    public class DeleteUphPasarResponse
    {
    }
}
