using System.Collections.Generic;
using MediatR;

namespace SiUpin.Shared.UphSaranas.Commands
{
    public class DeleteUphSaranaRequest : IRequest<DeleteUphSaranaResponse>
    {
        public IList<string> UphSaranaIDs { get; set; } = new List<string>();
    }

    public class DeleteUphSaranaResponse
    {
    }
}
